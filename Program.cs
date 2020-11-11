using System;
using System.Threading.Tasks;
using LdapForNet;
using static LdapForNet.Native.Native;

namespace LdapTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // This one doesn't work
            TestLdapBindAsync().Wait();

            // This one works
            // TestLdapDifferentServer().Wait();
        }

        private static async Task TestLdapBindAsync()
        {
            using var cn = new LdapConnection();
            cn.Connect(new Uri("ldaps://orange.testlab.nhs.uk"));

            await cn.BindAsync(LdapAuthType.Anonymous, new LdapCredential());
        }

        private static async Task TestLdapDifferentServer()
        {
            using var cn = new LdapConnection();
            cn.Connect(new Uri("ldap://ldap.forumsys.com"));

            await cn.BindAsync(
                LdapAuthType.Simple,
                new LdapCredential
                {
                    UserName = "cn=read-only-admin,dc=example,dc=com",
                    Password = "password"
                });
        }
    }
}
