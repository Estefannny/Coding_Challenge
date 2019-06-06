using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Data.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CodingChallengeGreenSlate.Data
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context)
        {

        }
        public User GetUserById(int userId)
        {
            return _dbset
                .Where(x => x.Id == userId)
                .FirstOrDefault();
        }

        public override IEnumerable<User> GetAll()
        {
            return _dbset.ToList();
        }
    }
}
