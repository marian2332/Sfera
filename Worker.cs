using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;



namespace SubiektGT_Sfera
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                try
                {
                    InsERT.GT gt = new InsERT.GT();
                    gt.Produkt = InsERT.ProduktEnum.gtaProduktSubiekt;
                    gt.Serwer = "ITPB\\INSERTGT";
                    gt.Baza = "Projekt1";
                    gt.Autentykacja = InsERT.AutentykacjaEnum.gtaAutentykacjaMieszana;
                    gt.Uzytkownik = "sa";
                    gt.UzytkownikHaslo = "";
                    gt.Operator = "Szef";
                    gt.OperatorHaslo = "";

                    InsERT.Subiekt subiekt = (InsERT.Subiekt)gt.Uruchom((Int32)InsERT.UruchomDopasujEnum.gtaUruchomDopasuj, (Int32)InsERT.UruchomEnum.gtaUruchomNieArchiwizujPrzyZamykaniu);



                    subiekt.Okno.Widoczne = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
