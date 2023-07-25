using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class inquiry_tableEntities
{
    private int inquiryIDPK = 0;
    private int packageNameIDFK = 0;
    private string inquiryName = "";
    private string inquiryEmail = "";
    private string inquiryCity = "";
    private string inquiryContactNo = "";
    private string inquiryDate = "";
    private string inquiryNoOfPeople = "";
    private string inquiryMessage = "";
    private string packageName = "";
    private string addedOn = "";
    private int isActive = 0;

    public int InquiryIDPK { get => inquiryIDPK; set => inquiryIDPK = value; }
    public int PackageNameIDFK { get => packageNameIDFK; set => packageNameIDFK = value; }
    public string InquiryName { get => inquiryName; set => inquiryName = value; }
    public string InquiryEmail { get => inquiryEmail; set => inquiryEmail = value; }
    public string InquiryCity { get => inquiryCity; set => inquiryCity = value; }
    public string InquiryContactNo { get => inquiryContactNo; set => inquiryContactNo = value; }
    public string InquiryDate { get => inquiryDate; set => inquiryDate = value; }
    public string InquiryNoOfPeople { get => inquiryNoOfPeople; set => inquiryNoOfPeople = value; }
    public string InquiryMessage { get => inquiryMessage; set => inquiryMessage = value; }
    public string AddedOn { get => addedOn; set => addedOn = value; }
    public int IsActive { get => isActive; set => isActive = value; }
    public string PackageName { get => packageName; set => packageName = value; }
}
