using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IPCamera
{
    static class Program
    {
        public static bool Login = false;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            欢迎 myWelcomeForm = new 欢迎();
            myWelcomeForm.ShowDialog();
            登入界面 deLu = new 登入界面();
            deLu.ShowDialog();
            if (Login == true)
            {
                Application.Run(new IPCamera.智慧监控());
            } 
        }
    }
}
