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
    public class TopicRepository : Repository<Topic>, ITopicRepository {

        private ApplicationDbContext _db;
        public TopicRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        public void Update(Topic topic) {
           _db.Topics.Update(topic);
        }
    }
}