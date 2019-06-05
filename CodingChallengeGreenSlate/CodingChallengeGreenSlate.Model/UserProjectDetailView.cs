using CodingChallengeGreenSlate.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingChallengeGreenSlate.Model
{
    public class UserProjectDetailView : Entity<int>
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public string TimeToStart { get; set; }
        public DateTime EndDate { get; set; }
        public int Credits { get; set; }
        public string Status { get; set; }
    }
}