using System;
using System.Windows.Forms;

namespace ProyectoFarmacia
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm login = new LoginForm();
            Application.Run(login);
        }
    }
}