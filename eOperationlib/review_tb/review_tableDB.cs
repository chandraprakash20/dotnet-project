using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class review_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "review";

    public review_tableDB()
    {
    }

    public int OnInsert(review_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [review]
                                   ( [reviewName], [reviewEmail], [reviewFeedBack] ,[reviewServices] ,[reviewLocation] ,[reviewFacilities] ,[addedOn] )
                             VALUES
                                   ( @reviewName, @reviewEmail, @reviewFeedBack, @reviewServices, @reviewLocation, @reviewFacilities, @addedOn)";

            OnClearParameter();
            AddParameter("@reviewName", SqlDbType.VarChar, 50, obj.ReviewName, ParameterDirection.Input);
            AddParameter("@reviewEmail", SqlDbType.VarChar, 50, obj.ReviewEmail, ParameterDirection.Input);
            AddParameter("@reviewFeedBack", SqlDbType.VarChar, 500, obj.ReviewFeedBack, ParameterDirection.Input);
            AddParameter("@reviewServices", SqlDbType.VarChar, 500, obj.ReviewServices, ParameterDirection.Input);
            AddParameter("@reviewLocation", SqlDbType.VarChar, 500, obj.ReviewLocation, ParameterDirection.Input);
            AddParameter("@reviewFacilities", SqlDbType.VarChar, 500, obj.ReviewFacilities, ParameterDirection.Input);
            AddParameter("@addedOn", SqlDbType.VarChar, 50, obj.AddedOn, ParameterDirection.Input);
            

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(review_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [review]
                             SET    [reviewName]=@reviewName,
                                    [reviewEmail]=@reviewEmail,
                                    [reviewFeedback]=@reviewFeedBack,
                                    [reviewServices]=@reviewServices,
                                    [reviewLocation]=@reviewLocation,
                                    [reviewFacilities]=@reviewFacilities
                         WHERE [reviewIDPK]=@reviewIDPK";
            OnClearParameter();
            AddParameter("@reviewIDPK", SqlDbType.Int, 50, obj.ReviewIDPK, ParameterDirection.Input);
            AddParameter("@reviewName", SqlDbType.VarChar, 50, obj.ReviewName, ParameterDirection.Input);
            AddParameter("@reviewEmail", SqlDbType.VarChar, 50, obj.ReviewEmail, ParameterDirection.Input);
            AddParameter("@reviewFeedBack", SqlDbType.VarChar, 500, obj.ReviewFeedBack, ParameterDirection.Input);
            AddParameter("@reviewServices", SqlDbType.VarChar, 500, obj.ReviewServices, ParameterDirection.Input);
            AddParameter("@reviewLocation", SqlDbType.VarChar, 500, obj.ReviewLocation, ParameterDirection.Input);
            AddParameter("@reviewFacilities", SqlDbType.VarChar, 500, obj.ReviewFacilities, ParameterDirection.Input);

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
            strQ += @"UPDATE [review]
                             SET
                             [isActive]=0
                         WHERE [reviewIDPK]=@reviewIDPK";

            OnClearParameter();
            AddParameter("@reviewIDPK", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private review_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            review_tableEntities obj = new review_tableEntities();

            obj.ReviewIDPK = (drRow["reviewIDPK"].Equals(DBNull.Value)) ? 0 : (int)drRow["reviewIDPK"];
            obj.ReviewName = (drRow["reviewName"].Equals(DBNull.Value)) ? "" : (string)drRow["reviewName"];
            obj.ReviewEmail = (drRow["reviewEmail"].Equals(DBNull.Value)) ? "" : (string)drRow["reviewEmail"];
            obj.ReviewFeedBack = (drRow["reviewFeedBack"].Equals(DBNull.Value)) ? "" : (string)drRow["reviewFeedBack"];
            obj.ReviewServices = (drRow["reviewServices"].Equals(DBNull.Value)) ? "" : (string)drRow["reviewServices"];
            obj.ReviewLocation= (drRow["reviewLocation"].Equals(DBNull.Value)) ? "" : (string)drRow["reviewLocation"];
            obj.ReviewFacilities = (drRow["reviewFacilities"].Equals(DBNull.Value)) ? "" : (string)drRow["reviewFacilities"];
            obj.AddedOn = (drRow["reviewFacilities"].Equals(DBNull.Value)) ? "" : (string)drRow["reviewFacilities"];
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

        review_tableEntities obj = new review_tableEntities();

        int studId = 0;
        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('review') ";

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

    public review_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        review_tableEntities obj = new review_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [review] 
                        WHERE [reviewIDPK] = @reviewIDPK  
                        and [isActive] = 1";

            OnClearParameter();
            AddParameter("@reviewIDPK", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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

    public List<review_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<review_tableEntities> oList = new List<review_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [review]
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
            strQ = @"SELECT [review].reviewIDPK
                                   ,[review].reviewName
                                    FROM [review]
                                    WHERE [review].isActive='1'";

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
                objData.ID = dtTable.Rows[intRow]["reviewIDPK"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["reviewIDPK"];
                objData.NAME = dtTable.Rows[intRow]["reviewFName"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["reviewFName"];
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
