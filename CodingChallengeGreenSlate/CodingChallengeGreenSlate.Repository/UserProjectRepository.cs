using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Data.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace CodingChallengeGreenSlate.Data
{
    public class UserProjectRepository : GenericRepository<UserProject>, IUserProjectRepository
    {
        public UserProjectRepository(DbContext context)
            : base(context)
        {

        }
        public IEnumerable<UserProject> GetProjectsByUserId(int? userId)
        {
            var listProjectsForUser = _dbset
                .Where(x => x.UserId == userId)
                .Include(u => u.Project)
                .Include(u => u.User)
                .AsEnumerable();
            return listProjectsForUser;
        }
    }
}
