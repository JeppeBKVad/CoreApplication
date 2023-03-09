use coreappdb;

CREATE TABLE users (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  username VARCHAR(255) NOT NULL,
  password VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  status ENUM('active', 'inactive', 'unverified') NOT NULL DEFAULT 'unverified',
  created_by INT NOT NULL,
  last_edited_by INT NOT NULL,
  created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP(),
  modified_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP(),
  UNIQUE INDEX uk_username(username),
  UNIQUE INDEX uk_email(email)
);
