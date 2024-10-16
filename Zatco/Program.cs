using System;
using System.Threading;
using System.Windows.Forms;
namespace Zatco
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            using (Mutex mutex = new Mutex(true, "YourAppUniqueName", out bool createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
                else
                {
                    // البرنامج قيد التشغيل بالفعل
                    MessageBox.Show("The program is already running.","ZATCO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }

    }
}