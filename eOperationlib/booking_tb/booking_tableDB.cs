using System;
using System.Collections.Generic;
using System.Data;

public class booking_tableDB : clsDB_Operation
{

    private const string mstrModuleName = "booking";

    public booking_tableDB()
    {
    }

    public int OnInsert(booking_tableEntities obj)
    {
        string strQ = "";
        try
        {
            strQ = @"INSERT INTO [booking]
                                   ( [userIDFK],[packageIDFK], [bookingName], [bookingType],[includeEvent] ,[includeFoodCourt] ,[includeDecorations] ,[includeRooms] ,[noOfPeoples] ,[eventDate] ,[eventTime] ,[bookingCharges] ,[bookingStatus] ,[addedOn] )
                             VALUES
                                   ( @userIDFK,@packageIDFK, @bookingName, @bookingType, @includeEvent, @includeFoodCourt,@includeDecorations,@includeRooms,@noOfPeoples,@eventDate,@eventTime,@bookingCharges,@bookingStatus, @addedOn)";

            OnClearParameter();
            AddParameter("@userIDFK", SqlDbType.Int, 50, obj.UserIDFK, ParameterDirection.Input);
            AddParameter("@packageIDFK", SqlDbType.Int, 50, obj.PackageIDFK, ParameterDirection.Input);
            AddParameter("@bookingName", SqlDbType.VarChar, 50, obj.BookingName, ParameterDirection.Input);
            AddParameter("@bookingType", SqlDbType.VarChar, 50, obj.BookingType, ParameterDirection.Input);
            AddParameter("@includeEvent", SqlDbType.VarChar, 50, obj.IncludeEvent, ParameterDirection.Input);
            AddParameter("@includeFoodCourt", SqlDbType.VarChar, 50, obj.IncludeFoodCourt, ParameterDirection.Input);
            AddParameter("@includeDecorations", SqlDbType.VarChar, 50, obj.IncludeDecorations, ParameterDirection.Input);
            AddParameter("@includeRooms", SqlDbType.VarChar, 50, obj.IncludeRooms, ParameterDirection.Input);
            AddParameter("@noOfPeoples", SqlDbType.VarChar, 50, obj.NoOfPeoples, ParameterDirection.Input);
            AddParameter("@eventDate", SqlDbType.VarChar, 50, obj.EventDate, ParameterDirection.Input);
            AddParameter("@eventTime", SqlDbType.VarChar, 50, obj.EventTime, ParameterDirection.Input);
            AddParameter("@bookingCharges", SqlDbType.VarChar, 50, obj.BookingCharges, ParameterDirection.Input);
            AddParameter("@bookingStatus", SqlDbType.VarChar, 50, obj.BookingStatus, ParameterDirection.Input);
            AddParameter("@addedOn", SqlDbType.VarChar, 50, obj.AddedOn, ParameterDirection.Input);

            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public int OnUpdate(booking_tableEntities obj)
    {
        string strQ = "";
        try
        {


            strQ = @"UPDATE [booking]
                             SET    [userIDFK]=@userIDFK,
                                    [packageIDFK]=@packageIDFK,
                                    [bookingName]=@bookingName,
                                    [bookingType]=@bookingType,
                                    [includeEvent]=@includeEvent,
                                    [includeFoodCourt]=@includeFoodCourt,
                                    [includeDecorations]=@includeDecorations,
                                    [includeRooms]=@includeRooms,
                                    [noOfPeoples]=@noOfPeoples,
                                    [eventDate]=@eventDate,
                                    [eventTime]=@eventTime,
                                    [bookingCharges]=@bookingCharges,
                                    [bookingStatus]=@bookingStatus
                         WHERE [bookingIDPK]=@bookingIDPK";
            OnClearParameter();
            AddParameter("@bookingIDPK", SqlDbType.Int, 50, obj.BookingIDPK, ParameterDirection.Input);
            AddParameter("@userIDFK", SqlDbType.Int, 50, obj.UserIDFK, ParameterDirection.Input);
            AddParameter("@packageIDFK", SqlDbType.Int, 50, obj.PackageIDFK, ParameterDirection.Input);
            AddParameter("@bookingName", SqlDbType.VarChar, 50, obj.BookingName, ParameterDirection.Input);
            AddParameter("@bookingType", SqlDbType.VarChar, 50, obj.BookingType, ParameterDirection.Input);
            AddParameter("@includeEvent", SqlDbType.VarChar, 50, obj.IncludeEvent, ParameterDirection.Input);
            AddParameter("@includeFoodCourt", SqlDbType.VarChar, 50, obj.IncludeFoodCourt, ParameterDirection.Input);
            AddParameter("@includeDecorations", SqlDbType.VarChar, 50, obj.IncludeDecorations, ParameterDirection.Input);
            AddParameter("@includeRooms", SqlDbType.VarChar, 50, obj.IncludeRooms, ParameterDirection.Input);
            AddParameter("@noOfPeoples", SqlDbType.VarChar, 50, obj.NoOfPeoples, ParameterDirection.Input);
            AddParameter("@eventDate", SqlDbType.VarChar, 50, obj.EventDate, ParameterDirection.Input);
            AddParameter("@eventTime", SqlDbType.VarChar, 50, obj.EventTime, ParameterDirection.Input);
            AddParameter("@bookingCharges", SqlDbType.VarChar, 50, obj.BookingCharges, ParameterDirection.Input);
            AddParameter("@bookingStatus", SqlDbType.VarChar, 50, obj.BookingStatus, ParameterDirection.Input);

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
            strQ += @"UPDATE [booking]
                             SET
                             [isActive]=0
                         WHERE [bookingIDPK]=@bookingIDPK";

            OnClearParameter();
            AddParameter("@bookingIDPK", SqlDbType.Int, 50, ID, ParameterDirection.Input);
            return OnExecNonQuery(strQ);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private booking_tableEntities BuildEntities(DataRow drRow)
    {

        try
        {
            //DateTime dtdata;
            booking_tableEntities obj = new booking_tableEntities();

            obj.BookingIDPK = (drRow["bookingIDPK"].Equals(DBNull.Value)) ? 0 : (int)drRow["bookingIDPK"];
            obj.UserIDFK = (drRow["userIDFK"].Equals(DBNull.Value)) ? 0 : (int)drRow["userIDFK"];
            obj.PackageIDFK = (drRow["packageIDFK"].Equals(DBNull.Value)) ? 0 : (int)drRow["packageIDFK"];
            obj.UserName = (drRow["userName"].Equals(DBNull.Value)) ? "" : (string)drRow["userName"];
            obj.PackageName = (drRow["packageName"].Equals(DBNull.Value)) ? "" : (string)drRow["packageName"];
            obj.BookingName = (drRow["bookingName"].Equals(DBNull.Value)) ? "" : (string)drRow["bookingName"];
            obj.BookingType = (drRow["bookingType"].Equals(DBNull.Value)) ? "" : (string)drRow["bookingType"];
            obj.IncludeEvent = (drRow["includeEvent"].Equals(DBNull.Value)) ? "" : (string)drRow["includeEvent"];
            obj.IncludeFoodCourt = (drRow["includeFoodCourt"].Equals(DBNull.Value)) ? "" : (string)drRow["includeFoodCourt"];
            obj.IncludeDecorations = (drRow["includeDecorations"].Equals(DBNull.Value)) ? "" : (string)drRow["includeDecorations"];
            obj.IncludeRooms = (drRow["includeRooms"].Equals(DBNull.Value)) ? "" : (string)drRow["includeRooms"];
            obj.NoOfPeoples = (drRow["noOfPeoples"].Equals(DBNull.Value)) ? "" : (string)drRow["noOfPeoples"];
            obj.EventDate = (drRow["eventDate"].Equals(DBNull.Value)) ? "" : (string)drRow["eventDate"];
            obj.EventTime = (drRow["eventTime"].Equals(DBNull.Value)) ? "" : (string)drRow["eventTime"];
            obj.BookingCharges = (drRow["bookingCharges"].Equals(DBNull.Value)) ? "" : (string)drRow["bookingCharges"];
            obj.BookingStatus = (drRow["bookingStatus"].Equals(DBNull.Value)) ? "" : (string)drRow["bookingStatus"];
            obj.AddedOn = (drRow["bookingStatus"].Equals(DBNull.Value)) ? "" : (string)drRow["bookingStatus"];
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

        booking_tableEntities obj = new booking_tableEntities();

        int studId = 0;
        string strQ = "";

        try
        {
            strQ = @"SELECT IDENT_CURRENT('booking') ";

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

    public booking_tableEntities OnGetData(int ID)
    {
        Exception exForce;
        DataTable dtTable;

        booking_tableEntities obj = new booking_tableEntities();

        string strQ = "";

        try
        {
            strQ = @"SELECT b.*,u.userName,p.packageName
                        FROM [booking] b
                        JOIN[user] u ON u.UserIdPk = b.userIDFK
                        JOIN[package] p ON p.packageIDPK = b.packageIDFK
                        WHERE [bookingIDPK] = @bookingIDPK  
                        and b.isActive = 1";

            OnClearParameter();
            AddParameter("@bookingIDPK", SqlDbType.Int, 2, ID, ParameterDirection.Input);

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

    public List<booking_tableEntities> OnGetListdt()
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<booking_tableEntities> oList = new List<booking_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT b.*,u.userName,p.packageName
                        FROM [booking] b
                        JOIN[package] p ON p.packageIDPK = b.packageIDFK
                        JOIN[user] u ON u.UserIdPk = b.userIDFK
                        WHERE   
                         b.isActive = 1";
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

    public List<booking_tableEntities> OnGetDataById(int userID)
    {
        Exception exForce;
        //IDataReader oReader;
        DataTable dtTable;
        List<booking_tableEntities> oList = new List<booking_tableEntities>();
        string strQ = "";

        try
        {
            strQ = @"SELECT b.*,u.userName,p.packageName
                        FROM [booking] b
                        JOIN[user] u ON u.UserIdPk = b.userIDFK
                        JOIN[package] p ON p.packageIDPK = b.packageIDFK
                        WHERE [userIDFK] = @userIDFK  
                        and b.isActive = 1";

            OnClearParameter();
            AddParameter("@userIDFK", SqlDbType.Int, 2, userID, ParameterDirection.Input);
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
            strQ = @"SELECT [booking].bookingIDPK
                                   ,[booking].bookingName
                                    FROM [booking]
                                    WHERE [booking].isActive='1'";

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
                objData.ID = dtTable.Rows[intRow]["bookingIDPK"].Equals(DBNull.Value) ? 0 : (int)dtTable.Rows[intRow]["bookingIDPK"];
                objData.NAME = dtTable.Rows[intRow]["bookingFName"].Equals(DBNull.Value) ? "" : (string)dtTable.Rows[intRow]["bookingFName"];
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
