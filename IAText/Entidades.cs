using Azure;
using Azure.AI.TextAnalytics;

namespace IAText
{
    public static class Entidades
    {
        public static void ObtenerEntidadesEnUnTexto(string documento)
        {
            var cliente = Cliente.DevolverClienteAzure();

            Console.WriteLine();

            try
            {
                Response<CategorizedEntityCollection> respuesta = cliente.RecognizeEntities(documento);
                CategorizedEntityCollection entidadesEnDocumento = respuesta.Value;

                Console.WriteLine($"Se reconocieron {entidadesEnDocumento.Count} entidades:");
                foreach (CategorizedEntity entidad in entidadesEnDocumento)
                {
                    Console.WriteLine($"  Texto: {entidad.Text}");
                    Console.WriteLine($"  Posición inicial (offset): {entidad.Offset}");
                    Console.WriteLine($"  Longitud: {entidad.Length}");
                    Console.WriteLine($"  Categoría: {entidad.Category}");
                    if (!string.IsNullOrEmpty(entidad.SubCategory))
                        Console.WriteLine($"  Subcategoría: {entidad.SubCategory}");
                    Console.WriteLine($"  Puntaje de confianza: {entidad.ConfidenceScore:P2}");
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
