using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary1.Factory;
using ClassLibrary1.Interface;

namespace Movienet
{
    /// <summary>
    /// Logique d'interaction pour User.xaml
    /// </summary>
    public partial class DisplayUsers : Page
    {
        public DisplayUsers()
        {
            IServiceFacade Services = ServiceFacadeFactory.GetServiceFacade();
            IUserDao uDao = Services.GetUserDao();
            List<ClassLibrary1.User> users = new List<ClassLibrary1.User>();
            try
            {
                users = uDao.getAllUsers();
                foreach (ClassLibrary1.User u in users)
                {
                    UserList.Items.Add(u.ToString());
                }
            } catch (Exception e)
            {
                if (Info != null) 
                    Info.Text = Info.Text + " Exception: " + e;
            }
            InitializeComponent();
        }
        
    }
}
