using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class event_tableEntities
{
    private int eventIDPK = 0;
    private string eventName = "";
    private string eventDescription = "";
    private string eventImage = "";
    private string eventCharges = "";
    private string addedOn = "";
    private int isActive = 0;

    public int EventIDPK { get => eventIDPK; set => eventIDPK = value; }
    public string EventName { get => eventName; set => eventName = value; }
    public string EventDescription { get => eventDescription; set => eventDescription = value; }
    public string EventImage { get => eventImage; set => eventImage = value; }
    public string EventCharges { get => eventCharges; set => eventCharges = value; }
    public string AddedOn { get => addedOn; set => addedOn = value; }
    public int IsActive { get => isActive; set => isActive = value; }
}
