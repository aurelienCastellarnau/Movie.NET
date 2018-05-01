using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ModelMovieNet;
using ModelMovieNet.Factory;
using ModelMovieNet.Interface;

namespace Movienet
{
    public class VM_User: ViewModelBase
    {
        protected static IServiceFacade Services { get; } = ServiceFacadeFactory.GetServiceFacade();
        protected static IUserDao uDao { get; } = Services.GetUserDao();
        public RelayCommand Add { get; set; } = null;
        public RelayCommand Update { get; set; } = null;
        public RelayCommand Delete { get; set; } = null;

        private User _user;
        private string _info;

        public VM_User()
        {
            User = new User();
            Add = new RelayCommand(AddUser, canAdd);
            _info = "Informations: ";
        }

        public User User
        {
            get { return _user; }
            set
            {
                Console.WriteLine("NewUser setter called");
                _user = value;
                if (Add != null)
                    Add.RaiseCanExecuteChanged();
                if (Update != null)
                    Update.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public string Firstname
        {
            get { return User.Firstname; }
            set {
                User.Firstname = value;
                if (Add != null)
                    Add.RaiseCanExecuteChanged();
                if (Update != null)
                    Update.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public string Lastname
        {
            get { return User.Lastname; }
            set
            {
                User.Lastname = value;
                if (Add != null)
                    Add.RaiseCanExecuteChanged();
                if (Update != null)
                    Update.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public string Login
        {
            get { return User.Login; }
            set
            {
                User.Login = value;
                if (Add != null)
                    Add.RaiseCanExecuteChanged();
                if (Update != null)
                    Update.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get { return User.Password; }
            set
            {
                User.Password = value;
                if (Add != null)
                    Add.RaiseCanExecuteChanged();
                if (Update != null)
                    Update.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        protected Boolean isValidUser()
        {
            Console.WriteLine("isValidUser, BEGIN");
            Boolean check = false;
            if (User != null)
            {
                /*
                 * Check property emptiness and size 
                */
                Console.WriteLine("isValidUser, newUsernotNULL");
                check = (User.Firstname != null && User.Firstname.Length != 0 &&
                    User.Lastname != null && User.Lastname.Length != 0 &&
                    User.Login != null && User.Login.Length != 0 &&
                    User.Password != null && User.Password.Length != 0 && User.Password.Length > 4);
            }
            Console.WriteLine("isValidUser return " + (check ? "true" : "false"));
            return check;
        }
        
        public string Info
        {
            get { return _info; }
            set
            {
                string _info = value;
                RaisePropertyChanged();
            }
        }

        void AddUser()
        {
            Console.WriteLine("In Add User from VM_AddUser");
            String infoAdd = "Adding a user";
            if (!isValidUser())
            {
                infoAdd = "You must fullfill all fields and password must be at least 4 characters";
            }
            else
            {
                User checkUser = new User();
                try
                {
                    uDao.getAllUsers();
                    checkUser = uDao.CreateUser(User);
                    infoAdd = "Adduser passed but we dont know the id";
                }
                catch (Exception e)
                {
                    infoAdd = "Add user failed: " + e;
                    Console.WriteLine("Exception PERSONNALISEE: " + e);
                }
                if (checkUser.Id > 0)
                {
                    infoAdd = "Everything happens well";
                }
            }
            if (infoAdd != null)
                Info = " Adding result: " + infoAdd;
            Console.WriteLine("Info : " + infoAdd);
        }

        Boolean canAdd()
        {
            return isValidUser();
        }
    }
}
