using GalaSoft.MvvmLight;
using ModelMovieNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movienet
{
    /**
     * Class used to communicate a state and a user variable
     * among view models.
     * The principe is to update those variable throught messenger
     * To get them, the good way is to subscribe to CurrentUser and CurrentState channels
     * then to ask a trigger sending a string to Context channel
     * */
    public class User_State_Machine : ViewModelBase
    {
        public enum STATE { NONE, ADD, SELECT, UPDATE, DELETE, NEED_AUTHENTICATION };
        private static STATE vm_user_state;
        private static User currentUser = null;
        private static User sessionUser = null;

        public User_State_Machine()
        {
            /**
             * The class subscribe to two setters and a request for the actual state
             * */
            MessengerInstance.Register<STATE>(this, "SetUserState", SetState);
            MessengerInstance.Register<User>(this, "SetUser", SetUser);
            MessengerInstance.Register<User>(this, "SetSessionUser", SetSessionUser);
            MessengerInstance.Register<string>(this, "Context", SendContext);
        }

        protected STATE VM_User_State
        {
            get { return vm_user_state; }
            private set
            {
                vm_user_state = value;
                MessengerInstance.Send(VM_User_State, "state_changed");
            }
        }

        protected User Session
        {
            get { return sessionUser; }
            private set
            {
                Console.WriteLine("User_State_Machine: Setting session User");
                sessionUser = value;
                MessengerInstance.Send(Session, "SessionUser");
            }
        }

        protected User CurrentUser
        {
            get { return currentUser; }
            private set
            {
                currentUser = value;
            }
        }

        /**
         * Possible upper logic for the class wich
         * implement it (Actually, VM_RootFrame)
         * */
        public virtual void StateChangedAck(STATE state)
        {
            Console.WriteLine("USER_STATE_MACHINE Ack");
        }

        /**
         * Setters messenger callbacks
         * */
        void SetState(STATE state)
        {
            Console.WriteLine("User_State_Machine: set State to: " + state);
            VM_User_State = state;
        }
        
        void SetUser(User user)
        {
            CurrentUser = user;
        }

        void SetSessionUser(User user)
        {
            Console.WriteLine("User State Machine set session user: " + ((user.Id > 0) ? user.Login : "INVALID USER"));
            Session = user;
        }

        /**
         * When a viewmodel send a messenger on 'Context'
         * User_State_Machine send CurrentUser and CurrentState
         * */
        void SendContext(string ask)
        {
            Console.WriteLine("User_State_Machine: send context to " + ask);
            Console.WriteLine("User_State_Machine: " + CurrentUser?.ToString() + " " + VM_User_State);
            MessengerInstance.Send(CurrentUser, "CurrentUser");
            MessengerInstance.Send(VM_User_State, "CurrentState");
        }
    }
}
