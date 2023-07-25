using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class faq_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "faq";

    public faq_tableDB()
    {
    }

    public int OnInsert(faq_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [faq]
                                   ( [faqQuestions], [faqAnswers],[addedOn] )
                             VALUES
                                   ( @faqQuestions, @faqAnswers, @addedOn)";

            OnClearParameter();
            AddParameter("@faqQuestions", SqlDbType.VarChar, 500, obj.FaqQuestions, ParameterDirection.Input);
            AddParameter("@faqAnswers", SqlDbType.VarChar, 500, obj.FaqAnswers, ParameterDirection.Input);
            AddParameter("@addedOn", SqlDbType.VarChar, 50, obj.AddedOn, ParameterDirection.Input);
            

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(faq_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [faq]
                             SET    [faqQuestions]=@faqQuestions,
                                    [faqAnswers]=@faqAnswers
                                    
                         WHERE [faqIDPK]=@faqIDPK";
            OnClearParameter();
            AddParameter("@faqIDPK", SqlDbType.Int, 50, obj.FaqIDPK, ParameterDirection.Input);
            AddParameter("@faqQuestions", SqlDbType.VarChar, 500, obj.FaqQuestions, ParameterDirection.Input);
            AddParameter("@faqAnswers", SqlDbType.VarChar, 500, obj.FaqAnswers, ParameterDirection.Input);
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
            strQ += @"UPDATE [faq]
                             SET
                             [isActive]=0
                         WHERE [faqIDPK]=@faqIDPK";

            OnClearParameter();
            AddParameter("@faqIDPK", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private faq_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            faq_tableEntities obj = new faq_tableEntities();

            obj.FaqIDPK = (drRow["faqIDPK"].Equals(DBNull.Value)) ? 0 : (int)drRow["faqIDPK"];
            obj.FaqQuestions = (drRow["faqQuestions"].Equals(DBNull.Value)) ? "" : (string)drRow["faqQuestions"];
            obj.FaqAnswers = (drRow["faqAnswers"].Equals(DBNull.Value)) ? "" : (string)drRow["faqAnswers"];
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

        faq_tableEntities obj = new faq_tableEntities();

        int studId = 0;
        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('faq') ";

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

    public faq_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        faq_tableEntities obj = new faq_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [faq] 
                        WHERE [faqIDPK] = @faqIDPK  
                        and [isActive] = 1";

            OnClearParameter();
            AddParameter("@faqIDPK", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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

    public List<faq_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<faq_tableEntities> oList = new List<faq_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [faq]
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
            strQ = @"SELECT [faq].faqIDPK
                                   ,[faq].faqQuestions
                                    FROM [faq]
                                    WHERE [faq].isActive='1'";

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
                objData.ID = dtTable.Rows[intRow]["faqIDPK"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["faqIDPK"];
                objData.NAME = dtTable.Rows[intRow]["faqQuestions"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["faqQuestions"];
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
