using projekt.classes;
using System;
using System.Windows.Forms;
namespace projekt
{
    static class Program
    {       public static Data data;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          
            Application.Run(new Form1());
           


    }
    }
}
