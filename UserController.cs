using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using CRUD_ASP.NET_App2.Models;

namespace CRUD_ASP.NET_App2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Home()
        {
            /*ViewBag.UserName = (String)Session["username"];*/

            ViewBag.User = (UserDetails)Session["user"];

            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id = 0)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=CRUD-ASP.NET-AP2-DB;Integrated Security=True;Pooling=False; MultipleActiveResultSets=true");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM User_Details WHERE userid = @UserId", con);
            cmd.Parameters.AddWithValue("@UserId", ((UserDetails)Session["user"]).UserId);

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            SqlCommand cmd2 = new SqlCommand("SELECT * FROM City_Details WHERE cityid = @CityId", con);
            cmd2.Parameters.AddWithValue("@CityId", (int)dr["usercity"]);

            SqlDataReader dr2 = cmd2.ExecuteReader();

            dr2.Read();

            try
            {
                return View(new UserDetails
                {
                    UserId = (int)dr["userid"],
                    UserLoginName = dr["userloginname"].ToString(),
                    UserFullName = dr["userfullname"].ToString(),
                    UserEmailId = dr["useremailid"].ToString(),
                    UserMobileNo = dr["usermobileno"].ToString(),
                    City = dr2["cityname"].ToString()
                });
               
            }
            catch
            {
                return RedirectToAction("Delete");
            }
            finally
            {
                dr.Close();
                dr2.Close();
                con.Close();
            }
           
        }

        // GET: User/Create
        public ActionResult Create()
        {
            List<SelectListItem> ls = new List<SelectListItem>();

            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=CRUD-ASP.NET-AP2-DB;Integrated Security=True;Pooling=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM City_Details", con);

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                    ls.Add(new SelectListItem{ Value = dr["cityid"].ToString(), Text = dr["cityname"].ToString() });

                UserDetails userObj = new UserDetails() { UserCity = ls };

                return View(userObj);
            }
            catch
            {
                return View();
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserDetails user)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=CRUD-ASP.NET-AP2-DB;Integrated Security=True;Pooling=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO User_Details(userid, userloginname, userpassword, userfullname, useremailid, usermobileno, usercity) VALUES(@UserId, @UserLoginName, @UserPassword, @UserFullName, @UserEmailid, @UserMobileNo, @UserCityNo)", con);

            cmd.Parameters.AddWithValue("@UserId", user.UserId);
            cmd.Parameters.AddWithValue("@UserLoginName", user.UserLoginName);
            cmd.Parameters.AddWithValue("@UserPassword", user.UserPassword);
            cmd.Parameters.AddWithValue("@UserFullName", user.UserFullName);
            cmd.Parameters.AddWithValue("@UserEmailId", user.UserEmailId);
            cmd.Parameters.AddWithValue("@UserMobileNo", user.UserMobileNo);
            cmd.Parameters.AddWithValue("@UserCityNo", user.UserCityNo);

            try
            {
                cmd.ExecuteNonQuery();

                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
            finally
            {
                con.Close();
            }
        }

        public ActionResult Login()
        {
            if (Request.Cookies["Chockochip"] != null)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=CRUD-ASP.NET-AP2-DB;Integrated Security=True;Pooling=False");
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM User_Details WHERE userloginname = @UserLoginName AND userpassword = @UserPassword", con);

                cmd.Parameters.AddWithValue("@UserLoginName", Request.Cookies["Chockochip"].Values["loginname"]);
                cmd.Parameters.AddWithValue("@UserPassword", Request.Cookies["Chockochip"].Values["password"]);

                SqlDataReader dr = cmd.ExecuteReader();

                try
                {
                    if (dr.Read())
                    {
                        Session["user"] = new UserDetails
                        {
                            UserId = (int)dr["userid"],
                            UserLoginName = dr["userloginname"].ToString()
                        };

                        return RedirectToAction("Home");
                    }
                    else
                        return RedirectToAction("Create");
                }
                catch
                {
                    return View();
                }
                finally
                {
                    dr.Close();
                    con.Close();
                }
            }
            else
            {
                UserDetails userObj = new UserDetails();

                return View(userObj);
            }
        }
                               
        [HttpPost]
        public ActionResult Login(UserDetails user)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=CRUD-ASP.NET-AP2-DB;Integrated Security=True;Pooling=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM User_Details WHERE userloginname = @UserLoginName AND userpassword = @UserPassword", con);

            cmd.Parameters.AddWithValue("@UserLoginName", user.UserLoginName);
            cmd.Parameters.AddWithValue("@UserPassword", user.UserPassword);

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read())
                {
                    Session["user"] = new UserDetails
                    {
                        UserId = (int)dr["userid"],
                        UserLoginName = dr["userloginname"].ToString()
                    };

                    /* Session["username"] = dr["userfullname"].ToString();*/

                    bool b = user.Remeberme;

                    if (user.Remeberme)
                    {
                        HttpCookie httpCookie = new HttpCookie("Chockochip");
                        httpCookie.Values["loginname"] = dr["userloginname"].ToString();
                        httpCookie.Values["password"] = dr["userpassword"].ToString();



                        Response.Cookies.Add(httpCookie);
                    }

                    return RedirectToAction("Home");
                }
                else
                    return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

            // GET: User/Edit/5
        public ActionResult Edit(int id = 0)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PartialLogout() 
        {
            return PartialView();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            if (Request.Cookies["Chockochip"] != null)
            {
                HttpCookie httpCookie = Request.Cookies["Chockochip"];
                httpCookie.Expires = DateTime.Now.AddSeconds(1);
                Response.Cookies.Add(httpCookie);
            }
            return RedirectToAction("Login");
        }
    }
}
