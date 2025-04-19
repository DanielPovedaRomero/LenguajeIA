namespace IAText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var textoPDF = PDF.ObtenerPDFBlobStorage();
            DetectarIdioma.ObtenerIdiomaEnTexto(textoPDF);
            AnalisisDeSentimiento.ObtenerSentimientoEnTexto(textoPDF);
            PalabrasClave.ObtenerPalabrasClaveDeTexto(textoPDF);
            Entidades.ObtenerEntidadesEnUnTexto(textoPDF);
            VinculacionDeEntidades.ObtenerVinculacionDeEntidades(textoPDF);
        }
    }
}
