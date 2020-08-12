
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EQuiz.Controllers
{
    
    public class HomeController : Controller
    {
        /// <summary>
        /// Login class for User and Admin
        /// </summary>
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(int id)
        {
            //tbl_user usr = db.tbl_user.Where(x => x.u_username == user.u_username && x.u_password == user.u_password).SingleOrDefault();
            try
            {
                return View();
                //if (usr != null)
                //{
                //    Session["u_id"] = usr.u_id.ToString();
                //    Session["u_role"] = usr.u_role.ToString();
                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //   return  ViewBag.error = "Invalid Username and / or password";
                //}
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }
        /// <summary>
        /// Create Quiz -> Availiable for Admin only
        ///     Give instructions for the quiz
        ///     Questions, Answers, Explanations, Duration of the Quiz.
        /// </summary>
        /// <returns> View </returns>
        public ActionResult CreateQuiz()
        {            
            return View();            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult EditQuiz()
        {           
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult EditQuestion()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ViewQuiz(int ? id)
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewAllQuiz()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
