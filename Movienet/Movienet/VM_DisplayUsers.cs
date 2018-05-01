using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using ModelMovieNet.Factory;
using ModelMovieNet.Interface;

namespace Movienet
{
    public class VM_DisplayUsers: ViewModelBase
    {
        private static IServiceFacade Services { get; } = ServiceFacadeFactory.GetServiceFacade();
        private static IUserDao uDao { get; } = Services.GetUserDao();

        private List<ModelMovieNet.User> users;
        public ObservableCollection<string> UserList { get; set; } = new ObservableCollection<string>();

        public VM_DisplayUsers()
        {

            Info = "Informations: ";
            try
            {

                Users = uDao.getAllUsers();
                foreach (var user in Users)
                {
                    this.UserList.Add(user.Id + " - " + user.Firstname + " " + user.Lastname);
                }
            } catch (Exception e)
            {
                Info = Info + e.Message;
                Console.WriteLine("PERSO EXCEPTION: " + e.ToString());
            }
        }

        public List<ModelMovieNet.User> Users
        {
            get { return users; }
            set {
                users = value;
                RaisePropertyChanged();
            }
        }


        private string info;

        public string Info
        {
            get { return info; }
            set { info = value; }
        }
    }
}
