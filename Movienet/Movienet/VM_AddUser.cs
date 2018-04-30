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
    public class VM_AddUser : ViewModelBase
    {
        private static IServiceFacade Services { get; } = ServiceFacadeFactory.GetServiceFacade();
        private static IUserDao uDao { get; } = Services.GetUserDao();

        private string info; 

        public string Info
        {
            get { return info; }
            set
            {
                string info = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand Add { get; }

        private User newUser;
        public User NewUser
        {
            get { return newUser; }
            set
            {
                Console.WriteLine("NewUser setter called");
                newUser = value;
                Add.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }
        
        public VM_AddUser()
        {
            Add = new RelayCommand(AddUser, canAdd);
            NewUser = new User();
            this.info = "Informations: ";
        }

        void AddUser()
        {
            Console.WriteLine("In Add User from VM_AddUser");
            String infoAdd = "Adding a user";
            if (!this.isValidUser())
            {
                infoAdd = "You must fullfill all fields and password must be at least 4 characters";
            } else
            {
                User checkUser = new User();
                try
                {
                    uDao.getAllUsers();
                    checkUser = uDao.CreateUser(NewUser);
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

        Boolean isValidUser()
        {
            Console.WriteLine("isValidUser, BEGIN");
            Boolean check = false;
            if (NewUser != null)
            {
                /*
                 * Check property emptiness and size 
                */
                Console.WriteLine("isValidUser, newUsernotNULL");
                check = (NewUser.Firstname != null && NewUser.Firstname.Length != 0 &&
                    NewUser.Lastname != null && NewUser.Lastname.Length != 0 &&
                    NewUser.Login != null && NewUser.Login.Length != 0 && 
                    NewUser.Password != null && NewUser.Password.Length != 0 && NewUser.Password.Length > 4);
            }
            Console.WriteLine("isValidUser return " + (check ? "true" : "false"));
            return check;
        }

    }
}

/*

*/
