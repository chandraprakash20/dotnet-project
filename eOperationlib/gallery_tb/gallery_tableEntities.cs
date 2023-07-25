using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class gallery_tableEntities
{
    private int galleryIDPK = 0;
    private string galleryImage = "";
    private string addedOn = "";
    private int isActive = 0;

    public int GalleryIDPK { get => galleryIDPK; set => galleryIDPK = value; }
    public string GalleryImage { get => galleryImage; set => galleryImage = value; }
    public string AddedOn { get => addedOn; set => addedOn = value; }
    public int IsActive { get => isActive; set => isActive = value; }
}
