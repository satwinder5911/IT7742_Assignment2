using System;
using System.Windows.Forms;

namespace CustomerApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new CustomerView());
        }
    }
}
