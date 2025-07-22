using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class DocumentService: IDocumentService
    {
        private readonly IConfiguration _configuration;
        public DocumentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Document>> GetDocuments()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/documents");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Document>>(),
                HttpStatusCode.NoContent => null
            };
        }
        public async Task<Document> CreateDocumentAsync(Document document)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(document), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/documents", httpContent);


            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<Document?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "Le document a crée est obligatoire." :
                $"Une erreur est survenue lors de l'ajout du document : {await response.Content.ReadAsStringAsync()}");
        }

        public async System.Threading.Tasks.Task UpdateDocumentAsync(Document document)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(document), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/documents", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("Le document à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"Le document avec l'id {document.Id} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification du document : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }

        public async System.Threading.Tasks.Task DeleteDocumentAsync(int id)
        {
            var response = await new HttpClient().DeleteAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/documents/{id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Une erreur est survenue lors de la suppression du document : {await response.Content.ReadAsStringAsync()}");
        }
    }
}
