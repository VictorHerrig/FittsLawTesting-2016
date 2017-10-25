using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LeapTest
{
    public partial class startupMenu : Form
    {
        public static string trackType;
        public static string clickType;
        public static string orientation;
        public static string size;
        public static int ID;
        public static int subNum;
        public static PointF upRightPos;
        public static PointF botLeftPos;

        public startupMenu()
        {
            InitializeComponent();
            string[] clickMethods = new string [4] { "Thumb Retract", "Simulated Finger Click", "Mouse Click", "F Key" };
            string[] trackMethods = new string [2] { "Index Finger", "Palm" };
            string[] orientation = new string[2] { "Vertical", "Horizontal" };
            string[] size = new string[2] { "Small", "Large" };
            ID = 1;
            comboBox1.DataSource = clickMethods;
            comboBox2.DataSource = trackMethods;
            comboBox3.DataSource = orientation;
            comboBox4.DataSource = size;
            nextButton.Focus();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            if (trackType == "Index Finger")
            {
                if (orientation == "Vertical")
                {
                    if (size == "Small") { upRightPos = calibrationForm.vertSmallUpRightPos; botLeftPos = calibrationForm.vertSmallBotLeftPos; }
                    else { upRightPos = calibrationForm.vertLargeUpRightPos; botLeftPos = calibrationForm.vertLargeBotLeftPos; }
                }
                else
                {
                    if (size == "Small") { upRightPos = calibrationForm.horSmallUpRightPos; botLeftPos = calibrationForm.horSmallBotLeftPos; }
                    else { upRightPos = calibrationForm.horLargeUpRightPos; botLeftPos = calibrationForm.horLargeBotLeftPos; }
                }
            }
            else
            {
                if (orientation == "Vertical")
                {
                    if (size == "Small") { upRightPos = calibrationForm.pvertSmallUpRightPos; botLeftPos = calibrationForm.pvertSmallBotLeftPos; }
                    else { upRightPos = calibrationForm.pvertLargeUpRightPos; botLeftPos = calibrationForm.pvertLargeBotLeftPos; }
                }
                else
                {
                    if (size == "Small") { upRightPos = calibrationForm.phorSmallUpRightPos; botLeftPos = calibrationForm.phorSmallBotLeftPos; }
                    else { upRightPos = calibrationForm.phorLargeUpRightPos; botLeftPos = calibrationForm.phorLargeBotLeftPos; }
                }
            }


                LeapTestForm leapTestForm = new LeapTestForm();
            leapTestForm.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clickType = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackType = comboBox2.Text;
            if(comboBox2.Text == "Index Finger") { comboBox1.Text = "Thumb Retract"; comboBox3.Text = "Vertical"; }
            else { comboBox1.Text = "Simulated Finger Click"; comboBox3.Text = "Horizontal"; }
        }

        private void Orientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            orientation = comboBox3.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = comboBox4.Text;
        }

        private void IDSetting_ValueChanged(object sender, EventArgs e)
        {
            ID = Decimal.ToInt32(IDSetting.Value);
        }

        private void subjNumber_ValueChanged(object sender, EventArgs e)
        {
            subNum = Decimal.ToInt32(subjNumber.Value);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            label1.Visible = false; label2.Visible = false; label5.Visible = false; label6.Visible = false; comboBox1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false;
            label3.Visible = true; subjLabel.Visible = true; IDSetting.Visible = true; subjNumber.Visible = true; recalibButton.Visible = false;
            nextButton.Visible = false; backButton.Visible = true; continueButton.Visible = true;
            this.Height = 170;
            continueButton.Focus();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            label1.Visible = true; label2.Visible = true; label5.Visible = true; label6.Visible = true; comboBox1.Visible = true; comboBox2.Visible = true; comboBox3.Visible = true; comboBox4.Visible = true;
            label3.Visible = false; subjLabel.Visible = false; IDSetting.Visible = false; subjNumber.Visible = false; recalibButton.Visible = true;
            backButton.Visible = false; nextButton.Visible = true; continueButton.Visible = false;
            this.Height = 245;
        }

        private void endbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void recalibButton_Click(object sender, EventArgs e)
        {
            calibrationForm calibForm = new calibrationForm();
            calibForm.Show();
            this.Close();
        }
    }

}