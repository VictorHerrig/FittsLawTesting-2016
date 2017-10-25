using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LeapTest

{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            calibrationForm calibForm = new calibrationForm();
            calibForm.Show();
            Application.Run();
        }
    }
}
