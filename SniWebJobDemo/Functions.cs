using Microsoft.Azure.WebJobs;
using SniWebJobDemo.Data;
using System;
using System.IO;
using System.Linq;

namespace SniWebJobDemo
{
    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("sni-webjob-queue")] string message, TextWriter log)
        {
            log.WriteLine(message);
            using (var context = new DemoContext())
            {
                try
                {
                    log.WriteLine(context.Stars.FirstOrDefault().Name);
                }
                catch
                {
                    log.WriteLine($"Unable to get data from the DB. Make sure you created the database 'SniWebJobs' and have the dbo.Stars table built.");
                    throw;
                }
            }
        }
    }
}
