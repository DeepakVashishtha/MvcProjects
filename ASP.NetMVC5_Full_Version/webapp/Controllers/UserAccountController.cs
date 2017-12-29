using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            SmartAdminMvc.Models.DbEntity.User user = new Models.DbEntity.User();
            ViewBag.UserTypeDDL = GetUserType();
            ViewBag.SecurityLevel = GetSecurityLevel();
            return View();
        }
        [HttpPost]
        public ActionResult Registration(SmartAdminMvc.Models.DbEntity.User user)
        {
            //user.Active = true;
            ViewBag.UserTypeDDL = GetUserType();
            ViewBag.SecurityLevel = GetSecurityLevel();
            if (ModelState.IsValid)
            {
                using (var context = new Models.DbEntity.GreenFieldEntities())
                {
                    ObjectParameter userId = new ObjectParameter("userId", typeof(global::System.Int32));
                    context.USP_Users_Insert(user.LoginName, user.Password, user.UserTypeID, user.ReferenceID, user.SecurityLevelID, user.LastName, user.FirstName, user.Title, user.TitleOfCourtesy, user.BirthDate, user.HireDate, user.Address, user.City, user.Region, user.PostalCode, user.Country, user.HomePhone, user.Extension, user.Notes, user.ReportsTo, user.Email, user.Active, userId);
                    TempData["userId"] = userId.Value;
                    if (TempData["userId"] != null)
                    {
                        TempData["Message"] = "Save Successfully.";
                    }
                    else
                    {
                        TempData["Message"] = "Error Occured!!";
                    }

                }
                return RedirectToAction("Registration");
            }
            return View(user);
            
        }
        public List<SelectListItem> GetUserType()
        {
            using (
                SmartAdminMvc.Models.DbEntity.GreenFieldEntities entity = new Models.DbEntity.GreenFieldEntities())
            {
                var vUserType = (from tblUserType in entity.UserTypes
                                 select new SelectListItem
                                 {
                                     Text = tblUserType.UserTypeName,
                                     Value = tblUserType.UserTypeID.ToString()
                                 });

                return vUserType.ToList();
            }


        }
        public List<SelectListItem> GetSecurityLevel()
        {
            using (SmartAdminMvc.Models.DbEntity.GreenFieldEntities entity = new Models.DbEntity.GreenFieldEntities())
            {
                var vUserType = (from tblSecuritylevels in entity.SecurityLevels
                                 select new SelectListItem
                                 {
                                     Text = tblSecuritylevels.SecurityLevelName,
                                     Value = tblSecuritylevels.SecurityLevelID.ToString()
                                 });

                return vUserType.ToList();
            }


        }
        public List<SelectListItem> GetPageList()
        {
            using (SmartAdminMvc.Models.DbEntity.GreenFieldEntities entity = new Models.DbEntity.GreenFieldEntities())
            {
                var vPage = (from tblPageDetial in entity.PageDetails
                              
                                 select new SelectListItem
                                 {
                                     Text = tblPageDetial.PageName,
                                     Value = tblPageDetial.PageId.ToString()
                                 });
                return vPage.ToList();
            }
        }
        public ActionResult PageSecurity()
        {
            using (SmartAdminMvc.Models.DbEntity.GreenFieldEntities entity = new Models.DbEntity.GreenFieldEntities())
            {
                List<SmartAdminMvc.Models.DbEntity.SecurityLevel> securityLevel = new List<SmartAdminMvc.Models.DbEntity.SecurityLevel>();
                
                var vRoleList = entity.USP_GETROLE().ToList();
               
                foreach (var item in vRoleList)
                {

                    SmartAdminMvc.Models.DbEntity.SecurityLevel security = new Models.DbEntity.SecurityLevel();
                    security.UserType = new Models.DbEntity.UserType();
                    security.SecurityLevelID = item.SecurityLevelID;
                    security.PageView = item.PageView;
                    security.UserTypeID = item.UserTypeID;
                    security.PageEdit = item.PageEdit;
                    security.SecurityLevelName = item.SecurityLevelName;
                    security.UserType.UserTypeName = item.UserTypeName;
                    securityLevel.Add(security);
                }
                ViewBag.PageList = GetPageList();
                ViewBag.RoleList = securityLevel;
                Session["RoleList"] = securityLevel;
                return View();
            }
        }

        public ActionResult GetListByPageId(string PageId)
        {
            using (SmartAdminMvc.Models.DbEntity.GreenFieldEntities entity = new Models.DbEntity.GreenFieldEntities())
            {
                List<SmartAdminMvc.Models.DbEntity.SecurityLevel> securityLevel = new List<SmartAdminMvc.Models.DbEntity.SecurityLevel>();

                var vRoleList = entity.USP_GETROLE().Where(x => x.PageId == Convert.ToInt32(PageId)).ToList();

                foreach (var item in vRoleList)
                {

                    SmartAdminMvc.Models.DbEntity.SecurityLevel security = new Models.DbEntity.SecurityLevel();
                    security.UserType = new Models.DbEntity.UserType();
                    security.SecurityLevelID = item.SecurityLevelID;
                    security.PageView = item.PageView;
                    security.UserTypeID = item.UserTypeID;
                    security.PageEdit = item.PageEdit;
                    security.SecurityLevelName = item.SecurityLevelName;
                    security.UserType.UserTypeName = item.UserTypeName;
                    securityLevel.Add(security);
                }
                ViewBag.PageList = GetPageList();
                ViewBag.RoleList = securityLevel;
                Session["RoleList"] = securityLevel;
                return View();
            }
        }
        [HttpPost]
        public ActionResult PageSecurity(SmartAdminMvc.Models.DbEntity.SecurityLevel securityLevelModel, FormCollection frm)
        {
            List<SmartAdminMvc.Models.DbEntity.SecurityLevel> securityLevel = new List<SmartAdminMvc.Models.DbEntity.SecurityLevel>();
            securityLevel = (List<SmartAdminMvc.Models.DbEntity.SecurityLevel>)Session["RoleList"];
            using (SmartAdminMvc.Models.DbEntity.GreenFieldEntities entity = new Models.DbEntity.GreenFieldEntities())
            {
                List<SmartAdminMvc.Models.DbEntity.SecurityLevel> securityLevel1 = new List<SmartAdminMvc.Models.DbEntity.SecurityLevel>();

                var vRoleList = entity.USP_GETROLE().ToList();

                foreach (var item in vRoleList)
                {
                    SmartAdminMvc.Models.DbEntity.SecurityLevel security = new Models.DbEntity.SecurityLevel();
                    security.UserType = new Models.DbEntity.UserType();
                    security.SecurityLevelID = item.SecurityLevelID;
                    security.PageView = item.PageView;
                    security.UserTypeID = item.UserTypeID;
                    security.PageEdit = item.PageEdit;
                    security.SecurityLevelName = item.SecurityLevelName;
                    security.UserType.UserTypeName = item.UserTypeName;
                    securityLevel1.Add(security);
                }
                ViewBag.PageList = GetPageList();
                ViewBag.RoleList = securityLevel1;
                
                for (int i = 0; i <= securityLevel.Count; i++)
                {
                    if(!string.IsNullOrEmpty(Convert.ToString(frm["SecurityLevelID_"+i])))
                    {
                        entity.USP_SecurityLevels_Update(Convert.ToInt32(frm["SecurityLevelID_" + i]), securityLevel[i].SecurityLevelName, securityLevel[i].UserTypeID, Convert.ToBoolean((Convert.ToString(frm["ChkView_" + i]).Split(',')[0])), Convert.ToBoolean(Convert.ToString(frm["ChkEdit_" + i]).Split(',')[0]), securityLevelModel.PageId);
                        TempData["Message"] = "Save Successfully.";
                    }
                }
               
            }
           
            return RedirectToAction("PageSecurity");
        }

        public ActionResult PageSecurityForAll()
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var listAllsecurity = context.USP_SecurityLevels_All().ToList();
                ViewBag.listAllsecurity = listAllsecurity;
                return View();
            }

        }

        // User List
        public ActionResult RegistrationList()
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var listAllUsers = context.USP_Users_All().ToList();
                return View(listAllUsers);
            }

        }


        public ActionResult edit_user(int id)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                var users = context.USP_Users_Get(id).SingleOrDefault();
                return View(users);
            }
        }
        [HttpPost]
        public ActionResult edit_user(Models.DbEntity.User user)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                context.USP_Users_Update(user.UserID, user.LoginName, user.Password, user.UserTypeID, user.ReferenceID, user.SecurityLevelID, user.LastName, user.FirstName, user.Title, user.TitleOfCourtesy, user.BirthDate, user.HireDate, user.Address, user.City, user.Region, user.PostalCode, user.Country, user.HomePhone, user.Extension, user.Notes, user.ReportsTo, user.Email, user.Active);
                TempData["Message"] = "Update Successfully.";
                return RedirectToAction("RegistrationList");
            }
        }

        public ActionResult delete_user(int id)
        {
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {
                context.USP_Users_Delete(id);
                TempData["Message"] = "Delete Successfully.";
                return RedirectToAction("RegistrationList");
            }
        }

        public ActionResult Login()
        {
            // We do not want to use any existing identity information
            //EnsureLoggedOut();
            Session["SecurityLevelID"] = null;
            // Store the originating URL so we can attach it to a form field
            //var viewModel = new AccountLoginModel { ReturnUrl = returnUrl };
            var viewModel = new SmartAdminMvc.Models.DbEntity.User();

            return View(viewModel);
        }

        // POST: /account/login
        [HttpPost]
        public ActionResult Login(SmartAdminMvc.Models.DbEntity.User viewModel)
        {
            // Ensure we have a valid viewModel to work with
            if (!ModelState.IsValid)
                return View(viewModel);

            // Verify if a user exists with the provided identity information
            //var user = await _manager.FindByEmailAsync(viewModel.Email);
            using (var context = new Models.DbEntity.GreenFieldEntities())
            {

                var user = context.USP_User_Login(viewModel.Email, viewModel.Password).ToList();
                
                
                //If a user was found
                if (user.Count !=0)
                {
                    // Then create an identity for it and sign it in
                    Session["SecurityLevelID"] = user[0].SecurityLevelID;
                    Session["UserTypeID"] = user[0].UserTypeID;
                    Session["SecurityLevelName"] = user[0].SecurityLevelName;
                    Session["PageId"] = user[0].PageId;
                    var Securitylevel = context.USP_SecurityLevels_All().Where(x => x.PageId == user[0].PageId && x.SecurityLevelID== user[0].SecurityLevelID).ToList();
                    Session["Securitylevel"] = Securitylevel;
                    Session["UserId"] = user[0].UserID;
                    //ViewBag.Securitylevel = Securitylevel;
                    // If the user came from a specific page, redirect back to it
                    return RedirectToAction("index", "home", new { area = "" });
                }

                // No existing user was found that matched the given criteria
                ModelState.AddModelError("", "Invalid username or password.");


            }
            // If a user was found
            //if (user != null)
            //{
            //    // Then create an identity for it and sign it in
            //    await SignInAsync(user, viewModel.RememberMe);

            //    // If the user came from a specific page, redirect back to it
            //    return RedirectToLocal(viewModel.ReturnUrl);
            //}

            // No existing user was found that matched the given criteria
            ModelState.AddModelError("", "Invalid username or password.");

            // If we got this far, something failed, redisplay form
            return View(viewModel);
        }


    }
}