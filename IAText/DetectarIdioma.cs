using Azure;
using Azure.AI.TextAnalytics;

namespace IAText
{
    public static class DetectarIdioma
    {
        public static void ObtenerIdiomaEnTexto(string documento)
        {
            var cliente = Cliente.DevolverClienteAzure();

            Console.WriteLine();

            try
            {
                Response<DetectedLanguage> respuesta = cliente.DetectLanguage(documento);
                DetectedLanguage idioma = respuesta.Value;

                Console.WriteLine($"El idioma detectado es {idioma.Name} con una puntuación de confianza de {idioma.ConfidenceScore:P2}.");
            }
            catch (RequestFailedException excepcion)
            {
                Console.WriteLine($"Código de error: {excepcion.ErrorCode}");
                Console.WriteLine($"Mensaje: {excepcion.Message}");
            }
        }
    }
}
