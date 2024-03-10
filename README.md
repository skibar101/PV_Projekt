# Uživatelské rozhraní pro správu obchodu

Jednoduché uživatelské rozhraní, které obsahuje manipulaci zákazníkových dat z databáze.

# Struktura databáze

 zakaznik 
 
    id int primary key identity(1,1),
    
    jmeno varchar(50) not null,
    
    prijmeni varchar(50) not null,
    
    email varchar(100) not null,
    
    vek int not null


 produkt
 
    id int primary key identity(1,1),
    
    nazev varchar(100) not null,
    
    cena float not null,
    
    skladem bit not null


 objednavka 
 
    id int primary key identity(1,1),
    
    datum datetime not null,
    
    zakaznik_id int,
    
    foreign key (zakaznik_id) references zakaznik(id)


 objednavka_produkt 
 
    objednavka_id int,
    
    produkt_id int,
    
    mnozstvi int not null,
    
    primary key (objednavka_id, produkt_id),
    
    foreign key (objednavka_id) references objednavka(id),
    
    foreign key (produkt_id) references produkt(id)


 platba
 
    id int primary key identity(1,1),
    
    objednavka_id int,
    
    castka float not null,
    
    datum datetime not null,
    
    foreign key (objednavka_id) references objednavka(id)


# Funkce rozhraní

Funkce rozhraní jsou vypsaní, přidání, smazání a aktualizaci dat u zákazníka. Přišlo mi zbytečné dělat u více tabulek z toho důvodu, že by to bylo to samé a že bych to nestíhal :D

Import dat z externího souboru jsem bohužel neudělal, jelikož jsem nenašel optimální řešení

Konfigurace celé aplikace je provedena skrz konfigurační soubor "App.config"

# Dokumentace

Kód je řádně okomentovaný, jak obyčejnýma komentářema, tak i komentáře ve formátu XML.

# Chyby

Nejde smazat id 1

Občas vypadne spojení s databází při provádění nějakého příkazu (většinou na konci), nešlo mi to vyřešit, tudíž to řeším tak, že exitnu konzoli







