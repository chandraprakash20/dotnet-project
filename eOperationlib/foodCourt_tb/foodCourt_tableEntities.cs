using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class foodCourt_tableEntities
{
    private int foodCourtIDPK = 0;
    private string foodCourtName = "";
    private string foodCourtImage = "";
    private string foodCourtDescription = "";
    private string addedOn = "";
    private int isActive = 0;

    public int FoodCourtIDPK { get => foodCourtIDPK; set => foodCourtIDPK = value; }
    public string FoodCourtName { get => foodCourtName; set => foodCourtName = value; }
    public string FoodCourtImage { get => foodCourtImage; set => foodCourtImage = value; }
    public string FoodCourtDescription { get => foodCourtDescription; set => foodCourtDescription = value; }
    public string AddedOn { get => addedOn; set => addedOn = value; }
    public int IsActive { get => isActive; set => isActive = value; }
}

    