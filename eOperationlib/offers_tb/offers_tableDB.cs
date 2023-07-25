using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class offers_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "offers";

    public offers_tableDB()
    {
    }

    public int OnInsert(offers_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [offers]
                                   ( [offersPromocode], [offersPhoto], [offersDescription] ,[addedOn] )
                             VALUES
                                   ( @offersPromocode, @offersPhoto, @offersDescription, @addedOn)";

            OnClearParameter();
            AddParameter("@offersPromocode", SqlDbType.VarChar, 50, obj.OffersPromocode, ParameterDirection.Input);
            AddParameter("@offersPhoto", SqlDbType.VarChar, 500, obj.OffersPhoto, ParameterDirection.Input);
            AddParameter("@offersDescription", SqlDbType.VarChar, 1000, obj.OffersDescription, ParameterDirection.Input);
            AddParameter("@addedOn", SqlDbType.VarChar, 50, obj.AddedOn, ParameterDirection.Input);
            

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(offers_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [offers]
                             SET    [offersPromoCode]=@offersPromoCode,
                                    [offersPhoto]=@offersPhoto,
                                    [offersDescription]=@offersDescription
                         WHERE [offersIDPK]=@offersIDPK";
            OnClearParameter();
            AddParameter("@offersIDPK", SqlDbType.Int, 50, obj.OffersIDPK, ParameterDirection.Input);
            AddParameter("@offersPromoCode", SqlDbType.VarChar, 50, obj.OffersPromocode, ParameterDirection.Input);
            AddParameter("@offersPhoto", SqlDbType.VarChar, 500, obj.OffersPhoto, ParameterDirection.Input);
            AddParameter("@offersDescription", SqlDbType.VarChar, 1000, obj.OffersDescription, ParameterDirection.Input);

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
            strQ += @"UPDATE [offers]
                             SET
                             [isActive]=0
                         WHERE [offersIDPK]=@offersIDPK";

            OnClearParameter();
            AddParameter("@offersIDPK", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private offers_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            offers_tableEntities obj = new offers_tableEntities();

            obj.OffersIDPK = (drRow["offersIDPK"].Equals(DBNull.Value)) ? 0 : (int)drRow["offersIDPK"];
            obj.OffersPromocode = (drRow["offersPromocode"].Equals(DBNull.Value)) ? "" : (string)drRow["offersPromocode"];
            obj.OffersPhoto = (drRow["offersPhoto"].Equals(DBNull.Value)) ? "" : (string)drRow["offersPhoto"];
            obj.OffersDescription = (drRow["offersDescription"].Equals(DBNull.Value)) ? "" : (string)drRow["offersDescription"];
            obj.AddedOn = (drRow["offersDescription"].Equals(DBNull.Value)) ? "" : (string)drRow["offersDescription"];
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

        offers_tableEntities obj = new offers_tableEntities();

        int studId = 0;
        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('offers') ";

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

    public offers_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        offers_tableEntities obj = new offers_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [offers] 
                        WHERE [offersIDPK] = @offersIDPK  
                        and [isActive] = 1";

            OnClearParameter();
            AddParameter("@offersIDPK", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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

    public List<offers_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<offers_tableEntities> oList = new List<offers_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [offers]
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
            strQ = @"SELECT [offers].offersIDPK
                                   ,[offers].reviewName
                                    FROM [offers]
                                    WHERE [offers].isActive='1'";

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
                objData.ID = dtTable.Rows[intRow]["offersIDPK"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["offersIDPK"];
                objData.NAME = dtTable.Rows[intRow]["offersFName"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["offersFName"];
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
 