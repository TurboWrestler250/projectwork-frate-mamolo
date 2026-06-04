CREATE DATABASE projectwork;

USE projectwork;

CREATE TABLE exhibitions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255) NOT NULL DEFAULT 'DEFAULT_TITLE',
    description TEXT NULL,
    start_date DATE NOT NULL DEFAULT '1000-01-01',
    end_date DATE NOT NULL DEFAULT '9999-12-31',
    image_url VARCHAR(4096) NULL,
    status ENUM('active', 'upcoming', 'archived') NOT NULL DEFAULT 'upcoming',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE artworks (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255) NOT NULL DEFAULT 'DEFAULT_TITLE',
    author VARCHAR(255) NULL,
    created_year SMALLINT SIGNED NULL,
    description TEXT NULL,
    technique VARCHAR(255) NULL,
    image_url VARCHAR(4096) NULL,
    exhibition_id INT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

    CONSTRAINT fk_artworks_exhibition
        FOREIGN KEY (exhibition_id)
        REFERENCES exhibitions(id)
        ON DELETE SET NULL
);

CREATE TABLE guided_tours (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255) NOT NULL DEFAULT 'DEFAULT_TITLE',
    description TEXT NULL,
    scheduled_at TIMESTAMP NOT NULL DEFAULT '2038-01-19 03:14:07',
    duration TIME NOT NULL DEFAULT '838:59:59',
    guide_name VARCHAR(255) NOT NULL,
    guide_surname VARCHAR(255) NOT NULL,
    max_participants SMALLINT UNSIGNED NOT NULL,
    exhibition_id INT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

    CONSTRAINT fk_guided_tours_exhibition
        FOREIGN KEY (exhibition_id)
        REFERENCES exhibitions(id)
        ON DELETE SET NULL
);

CREATE TABLE visitors (
    id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE reservations (
    id INT AUTO_INCREMENT PRIMARY KEY,
    visitor_id INT NOT NULL,
    guided_tour_id INT NOT NULL,
    participants INT NOT NULL,
    reservation_date TIMESTAMP DEFAULT '2038-01-19 03:14:07',
    status ENUM('confirmed', 'cancelled') NOT NULL DEFAULT 'cancelled',

    CONSTRAINT fk_reservations_visitor
        FOREIGN KEY (visitor_id)
        REFERENCES visitors(id)
        ON DELETE CASCADE,

    CONSTRAINT fk_reservations_tour
        FOREIGN KEY (guided_tour_id)
        REFERENCES guided_tours(id)
        ON DELETE CASCADE
);

CREATE TABLE ticket_types (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name ENUM('full', 'reduced', 'free') NOT NULL,
    base_price DECIMAL(10,2) NOT NULL DEFAULT 0.00
);

CREATE TABLE tickets (
    id INT AUTO_INCREMENT PRIMARY KEY,
    visitor_id INT NOT NULL,
    ticket_type_id INT NOT NULL,
    quantity INT NOT NULL,
    total_price DECIMAL(10,2) NOT NULL,
    purchase_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    exhibition_id INT NULL,
    guided_tour_id INT NULL,

    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

    CONSTRAINT fk_tickets_visitor
        FOREIGN KEY (visitor_id)
        REFERENCES visitors(id)
        ON DELETE CASCADE,

    CONSTRAINT fk_tickets_type
        FOREIGN KEY (ticket_type_id)
        REFERENCES ticket_types(id)
        ON DELETE RESTRICT,

    CONSTRAINT fk_tickets_exhibition
        FOREIGN KEY (exhibition_id)
        REFERENCES exhibitions(id)
        ON DELETE SET NULL,

    CONSTRAINT fk_tickets_tour
        FOREIGN KEY (guided_tour_id)
        REFERENCES guided_tours(id)
        ON DELETE SET NULL
);

INSERT INTO artworks (
    id,
    title,
    author,
    created_year,
    description,
    technique,
    image_url,
    exhibition_id
)
VALUES (
    0,
    'Persistenza della memoria',
    'Gerry Scotty',
    1967,
    "dasdhsaidhsahdsajdhsaldhsajkòhdaksjhdkashj",
    'Olio su tela',
    'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUGDQMV6gUMEDb1rrcLsioe0L5vyV-VzVFq2J0Vc4KXTHFO6AWozjtgSA&s=10',
    NULL
),
(
    1,
    'Skibidi toilet',
    'Thomas Turbato',
    1690,
    "Skibidi toilet è un fenomeno virale che ha conquistato internet con la sua combinazione di musica orecchiabile e coreografie stravaganti. Il video originale, pubblicato su YouTube, mostra persone che ballano in modo bizzarro mentre indossano costumi da bagno e si muovono in modo sincronizzato. La canzone, con il suo ritmo contagioso, ha ispirato milioni di persone a creare i propri video di danza Skibidi, rendendo il fenomeno un successo globale. La popolarità del Skibidi toilet ha dimostrato come la creatività e l'umorismo possano unire le persone attraverso i social media, creando una comunità globale di fan che condividono la loro passione per questa stravagante tendenza.",
    'Aglio su pasta',
    'https://m.media-amazon.com/images/M/MV5BMzgzMzY2MmMtMWNkNy00ZjVkLWIxOWUtZDJjODNmY2IyOWFiXkEyXkFqcGc@._V1_QL75_UX190_CR0,28,190,281_.jpg',
    NULL
);

RENAME TABLE old_table_name TO new_table_name;

ALTER TABLE artworks
RENAME COLUMN year TO created_year;

DROP TABLE IF EXISTS tickets;
DROP TABLE IF EXISTS reservations;
DROP TABLE IF EXISTS guided_tours;
DROP TABLE IF EXISTS artworks;
DROP TABLE IF EXISTS ticket_types;
DROP TABLE IF EXISTS visitors;
DROP TABLE IF EXISTS exhibitions;