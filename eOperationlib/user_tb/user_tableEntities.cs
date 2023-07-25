using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class user_tableEntities
{
    private int userIdPk = 0;
    private string userName = "";
    private string email = "";
    private string password = "";
    private string contactNo = "";
    private string userType = "";
    private string addedOn = "";
    private int isActive = 0;

    public int UserIdPk { get => userIdPk; set => userIdPk = value; }
    public string UserName { get => userName; set => userName = value; }
    public string Email { get => email; set => email = value; }
    public string Password { get => password; set => password = value; }
    public string ContactNo { get => contactNo; set => contactNo = value; }
    public string AddedOn { get => addedOn; set => addedOn = value; }
    public int IsActive { get => isActive; set => isActive = value; }
    public string UserType { get => userType; set => userType = value; }
}
