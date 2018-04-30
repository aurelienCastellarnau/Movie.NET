using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelMovieNet.Dao;
using ModelMovieNet.Interface;

namespace ModelMovieNet.Factory
{
   class DaoFactory : AbstractDaoFactory
    {
        public override ICommentDao getCommentDao()
        {
            return new CommentDao();
        }

        public override IMovieDao getMovieDao()
        {
            return new MovieDao();
        }

        public override IUserDao GetUserDao()
        {
            return new UserDao();
        }
    }
}
