# NET
Zajęcia laboratoryjne z programowania w ASP.NET

1. Stare repozytorium "NET_1" calkowicie skasujcie.
2. Klonujemy te repozytorium
git clone https://github.com/LordBlaze500/NET
3. Tworzymy od razu swoja galaz
git checkout -b ksywa_z_github
4. Przy pierwszym otwarciu projektu prawdopodobnie przez chwile beda sie pobierac "Packages"
5. Tworzymy plik bazy danych, Shop.mdf w App_Data
6. Przy pierwszym uruchomieniu projektu baza powinna sie wygenerowac
7. Robimy co mamy zrobic, pozniej klasycznie:
git add -A
git commit -m "Krotki komentarz"
git push 
8. Dodalem plik .gitignore dedykowany do pracy z Visual Studio, tak wiec poza plikiem .sln i kodem zrodlowym wiekszosc plikow nie bedzie obecna w repozytorium (w tym miedzy innymi plik bazy danych, pliki personalizacji, wszelkie pliki debug/release itp.)
