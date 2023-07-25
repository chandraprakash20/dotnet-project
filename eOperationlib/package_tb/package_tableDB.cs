using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class package_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "package";

    public package_tableDB()
    {
    }

    public int OnInsert(package_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [package]
                                   ( [packageName], [packageDescription], [packageImage] ,[packageCharges] ,[addedOn] )
                             VALUES
                                   ( @packageName, @packageDescription, @packageImage, @packageCharges, @addedOn)";

            OnClearParameter();
            AddParameter("@packageName", SqlDbType.VarChar, 50, obj.PackageName, ParameterDirection.Input);
            AddParameter("@packageDescription", SqlDbType.VarChar, 1000, obj.PackageDescription, ParameterDirection.Input);
            AddParameter("@packageImage", SqlDbType.VarChar, 500, obj.PackageImage, ParameterDirection.Input);
            AddParameter("@packageCharges", SqlDbType.VarChar, 50, obj.PackageCharges, ParameterDirection.Input);
            AddParameter("@addedOn", SqlDbType.VarChar, 50, obj.AddedOn, ParameterDirection.Input);
            

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(package_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [package]
                             SET    [packageName]=@packageName,
                                    [packageDescription]=@packageDescription,
                                    [packageImage]=@packageImage,
                                    [packageCharges]=@packageCharges
                         WHERE [packageIDPK]=@packageIDPK";
            OnClearParameter();
            AddParameter("@packageIDPK", SqlDbType.Int, 50, obj.PackageIDPK, ParameterDirection.Input);
            AddParameter("@packageName", SqlDbType.VarChar, 50, obj.PackageName, ParameterDirection.Input);
            AddParameter("@packageDescription", SqlDbType.VarChar, 1000, obj.PackageDescription, ParameterDirection.Input);
            AddParameter("@packageImage", SqlDbType.VarChar, 500, obj.PackageImage, ParameterDirection.Input);
            AddParameter("@packageCharges", SqlDbType.VarChar, 50, obj.PackageCharges, ParameterDirection.Input);

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
            strQ += @"UPDATE [package]
                             SET
                             [isActive]=0
                         WHERE [packageIDPK]=@packageIDPK";

            OnClearParameter();
            AddParameter("@packageIDPK", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private package_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            package_tableEntities obj = new package_tableEntities();

            obj.PackageIDPK = (drRow["packageIDPK"].Equals(DBNull.Value)) ? 0 : (int)drRow["packageIDPK"];
            obj.PackageName = (drRow["packageName"].Equals(DBNull.Value)) ? "" : (string)drRow["packageName"];
            obj.PackageDescription = (drRow["packageDescription"].Equals(DBNull.Value)) ? "" : (string)drRow["packageDescription"];
            obj.PackageImage = (drRow["packageImage"].Equals(DBNull.Value)) ? "" : (string)drRow["packageImage"];
            obj.PackageCharges = (drRow["packageCharges"].Equals(DBNull.Value)) ? "" : (string)drRow["packageCharges"];
            obj.AddedOn = (drRow["packageCharges"].Equals(DBNull.Value)) ? "" : (string)drRow["packageCharges"];
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

        package_tableEntities obj = new package_tableEntities();

        int studId = 0;
        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('package') ";

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

    public package_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        package_tableEntities obj = new package_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [package] 
                        WHERE [packageIDPK] = @packageIDPK  
                        and [isActive] = 1";

            OnClearParameter();
            AddParameter("@packageIDPK", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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

    public List<package_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<package_tableEntities> oList = new List<package_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [package]
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
            strQ = @"SELECT [package].packageIDPK
                                   ,[package].packageName
                                    FROM [package]
                                    WHERE [package].isActive='1'";

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
                objData.ID = dtTable.Rows[intRow]["packageIDPK"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["packageIDPK"];
                objData.NAME = dtTable.Rows[intRow]["packageFName"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["packageFName"];
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
