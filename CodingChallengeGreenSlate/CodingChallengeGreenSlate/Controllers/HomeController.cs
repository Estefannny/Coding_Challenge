using System;
using System.Web.Mvc;
using System.Net;
using CodingChallengeGreenSlate.Service;

namespace CodingChallengeGreenSlate.Controllers
{
    public class HomeController : Controller
    {
        IUserProjectService _userProjectService;
        IUserService _userService;
        IProjectService _projectService;

        public HomeController(IUserProjectService userProjectService, IUserService userService, IProjectService projectService)
        {
            _userProjectService = userProjectService;
            _userService = userService;
            _projectService = projectService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getUsers()
        {
            try
            {
                var data = _userService.GetAll();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return View("Error",new HandleErrorInfo(ex,"GetUsers","Index"));
            }
        }

        // GET: Home/DetailsUserProjects/5
        public ActionResult DetailsUserProjects(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var listProjectsForUser = _userProjectService.GetProjectsByUserId(id);

                var data = listProjectsForUser;
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "DetailsUserProjects", "Index"));
            }
        }
    }
}