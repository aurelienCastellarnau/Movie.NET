using ModelMovieNet.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMovieNet.Factory
{
    abstract class AbstractDaoFactory
    {
        public abstract IUserDao GetUserDao();

        public abstract IMovieDao getMovieDao();

        public abstract ICommentDao getCommentDao();

        public static AbstractDaoFactory getFactory()
        {
            return new DaoFactory();
        }
    }
}
