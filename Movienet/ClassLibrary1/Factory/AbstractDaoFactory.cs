using ClassLibrary1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Factory
{
    abstract class AbstractDaoFactory
    {
        public abstract IUserDao GetUserDao();

        public abstract IFilmDao getFilmDao();

        public abstract ICommentDao getCommentDao();

        public static AbstractDaoFactory getFactory()
        {
            return new DaoFactory();
        }
    }
}
