using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class foodCourt_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "foodCourt";

    public foodCourt_tableDB()
    {
    }

    public int OnInsert(foodCourt_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [foodCourt]
                                   ( [foodCourtName], [foodCourtImage], [foodCourtDescription] ,[addedOn] )
                             VALUES
                                   ( @foodCourtName, @foodCourtImage, @foodCourtDescription, @addedOn)";

            OnClearParameter();
            AddParameter("@foodCourtName", SqlDbType.VarChar, 50, obj.FoodCourtName, ParameterDirection.Input);
            AddParameter("@foodCourtImage", SqlDbType.VarChar, 500, obj.FoodCourtImage, ParameterDirection.Input);
            AddParameter("@foodCourtDescription", SqlDbType.VarChar, 1000, obj.FoodCourtDescription, ParameterDirection.Input);
            AddParameter("@addedOn", SqlDbType.VarChar, 50, obj.AddedOn, ParameterDirection.Input);
            

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(foodCourt_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [foodCourt]
                             SET    [foodCourtName]=@foodCourtName,
                                    [foodCourtImage]=@foodCourtImage,
                                    [foodCourtDescription]=@foodCourtDescription
                                    
                         WHERE [foodCourtIDPK]=@foodCourtIDPK";
            OnClearParameter();
            AddParameter("@foodCourtIDPK", SqlDbType.Int, 50, obj.FoodCourtIDPK, ParameterDirection.Input);
            AddParameter("@foodCourtName", SqlDbType.VarChar, 50, obj.FoodCourtName, ParameterDirection.Input);
            AddParameter("@foodCourtImage", SqlDbType.VarChar, 500, obj.FoodCourtImage, ParameterDirection.Input);
            AddParameter("@foodCourtDescription", SqlDbType.VarChar, 1000, obj.FoodCourtDescription, ParameterDirection.Input);
           
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
            strQ += @"UPDATE [foodCourt]
                             SET
                             [isActive]=0
                         WHERE [foodCourtIDPK]=@foodCourtIDPK";

            OnClearParameter();
            AddParameter("@foodCourtIDPK", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private foodCourt_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            foodCourt_tableEntities obj = new foodCourt_tableEntities();

            obj.FoodCourtIDPK = (drRow["foodCourtIDPK"].Equals(DBNull.Value)) ? 0 : (int)drRow["foodCourtIDPK"];
            obj.FoodCourtName = (drRow["foodCourtName"].Equals(DBNull.Value)) ? "" : (string)drRow["foodCourtName"];
            obj.FoodCourtImage = (drRow["foodCourtImage"].Equals(DBNull.Value)) ? "" : (string)drRow["foodCourtImage"];
            obj.FoodCourtDescription = (drRow["foodCourtDescription"].Equals(DBNull.Value)) ? "" : (string)drRow["foodCourtDescription"];
            obj.AddedOn = (drRow["foodCourtDescription"].Equals(DBNull.Value)) ? "" : (string)drRow["foodCourtDescription"];
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

        foodCourt_tableEntities obj = new foodCourt_tableEntities();

        int studId = 0;
        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('foodCourt') ";

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

    public foodCourt_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        foodCourt_tableEntities obj = new foodCourt_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [foodCourt] 
                        WHERE [foodCourtIDPK] = @foodCourtIDPK  
                        and [isActive] = 1";

            OnClearParameter();
            AddParameter("@foodCourtIDPK", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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

    public List<foodCourt_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<foodCourt_tableEntities> oList = new List<foodCourt_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [foodCourt]
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
            strQ = @"SELECT [foodCourt].foodCourtIDPK
                                   ,[foodCourt].foodCourtName
                                    FROM [foodCourt]
                                    WHERE [foodCourt].isActive='1'";

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
                objData.ID = dtTable.Rows[intRow]["foodCourtIDPK"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["foodCourtIDPK"];
                objData.NAME = dtTable.Rows[intRow]["foodCourtFName"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["foodCourtFName"];
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
