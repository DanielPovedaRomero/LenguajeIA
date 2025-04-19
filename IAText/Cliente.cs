using Azure.AI.TextAnalytics;
using Azure;

namespace IAText
{
    public static class Cliente
    {
        public static TextAnalyticsClient DevolverClienteAzure() {
            Uri endpoint = new("END_POINT_AZURE");
            AzureKeyCredential credential = new("KEY_AZURE");
            TextAnalyticsClient client = new(endpoint, credential);
            return client;
        }
    }
}
