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
                    InsERT.Subiekt subiekt;
                    InsERT.GT gt = new InsERT.GT();                    
                    gt.Produkt = InsERT.ProduktEnum.gtaProduktSubiekt;
                    gt.Serwer = "ITPB\\INSERTGT";
                    gt.Baza = "Projekt1";
                    gt.Autentykacja = InsERT.AutentykacjaEnum.gtaAutentykacjaMieszana;
                    gt.Uzytkownik = "sa";
                    gt.UzytkownikHaslo = "";
                    gt.Operator = "Szef";
                    gt.OperatorHaslo = "";

                    subiekt = (InsERT.Subiekt)gt.Uruchom((Int32)InsERT.UruchomDopasujEnum.gtaUruchomDopasuj, (Int32)InsERT.UruchomEnum.gtaUruchomNieArchiwizujPrzyZamykaniu);

                    subiekt.Okno.Widoczne = true;

                    InsERT.Kontrahent kh;


                    for (int i=1;i<10;i++)
                    {
                        kh = subiekt.Kontrahenci.Dodaj(0);
                        kh.Symbol = "Test" + i;
                        kh.Nazwa = "Nazwa" + i;
                        kh.Ulica = "Ulica" + i;
                        kh.Miejscowosc = "Miejscowosc" + i;
                        kh.KodPocztowy = "62-06" + i;
                        kh.WWW = "www.wp.d" + i;
                        kh.Zapisz();
                    }
                    
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
