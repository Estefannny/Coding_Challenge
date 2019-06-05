using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodingChallengeGreenSlate.Model;

namespace CodingChallengeGreenSlate.Controllers
{
    public class UserProjectController : Controller
    {
        private ContextEF db = new ContextEF();

        // GET: UserProject
        public ActionResult Index(int? Id)
        {
            //Get List User Registers
            List<User> UserList = db.Users.ToList();
            ViewBag.UserList = new SelectList(UserList, "Id", "FirstName");

            if (Id!=null)
            {
                var userProjects = db.UserProjects.Where(x => x.UserId==Id).Include(u => u.Project).Include(u => u.User);
                return View(userProjects.ToList());
            }
            else
            {
                return View();
            }
           
           // var userProjects = db.UserProjects.Include(u => u.Project).Include(u => u.User);
            
        }


        // GET: UserProject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProject userProject = db.UserProjects.Find(id);
            string daysTimeToStart = calculateTimeToStart(userProject.Project.StartDate.ToString("yyyyMMdd"), userProject.AssignedDate.ToString("yyyyMMdd"));
            string status = validateStatus(userProject.IsActive);
            UserProjectDetailView userProjectDetail = new UserProjectDetailView
            {
                UserId = userProject.UserId,
                ProjectId = userProject.ProjectId,
                StartDate = userProject.Project.StartDate,
                TimeToStart = daysTimeToStart,
                EndDate = userProject.Project.EndDate,
                Credits = userProject.Project.Credits,
                Status = status
            };

            if (userProject == null)
            {
                return HttpNotFound();
            }
            // return View(userProject);

            return View(userProjectDetail);
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

        // GET: UserProject/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Id");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: UserProject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,ProjectId,IsActive,AssignedDate")] UserProject userProject)
        {
            if (ModelState.IsValid)
            {
                db.UserProjects.Add(userProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Id", userProject.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userProject.UserId);
            return View(userProject);
        }

        // GET: UserProject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProject userProject = db.UserProjects.Find(id);
            if (userProject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Id", userProject.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userProject.UserId);
            return View(userProject);
        }

        // POST: UserProject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,ProjectId,IsActive,AssignedDate")] UserProject userProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Id", userProject.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userProject.UserId);
            return View(userProject);
        }

        // GET: UserProject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProject userProject = db.UserProjects.Find(id);
            if (userProject == null)
            {
                return HttpNotFound();
            }
            return View(userProject);
        }

        // POST: UserProject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProject userProject = db.UserProjects.Find(id);
            db.UserProjects.Remove(userProject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
