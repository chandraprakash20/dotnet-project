using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using eCommanLib;

public class event_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "event";

    public event_tableDB()
    {
    }

    public int OnInsert(event_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [event]
                                   ( [eventName], [eventDescription], [eventImage] ,[eventCharges] ,[addedOn] )
                             VALUES
                                   ( @eventName, @eventDescription, @eventImage, @eventCharges, @addedOn)";

            OnClearParameter();
            AddParameter("@eventName", SqlDbType.VarChar, 50, obj.EventName, ParameterDirection.Input);
            AddParameter("@eventDescription", SqlDbType.VarChar, 1000, obj.EventDescription, ParameterDirection.Input);
            AddParameter("@eventImage", SqlDbType.VarChar, 500, obj.EventImage, ParameterDirection.Input);
            AddParameter("@eventCharges", SqlDbType.VarChar, 50, obj.EventCharges, ParameterDirection.Input);
            AddParameter("@addedOn", SqlDbType.VarChar, 50, obj.AddedOn, ParameterDirection.Input);
            

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(event_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [event]
                             SET    [eventName]=@eventName,
                                    [eventDescription]=@eventDescription,
                                    [eventImage]=@eventImage,
                                    [eventCharges]=@eventCharges
                         WHERE [eventIDPK]=@eventIDPK";
            OnClearParameter();
            AddParameter("@eventIDPK", SqlDbType.Int, 50, obj.EventIDPK, ParameterDirection.Input);
            AddParameter("@eventName", SqlDbType.VarChar, 50, obj.EventName, ParameterDirection.Input);
            AddParameter("@eventDescription", SqlDbType.VarChar, 1000, obj.EventDescription, ParameterDirection.Input);
            AddParameter("@eventImage", SqlDbType.VarChar, 500, obj.EventImage, ParameterDirection.Input);
            AddParameter("@eventCharges", SqlDbType.VarChar, 50, obj.EventCharges, ParameterDirection.Input);

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
            strQ += @"UPDATE [event]
                             SET
                             [isActive]=0
                         WHERE [eventIDPK]=@eventIDPK";

            OnClearParameter();
            AddParameter("@eventIDPK", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private event_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            event_tableEntities obj = new event_tableEntities();

            obj.EventIDPK = (drRow["eventIDPK"].Equals(DBNull.Value)) ? 0 : (int)drRow["eventIDPK"];
            obj.EventName = (drRow["eventName"].Equals(DBNull.Value)) ? "" : (string)drRow["eventName"];
            obj.EventDescription = (drRow["eventDescription"].Equals(DBNull.Value)) ? "" : (string)drRow["eventDescription"];
            obj.EventImage = (drRow["eventImage"].Equals(DBNull.Value)) ? "" : (string)drRow["eventImage"];
            obj.EventCharges = (drRow["eventCharges"].Equals(DBNull.Value)) ? "" : (string)drRow["eventCharges"];
            obj.AddedOn = (drRow["eventCharges"].Equals(DBNull.Value)) ? "" : (string)drRow["eventCharges"];
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

        event_tableEntities obj = new event_tableEntities();

        int studId = 0;
        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('event') ";

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

    public event_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        event_tableEntities obj = new event_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [event] 
                        WHERE [eventIDPK] = @eventIDPK  
                        and [isActive] = 1";

            OnClearParameter();
            AddParameter("@eventIDPK", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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

    public List<event_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<event_tableEntities> oList = new List<event_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT *
                        FROM [event]
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
            strQ = @"SELECT [event].eventIDPK
                                   ,[event].eventName
                                    FROM [event]
                                    WHERE [event].isActive='1'";

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
                objData.ID = dtTable.Rows[intRow]["eventIDPK"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["eventIDPK"];
                objData.NAME = dtTable.Rows[intRow]["eventFName"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["eventFName"];
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
