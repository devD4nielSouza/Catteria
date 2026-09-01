using System;
using System.Windows.Forms;
using Catteria.Desktop.Forms;

namespace Catteria.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Para .NET 10 / WinForms
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}