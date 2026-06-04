CREATE DATABASE projectwork;

USE projectwork;

CREATE TABLE exhibitions (
    id BINARY(16) PRIMARY KEY,
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
    id BINARY(16) PRIMARY KEY,
    title VARCHAR(255) NOT NULL DEFAULT 'DEFAULT_TITLE',
    author VARCHAR(255) NULL,
    created_year SMALLINT SIGNED NULL,
    description TEXT NULL,
    technique VARCHAR(255) NULL,
    image_url VARCHAR(4096) NULL,
    exhibition_id BINARY(16) NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

    CONSTRAINT fk_artworks_exhibition
        FOREIGN KEY (exhibition_id)
        REFERENCES exhibitions(id)
        ON DELETE SET NULL
);

CREATE TABLE guided_tours (
    id BINARY(16) PRIMARY KEY,
    title VARCHAR(255) NOT NULL DEFAULT 'DEFAULT_TITLE',
    description TEXT NULL,
    scheduled_at TIMESTAMP NOT NULL DEFAULT '2038-01-19 03:14:07',
    duration TIME NOT NULL DEFAULT '838:59:59',
    guide_name VARCHAR(255) NOT NULL,
    guide_surname VARCHAR(255) NOT NULL,
    max_participants SMALLINT UNSIGNED NOT NULL,
    exhibition_id BINARY(16) NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

    CONSTRAINT fk_guided_tours_exhibition
        FOREIGN KEY (exhibition_id)
        REFERENCES exhibitions(id)
        ON DELETE SET NULL
);

CREATE TABLE visitors (
    id BINARY(16) PRIMARY KEY,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE reservations (
    id BINARY(16) PRIMARY KEY,
    visitor_id BINARY(16) NOT NULL,
    guided_tour_id BINARY(16) NOT NULL,
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
    id BINARY(16) PRIMARY KEY,
    name ENUM('full', 'reduced', 'free') NOT NULL,
    base_price DECIMAL(10,2) NOT NULL DEFAULT 0.00
);

CREATE TABLE tickets (
    id BINARY(16) PRIMARY KEY,
    visitor_id BINARY(16) NOT NULL,
    ticket_type_id BINARY(16) NOT NULL,
    quantity INT NOT NULL,
    total_price DECIMAL(10,2) NOT NULL,
    purchase_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    exhibition_id BINARY(16) NULL,
    guided_tour_id BINARY(16) NULL,

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