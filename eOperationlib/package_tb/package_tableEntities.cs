using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class package_tableEntities
{
    private int packageIDPK = 0;
    private string packageName = "";
    private string packageDescription = "";
    private string packageImage = "";
    private string packageCharges = "";
    private string addedOn = "";
    private int isActive = 0;

    public int PackageIDPK { get => packageIDPK; set => packageIDPK = value; }
    public string PackageName { get => packageName; set => packageName = value; }
    public string PackageDescription { get => packageDescription; set => packageDescription = value; }
    public string PackageImage { get => packageImage; set => packageImage = value; }
    public string PackageCharges { get => packageCharges; set => packageCharges = value; }
    public string AddedOn { get => addedOn; set => addedOn = value; }
    public int IsActive { get => isActive; set => isActive = value; }
}
