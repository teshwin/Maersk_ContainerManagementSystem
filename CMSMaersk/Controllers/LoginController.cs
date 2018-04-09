using CMSMaersk.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSMaersk.Controllers
{
    public class LoginController : Controller
    {
        AgentRepository agentRepository = new AgentRepository();
        AdminRepository adminRepository = new AdminRepository();
        
        // GET: Login
        public ActionResult Index(bool invalidUsername = false)
        {
            return View(invalidUsername);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult Authenticate()
        {
            var username = Request.QueryString["username"];
            var password = Request.QueryString["password"];
            var agent = agentRepository.AuthenticateCredentials(username, password);
            if (agent==null)
            {
                var admin = adminRepository.AuthenticateCredentials(username, password);
                if (admin != null)
                {
                    Session["user"] = admin;
                    Session["type"] = "admin";
                    return RedirectToAction("AdminHome");
                }
                else
                {
                    Debug.WriteLine("Yup here");
                    bool tr = true;
                    return RedirectToAction("Index", new { invalidUsername = true });
                }
            }
            else
            {
                Session["user"] = agent;
                Session["type"] = "agent";
                return RedirectToAction("Home");
            }
        }

        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}