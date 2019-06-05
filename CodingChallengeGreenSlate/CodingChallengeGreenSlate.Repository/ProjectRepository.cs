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
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DbContext context)
            : base(context)
        {

        }
        public Project GetProjectById(int projectId)
        {
            return _dbset.Where(x => x.Id == projectId).FirstOrDefault();
        }

        public override IEnumerable<Project> GetAll()
        {
            return _entities.Set<Project>().AsEnumerable();
        }
    }
}
