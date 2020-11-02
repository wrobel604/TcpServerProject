Serwer domyślnie uruchamia się na adresie 127.0.0.1:5555
Uruchamiając program z linii poleceń: pierwszy argument to adres, na którym serwer nasłuchuje, a drugi argument to numer portu.
Przykład: TcpServerApp.exe 127.0.0.1 1234

Pułapka warunkowa występuje w metodzie MessageTimeParser.messageParser jeśli przesłany ciąg bajtów zawiera tylko białe znaki(są one usuwane przez metodę Trim, więc warunek sprawdza czy ciąg jest pusty).