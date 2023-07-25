using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Security;
using System.Web.SessionState;


//namespace IndentSystem
//{
public class clsDB_Config : System.Web.UI.Page
{
    private string mstrModuleName = "clsDB_Config";
    private clsConfigProperty objConfigProperty = new clsConfigProperty();
    private string mstrConnectionString;
    private string objText = "";
    private SqlConnection objConnection;

    public SqlConnection _HRSqlConnection
    {
        get
        {
            return objConnection;
        }
        set
        {
            objConnection = value;
        }
    }
    public void DatabadeConnection()
    {

        objConnection = new SqlConnection();
        objConnection.ConnectionString = (string)Session["Connection_String"];//clsDB_Config._ConnectionString;
        objConnection.Open();


    }
    public clsConfigProperty _ConfigProperty
    {
        get { return objConfigProperty; }
        set { objConfigProperty = value; }
    }

    public string _ConnectionString
    {
        get
        {
            return mstrConnectionString;
        }
        set
        {
            mstrConnectionString = value;
            //OpenConnection();
        }
    }
    public string BuildConnectionString()
    {
        try
        {
            objText = String.Format(@"Data Source=DESKTOP-L3I2L0U\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return objText;
    }
}
//}