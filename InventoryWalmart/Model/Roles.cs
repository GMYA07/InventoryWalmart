internal class Roles
{
    public int IdRol { get; set; }
    public string RoleName { get; set; }
    public string RoleDescription { get; set; }

    public Roles(int idRol, string roleName, string roleDescription)
    {
        IdRol = idRol;
        RoleName = roleName;
        RoleDescription = roleDescription;
    }

  
    public Roles() { }
}
