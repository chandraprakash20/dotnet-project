using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class review_tableEntities
{
    private int reviewIDPK = 0;
    private string reviewName = "";
    private string reviewEmail = "";
    private string reviewFeedBack = "";
    private string reviewServices = "";
    private string reviewLocation = "";
    private string reviewFacilities = "";
    private string addedOn = "";
    private int isActive = 0;

    public int ReviewIDPK { get => reviewIDPK; set => reviewIDPK = value; }
    public string ReviewName { get => reviewName; set => reviewName = value; }
    public string ReviewEmail { get => reviewEmail; set => reviewEmail = value; }
    public string ReviewFeedBack { get => reviewFeedBack; set => reviewFeedBack = value; }
    public string ReviewServices { get => reviewServices; set => reviewServices = value; }
    public string ReviewLocation { get => reviewLocation; set => reviewLocation = value; }
    public string ReviewFacilities { get => reviewFacilities; set => reviewFacilities = value; }
    public string AddedOn { get => addedOn; set => addedOn = value; }
    public int IsActive { get => isActive; set => isActive = value; }
}
