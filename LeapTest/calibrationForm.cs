using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leap;

namespace LeapTest
{
    public partial class calibrationForm : Form
    {
        private Controller controller;
        //private LeapEventListener listener;

        public static Point bounds;
        float[] fingerCenter;
        float[] palmCenter;
        public static PointF vertSmallUpRightPos;
        public static PointF vertSmallBotLeftPos;
        public static PointF vertLargeUpRightPos;
        public static PointF vertLargeBotLeftPos;
        public static PointF horSmallUpRightPos;
        public static PointF horSmallBotLeftPos;
        public static PointF horLargeUpRightPos;
        public static PointF horLargeBotLeftPos;
        public static PointF pvertSmallUpRightPos;
        public static PointF pvertSmallBotLeftPos;
        public static PointF pvertLargeUpRightPos;
        public static PointF pvertLargeBotLeftPos;
        public static PointF phorSmallUpRightPos;
        public static PointF phorSmallBotLeftPos;
        public static PointF phorLargeUpRightPos;
        public static PointF phorLargeBotLeftPos;

        public calibrationForm()
        {
            InitializeComponent();
            this.controller = new Controller();
            //this.listener = new LeapEventListener(this);
            //controller.AddListener(listener);

            bounds.Y = SystemInformation.VirtualScreen.Height;
            bounds.X = SystemInformation.VirtualScreen.Width;
            this.Size = (Size)bounds;
            calibButton.Location = new Point(Convert.ToInt32(this.Width * .5 - calibButton.Width * .5), Convert.ToInt32(this.Height * .5 - calibButton.Height * .5));
            //startButton1.Location = new Point(5, 5);
            //startButton2.Location = new Point(this.Width - 5 - startButton2.Width, this.Height - 65 - startButton2.Width);
            //startButton3.Location = new Point(this.Width - 5 - startButton3.Width, 5);
            //startButton4.Location = new Point(5, this.Height - 65 - startButton4.Width);

            calibButton.Focus();
        }

        private void calibButton_Click(object sender, EventArgs e)
        {

            //Get the position of the finger/palm (supposedly centered)
            fingerCenter = new float[3] { controller.Frame().Hands[0].Fingers[1].TipPosition.x,
                                          controller.Frame().Hands[0].Fingers[1].TipPosition.y,
                                          controller.Frame().Hands[0].Fingers[1].TipPosition.z };
            palmCenter = new float[3] { controller.Frame().Hands[0].PalmPosition.x,
                                        controller.Frame().Hands[0].PalmPosition.y,
                                        controller.Frame().Hands[0].PalmPosition.z };
            //startButton1.Visible = true;
            //startButton1.Focus();

            vertSmallUpRightPos = new PointF(fingerCenter[0] + 64, fingerCenter[1] + 36);
            vertSmallBotLeftPos = new PointF(fingerCenter[0] - 64, fingerCenter[1] - 36);
            vertLargeUpRightPos = new PointF(fingerCenter[0] + 256, fingerCenter[1] + 128);
            vertLargeBotLeftPos = new PointF(fingerCenter[0] - 256, fingerCenter[1] - 128);
            horSmallUpRightPos = new PointF(fingerCenter[0] + 40, fingerCenter[2] - 22);
            horSmallBotLeftPos = new PointF(fingerCenter[0] - 40, fingerCenter[2] + 22);
            horLargeUpRightPos = new PointF(fingerCenter[0] + 80, fingerCenter[2] - 45);
            horLargeBotLeftPos = new PointF(fingerCenter[0] - 80, fingerCenter[2] + 45);

            pvertSmallUpRightPos = new PointF(fingerCenter[0] + 64, fingerCenter[1] + 36);
            pvertSmallBotLeftPos = new PointF(fingerCenter[0] - 64, fingerCenter[1] - 36);
            pvertLargeUpRightPos = new PointF(fingerCenter[0] + 256, fingerCenter[1] + 128);
            pvertLargeBotLeftPos = new PointF(fingerCenter[0] - 256, fingerCenter[1] - 128);
            phorSmallUpRightPos = new PointF(fingerCenter[0] + 40, fingerCenter[2] - 22);
            phorSmallBotLeftPos = new PointF(fingerCenter[0] - 40, fingerCenter[2] + 22);
            phorLargeUpRightPos = new PointF(fingerCenter[0] + 80, fingerCenter[2] - 45);
            phorLargeBotLeftPos = new PointF(fingerCenter[0] - 80, fingerCenter[2] + 45);

            calibButton.Visible = false;
            startupMenu startupMenu = new startupMenu();
            startupMenu.Show();
            this.Hide();
        }

        //private void startButton1_MouseHover(object sender, EventArgs e)
        //{
        //    startButton2.Visible = true;
        //    startButton1.Visible = false;
        //}

        //private void startButton2_MouseHover(object sender, EventArgs e)
        //{
        //    startButton3.Visible = true;
        //    startButton2.Visible = false;
        //}

        //private void startButton3_MouseHover(object sender, EventArgs e)
        //{
        //    startButton4.Visible = true;
        //    startButton3.Visible = false;
        //}

        //private void startButton4_MouseHover(object sender, EventArgs e)
        //{
        //    startButton4.Visible = false;
        //    startupMenu startupMenu = new startupMenu();
        //    startupMenu.Show();
        //    this.Close();
        //}
    }
}
