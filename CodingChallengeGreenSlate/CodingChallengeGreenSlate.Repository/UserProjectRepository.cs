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
    public class UserProjectRepository : GenericRepository<UserProject>, IUserProjectRepository
    {
        public UserProjectRepository(DbContext context)
            : base(context)
        {

        }
        public IEnumerable<UserProject> GetProjectsByUserId(int? userId)
        {
            //return _dbset.Where(x => x.UserId == userId).Include(u => u.Project).Include(u => u.User).AsEnumerable();

            var listProjectsForUser = _dbset.Where(x => x.UserId == userId).Include(u => u.Project).Include(u => u.User).AsEnumerable();
            //foreach (var f in listProjectsForUser)
            //{
                
            //}


            //List<UserProjectDetailView> listUserProjectDetails = new List<UserProjectDetailView>();
            //foreach (var userProject in listProjectsForUser)
            //{
            //    string daysTimeToStart = calculateTimeToStart(userProject.Project.StartDate.ToString("yyyyMMdd"), userProject.AssignedDate.ToString("yyyyMMdd"));
            //    string status = validateStatus(userProject.IsActive);
            //    UserProjectDetailView userProjectDetail = new UserProjectDetailView
            //    {
            //        UserId = userProject.UserId,
            //        ProjectId = userProject.ProjectId,
            //        StartDate = userProject.Project.StartDate,
            //        TimeToStart = daysTimeToStart,
            //        EndDate = userProject.Project.EndDate,
            //        Credits = userProject.Project.Credits,
            //        Status = status
            //    };
            //    listUserProjectDetails.Add(userProjectDetail);
            //}

            return listProjectsForUser;
        }

        private string calculateTimeToStart(string StartDate, string AssignedDate)
        {
            int intStartDate = Convert.ToInt32(StartDate);
            int intAssignedDate = Convert.ToInt32(AssignedDate);
            if (intStartDate < intAssignedDate)
            {
                return "Started";
            }
            else
            {
                int daysToStartProject = intStartDate - intAssignedDate;
                string daysToStart = daysToStartProject.ToString() + " days";
                return daysToStart;
            }
        }

        private string validateStatus(bool statusActive)
        {
            if (statusActive.Equals(true))
            {
                return "Active";
            }
            else
            {
                return "Inactive";
            }
        }
    }
}
