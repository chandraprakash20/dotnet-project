using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class gallery_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "gallery";

    public gallery_tableDB()
    {
    }

    public int OnInsert(gallery_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [gallery]
                                   ( [galleryImage] ,[addedOn] )
                             VALUES
                                   ( @galleryImage, @addedOn)";

            OnClearParameter();
            AddParameter("@galleryImage", SqlDbType.VarChar, 500, obj.GalleryImage, ParameterDirection.Input);
            AddParameter("@addedOn", SqlDbType.VarChar, 50, obj.AddedOn, ParameterDirection.Input);
            

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(gallery_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [gallery]
                             SET    [galleryImage]=@galleryImage
                                 
                         WHERE [galleryIDPK]=@galleryIDPK";
            OnClearParameter();
            AddParameter("@galleryIDPK", SqlDbType.Int, 50, obj.GalleryIDPK, ParameterDirection.Input);
            AddParameter("@galleryImage", SqlDbType.VarChar, 500, obj.GalleryImage, ParameterDirection.Input);
           
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
            strQ += @"UPDATE [gallery]
                             SET
                             [isActive]=0
                         WHERE [galleryIDPK]=@galleryIDPK";

            OnClearParameter();
            AddParameter("@galleryIDPK", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private gallery_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            gallery_tableEntities obj = new gallery_tableEntities();

            obj.GalleryIDPK = (drRow["galleryIDPK"].Equals(DBNull.Value)) ? 0 : (int)drRow["galleryIDPK"];
            obj.GalleryImage = (drRow["galleryImage"].Equals(DBNull.Value)) ? "" : (string)drRow["galleryImage"];
            obj.AddedOn = (drRow["galleryImage"].Equals(DBNull.Value)) ? "" : (string)drRow["galleryImage"];
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

        gallery_tableEntities obj = new gallery_tableEntities();

        int studId = 0;
        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('gallery') ";

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

    public gallery_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        gallery_tableEntities obj = new gallery_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [gallery] 
                        WHERE [galleryIDPK] = @galleryIDPK  
                        and [isActive] = 1";

            OnClearParameter();
            AddParameter("@galleryIDPK", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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

    public List<gallery_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<gallery_tableEntities> oList = new List<gallery_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [gallery]
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
            strQ = @"SELECT [gallery].galleryIDPK
                                   ,[gallery].galleryImage
                                    FROM [gallery]
                                    WHERE [gallery].isActive='1'";

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
                objData.ID = dtTable.Rows[intRow]["galleryIDPK"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["galleryIDPK"];
                objData.NAME = dtTable.Rows[intRow]["galleryFName"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["galleryFName"];
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
