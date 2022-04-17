# SubiektGT-Sfera

#Przyk³ady kodu
Dodawanie kontrahentów:
InsERT.Kontrahent kh;

```
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
```		