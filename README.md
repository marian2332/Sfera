# SubiektGT-Sfera
Przykłady kodu zostały napisane w .Net 5

## Start

Dodanie referencji COM:
```
InsERT dla aplikacji - Biblioteka obiektowa (ver. 1.0)
Microsoft ActiveX Data Objects 6.0 BackCompact Library
InsERT GT ZestMan 1.0 Type Library
```

## Przykłady kodu
###### Połączenie przez Sferę:
```
InsERT.Subiekt subiekt;
InsERT.Kontrahent kh;
InsERT.GT gt = new InsERT.GT();                    
gt.Produkt = InsERT.ProduktEnum.gtaProduktSubiekt;
gt.Serwer = "Serwer\\Baza";
gt.Baza = "Projekt1";
gt.Autentykacja = InsERT.AutentykacjaEnum.gtaAutentykacjaMieszana;
gt.Uzytkownik = "sa";
gt.UzytkownikHaslo = "";
gt.Operator = "Szef";
gt.OperatorHaslo = "";

subiekt = (InsERT.Subiekt)gt.Uruchom((Int32)InsERT.UruchomDopasujEnum.gtaUruchomDopasuj, (Int32)InsERT.UruchomEnum.gtaUruchomNieArchiwizujPrzyZamykaniu);

subiekt.Okno.Widoczne = true;
```

###### Dodawanie kontrahentów:
```
InsERT.Kontrahent kh;
for (int i=1;i<10;i++)
{
	kh = subiekt.Kontrahenci.Dodaj(0);
	kh.Symbol = "Test";
	kh.Nazwa = "Nazwa";
	kh.Ulica = "Ulica";
	kh.Miejscowosc = "Miejscowosc";
	kh.KodPocztowy = "62-06";
	kh.WWW = "www.df.d";
	kh.Zapisz();
}
```		
