using EcoleDeLaPerformance.Ui._Helper;
using EcoleDeLaPerformance.Ui.Interfaces;
using System.DirectoryServices;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class AgencyService: IAgencyService
    {
        private readonly IConfiguration _configuration;
        public AgencyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<string> GetAgenciesAAD()
        {
            using DirectorySearcher dirsearcher = new(_Helper.Domain.GetDirectoryEntry(),
                                                      "(&(objectCategory=Person)(objectClass=user)(company=*))",
                                                      new string[] { "company" });
            return dirsearcher.FindAll()?.Cast<SearchResult>()?.Select(c => c.GetPropertyValue("company").ToUpper())?
                                                               .Distinct()
                                                               .OrderBy(c => c).ToList() ?? new List<string>();
        }
    }
}
