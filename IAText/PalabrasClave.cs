using Azure;
using Azure.AI.TextAnalytics;

namespace IAText
{
    public static class PalabrasClave
    {
        public static void ObtenerPalabrasClaveDeTexto(string documento)
        {
            var cliente = Cliente.DevolverClienteAzure();

            Console.WriteLine();

            try
            {
                Response<KeyPhraseCollection> respuesta = cliente.ExtractKeyPhrases(documento);
                KeyPhraseCollection frasesClave = respuesta.Value;

                Console.WriteLine($"Se extrajeron {frasesClave.Count} frases clave:");
                foreach (string fraseClave in frasesClave)
                {
                    Console.WriteLine($"  {fraseClave}");
                }
            }
            catch (RequestFailedException excepcion)
            {
                Console.WriteLine($"Código de error: {excepcion.ErrorCode}");
                Console.WriteLine($"Mensaje: {excepcion.Message}");
            }
        }
    }
}
