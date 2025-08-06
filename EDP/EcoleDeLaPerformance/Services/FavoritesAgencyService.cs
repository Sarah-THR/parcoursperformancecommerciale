using EcoleDeLaPerformance.Ui._Helper;
using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Newtonsoft.Json;
using System.DirectoryServices;
using System.Net;
using System.Net.Http.Headers;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class FavoritesAgencyService: IFavoritesAgencyService
    {
        private readonly IConfiguration _configuration;
        public FavoritesAgencyService(IConfiguration configuration)
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
        public async Task<List<FavoritesAgency?>> GetFavoritesAgencyAsync()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/favoritesagency");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<FavoritesAgency?>>(),
                HttpStatusCode.NoContent => null,
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des agences favorites : {await response.Content.ReadAsStringAsync()}"),
            };
        }
        public async Task<FavoritesAgency?> InsertFavoritesAgencyAsync(FavoritesAgency favoritesAgency)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(favoritesAgency), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/favoritesagency", httpContent);


            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<FavoritesAgency?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "L'agence a crée est obligatoire." :
                $"Une erreur est survenue lors de l'ajout de l'agence : {await response.Content.ReadAsStringAsync()}");
        }

        public async System.Threading.Tasks.Task DeleteFavoritesAgencyAsync(int Id)
        {
            var response = await new HttpClient().DeleteAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/favoritesagency/{Id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Une erreur est survenue lors de la suppression de l'agence : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task UpdateFavoritesAgencyAsync(FavoritesAgency favoritesAgency)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(favoritesAgency), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/favoritesagency", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("Le l'agence à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"Le l'agence avec l'id {favoritesAgency.Id} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification de l'agence : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }
    }
}
