using Azure;
using Azure.AI.TextAnalytics;

namespace IAText
{
    public static class VinculacionDeEntidades
    {
        public static void ObtenerVinculacionDeEntidades(string documento)
        {
            var cliente = Cliente.DevolverClienteAzure();

            Console.WriteLine();

            try
            {
                Response<LinkedEntityCollection> respuesta = cliente.RecognizeLinkedEntities(documento);
                LinkedEntityCollection entidadesVinculadas = respuesta.Value;

                Console.WriteLine($"Se reconocieron {entidadesVinculadas.Count} entidades vinculadas:");
                foreach (LinkedEntity entidadVinculada in entidadesVinculadas)
                {
                    Console.WriteLine($"  Nombre: {entidadVinculada.Name}");
                    Console.WriteLine($"  Idioma: {entidadVinculada.Language}");
                    Console.WriteLine($"  Fuente de datos: {entidadVinculada.DataSource}");
                    Console.WriteLine($"  URL: {entidadVinculada.Url}");
                    Console.WriteLine($"  ID de entidad en la fuente de datos: {entidadVinculada.DataSourceEntityId}");
                    foreach (LinkedEntityMatch coincidencia in entidadVinculada.Matches)
                    {
                        Console.WriteLine($"    Texto coincidente: {coincidencia.Text}");
                        Console.WriteLine($"    Posición inicial (offset): {coincidencia.Offset}");
                        Console.WriteLine($"    Longitud: {coincidencia.Length}");
                        Console.WriteLine($"    Puntaje de confianza: {coincidencia.ConfidenceScore:P2}");
                    }
                    Console.WriteLine();
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
