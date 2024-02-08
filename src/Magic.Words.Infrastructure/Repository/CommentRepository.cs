using Magic.Words.Core.Data;
using Magic.Words.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic.Words.Core.IRepository;

namespace Magic.Words.Core.Repository 
    {
    public class CommentRepository : Repository<Comment>, ICommentRepository {

        private ApplicationDbContext _db;
        public CommentRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        public void Update(Comment comment) {
           _db.Comments.Update(comment);
        }
    }
}