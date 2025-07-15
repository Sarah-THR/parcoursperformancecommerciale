using System.DirectoryServices;

namespace EcoleDeLaPerformance.Ui._Helper
{
    public static class Domain
    {
        public static DirectoryEntry GetDirectoryEntry()
        {
            return new("LDAP://OU=Utilisateurs,OU=XEFI,DC=xefi,DC=priv");
        }

        public static string GetPropertyValue(this SearchResult result, string propertyName)
        {
            try
            {
                return result.Properties.Contains(propertyName) ? (result.Properties[propertyName][0].ToString() ?? string.Empty) : string.Empty;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
