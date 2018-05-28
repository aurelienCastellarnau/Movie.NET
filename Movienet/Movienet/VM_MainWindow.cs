using GalaSoft.MvvmLight;
using ModelMovieNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Movienet
{
    public class VM_MainWindow: User_State_Machine
    {
        private User sessionUser;
        private Page _rootPage;
        public Page RootPage
        {
            get
            {
                return _rootPage;
            }
            set
            {
                _rootPage = value;
                RaisePropertyChanged("RootPage");
            }
        }

        /**
         * Constructor
         * */
        public VM_MainWindow()
        {
            Console.WriteLine("Defining DataDirectory");
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            int index = baseDir.IndexOf("Movienet");
            string dataDir = baseDir.Substring(0, index) + "Movienet\\ModelMovieNet\\";
            Console.WriteLine("dataDir: " + dataDir);
            AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            Console.WriteLine("Buidling RootPage");
            MessengerInstance.Register<User>(this, "SessionUser", SetSessionUser);
            RootPage = new Authentication();
        }

        public User SessionUser
        {
            get { return sessionUser; }
            set {
                sessionUser = value;
            }
        }


        void SetSessionUser(User user)
        {
            Console.WriteLine("VM_MainWindow: SetSession User.");
            if (user != null)
            {
                Console.WriteLine("VM_MainWindow: rootFrame");
                RootPage = new RootFrame();
            }
            else
            {
                Console.WriteLine("VM_MainWindow: authentication");
                RootPage = new Authentication();
            }
        }
    }
}
