using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class user_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "user";
    public user_tableDB()
    {
    }
    public user_tableEntities OnGetDatabyemail(string email)
    {
        Exception exForce;
        DataTable dtTable;

        user_tableEntities obj = new user_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [user] WHERE [email] = @email and [isActive] = 1";

            OnClearParameter();
            AddParameter("@email", SqlDbType.VarChar, 50, email, ParameterDirection.Input);

            //DB_Config.OnStartConnection();
            dtTable = OnExecQuery(strQ, "list").Tables[0];


            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }


            if (dtTable.Rows.Count != 0)
            {
                obj = BuildEntities(dtTable.Rows[0]);
            }

            return obj;

        }
        catch (Exception ex)
        {
            throw ex;
            return obj;
        }
    }
    public user_tableEntities LoginData(string email, string password)
    {
        Exception exForce;
        DataTable dtTable;

        user_tableEntities obj = new user_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT * FROM [user] WHERE [email] = @email and [password] = @password";

            OnClearParameter();
            AddParameter("@email", SqlDbType.VarChar, 50, email, ParameterDirection.Input);
            AddParameter("@password", SqlDbType.VarChar, 50, password, ParameterDirection.Input);

            //DB_Config.OnStartConnection();
            dtTable = OnExecQuery(strQ, "list").Tables[0];


            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }


            if (dtTable.Rows.Count != 0)
            {
                obj = BuildEntities(dtTable.Rows[0]);
            }

            return obj;

        }
        catch (Exception ex)
        {
            throw ex;
            return obj;
        }
    }
    public int OnInsert(user_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [user]
                                   ( [userName], [email], [password] ,[contactNo],[userType],[addedOn] )
                             VALUES
                                   ( @userName, @email, @password, @contactNo,@userType,@addedOn)";

            OnClearParameter();
            AddParameter("@userName", SqlDbType.VarChar, 50, obj.UserName, ParameterDirection.Input);
            AddParameter("@email", SqlDbType.VarChar, 50, obj.Email, ParameterDirection.Input);
            AddParameter("@password", SqlDbType.VarChar, 50, obj.Password, ParameterDirection.Input);
            AddParameter("@contactNo", SqlDbType.VarChar, 50, obj.ContactNo, ParameterDirection.Input);
            AddParameter("@userType", SqlDbType.VarChar, 50, obj.UserType, ParameterDirection.Input);
            AddParameter("@addedOn", SqlDbType.VarChar, 50, obj.AddedOn, ParameterDirection.Input);
            

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(user_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [user]
                             SET    [userName]=@userName,
                                    [email]=@email,
                                    [password]=@password,
                                    [contactNo]=@contactNo,
                                    [userType]=@userType
                         WHERE [userIDPK]=@userIDPK";
            OnClearParameter();
            AddParameter("@userIDPK", SqlDbType.Int, 50, obj.UserIdPk, ParameterDirection.Input);
            AddParameter("@userName", SqlDbType.VarChar, 50, obj.UserName, ParameterDirection.Input);
            AddParameter("@email", SqlDbType.VarChar, 50, obj.Email, ParameterDirection.Input);
            AddParameter("@password", SqlDbType.VarChar, 50, obj.Password, ParameterDirection.Input);
            AddParameter("@contactNo", SqlDbType.VarChar, 50, obj.ContactNo, ParameterDirection.Input);
            AddParameter("@userType", SqlDbType.VarChar, 50, obj.UserType, ParameterDirection.Input);
            return OnExecNonQuery(strQ);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int OnDelete(int ID)
    {
        string strQ = "";
        try
        {
            strQ += @"UPDATE [user]
                             SET
                             [isActive]=0
                         WHERE [userIDPK]=@userIDPK";

            OnClearParameter();
            AddParameter("@userIDPK", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private user_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            user_tableEntities obj = new user_tableEntities();

            obj.UserIdPk = (drRow["userIDPK"].Equals(DBNull.Value)) ? 0 : (int)drRow["userIDPK"];
            obj.UserName = (drRow["userName"].Equals(DBNull.Value)) ? "" : (string)drRow["userName"];
            obj.Email = (drRow["email"].Equals(DBNull.Value)) ? "" : (string)drRow["email"];
            obj.Password= (drRow["password"].Equals(DBNull.Value)) ? "" : (string)drRow["password"];
            obj.UserType = (drRow["userType"].Equals(DBNull.Value)) ? "" : (string)drRow["userType"];
            obj.ContactNo = (drRow["contactNo"].Equals(DBNull.Value)) ? "" : (string)drRow["contactNo"];
            obj.AddedOn = (drRow["contactNo"].Equals(DBNull.Value)) ? "" : (string)drRow["contactNo"];
            obj.IsActive = (drRow["isActive"].Equals(DBNull.Value)) ? 0 : Int32.Parse(drRow["isActive"].ToString());



            //if (DateTime.TryParseExact((string)drRow["addon"], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtdata))
            //{
            //    obj.Addon = dtdata;
            //}

            //if (DateTime.TryParseExact((string)drRow["modifyon"], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtdata))
            //{
            //    obj.Modifyon = dtdata;
            //}

            return obj;
        }
        catch (Exception ex)
        {
            throw ex;
            return null;
        }
    }

    public int OnLastRecordInserted()
    {
        Exception exForce;
        DataTable dtTable;

        user_tableEntities obj = new user_tableEntities();

        int studId = 0;
        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('user') ";

            OnClearParameter();

            //DB_Config.OnStartConnection();
            dtTable = OnExecQuery(strQ, "list").Tables[0];


            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }


            if (dtTable.Rows.Count != 0)
            {
                studId = Int32.Parse(dtTable.Rows[0].ItemArray[0].ToString());
            }

            return studId;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public user_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        user_tableEntities obj = new user_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [user] 
                        WHERE [userIDPK] = @userIDPK  
                        and [isActive] = 1";

            OnClearParameter();
            AddParameter("@userIDPK", SqlDbType.Int, 2, ID, ParameterDirection.Input);

            //DB_Config.OnStartConnection();
            dtTable = OnExecQuery(strQ, "list").Tables[0];


            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }


            if (dtTable.Rows.Count != 0)
            {
                obj = BuildEntities(dtTable.Rows[0]);
            }

            return obj;

        }
        catch (Exception ex)
        {
            throw ex;
            return obj;
        }
    }

    public List<user_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<user_tableEntities> oList = new List<user_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [user]
                        WHERE isActive = 1";
            OnClearParameter();

            dtTable = OnExecQuery(strQ, "list").Tables[0];



            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }
            int intRow = 0;
            while (intRow < dtTable.Rows.Count)
            {
                oList.Add(BuildEntities(dtTable.Rows[intRow]));
                intRow = intRow + 1;
            }
            return oList;
        }
        catch (Exception ex)
        {
            throw ex;
            return null;
        }
        finally
        {
            //    DB_Config.OnStopConnection();
        }
    }
    public List<ComboboxItem> OnGetListForCombo()
    {
        Exception exForce;
        DataTable dtTable;

        List<ComboboxItem> oList = new List<ComboboxItem>();

        string strQ = "";

        try
        {

            OnClearParameter();
            strQ = @"SELECT [user].userIDPK
                                   ,[user].userName
                                    FROM [user]
                                    WHERE [user].isActive='1'";

            dtTable = OnExecQuery(strQ, "list").Tables[0];

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                exForce = new Exception(ErrorNumber + ": " + ErrorMessage);
                throw exForce;
            }

            int intRow = 0;
            while (intRow < dtTable.Rows.Count)
            {
                ComboboxItem objData = new ComboboxItem();
                objData.ID = dtTable.Rows[intRow]["userIDPK"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["userIDPK"];
                objData.NAME = dtTable.Rows[intRow]["userFName"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["userFName"];
                oList.Add(objData);

                intRow = intRow + 1;
            }
            return oList;
        }
        catch (Exception ex)
        {
            throw ex;
            return oList;
        }
    }
}
