using Aspose.Words.Cloud.Sdk.Model.Requests;
using Aspose.Words.Cloud.Sdk.Model;
using Aspose.Words.Cloud.Sdk;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class PdfService
    {
        private readonly IConfiguration _configuration;
        public PdfService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<byte[]> CompressPdf(byte[] pdfBytes)
        {
            try
            {
                string clientId = _configuration.GetValue<string>("AsposeAPI:clientId");
                string clientSecret = _configuration.GetValue<string>("AsposeAPI:clientSecret");

                var config = new Configuration { ClientId = clientId, ClientSecret = clientSecret };
                var wordsApi = new WordsApi(config);

                using var requestDocument = new MemoryStream(pdfBytes);
                var requestCompressOptions = new CompressOptions()
                {
                    ImagesQuality = 75
                };

                var compressDocumentRequest = new CompressDocumentOnlineRequest(requestDocument, requestCompressOptions);
                var compressDocument = await wordsApi.CompressDocumentOnline(compressDocumentRequest);

                var convertDocumentRequest = new ConvertDocumentRequest(compressDocument.Document.Values.First(), "pdf");
                var convertedDocumentResponse = await wordsApi.ConvertDocument(convertDocumentRequest);

                using var memoryStream = new MemoryStream();
                convertedDocumentResponse.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur est survenue lors de la compression du fichier PDF.");
                return null;
            }
        }
    }
}
