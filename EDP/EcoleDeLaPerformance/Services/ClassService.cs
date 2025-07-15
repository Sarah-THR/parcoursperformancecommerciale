using BlazorDownloadFile;
using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class ClassService : IClassService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly StateContainerService _stateContainerService;
        private readonly IBlazorDownloadFileService _blazorDownloadFileService;
        public ClassService(IConfiguration configuration, IHttpClientFactory httpClientFactory, StateContainerService stateContainerService, IBlazorDownloadFileService blazorDownloadFileService)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _stateContainerService = stateContainerService;
            _blazorDownloadFileService = blazorDownloadFileService;
        }

        public async Task<List<Class?>> GetClassesAsync()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/classes/");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Class?>>(),
                HttpStatusCode.NoContent => null,
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des cours : {await response.Content.ReadAsStringAsync()}"),
            };
        }
        public async Task<int> CreateDocumentRecordAsync(Document document)
        {
            // Créer un document sans le contenu PDF pour obtenir l'ID
            Document initialDocument = new Document
            {
                Pdffile = string.Empty, // Contenu PDF vide au départ
                Title = document.Title,
                CreateDate = DateTime.Now,
                UpdateDate = null,
                CreateBy = document.CreateBy,
                UpdateBy = null,
                ClassId = document.ClassId
            };

            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(initialDocument), System.Text.Encoding.UTF8, "application/json");
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/documents", httpContent);

            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
            {
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                    "Le document est obligatoire." :
                    $"Une erreur est survenue lors de la création du document : {await response.Content.ReadAsStringAsync()}");
            }

            var createdDocument = JsonConvert.DeserializeObject<Document>(await response.Content.ReadAsStringAsync());
            return createdDocument.DocumentId;
        }

        public async Task CreateDocumentAsync(Document document)
        {
            int chunkSize = (int)(20L * 1024 * 1024); // 20 MB chunks
            List<string> pdfChunks = SplitPdfFile(document.Pdffile, chunkSize);

            int documentId = await CreateDocumentRecordAsync(document);

            foreach (var chunk in pdfChunks)
            {
                Document chunkDocument = new Document
                {
                    DocumentId = documentId,
                    Pdffile = chunk,
                    Title = document.Title,
                    CreateDate = document.CreateDate,
                    CreateBy = document.CreateBy,
                    ClassId = document.ClassId
                };

                using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(chunkDocument), System.Text.Encoding.UTF8, "application/json");
                var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/documents", httpContent);

                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
                {
                    throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                        "Le document est obligatoire." :
                        $"Une erreur est survenue lors de l'ajout du document : {await response.Content.ReadAsStringAsync()}");
                }
            }
        }

        public List<string> SplitPdfFile(string pdfContent, int chunkSize)
        {
            List<string> chunks = new List<string>();
            for (int i = 0; i < pdfContent.Length; i += chunkSize)
            {
                chunks.Add(pdfContent.Substring(i, Math.Min(chunkSize, pdfContent.Length - i)));
            }
            return chunks;
        }

        public async Task<List<Document>> GetDocumentsAsync()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/documents");
            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Document>>(),
                HttpStatusCode.NoContent => null,
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des documents : {await response.Content.ReadAsStringAsync()}"),
            };
        }

        public async Task DeleteDocumentAsync(int documentId)
        {
            var response = await new HttpClient().DeleteAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/documents/{documentId}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Une erreur est survenue lors de la suppression du document : {await response.Content.ReadAsStringAsync()}");
        }

        public async Task<Document> UpdateDocumentAsync(Document document)
        {
            await DeleteDocumentAsync(document.DocumentId);

            Document updatedDocument = new Document();
            int chunkSize = (int)(20L * 1024 * 1024); // 20 MB chunks
            List<string> pdfChunks = SplitPdfFile(document.Pdffile, chunkSize);

            foreach (var chunk in pdfChunks)
            {
                Document chunkDocument = new Document
                {
                    DocumentId = document.DocumentId,
                    Pdffile = chunk,
                    Title = document.Title,
                    CreateDate = document.CreateDate,
                    UpdateDate = document.UpdateDate,
                    CreateBy = document.CreateBy,
                    UpdateBy = document.UpdateBy,
                    ClassId = document.ClassId
                };

                using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(chunkDocument), System.Text.Encoding.UTF8, "application/json");
                var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/documents", httpContent);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    updatedDocument = await response.Content.ReadFromJsonAsync<Document?>();
                    return updatedDocument!;
                }
                else
                {
                    throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                        "Le document est obligatoire." :
                        $"Une erreur est survenue lors de l'ajout du document : {await response.Content.ReadAsStringAsync()}");
                }
            }
            return updatedDocument;
        }

        public async Task DownloadDocumentAsync(Document document)
        {
            if (document != null)
            {
                await _blazorDownloadFileService.DownloadFile(Path.GetFileName(document.Title), document.Pdffile, "application/pdf");
            }
        }
    }
}
