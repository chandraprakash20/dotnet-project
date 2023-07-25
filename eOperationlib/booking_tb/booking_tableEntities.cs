using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class booking_tableEntities
{
    private int userIDFK = 0;
    private int packageIDFK = 0; 
    private int bookingIDPK = 0;
    private string bookingName = "";
    private string bookingType = "";
    private string includeEvent = "";
    private string includeFoodCourt = "";
    private string includeDecorations = "";
    private string includeRooms = "";
    private string noOfPeoples = "";
    private string eventDate = "";
    private string eventTime = "";
    private string bookingCharges = "";
    private string bookingStatus = "";
    private string userName = "";
    private string packageName = "";
    private string addedOn = "";
    private int isActive = 0;

    public int UserIDFK { get => userIDFK; set => userIDFK = value; }
    public int BookingIDPK { get => bookingIDPK; set => bookingIDPK = value; }
    public string BookingName { get => bookingName; set => bookingName = value; }
    public string BookingType { get => bookingType; set => bookingType = value; }
    public string IncludeEvent { get => includeEvent; set => includeEvent = value; }
    public string IncludeFoodCourt { get => includeFoodCourt; set => includeFoodCourt = value; }
    public string IncludeDecorations { get => includeDecorations; set => includeDecorations = value; }
    public string IncludeRooms { get => includeRooms; set => includeRooms = value; }
    public string NoOfPeoples { get => noOfPeoples; set => noOfPeoples = value; }
    public string EventDate { get => eventDate; set => eventDate = value; }
    public string EventTime { get => eventTime; set => eventTime = value; }
    public string BookingCharges { get => bookingCharges; set => bookingCharges = value; }
    public string BookingStatus { get => bookingStatus; set => bookingStatus = value; }
    public string AddedOn { get => addedOn; set => addedOn = value; }
    public int IsActive { get => isActive; set => isActive = value; }
    public string UserName { get => userName; set => userName = value; }
    public int PackageIDFK { get => packageIDFK; set => packageIDFK = value; }
    public string PackageName { get => packageName; set => packageName = value; }
}
