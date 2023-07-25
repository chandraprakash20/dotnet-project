using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class offers_tableEntities
{
    private int offersIDPK = 0;
    private string offersPromocode = "";
    private string offersPhoto = "";
    private string offersDescription = "";
    private string addedOn = "";
    private int isActive = 0;

    public int OffersIDPK { get => offersIDPK; set => offersIDPK = value; }
    public string OffersPromocode { get => offersPromocode; set => offersPromocode = value; }
    public string OffersPhoto { get => offersPhoto; set => offersPhoto = value; }
    public string OffersDescription { get => offersDescription; set => offersDescription = value; }
    public string AddedOn { get => addedOn; set => addedOn = value; }
    public int IsActive { get => isActive; set => isActive = value; }
}
