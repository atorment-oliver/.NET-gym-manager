using System;
using System.Web;

public class Helper
{
	public Helper()
	{
	}
    public class Privilege
    {
        private int id;
        private string nombre;
        private string descripcion;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
    public class Member
    {
        private Guid userId;
        private string userName;
        private string firstName;
        private string lastName;
        private DateTime lastActivityDate;
        private string email;
        private bool isLockedOut;
        private bool isApproved;
        private DateTime createDate;
        private DateTime lastLoginDate;

        public Guid UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public DateTime LastActivityDate
        {
            get { return lastActivityDate; }
            set { lastActivityDate = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public bool IsLockedOut
        {
            get { return isLockedOut; }
            set { isLockedOut = value; }
        }
        public bool IsApproved
        {
            get { return isApproved; }
            set { isApproved = value; }
        }
        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
        public DateTime LastLoginDate
        {
            get { return lastLoginDate; }
            set { lastLoginDate = value; }
        }
    }
    public class Rol
    {
        private string rolName;
        public string RolName
        {
            get { return rolName; }
            set { rolName = value; } 
        }
    }

    public enum MessageType
    {
        Info, 
        Warning, 
        Error
    }
}