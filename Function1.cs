using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace QuadroMedalhas
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([QueueTrigger("quadromedalhasqueue")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");


            // Connectar ao servidor
            var connString = "localhost";
            var redis = ConnectionMultiplexer.Connect(connString);
            IDatabase db = redis.GetDatabase();

            db.StringSet("ListaMedalhas", myQueueItem);

        }
    }
}
