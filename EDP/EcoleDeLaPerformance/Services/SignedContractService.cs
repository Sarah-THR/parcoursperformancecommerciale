using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
namespace EcoleDeLaPerformance.Ui.Services
{
    public class SignedContractService : ISignedContractService
    {
        private readonly IConfiguration _configuration;

        public SignedContractService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<SignedContract?>> GetSignedContractByWeekId(int weekId)
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/signedcontract?weekId={weekId}");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<SignedContract?>>(),
                HttpStatusCode.NoContent => null,
                HttpStatusCode.BadRequest => throw new Exception("L'id de semaine est obligatoire."),
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des contrats signée de l'utilisateur : {await response.Content.ReadAsStringAsync()}"),
            };
        }
    }
}
