using CodingChallengeGreenSlate.Model;
using CodingChallengeGreenSlate.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeGreenSlate.Service
{
    public interface IProjectService : IEntityService<Project>
    {
        Project GetProjectById(int projectId);
    }
}
