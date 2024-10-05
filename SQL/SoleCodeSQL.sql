-- a. Initial Data
--Point 1
INSERT INTO Kategori 
VALUES 
(1,'Fiksi'),
(2,'Non Fiksi'),
(3,'Quotes'),
(4,'Novel'),
(5,'Komik');

--Point 2
INSERT INTO user
VALUES
(1,'User 1','Binong','3576014403910001','08577050001','user1@email.com','2024-08-05'),
(2,'User 2','Bintaro','3576014403910002','08577050002','user2@email.com','2024-08-05'),
(3,'User 3','Pamulang','3576014403910003','08577050003','user3@email.com','2024-08-05'),
(4,'User 4','Ciledug','3576014403910004','08577050004','user4@email.com','2024-08-05'),
(5,'User 5','Curug','3576014403910005','08577050005','user5@email.com','2024-08-05');

--Point 3
INSERT INTO buku 
VALUES
(1,'Laskar Pelangi','Andrea Hirata','Bentang Pustaka','9789791227531',2005,15,1),
(2,'Bumi Manusia','Pramoedya Ananta Toer','Lentera Dipantara','9789799731245',1980,10,1),
(3,'Perahu Kertas','Dee Lestari','Bentang Pustaka','9786028811119',2009,8,4),
(4,'The Alchemist','Paulo Coelho','HarperCollins','9780061122415',1988,12,5),
(5,'Harry Potter and the Sorcerers Stone','J.K. Rowling','Bloomsbury','9780747532699',1997,20,4),
(6,'1984','George Orwell','Secker & Warburg','9780451524935',1949,5,3),
(7,'Pride and Prejudice','Jane Austen','T. Egerton','9780141199078',1813,7,2),
(8,'To Kill a Mockingbird','Harper Lee','J.B. Lippincott & Co.','9780060935461',1960,6,2),
(9,'The Great Gatsby','F. Scott Fitzgerald','Charles Scribners Sons','9780743273565',1925,10,3),
(10,'The Catcher in the Rye','J.D. Salinger','Little, Brown and Company','9780316769488',1951,9,5);

--Point 4 & 5
INSERT INTO peminjaman
VALUES (1,1,1,'2024-08-05',DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY),'2024-08-10',
    CASE 
        WHEN tanggal_kembali > DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY) 
        THEN DATEDIFF(tanggal_kembali, DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY)) * 1000
        ELSE 0
    END
),
(2,1,2,'2024-08-05',DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY),'2024-08-13',
    CASE 
        WHEN tanggal_kembali > DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY) 
        THEN DATEDIFF(tanggal_kembali, DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY)) * 1000
        ELSE 0
    END
),
(3,1,3,'2024-08-13',DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY),'2024-08-25',
    CASE 
        WHEN tanggal_kembali > DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY) 
        THEN DATEDIFF(tanggal_kembali, DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY)) * 1000
        ELSE 0
    END
),
(4,2,4,'2024-08-09',DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY),'2024-08-13',
    CASE 
        WHEN tanggal_kembali > DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY) 
        THEN DATEDIFF(tanggal_kembali, DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY)) * 1000
        ELSE 0
    END
),
(5,2,5,'2024-08-09',DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY),'2024-08-18',
    CASE 
        WHEN tanggal_kembali > DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY) 
        THEN DATEDIFF(tanggal_kembali, DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY)) * 1000
        ELSE 0
    END
),
(6,2,6,'2024-08-18',DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY),'2024-08-25',
    CASE 
        WHEN tanggal_kembali > DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY) 
        THEN DATEDIFF(tanggal_kembali, DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY)) * 1000
        ELSE 0
    END
),
(7,3,7,'2024-08-18',DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY),'2024-08-23',
    CASE 
        WHEN tanggal_kembali > DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY) 
        THEN DATEDIFF(tanggal_kembali, DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY)) * 1000
        ELSE 0
    END
),
(8,3,8,'2024-08-23',DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY),'2024-08-29',
    CASE 
        WHEN tanggal_kembali > DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY) 
        THEN DATEDIFF(tanggal_kembali, DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY)) * 1000
        ELSE 0
    END
),
(9,3,9,'2024-09-01',DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY),'2024-09-19',
    CASE 
        WHEN tanggal_kembali > DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY) 
        THEN DATEDIFF(tanggal_kembali, DATE_ADD(tanggal_pinjam, INTERVAL 13 DAY)) * 1000
        ELSE 0
    END
);

-- b. Manipulasi Data
-- No. 1
SELECT id, judul 
FROM buku WHERE NOT EXISTS (
    SELECT 1 FROM peminjaman WHERE peminjaman.buku_id = buku.id
);

-- No.2
SELECT user.nama, peminjaman.denda 
FROM peminjaman
JOIN user ON user.id = peminjaman.anggota_id WHERE peminjaman.denda>0;

-- No.3
SELECT ROW_NUMBER() OVER (ORDER BY user.nama) AS No, user.nama, GROUP_CONCAT(buku.judul ORDER BY buku.judul DESC SEPARATOR ',') AS buku
FROM peminjaman
JOIN user ON user.id = peminjaman.anggota_id
JOIN buku ON buku.id = peminjaman.buku_id
GROUP BY user.nama;