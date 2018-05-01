using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using ModelMovieNet;
using ModelMovieNet.Factory;
using ModelMovieNet.Interface;

namespace Movienet
{
    public class VM_DisplayUsers: VM_User
    {
        private ObservableCollection<User> _users { get; set; }
        private User _selectItem;
        private string _info;
        private Page _detail;

        public VM_DisplayUsers()
        {
            Info = "Informations: ";
            Detail = new Page();
            try
            {
                Users = new ObservableCollection<User>(uDao.getAllUsers());
            } catch (Exception e)
            {
                Info = Info + e.Message;
                Console.WriteLine("PERSO EXCEPTION: " + e.ToString());
            }
        }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set {
                _users = value;
                RaisePropertyChanged("Users");
            }
        }

        new public string Info
        {
            get { return _info; }
            set {
                _info = value;
                RaisePropertyChanged("Info");
            }
        }

        public User SelectItem
        {
            get { return _selectItem; }
            set {
                Console.WriteLine("set select item" + value.Firstname);
                _selectItem = value;
                Detail = new UserDetail();
                Info = "Item selected";
                RaisePropertyChanged("SelectedItem");
            }
        }

        public Page Detail
        {
            get { return _detail; }
            set {
                _detail = value;
                RaisePropertyChanged("Detail");
            }
        }

    }
}
