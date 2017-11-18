using System;
using System.Windows.Forms;

namespace Lab2_2a
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Schedule());
        }
    }
}