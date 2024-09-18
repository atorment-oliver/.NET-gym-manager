using System;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;
using System.Web.Profile;
using System.Data;

public class AppSecurity
{
	public AppSecurity()
	{
	}
    public static bool HasAccess(string privilegeName, string roleName)
    {
        SecurityTableAdapters.Privileges_TableAdapter adapter = new SecurityTableAdapters.Privileges_TableAdapter();
        Security.PrivilegesDataTable table = adapter.TraerXRolPrivilege(roleName, privilegeName);

        if (table != null && table.Rows.Count > 0)
            return true;
        return false;
    }
    public static bool HasAccess(string privilegeName)
    {
        string[] roles = System.Web.Security.Roles.GetRolesForUser();
        if (roles.Length <= 0)
            return false;

        SecurityTableAdapters.Privileges_TableAdapter adapter = new SecurityTableAdapters.Privileges_TableAdapter();
        Security.PrivilegesDataTable table = adapter.TraerXRolPrivilege(roles[0], privilegeName);

        if (table != null && table.Rows.Count > 0)
            return true;
        return false;
    }
    public static List<Helper.Privilege> GetPrivileges(string roleName)
    {
        List<Helper.Privilege> privileges = new List<Helper.Privilege>();

        SecurityTableAdapters.Privileges_TableAdapter adapter = new SecurityTableAdapters.Privileges_TableAdapter();
        Security.PrivilegesDataTable table = adapter.TraerXRolName(roleName);

        foreach (Security.PrivilegesRow row in table)
        {
            Helper.Privilege privilege = new Helper.Privilege { Id = row.id, Nombre = row.nombre, Descripcion = row.descripcion };
            privileges.Add(privilege);
        }

        return privileges;
    }
    public static int GetPrivilegesNumber(string roleName)
    {
        SecurityTableAdapters.Privileges_TableAdapter adapter = new SecurityTableAdapters.Privileges_TableAdapter();
        Security.PrivilegesDataTable table = adapter.TraerXRolName(roleName);

        if (table != null && table.Rows.Count > 0)
            return table.Rows.Count;

        return 0;
    }

    public static List<string> GetEmailByPrivilege(int privilegeId)
    {
        List<string> emails = new List<string>();

        SecurityTableAdapters.UserByPrivilege_TraerXPrivilegeTableAdapter adapter = new SecurityTableAdapters.UserByPrivilege_TraerXPrivilegeTableAdapter();
        Security.UserByPrivilegeDataTable table = adapter.TraerXPrivilegeId(privilegeId);

        foreach (Security.UserByPrivilegeRow row in table)
        {
            emails.Add(row.Email);
        }

        return emails;
    }
    public static List<Helper.Privilege> GetPrivileges()
    {
        List<Helper.Privilege> privileges = new List<Helper.Privilege>();

        SecurityTableAdapters.Privileges_TableAdapter adapter = new SecurityTableAdapters.Privileges_TableAdapter();
        Security.PrivilegesDataTable table = adapter.TraerTodos();

        foreach (Security.PrivilegesRow row in table)
        {
            Helper.Privilege privilege = new Helper.Privilege { Id = row.id, Nombre = row.nombre, Descripcion = row.descripcion };
            privileges.Add(privilege);
        }

        return privileges;
    }
    public static bool InsertarPrivilegio(string roleName, int privilegeId)
    {
        int? id = 0;
        SecurityTableAdapters.Privileges_TableAdapter adapter = new SecurityTableAdapters.Privileges_TableAdapter();
        adapter.Insertar(ref id, roleName, privilegeId);
        return id != 0;
    }
    public static bool EliminarPrivilegios(string roleName)
    {
        if (GetPrivilegesNumber(roleName) <= 0)
            return true;

        SecurityTableAdapters.Privileges_TableAdapter adapter = new SecurityTableAdapters.Privileges_TableAdapter();
        int resultado = Convert.ToInt32(adapter.Eliminar(roleName));
        return resultado > 0;
    }
    public static void EliminarUsuario(string userName)
    {
        MembershipUser user = Membership.GetUser(userName);
        if (user == null)
            return;

        Roles.RemoveUserFromRoles(userName, Roles.GetRolesForUser(userName));

        user.IsApproved = false;
        Membership.UpdateUser(user);

        ProfileCommon profile = (ProfileCommon)ProfileBase.Create(userName, true);
        profile.Deleted = true;
        profile.Save();
    }
    public static bool UserIsDeleted(string userName)
    {
        ProfileCommon profile = (ProfileCommon)ProfileBase.Create(userName, true);
        return profile.Deleted;        
    }
    public static bool UserExists(string userName)
    {
        MembershipUser user = Membership.GetUser(userName);
        if (user != null && user.IsApproved)
            return true;
        return false;
    }
    public static bool ChangePassword(string userName, string newPassword)
    {
        MembershipUser user = Membership.GetUser(userName);
        if (user != null)
        {
            user.ChangePassword(user.ResetPassword(), newPassword);
            return true;
        }
        return false;
    }
    public static void ApproveUser(string userName, bool status)
    {
        MembershipUser user = Membership.GetUser(userName);
        if (user == null)
            return;

        user.IsApproved = status;
        Membership.UpdateUser(user);
    }
    public static void UnlockUser(string userName)
    {
        MembershipUser user = Membership.GetUser(userName);
        if (user == null)
            return;

        user.UnlockUser();
    }
    public static bool IsLocked(string userName)
    {
        MembershipUser user = Membership.GetUser(userName);
        return user.IsLockedOut;
    }
    public static bool IsApproved(string userName)
    {
        MembershipUser user = Membership.GetUser(userName);
        if (user == null)
            return false;
        return user.IsApproved;
    }
    public static Helper.Member GetUser(string userName)
    {
        MembershipUser user = Membership.GetUser(userName);
        if (user == null)
            return null;

        return LoadUser(user);
    }
    public static Helper.Member GetUser(Guid id)
    {
        MembershipUser user = Membership.GetUser(id);
        if (user == null)
            return null;

        return LoadUser(user);
    }
    public static void SetRol(string userName, string roleName)
    {
        string []roles = Roles.GetRolesForUser(userName);
        if (roles.Length > 0)
            Roles.RemoveUserFromRoles(userName, roles);
        Roles.AddUserToRole(userName, roleName);
    }
    public static List<Helper.Member> GetUsers(string userName, string firstName, string lastName, bool onLine, bool? status)
    {
        List<Helper.Member> members = new List<Helper.Member>();

        MembershipUserCollection users = Membership.GetAllUsers();
        foreach (MembershipUser user in users)
        {
            if (IsOnline(onLine, user) && IsApproved(status, user) && MatchUserName(userName, user) && MatchFirstName(firstName, user) && MatchLastName(lastName, user) && !IsDeleted(user))
            {
                Helper.Member member = LoadUser(user);
                members.Add(member);
            }
        }
        return members;
    }

    public static DataTable GetUsersList(string userName, string firstName, string lastName, bool onLine, bool status)
    {
        DataTable members = new DataTable();
        members.Columns.Add("UserId", typeof(Guid));
        members.Columns.Add("UserName", typeof(string));
        members.Columns.Add("FirstName", typeof(string));
        members.Columns.Add("LastName", typeof(string));
        members.Columns.Add("LastActivityDate", typeof(DateTime));
        members.Columns.Add("email", typeof(string));
        members.Columns.Add("IsLockedOut", typeof(bool));
        members.Columns.Add("IsApproved", typeof(bool));
        members.Columns.Add("CreateDate", typeof(DateTime));
        members.Columns.Add("LastLoginDate", typeof(DateTime));

        MembershipUserCollection users = Membership.GetAllUsers();
        foreach (MembershipUser user in users)
        {
            if (IsOnline(onLine, user) && IsApproved(status, user) && MatchUserName(userName, user) && MatchFirstName(firstName, user) && MatchLastName(lastName, user) && !IsDeleted(user))
            {
                DataRow member = members.NewRow();
                members.Rows.Add(LoadUser(user, member));
            }
        }
        return members;
    }
    public static DataTable GetRolesList()
    {
        DataTable roles = new DataTable();
        roles.Columns.Add("RolName", typeof(string));
        roles.Columns.Add("NroPrivilegios", typeof(int));
        roles.Columns.Add("NroUsuarios", typeof(int));

        string[] roleList = Roles.GetAllRoles();
        foreach (string role in roleList)
        {
            DataRow row = roles.NewRow();
            row["RolName"] = role;
            row["NroPrivilegios"] = GetPrivileges(role).Count;
            row["NroUsuarios"] = Roles.GetUsersInRole(role).Length;
            
            roles.Rows.Add(row);
        }

        return roles;
    }
    public static DataTable GetPrivilegesList()
    {
        SecurityTableAdapters.Privileges_TableAdapter adapter = new SecurityTableAdapters.Privileges_TableAdapter();
        return adapter.TraerTodos();
    }

    private static Helper.Member LoadUser(MembershipUser user)
    {
        //Profile.GetProfile(user.UserName);
        ProfileCommon profile = (ProfileCommon)ProfileBase.Create(user.UserName, true);

        Helper.Member member = new Helper.Member();
        member.UserId = (Guid)user.ProviderUserKey;
        member.UserName = user.UserName;
        member.FirstName = profile.FirstName;
        member.LastName = profile.LastName;
        member.Email = user.Email;
        member.CreateDate = user.CreationDate;
        member.LastLoginDate = user.LastLoginDate;
        member.LastActivityDate = user.LastActivityDate;
        member.IsLockedOut = user.IsLockedOut;
        member.IsApproved = user.IsApproved;

        return member;
    }
    private static DataRow LoadUser(MembershipUser user, DataRow member)
    {
        ProfileCommon profile = (ProfileCommon)ProfileBase.Create(user.UserName, true);

        member["UserId"] = (Guid)user.ProviderUserKey;
        member["UserName"] = user.UserName;
        member["FirstName"] = profile.FirstName;
        member["LastName"] = profile.LastName;
        member["Email"] = user.Email;
        member["CreateDate"] = user.CreationDate;
        member["LastLoginDate"] = user.LastLoginDate;
        member["LastActivityDate"] = user.LastActivityDate;
        member["IsLockedOut"] = user.IsLockedOut;
        member["IsApproved"] = user.IsApproved;

        return member;
    }
    private static bool IsOnline(bool onLine, MembershipUser user)
    {
        if (onLine)
        {
            if (!user.IsOnline)
                return false;
        }
        return true;
    }
    private static bool IsApproved(bool? status, MembershipUser user)
    {
        if (status != null)
        {
            if (status == true && user.IsApproved)
                return true;
            else if (status == false && !user.IsApproved)
                return true;
            return false;
        }
        return true;
    }
    private static bool IsDeleted(MembershipUser user)
    {
        ProfileCommon profile = (ProfileCommon)ProfileBase.Create(user.UserName, true);
        return profile.Deleted;
    }
    private static bool MatchUserName(string userName, MembershipUser user)
    {
        if (!string.IsNullOrEmpty(userName))
        {
            return user.UserName.ToLower().Contains(userName.ToLower());
        }
        return true;
    }
    private static bool MatchFirstName(string firstName, MembershipUser user)
    {        
        if (!string.IsNullOrEmpty(firstName))
        {
            ProfileCommon profile = (ProfileCommon)ProfileBase.Create(user.UserName, true);
            return profile.FirstName.ToLower().Contains(firstName.ToLower());
        }
        return true;
    }
    private static bool MatchLastName(string lastName, MembershipUser user)
    {
        if (!string.IsNullOrEmpty(lastName))
        {
            ProfileCommon profile = (ProfileCommon)ProfileBase.Create(user.UserName, true);
            return profile.LastName.ToLower().Contains(lastName.ToLower());
        }
        return true;
    }
}