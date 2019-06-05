using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeGreenSlate.Repository
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Project GetProjectById(int projectId);
    }
}
