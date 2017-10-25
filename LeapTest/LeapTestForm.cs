

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Leap;

namespace LeapTest
{
    public partial class LeapTestForm : Form, ILeapEventDelegate
    {
        private Controller controller;
        private LeapEventListener listener;
        private static PointF upRightPos;
        private static PointF botLeftPos;
        private Stopwatch timer1;
        fittsDiags diagnostics;
        private static Point bounds;
        private static string trackType;
        private static string clickType;
        private static string orientation;
        private static string size;
        private static int IDSetting;
        private static int subjNum;
        private int fittsRadius;
        //float[] fingerCenter;
        bool thumbExteded;
        bool thumbExtendedLast;
        long baseFrame;
        bool tracking;


        private StreamWriter fittsOut;

        //Using System.Reflection to call the tracking methods dynamically? - Working on that
        //Gestures are no longer supported by Leap!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        public LeapTestForm()
        {
            InitializeComponent();
            this.controller = new Controller();
            this.listener = new LeapEventListener(this);
            controller.AddListener(listener);
            baseFrame = 0;
            tracking = true;

            timer1 = new Stopwatch();
            diagnostics = new fittsDiags();

            trackType = startupMenu.trackType;
            clickType = startupMenu.clickType;
            orientation = startupMenu.orientation;
            size = startupMenu.size;
            IDSetting = startupMenu.ID;
            bounds = calibrationForm.bounds;
            subjNum = startupMenu.subNum;
            upRightPos = startupMenu.upRightPos;
            botLeftPos = startupMenu.botLeftPos;

            //Setting up the form and buttons
            this.Size = (Size)bounds;
            infoButton.Location = new Point(Convert.ToInt32(this.Width * .5 - .5 * infoButton.Width), this.Height - 95);
            //calibButton.Location = new Point(Convert.ToInt32(this.Width * .5 - calibButton.Width * .5), Convert.ToInt32(this.Height * .5 - calibButton.Height * .5));
            //startButton1.Location = new Point(5, 5);
            //startButton2.Location = new Point(this.Width - 5 - startButton2.Width, this.Height - 65 - startButton2.Width);
            //startButton3.Location = new Point(this.Width - 5 - startButton3.Width, 5);
            //startButton4.Location = new Point(5, this.Height - 65 - startButton4.Width);
            fittsButton.Width = (int)(bounds.X / ( 20 * Math.Log(IDSetting + IDSetting * 3,2)));
            fittsButton.Height = fittsButton.Width;
            fittsRadius = (int)((fittsButton.Width * Math.Pow(2, IDSetting)) / 2);
            fittsButton.Location = new Point(Convert.ToInt32(this.Width * .5), Convert.ToInt32(this.Height * 0.5 - fittsRadius));
            label36.Text = fittsButton.Location.ToString();

            //Show the menu screen options
            label30.Text = trackType;
            label32.Text = clickType;
            label34.Text = new Point(this.Height, this.Width).ToString();
            label62.Text = orientation;
            label66.Text = IDSetting.ToString();

            fittsOut = new StreamWriter(@"fittsOutput.txt", true);
            fittsOut.WriteLine("ID: " + IDSetting.ToString() + " Subj#: " + subjNum + " Size: " + size.ToString() + " " + " Tracking Type: " + trackType.ToString() + " Click type: " + clickType.ToString() + " " + DateTime.Now);
            fittsOut.WriteLine("MT   Err  Pos(x,y) Click_Pos(x,y)");
            //fittsOut.Close();
        }


        private void LeapTestForm_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void LeapTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fittsOut.WriteLine(" ");
            fittsOut.Close();
            tracking = false;
        }

        //////////////////////////////////
        //////////Cursor Stuff////////////
        //////////////////////////////////

        private void MoveCursor()
        {
            if (orientation == "Vertical")
                Vertical();
            else
                Horizontal();
        }

        private void Vertical()
        {
            Hand hand = controller.Frame().Hands[0];

            if (controller.Frame().Hands.Count > 0)
            {
                this.Cursor = new Cursor(Cursor.Current.Handle);
                Point newMouseLoc = new Point();

                //Palm Position Tracking
                if (trackType == "Palm")
                {
                    if (hand.PalmPosition.x > botLeftPos.X && hand.PalmPosition.x < upRightPos.X)
                        newMouseLoc.X = (int)(bounds.X * Math.Abs(hand.PalmPosition.x - botLeftPos.X) / Math.Abs(upRightPos.X - botLeftPos.X));
                    else if (hand.PalmPosition.x < botLeftPos.X)
                        newMouseLoc.X = bounds.X;
                    else
                        newMouseLoc.X = 0;
                    if (hand.PalmPosition.y >= botLeftPos.Y && hand.PalmPosition.y < upRightPos.Y)
                        newMouseLoc.Y = bounds.Y - (int)(bounds.Y * ((Math.Abs(hand.PalmPosition.y - botLeftPos.Y) / Math.Abs(upRightPos.Y - botLeftPos.Y))));
                    else if (hand.PalmPosition.y < botLeftPos.Y)
                        newMouseLoc.Y = bounds.Y;
                    else
                        newMouseLoc.Y = 0;
                }

                //Index Finger Position Tracking
                else
                {
                    Finger indexF = hand.Fingers[1];
                    if (indexF.IsExtended)            //Only tracks if the index finger is actually extended
                    {
                        if (indexF.StabilizedTipPosition.x > botLeftPos.X && indexF.StabilizedTipPosition.x < upRightPos.X)  //Using Stabilized tip position should give a stable cursor, but will be somewhat laggy.
                            newMouseLoc.X = (int)(bounds.X * Math.Abs(indexF.StabilizedTipPosition.x - botLeftPos.X) / Math.Abs(upRightPos.X - botLeftPos.X));
                        else if (indexF.StabilizedTipPosition.x < botLeftPos.X)
                            newMouseLoc.X = bounds.X;
                        else
                            newMouseLoc.X = 0;
                        if (indexF.StabilizedTipPosition.y >= botLeftPos.Y && indexF.StabilizedTipPosition.y < upRightPos.Y)
                            newMouseLoc.Y = bounds.Y - (int)(bounds.Y * ((Math.Abs(indexF.StabilizedTipPosition.y - botLeftPos.Y) / Math.Abs(upRightPos.Y - botLeftPos.Y))));
                        else if (indexF.StabilizedTipPosition.y < botLeftPos.Y)
                            newMouseLoc.Y = bounds.Y;
                        else
                            newMouseLoc.Y = 0;
                    }
                }

                //Check for clicks
                thumbExtendedLast = thumbExteded;
                thumbExteded = controller.Frame().Hands[0].Fingers[0].IsExtended;
                if (thumbExteded == false && thumbExtendedLast == true)
                    thumbClick();
                fingerClick();

                //Set the new cursor position
                Cursor.Position = newMouseLoc;
            }
        }

        private void Horizontal()
        {
            //Set the current hand we're looking at to the first hand
            Hand hand = controller.Frame().Hands[0];

            //As long as calibration is done and there is at least one hand detected (What if there is a tool present? Do we want to look at that?)
            if (controller.Frame().Hands.Count > 0)
            {
                this.Cursor = new Cursor(Cursor.Current.Handle);
                Point newMouseLoc = new Point();

                //Palm Position Tracking
                if (trackType == "Palm")
                {
                    if (hand.PalmPosition.x >= botLeftPos.X && hand.PalmPosition.x < upRightPos.X)
                        newMouseLoc.X = (int)(bounds.X * Math.Abs(hand.PalmPosition.x - botLeftPos.X) / Math.Abs(upRightPos.X - botLeftPos.X));
                    else if (hand.PalmPosition.x < botLeftPos.X)
                        newMouseLoc.X = 0;
                    else
                        newMouseLoc.X = bounds.X;
                    if (hand.PalmPosition.z <= botLeftPos.Y && hand.PalmPosition.z > upRightPos.Y)
                        newMouseLoc.Y = bounds.Y - (int)(bounds.Y * ((Math.Abs(hand.PalmPosition.z - botLeftPos.Y) / Math.Abs(upRightPos.Y - botLeftPos.Y))));
                    else if (hand.PalmPosition.z > botLeftPos.Y)
                        newMouseLoc.Y = bounds.Y;
                    else
                        newMouseLoc.Y = 0;
                }
                //Index Finger Position Tracking
                else
                {
                    Finger indexF = hand.Fingers[1];  //Define the index finger
                    if (indexF.IsExtended)            //Only tracks if the index finger is actually extended
                    {
                        if (indexF.StabilizedTipPosition.x > botLeftPos.X && indexF.StabilizedTipPosition.x < upRightPos.X)  //Using stabilized tip position should give a more, well, 
                            newMouseLoc.X = (int)(bounds.X * Math.Abs(indexF.StabilizedTipPosition.x - botLeftPos.X) / Math.Abs(upRightPos.X - botLeftPos.X)); //stable cursor, but will
                        else if (indexF.StabilizedTipPosition.x < botLeftPos.X)                                                                                //also come with some latency.
                            newMouseLoc.X = bounds.X;
                        else
                            newMouseLoc.X = 0;
                        if (indexF.StabilizedTipPosition.z <= botLeftPos.Y && indexF.StabilizedTipPosition.z > upRightPos.Y)
                            newMouseLoc.Y = bounds.Y - (int)(bounds.Y * ((Math.Abs(indexF.StabilizedTipPosition.z - botLeftPos.Y) / Math.Abs(upRightPos.Y - botLeftPos.Y))));
                        else if (indexF.StabilizedTipPosition.y > botLeftPos.Y)
                            newMouseLoc.Y = bounds.Y;
                        else
                            newMouseLoc.Y = 0;
                    }
                }

                //Check for clicks
                thumbExtendedLast = thumbExteded;
                thumbExteded = controller.Frame().Hands[0].Fingers[0].IsExtended;
                if (thumbExteded == false && thumbExtendedLast == true)
                    thumbClick();
                fingerClick();

                //Set the new cursor position
                Cursor.Position = newMouseLoc;
            }
        }

        ////////////////////////////////////
        //////////Clicking Stuff////////////
        ////////////////////////////////////

        private void LeapTestForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'f' && clickType == "F Key" && fittsButton.ClientRectangle.Contains(fittsButton.PointToClient(Control.MousePosition)))
                fittsButton.PerformClick();
            else
                diagnostics.addError();
        }

        private void thumbClick()
        {
            if (clickType == "Thumb Retract" && fittsButton.ClientRectangle.Contains(fittsButton.PointToClient(Control.MousePosition)))
                fittsButton.PerformClick();
            else
                diagnostics.addError();
        }

        private void LeapTestForm_Click(object sender, EventArgs e)
        {
            diagnostics.addError();
        }

        private void fingerClick()
        {
            float delta = controller.Frame().Hands[0].Fingers[1].TipVelocity.y - controller.Frame().Hands[0].PalmVelocity.y;


            if (delta > 50)
            {
                if (controller.Frame().Id > baseFrame + controller.Frame().CurrentFramesPerSecond && fittsButton.ClientRectangle.Contains(fittsButton.PointToClient(Control.MousePosition)))
                {

                    //FingerAngle.Text = "Click";
                    baseFrame = controller.Frame().Id;
                    fittsButton.PerformClick();
                }
            }
            else
            {
                //FingerAngle.Text = "";
            }

        }

        ////////////////////////////////////////////
        //////////Label Notification Stuff//////////
        ////////////////////////////////////////////

        private void showDiagnostics()
        {
            label2.Text = Cursor.Position.ToString();
            label4.Text = controller.Frame().Hands.Count.ToString();
            label6.Text = bounds.ToString();
            label8.Text = controller.Frame().Hands[0].PalmPosition.ToString();
            label10.Text = upRightPos.ToString();
            label12.Text = botLeftPos.ToString();
            label14.Text = "(" + Cursor.Position.X + ", " + Cursor.Position.Y + ")";
            label16.Text = controller.Frame().Hands[0].Fingers[1].TipPosition.ToString();
            label18.Text = controller.Frame().Hands[0].Fingers[1].IsExtended.ToString();
            label20.Text = controller.Frame().Hands[0].Fingers[2].TipPosition.ToString();
            label22.Text = controller.Frame().Hands[0].Fingers[2].IsExtended.ToString();
            label64.Text = controller.Frame().CurrentFramesPerSecond.ToString();
            label58.Text = controller.Frame().Hands[0].Fingers[0].IsExtended.ToString();

            //PointF armAngle = getArmAngle(controller.Frame().Hands[0]);
            //label24.Text = armAngle.X.ToString();
            //label26.Text = armAngle.Y.ToString();

            label28.Text = controller.Frame().Hands[0].Fingers[1].IsExtended.ToString();  //This seems to work more times than not
        }

        ////////////////////////////////////////////
        //////////////Fitts Test Stuff//////////////
        ////////////////////////////////////////////

        private void infoButton1_Click(object sender, EventArgs e)
        //Enable or disable all the cluttery labels
        {
            if (label1.Visible) { label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false; label6.Visible = false; label7.Visible = false; label8.Visible = false; label9.Visible = false; label10.Visible = false; label11.Visible = false; label12.Visible = false; label13.Visible = false; label14.Visible = false; label15.Visible = false; label16.Visible = false; label17.Visible = false; label18.Visible = false; label19.Visible = false; label20.Visible = false; label21.Visible = false; label22.Visible = false; label23.Visible = false; label24.Visible = false; label25.Visible = false; label26.Visible = false; label27.Visible = false; label28.Visible = false; label29.Visible = false; label30.Visible = false; label31.Visible = false; label32.Visible = false; label33.Visible = false; label34.Visible = false; label35.Visible = false; label36.Visible = false; label37.Visible = false; label38.Visible = false; label39.Visible = false; label40.Visible = false; label41.Visible = false; label42.Visible = false; label43.Visible = false; label44.Visible = false; label45.Visible = false; label46.Visible = false; label59.Visible = false; label60.Visible = false; label61.Visible = false; label62.Visible = false; label63.Visible = false; label64.Visible = false; label65.Visible = false; label62.Visible = false; }
            else { label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = true; label6.Visible = true; label7.Visible = true; label8.Visible = true; label9.Visible = true; label10.Visible = true; label11.Visible = true; label12.Visible = true; label13.Visible = true; label14.Visible = true; label15.Visible = true; label16.Visible = true; label17.Visible = true; label18.Visible = true; label19.Visible = true; label20.Visible = true; label21.Visible = true; label22.Visible = true; label23.Visible = true; label24.Visible = true; label25.Visible = true; label26.Visible = true; label27.Visible = true; label28.Visible = true; label29.Visible = true; label30.Visible = true; label31.Visible = true; label32.Visible = true; label33.Visible = true; label34.Visible = true; label35.Visible = true; label36.Visible = true; label37.Visible = true; label38.Visible = true; label39.Visible = true; label40.Visible = true; label41.Visible = true; label42.Visible = true; label43.Visible = true; label44.Visible = true; label45.Visible = true; label46.Visible = true; label59.Visible = true; label60.Visible = true; label61.Visible = false; label62.Visible = false; label63.Visible = false; label64.Visible = false; label65.Visible = false; label66.Visible = false; }
        }

        private void fittsButton_Click(object sender, EventArgs e)
        {
            if (!diagnostics.finished)
            {
                //diagnostics.calcID(this.Size.Height / 2, fittsButton.Width);
                double time = timer1.ElapsedMilliseconds;  //Get the current time on the stopwatch
                //diagnostics.calcIP(time);  //Get the IP from the time and established ID
                float newAngle = new float();
                newAngle = (float)(((Math.Atan2(fittsButton.Location.X - this.Size.Width * 0.5, this.Size.Height * 0.5 - fittsButton.Location.Y)) + ((4 * Math.PI) / 6))); //(arctan(y/x) + 2pi/3) % pi                                                                                                                                              

                //Debugging
                label42.Text = Math.Atan2(fittsButton.Location.X - this.Size.Width * 0.5, this.Size.Height * 0.5 - fittsButton.Location.Y).ToString(); //Doesn't work?
                label44.Text = (Math.Atan2(fittsButton.Location.X - this.Size.Width * 0.5, this.Size.Height * 0.5 - fittsButton.Location.Y) + ((4 * Math.PI) / 6)).ToString();
                label46.Text = ((5 * Math.PI) / 6).ToString();

                //Writing the info to fittsOutput
                fittsOut.WriteLine(diagnostics.dump(time, fittsButton.Location, Cursor.Position));

                //Setting button location
                fittsButton.Location = new Point(Convert.ToInt32((this.Size.Width * 0.5) + fittsRadius * Math.Cos(newAngle)), // R*cos(theta) + translation
                                                 Convert.ToInt32((this.Size.Height * 0.5) + fittsRadius * Math.Sin(newAngle))); // R*sin(theta) + translation

                timer1.Reset();
                timer1.Start();

                //Debugging
                label36.Text = fittsButton.Location.ToString();
                label38.Text = Math.Atan2((this.Size.Height * 0.5 - fittsButton.Location.Y), (fittsButton.Location.X - this.Size.Width * 0.5)).ToString();
                label40.Text = new Point(Convert.ToInt32(fittsButton.Location.X - this.Size.Width * 0.5), Convert.ToInt32(this.Size.Height * 0.5 - fittsButton.Location.Y)).ToString();
            }
            else
            {
                fittsButton.Visible = false;
                startupMenu startMenu = new startupMenu();
                startMenu.Show();
                this.Close();
            }
        }

        public class fittsDiags
        {
            int errorCount;  //Total number of errors in trial
            int numData;  //Number of times a button has been pressed
            public bool finished; //Whether or not the test is done

            public fittsDiags()
            {
                errorCount = 0;
                numData = 0;
                finished = false;
            }

            //For adding to the error value
            public void addError()
            {
                errorCount++;
            }

            public string dump(double time, Point buttonLocation, Point cursorPosition)
            {
                numData++;
                finished = numData > 11;
                string output = time.ToString() + " ";
                output += errorCount.ToString() + " ";
                output += buttonLocation.ToString() + " ";
                output += cursorPosition.ToString();
                return output;
            }
        }

        ///////////////////////////////////////////////
        //////////////Leap Delegate Stuff//////////////
        ///////////////////////////////////////////////

        delegate void LeapEventDelegate(string EventName);

        public void LeapEventNotification(string EventName)
        {
            if (!this.InvokeRequired)
            {
                switch (EventName)
                {
                    case "onInit":
                        Debug.WriteLine("Init");
                        break;
                    case "onFrame":
                        if(tracking)
                            MoveCursor();
                        showDiagnostics();
                        break;
                }
            }
            else
            {
                BeginInvoke(new LeapEventDelegate(LeapEventNotification), new object[] { EventName });
            }
        }
    }

    //////////////////////////////////////////////
    /////////Leap Listener and Interface//////////
    //////////////////////////////////////////////

    public interface ILeapEventDelegate
    {
        void LeapEventNotification(string EventName);
    }

    public class LeapEventListener : Listener
    {
        ILeapEventDelegate eventDelegate;

        public LeapEventListener(ILeapEventDelegate delegateObject)
        {
            this.eventDelegate = delegateObject;
        }
        public override void OnInit(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onInit");
        }
        public override void OnConnect(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onConnect");
        }
        public override void OnExit(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onExit");
        }
        public override void OnDisconnect(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onDisconnect");
        }
        public override void OnFrame(Controller controller)
        {
            this.eventDelegate.LeapEventNotification("onFrame");
        }
    }
}



