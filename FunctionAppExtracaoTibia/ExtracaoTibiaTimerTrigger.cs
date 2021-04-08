using System;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using FunctionAppExtracaoTibia.Documents;

namespace FunctionAppExtracaoTibia
{
    public static class ExtracaoTibiaTimerTrigger
    {
        [Function("ExtracaoTibiaTimerTrigger")]
        public static void Run([TimerTrigger("*/10 * * * * *")] FunctionContext context)
        {
            var logger = context.GetLogger("ExtracaoTibiaTimerTrigger");

            var endpointTibia = Environment.GetEnvironmentVariable("EndpointTibia");
            var ranking = new HttpClient().GetFromJsonAsync<RankingTibia>(
                endpointTibia).Result;
            logger.LogInformation($"Obtidos dados do endpoint: {endpointTibia}");
            
            logger.LogInformation($"{nameof(ExtracaoTibiaTimerTrigger)} executada em: {DateTime.Now}");
        }
    }
}