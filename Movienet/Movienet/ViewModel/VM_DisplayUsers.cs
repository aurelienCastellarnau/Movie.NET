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
    public class VM_DisplayUsers: VM_User
    {
        private List<ModelMovieNet.User> _users;
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
            get { return _users; }
            set {
                _users = value;
                RaisePropertyChanged();
            }
        }

        private string _info;
        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }
    }
}
