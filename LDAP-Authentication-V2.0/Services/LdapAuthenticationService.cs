using LDAP_Authentication_V2._0;
using Microsoft.Extensions.Options;
using Novell.Directory.Ldap;

namespace LDAP_Authentication_V2.Services
{
    public class LdapAuthenticationService
    {
        private readonly LdapSettings _ldapSettings;

        public LdapAuthenticationService(IOptions<LdapSettings> ldapSettings)
        {
            _ldapSettings = ldapSettings.Value;
        }

        public bool Authenticate(string username, string password)
        {
            try
            {
                using (var connection = new LdapConnection())
                {
                    connection.Connect(_ldapSettings.LdapServer, _ldapSettings.LdapPort);
                    connection.Bind(_ldapSettings.LdapBindDn, _ldapSettings.LdapBindPassword);

                    var searchFilter = $"(uid={username})";
                    var searchResults = connection.Search(
                        _ldapSettings.LdapBaseDn,
                        LdapConnection.ScopeSub,
                        searchFilter,
                        null,
                        false
                    );

                    if (searchResults.HasMore())
                    {
                        var entry = searchResults.Next();
                        if (entry != null)
                        {
                            var userDn = entry.Dn;
                            connection.Bind(userDn, password);
                            return connection.Bound;
                        }
                    }

                    return false;
                }
            }
            catch (LdapException)
            {
                return false;
            }
        }
    }
}
