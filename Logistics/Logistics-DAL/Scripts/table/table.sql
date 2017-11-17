CREATE TABLE yungalaxy_z_251.logistics_demo (
  TenantID bigint(20) NOT NULL,
  ID bigint(20) NOT NULL,
  Name varchar(20) NOT NULL,
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (TenantID, ID),
  INDEX IDX_Name (Name)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;



CREATE TABLE `log` (
`ID`  int(11) NOT NULL AUTO_INCREMENT ,
`log_datetime`  timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP ,
`log_thread`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`log_level`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`log_logger`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`log_message`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=12
ROW_FORMAT=DYNAMIC
;
