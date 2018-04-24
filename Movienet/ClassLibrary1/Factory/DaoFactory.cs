using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Dao;
using ClassLibrary1.Interface;

namespace ClassLibrary1.Factory
{
    class DaoFactory : AbstractDaoFactory
    {
        public override ICommentDao getCommentDao()
        {
            return new CommentDao();
        }

        public override IFilmDao getFilmDao()
        {
            return new FilmDao();
        }

        public override IUserDao GetUserDao()
        {
            return new UserDao();
        }
    }
}
