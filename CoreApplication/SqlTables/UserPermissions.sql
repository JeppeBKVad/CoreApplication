use coreappdb;

CREATE TABLE user_permissions (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  user INT NOT NULL,
  permission ENUM('owner', 'administrator', 'user') NOT NULL DEFAULT 'user',
  last_edited_by INT NOT NULL,
  created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP(),
  modified_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP(),
  FOREIGN KEY (user) REFERENCES users(id),
  FOREIGN KEY (last_edited_by) REFERENCES users(id)
);
