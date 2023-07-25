using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class inquiry_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "inquiry";

    public inquiry_tableDB()
    {
    }

    public int OnInsert(inquiry_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [inquiry]
                                   ( [packageNameIDFK], [inquiryName], [inquiryEmail] ,[inquiryCity] ,[inquiryContactNo] ,[inquiryDate] ,[inquiryNoOfPeople] ,[inquiryMessage] ,[addedOn] )
                             VALUES
                                   ( @packageNameIDFK, @inquiryName, @inquiryEmail, @inquiryCity, @inquiryContactNo, @inquiryDate, @inquiryNoOfPeople, @inquiryMessage, @addedOn)";

            OnClearParameter();
            AddParameter("@packageNameIDFK", SqlDbType.VarChar, 50, obj.PackageNameIDFK, ParameterDirection.Input);
            AddParameter("@inquiryName", SqlDbType.VarChar, 50, obj.InquiryName, ParameterDirection.Input);
            AddParameter("@inquiryEmail", SqlDbType.VarChar, 50, obj.InquiryEmail, ParameterDirection.Input);
            AddParameter("@inquiryCity", SqlDbType.VarChar, 50, obj.InquiryCity, ParameterDirection.Input);
            AddParameter("@inquiryContactNo", SqlDbType.VarChar, 50, obj.InquiryContactNo, ParameterDirection.Input);
            AddParameter("@inquiryDate", SqlDbType.VarChar, 50, obj.InquiryDate, ParameterDirection.Input);
            AddParameter("@inquiryNoOfPeople", SqlDbType.VarChar, 50, obj.InquiryNoOfPeople, ParameterDirection.Input);
            AddParameter("@inquiryMessage", SqlDbType.VarChar, 500, obj.InquiryMessage, ParameterDirection.Input);
            AddParameter("@addedOn", SqlDbType.VarChar, 50, obj.AddedOn, ParameterDirection.Input);
            

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(inquiry_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [inquiry]
                             SET    [packageNameIDFK]=@packageNameIDFK,
                                    [inquiryName]=@inquiryName,
                                    [inquiryEmail]=@inquiryEmail,
                                    [inquiryCity]=@inquiryCity,
                                    [inquiryContactNo]=@inquiryContactNo,
                                    [inquiryDate]=@inquiryDate,
                                    [inquiryNoOfPeople]=@inquiryNoOfPeople,
                                    [inquiryMessage]=@inquiryMessage
                         WHERE [inquiryIDPK]=@inquiryIDPK";
            OnClearParameter();
            AddParameter("@inquiryIDPK", SqlDbType.Int, 50, obj.InquiryIDPK, ParameterDirection.Input);
            AddParameter("@packageNameIDFK", SqlDbType.Int, 50, obj.PackageNameIDFK, ParameterDirection.Input);
            AddParameter("@inquiryName", SqlDbType.VarChar, 50, obj.InquiryName, ParameterDirection.Input);
            AddParameter("@inquiryEmail", SqlDbType.VarChar, 50, obj.InquiryEmail, ParameterDirection.Input);
            AddParameter("@inquiryCity", SqlDbType.VarChar, 50, obj.InquiryCity, ParameterDirection.Input);
            AddParameter("@inquiryContactNo", SqlDbType.VarChar, 50, obj.InquiryContactNo, ParameterDirection.Input);
            AddParameter("@inquiryDate", SqlDbType.VarChar, 50, obj.InquiryDate, ParameterDirection.Input);
            AddParameter("@inquiryNoOfPeople", SqlDbType.VarChar, 50, obj.InquiryNoOfPeople, ParameterDirection.Input);
            AddParameter("@inquiryMessage", SqlDbType.VarChar, 500, obj.InquiryMessage, ParameterDirection.Input);

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
            strQ += @"UPDATE [inquiry]
                             SET
                             [isActive]=0
                         WHERE [inquiryIDPK]=@inquiryIDPK";

            OnClearParameter();
            AddParameter("@inquiryIDPK", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private inquiry_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            inquiry_tableEntities obj = new inquiry_tableEntities();

            obj.InquiryIDPK = (drRow["inquiryIDPK"].Equals(DBNull.Value)) ? 0 : (int)drRow["inquiryIDPK"];
            obj.PackageNameIDFK = (drRow["packageNameIDFK"].Equals(DBNull.Value)) ? 0 : (int)drRow["packageNameIDFK"];
            obj.InquiryName = (drRow["inquiryName"].Equals(DBNull.Value)) ? "" : (string)drRow["inquiryName"];
            obj.InquiryEmail = (drRow["inquiryEmail"].Equals(DBNull.Value)) ? "" : (string)drRow["inquiryEmail"];
            obj.InquiryCity = (drRow["inquiryCity"].Equals(DBNull.Value)) ? "" : (string)drRow["inquiryCity"];
            obj.InquiryContactNo = (drRow["inquiryContactNo"].Equals(DBNull.Value)) ? "" : (string)drRow["inquiryContactNo"];
            obj.InquiryDate = (drRow["inquiryDate"].Equals(DBNull.Value)) ? "" : (string)drRow["inquiryDate"];
            obj.PackageName = (drRow["packageName"].Equals(DBNull.Value)) ? "" : (string)drRow["packageName"];
            obj.InquiryNoOfPeople = (drRow["inquiryNoOfPeople"].Equals(DBNull.Value)) ? "" : (string)drRow["inquiryNoOfPeople"];
            obj.InquiryMessage = (drRow["inquiryMessage"].Equals(DBNull.Value)) ? "" : (string)drRow["inquiryMessage"];
            obj.AddedOn = (drRow["inquiryMessage"].Equals(DBNull.Value)) ? "" : (string)drRow["inquiryMessage"];
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

        inquiry_tableEntities obj = new inquiry_tableEntities();

        int studId = 0;
        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('inquiry') ";

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

    public inquiry_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        inquiry_tableEntities obj = new inquiry_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT i.*,p.packageName
                        FROM [inquiry] i
                        JOIN [package] p ON p.packageIDPK = i.packageNameIDFK
                        WHERE [inquiryIDPK] = @inquiryIDPK  
                        and i.isActive = 1";

            OnClearParameter();
            AddParameter("@inquiryIDPK", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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

    public List<inquiry_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<inquiry_tableEntities> oList = new List<inquiry_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT i.*,p.packageName
                        FROM [inquiry] i
                        JOIN [package] p ON p.packageIDPK = i.packageNameIDFK
                        WHERE i.isActive = 1";
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
            strQ = @"SELECT [inquiry].inquiryIDPK
                                   ,[inquiry].inquiryName
                                    FROM [inquiry]
                                    WHERE [inquiry].isActive='1'";

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
                objData.ID = dtTable.Rows[intRow]["inquiryIDPK"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["inquiryIDPK"];
                objData.NAME = dtTable.Rows[intRow]["inquiryFName"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["inquiryFName"];
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
