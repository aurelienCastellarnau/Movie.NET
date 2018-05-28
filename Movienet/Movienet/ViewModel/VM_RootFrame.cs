using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Controls;
using ModelMovieNet;
using static Movienet.User_State_Machine;

namespace Movienet
{
    /**
     * RootFrame is displaying a List (left) and a Detail (right) views
     * For now, it's build to display only user views, it could be nice
     * to abstract this logic to switch between Users and Movies.
     * */
    public class VM_RootFrame: ViewModelBase
    {
        /**
         * Application pages
         * */
        private Page _list;
        public Page List
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
                RaisePropertyChanged("List");
            }
        }
        private Page _detail;
        public Page Detail
        {
            get
            {
                return _detail;
            }
            set
            {
                _detail = value;
                RaisePropertyChanged("Detail");
            }
        }
        
        // Information
        private String _info;
        
        // Navigation
        public RelayCommand OpenCreateUser { get; set; }
        public RelayCommand OpenAuthentication { get; set; }

        /**
         * Constructor
         * */
        public VM_RootFrame(): base()
        {
            List = new DisplayUsers();
            Detail = new UserDetail();
            MessengerInstance.Register<STATE>(this, "state_changed", StateChangedAck);
            OpenCreateUser = new RelayCommand(() => GoToAddUser());
        }

        /**
         * Information
         * */
        public String Info
        {
            get
            {
                return _info;
            }
            set
            {
                _info = value;
                RaisePropertyChanged("Info");
            }
        }

        /**
         * State catcher
         * Building views after state changed
         * Views are supposed to ask the state on build
         * */
        protected void StateChangedAck(STATE state)
        {
            Console.WriteLine("VM_Root_Frame VM_USER_STATE CHANGED");
            switch (state)
            {
                case STATE.ADD:
                    Info = "VM_Root_Frame Handling ADD state";
                    Console.WriteLine(Info);
                    Detail = new AddUser();
                    break;
                case STATE.SELECT:
                    Info = "VM_Root_Frame Handling SELECT state";
                    Console.WriteLine(Info);
                    Detail = new UserDetail();
                    break;
                case STATE.UPDATE:
                    Info = "VM_Root_Frame Handling UPDATE state";
                    Console.WriteLine(Info);
                    break;
                case STATE.DELETE:
                    Info = "VM_Root_Frame Handling DELETE state";
                    Console.WriteLine(Info);
                    break;
                case STATE.NEED_AUTHENTICATION:
                    Info = "VM_Root_Frame Handling NEED_AUTHENTICATION state";
                    Console.WriteLine(Info);
                    Detail = new Authentication();
                    break;
                default:
                    break;
            }

        }

        /**
         * Display an AddUser view on Detail page
         * */
        private void GoToAddUser()
        {
            User u = new User();
            MessengerInstance.Send(u, "SetUser");
            MessengerInstance.Send(STATE.ADD, "SetUserState");
            Info = "RootFrame set context to Add and user to new one";
            Console.WriteLine(Info);
        }

        /**
         * Display an Authentication view on Detail page
         * */
        private void GoToAuthentication()
        {
            User u = new User();
            MessengerInstance.Send(u, "SetUser");
            MessengerInstance.Send(STATE.NEED_AUTHENTICATION, "SetUserState");
            Info = "RootFrame set context to Authentication and user to new one";
            Console.WriteLine(Info);
        }
    }
}
