using System;
using System.Windows.Forms;

namespace Lab2_2b
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