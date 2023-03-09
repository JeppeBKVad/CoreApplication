use coreappdb;

CREATE TABLE customer_groups (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  description VARCHAR(255) NOT NULL,
  owned_by INT NOT NULL,
  created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP(),
  modified_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP(),
  status ENUM('active', 'inactive', 'unverified'),
  FOREIGN KEY(owned_by) REFERENCES users(id)
);
