using Azure.Storage.Blobs;
using UglyToad.PdfPig;

namespace IAText
{
    public static class PDF
    {
        public static string ObtenerPDFBlobStorage() 
        {
            string blobConnectionString = "STRING CONNECTION BLOB";
            string containerName = "NOMBRE_CONTENEDOR BLOB";
            string blobName = "NOMBRE_PDF.pdf";

            BlobServiceClient blobServiceClient = new BlobServiceClient(blobConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            MemoryStream pdfStream = new MemoryStream();
            blobClient.DownloadTo(pdfStream);
            pdfStream.Position = 0;

            string extractedText = "";

            using (PdfDocument documentPdf = PdfDocument.Open(pdfStream))
            {
                foreach (UglyToad.PdfPig.Content.Page page in documentPdf.GetPages())
                {
                    extractedText += page.Text + " ";
                }
            }

            return extractedText;
        }
    }
}
