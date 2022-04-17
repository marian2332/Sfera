# SubiektGT-Sfera

#Przykłady kodu
Dodawanie kontrahentów:
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
