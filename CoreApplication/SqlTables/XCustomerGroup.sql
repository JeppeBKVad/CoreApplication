use coreappdb;

CREATE TABLE x_customer_group (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `customer` INT NOT NULL,
  `group` INT NOT NULL,
  FOREIGN KEY (`customer`) REFERENCES customers(id),
  FOREIGN KEY (`group`) REFERENCES customer_groups(id)
);
