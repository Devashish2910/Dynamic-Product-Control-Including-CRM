using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;


public class Utils
{
    public const string UserName = "UserName";
    public const string Admin = "Admin";
    public const string Staff = "Staff";

    public static string CurrentLoggedInUser()
    {
        return Convert.ToString(((UserObject)(HttpContext.Current.Session["UserObject"])).UserName);
    }
    public static UserObject CurrentUser()
    {
        return (UserObject)(HttpContext.Current.Session["UserObject"]);
    }
    public static bool IsLoggedIn()
    {

        if (HttpContext.Current.Session.Count == 0)
        {
            return false;
        }
        if (string.IsNullOrEmpty(CurrentLoggedInUser()))
        {
            return false;
        }
        else { return true; }
    }
    public static void Login(string UserName, string Password)
    {

        Clsconnection cls = new Clsconnection();
        DataTable dtUser = new DataTable();

        dtUser = cls.ReturnDataTable("Login_UserLogin", new SqlParameter("@UserName", UserName), new SqlParameter("@Pwd", Password));
        UserObject usr = new UserObject((Guid)dtUser.Rows[0]["UserID"], dtUser.Rows[0]["UserName"].ToString());

        HttpContext.Current.Session["UserObject"] = usr;
    }

    public static void LogOut()
    {
        HttpContext.Current.Session.Abandon();
        HttpContext.Current.Response.Redirect("../admin/Default.aspx");
    }
}

[Serializable()]
public class UserObject
{

    #region "Public Properties"

    private Guid _userID = Guid.Empty;
    /// <summary>
    /// Gets the UserId value
    /// </summary>
    public Guid UserID
    {
        get { return _userID; }
    }
    private string _userName = string.Empty;
    /// <summary>
    /// Gets the Value value
    /// </summary>
    public string UserName
    {
        get { return _userName; }
    }
    #endregion

    #region "Constructors"

    public UserObject(Guid UserID, string UserName)
    {
        _userID = UserID;
        _userName = UserName;
    }

    public UserObject()
    {
    }
    #endregion
}
