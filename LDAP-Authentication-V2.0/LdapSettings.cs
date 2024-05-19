namespace LDAP_Authentication_V2._0
{
    public class LdapSettings
    {
        public string LdapServer { get; set; }
        public int LdapPort { get; set; }
        public string LdapBaseDn { get; set; }
        public string LdapBindDn { get; set; }
        public string LdapBindPassword { get; set; }
    }
}
