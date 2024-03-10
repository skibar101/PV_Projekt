# Uživatelské rozhraní pro správu obchodu

Jednoduché uživatelské rozhraní obsahuje možnost vypsat zákazníky, smazat zákazníky, přidat zákazníky nebo upravit zákazníky v databázi

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


