using CodingChallengeGreenSlate.Model.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingChallengeGreenSlate.Model
{
    public class UserProject : Entity<int>
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime AssignedDate { get; set; }

        [NotMapped]
        public String TimeToStart
        {
            get
            {
                double days = (Project.StartDate - AssignedDate)
                    .TotalDays;

                if (Project.StartDate < AssignedDate)
                {
                    return "Started";
                }
                else
                {
                    string daysToStart = days
                        .ToString() + " days";
                    return daysToStart;
                }
            }
            private set
            {

            }
        }

        [Display(Name = "Status")]
        [NotMapped]
        public String Status
        {
            get
            {
                if (IsActive.Equals(true))
                {
                    return "Active";
                }
                else
                {
                    return "Inactive";
                }
            }
            private set
            {

            }
        }

        [Display(Name = "Start Date")]
        [NotMapped]
        public String StartDate
        {
            get
            {
                return Project
                    .StartDate
                    .ToString("dd/MM/yyyy") ;
            }
            private set
            {

            }
        }

        [Display(Name = "End Date")]
        [NotMapped]
        public String EndDate
        {
            get
            {
                return Project
                    .EndDate
                    .ToString("dd/MM/yyyy");
            }
            private set
            {

            }
        }

        [Display(Name = "Credits")]
        [NotMapped]
        public int Credits
        {
            get
            {
                return Project.Credits;
            }
            private set
            {

            }
        }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
}