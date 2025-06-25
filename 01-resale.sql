
cREATE TABLE resales (
    id UUID PRIMARY KEY,
    cnpj VARCHAR(20),
    razao_social VARCHAR(200),
    name VARCHAR(150)
);

CREATE TABLE delivery_addresses (
    id UUID PRIMARY KEY,
    street VARCHAR(200),
    city VARCHAR(100),
    zip_code VARCHAR(20),
    country VARCHAR(100),
    resale_id UUID NOT NULL,
    CONSTRAINT fk_delivery_resale FOREIGN KEY (resale_id) REFERENCES resales(id) ON DELETE CASCADE
);

CREATE TABLE contacts (
    id UUID PRIMARY KEY,
    telephone VARCHAR(20),
    responsible VARCHAR(100),
    resale_id UUID NOT NULL,
    CONSTRAINT fk_contact_resale FOREIGN KEY (resale_id) REFERENCES resales(id) ON DELETE CASCADE
);

CREATE TABLE orders (
    id UUID PRIMARY KEY,
    request TIMESTAMP NOT NULL,
    status INTEGER NOT NULL,
    id_resale UUID NOT NULL,
    id_delivery_address UUID NOT NULL,
    CONSTRAINT fk_order_resale FOREIGN KEY (id_resale) REFERENCES resales(id) ON DELETE RESTRICT,
    CONSTRAINT fk_order_delivery FOREIGN KEY (id_delivery_address) REFERENCES delivery_addresses(id) ON DELETE RESTRICT
);

CREATE TABLE items (
    id UUID PRIMARY KEY,
    description VARCHAR(200),
    amount INTEGER NOT NULL,
    sku VARCHAR(255),
    id_order UUID NOT NULL,
    CONSTRAINT fk_items_order FOREIGN KEY (id_order) REFERENCES orders(id) ON DELETE CASCADE
);
