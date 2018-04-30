using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMovieNet.Interface
{
    public interface ICommentDao
    {
        Comment CreateComment(Comment comment);
        Comment UpdateComment(Comment comment);
        Boolean DeleteComment(Comment comment);
        Comment GetComment(int cid);
        List<Comment> getAllComments();
    }
}
