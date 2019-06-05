using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeGreenSlate.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context)
        {

        }
        public User GetUserById(int userId)
        {
            return _dbset.Where(x => x.Id == userId).FirstOrDefault();
        }

        public override IEnumerable<User> GetAll()
        {
            return _dbset.ToList();
            //retunr  _entities.Set<User>().AsEnumerable();
        }
    }
}
