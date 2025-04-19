using Azure.AI.TextAnalytics;
using Azure;

namespace IAText
{
    public static class AnalisisDeSentimiento
    {
        public static void ObtenerSentimientoEnTexto(string documento)
        {
            var cliente = Cliente.DevolverClienteAzure();

            Console.WriteLine();

            try
            {
                Response<DocumentSentiment> respuesta = cliente.AnalyzeSentiment(documento);
                DocumentSentiment sentimientoDocumento = respuesta.Value;

                Console.WriteLine($"El sentimiento del documento es: {sentimientoDocumento.Sentiment}");
                Console.WriteLine($"  Puntaje de confianza positiva: {sentimientoDocumento.ConfidenceScores.Positive:P2}");
                Console.WriteLine($"  Puntaje de confianza neutral: {sentimientoDocumento.ConfidenceScores.Neutral:P2}");
                Console.WriteLine($"  Puntaje de confianza negativa: {sentimientoDocumento.ConfidenceScores.Negative:P2}");
            }
            catch (RequestFailedException excepcion)
            {
                Console.WriteLine($"Código de error: {excepcion.ErrorCode}");
                Console.WriteLine($"Mensaje: {excepcion.Message}");
            }
        }
    }
}
