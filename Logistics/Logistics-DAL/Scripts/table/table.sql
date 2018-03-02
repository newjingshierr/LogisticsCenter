﻿USE yungalaxy_z_251;

DROP TABLE logistics_base_country;

CREATE TABLE logistics_base_country (
  TenantID bigint(20) NOT NULL COMMENT '商户ID',
  ID bigint(20) NOT NULL COMMENT 'ID',
  englishName varchar(250) NOT NULL COMMENT '英文名',
  code varchar(250) DEFAULT NULL COMMENT '简称',
  chineseName varchar(200) DEFAULT '' COMMENT '中文名',
  Created timestamp(3) NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) DEFAULT NULL,
  ModifiedBy bigint(20) DEFAULT NULL,
  PRIMARY KEY (TenantID, ID),
  INDEX IDX_userinfo (englishName, code, chineseName)
)
ENGINE = INNODB
AVG_ROW_LENGTH = 8192
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_base_log;

CREATE TABLE logistics_base_log (
  ID bigint(20) NOT NULL,
  log_Datetime timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  log_Level bit(1) DEFAULT NULL COMMENT '等级 error,Info',
  Model bit(1) DEFAULT NULL COMMENT '异常模块 1用户模块 2、权限模块',
  Message text DEFAULT NULL COMMENT '异常信息',
  Userid bigint(20) NOT NULL COMMENT '用户ID',
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (ID),
  INDEX IDX_log (log_Datetime, log_Level, Model, Userid)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_base_navigation;

CREATE TABLE logistics_base_navigation (
  TenantID bigint(20) NOT NULL,
  ID bigint(20) NOT NULL,
  Name_CN varchar(255) DEFAULT NULL,
  Name_EN varchar(255) DEFAULT NULL,
  Summary string DEFAULT NULL,
  Image string DEFAULT NULL,
  Url string DEFAULT NULL,
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  ParentID int(11) DEFAULT 0,
  SortID int(11) DEFAULT NULL,
  PRIMARY KEY (ID, TenantID),
  INDEX IDX_navigation (ParentID)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_base_navigation_role_binding;

CREATE TABLE logistics_base_navigation_role_binding (
  TenantID bigint(20) NOT NULL,
  ID bigint(20) NOT NULL,
  NavigationID bigint(20) NOT NULL,
  RoleID bigint(20) NOT NULL,
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (TenantID, ID, NavigationID, RoleID)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_base_role;

CREATE TABLE logistics_base_role (
  TenantID bigint(20) NOT NULL,
  RoleID bigint(20) NOT NULL COMMENT 'ID',
  roleName varchar(200) NOT NULL COMMENT '角色名称',
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (RoleID, TenantID),
  INDEX IDX_Role (roleName)
)
ENGINE = INNODB
AVG_ROW_LENGTH = 3276
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_base_role_user_binding;

CREATE TABLE logistics_base_role_user_binding (
  TenantID bigint(20) NOT NULL,
  ID bigint(20) NOT NULL COMMENT 'ID',
  RoleID bigint(20) NOT NULL COMMENT 'ID',
  Userid bigint(20) NOT NULL COMMENT '用户ID',
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (ID, TenantID),
  UNIQUE INDEX IDX_Role (RoleID, Userid)
)
ENGINE = INNODB
AVG_ROW_LENGTH = 16384
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_base_sms_validate;

CREATE TABLE logistics_base_sms_validate (
  TenantID bigint(20) NOT NULL,
  ID bigint(20) NOT NULL,
  mail varchar(255) DEFAULT NULL COMMENT '邮箱',
  tel varchar(50) NOT NULL COMMENT '电话',
  code varchar(50) NOT NULL COMMENT '验证码',
  startTime datetime NOT NULL COMMENT '验证码开始时间',
  endTime datetime NOT NULL COMMENT '验证码结束时间',
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (TenantID, ID),
  INDEX IDX_log (tel, code, startTime, endTime)
)
ENGINE = INNODB
AVG_ROW_LENGTH = 4096
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_base_userinfo;

CREATE TABLE logistics_base_userinfo (
  TenantID bigint(20) NOT NULL COMMENT '商户ID',
  Userid bigint(20) NOT NULL COMMENT '用户ID',
  Email varchar(250) DEFAULT NULL,
  Token varchar(200) DEFAULT '' COMMENT '用户Token',
  Username varchar(200) NOT NULL COMMENT '用户姓名',
  Pwd blob DEFAULT NULL COMMENT '用户密码',
  Tel varchar(200) DEFAULT NULL COMMENT '电话号码',
  WebChatID varchar(500) DEFAULT NULL COMMENT '微信号',
  MemeberCode varchar(200) DEFAULT NULL COMMENT '会员号',
  LastLoginTime timestamp NULL DEFAULT NULL COMMENT '最近一次登录时间',
  Created timestamp(3) NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) DEFAULT NULL,
  ModifiedBy bigint(20) DEFAULT NULL,
  PRIMARY KEY (Userid, TenantID),
  INDEX IDX_userinfo (Username, MemeberCode, Tel)
)
ENGINE = INNODB
AVG_ROW_LENGTH = 3276
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_base_userinfo_recipients_address;

CREATE TABLE logistics_base_userinfo_recipients_address (
  ID bigint(20) NOT NULL COMMENT 'ID',
  Userid bigint(20) NOT NULL COMMENT '关联用户ID',
  ProvinceID bigint(200) NOT NULL COMMENT '国家ID',
  CityID bigint(200) NOT NULL COMMENT '城市ID',
  postalcode varchar(200) NOT NULL COMMENT '邮政编码',
  Tel varchar(200) NOT NULL COMMENT '电话号码',
  Address varchar(2000) NOT NULL COMMENT '地址',
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (ID),
  INDEX IDX_userinfoadreessmangement (Userid)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_businessnorule;

CREATE TABLE logistics_businessnorule (
  DefKey varchar(255) NOT NULL COMMENT '业务标识',
  Prefix varchar(255) NOT NULL COMMENT '编号前缀 例:[QINGJIA_{date}_{time}]',
  StartIndex bigint(20) NOT NULL DEFAULT 0 COMMENT '开始编号',
  CustomLength int(11) NOT NULL DEFAULT 8 COMMENT '自定义编号长度',
  AutoIncrement int(11) NOT NULL DEFAULT 1 COMMENT '增量',
  CurrentNo bigint(20) NOT NULL DEFAULT 0 COMMENT '当前编号',
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (DefKey)
)
ENGINE = INNODB
AVG_ROW_LENGTH = 157
CHARACTER SET utf8
COLLATE utf8_general_ci
COMMENT = '业务编号规则';

DROP TABLE logistics_demo;

CREATE TABLE logistics_demo (
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
AVG_ROW_LENGTH = 2730
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_pay_integral_balance_log;

CREATE TABLE logistics_pay_integral_balance_log (
  BalanceLogID bigint(20) NOT NULL,
  BalanceID bigint(20) NOT NULL COMMENT 'balance 外键',
  OrderID bigint(20) NOT NULL COMMENT '订单ID',
  DataSource int(11) DEFAULT NULL COMMENT '数据来源',
  Type int(11) NOT NULL DEFAULT 0 COMMENT '消费类型,1 消费 2 冲正消费',
  Direction bit(1) DEFAULT NULL COMMENT '正向/反向',
  Amount decimal(15, 2) NOT NULL DEFAULT 0.00 COMMENT '使用金额',
  Orignal decimal(15, 2) NOT NULL DEFAULT 0.00 COMMENT '原始值',
  AfterBalance decimal(15, 2) NOT NULL DEFAULT 0.00 COMMENT '修改后的值',
  Comment text DEFAULT NULL COMMENT '变更时间',
  BalanceDate int(11) DEFAULT NULL COMMENT '使用时间',
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  Ext1 string DEFAULT NULL,
  Ext2 string DEFAULT NULL,
  Ext3 string DEFAULT NULL,
  PRIMARY KEY (BalanceLogID, BalanceID, OrderID),
  INDEX IDX_BalanceID (BalanceDate)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_pay_integral_transaction;

CREATE TABLE logistics_pay_integral_transaction (
  TransationID bigint(20) NOT NULL,
  OrderID bigint(20) NOT NULL DEFAULT 0,
  Amount decimal(15, 2) NOT NULL,
  DataSource int(11) NOT NULL DEFAULT 0 COMMENT '来源',
  Comment text DEFAULT NULL,
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (TransationID, OrderID)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_pay_integral_transaction_log;

CREATE TABLE logistics_pay_integral_transaction_log (
  TransationID bigint(20) NOT NULL,
  OrderID bigint(20) NOT NULL DEFAULT 0,
  Amount decimal(15, 2) NOT NULL,
  DataSource int(11) NOT NULL DEFAULT 0 COMMENT '来源',
  Comment text DEFAULT NULL,
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (TransationID, OrderID)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_pay_ntegral_balance_freeze;

CREATE TABLE logistics_pay_ntegral_balance_freeze (
  FreezeID bigint(20) NOT NULL,
  OrderID bigint(20) NOT NULL,
  BalanceID bigint(20) NOT NULL COMMENT '积分余额主表',
  BalanceLogID bigint(20) NOT NULL COMMENT 'logid',
  Amount decimal(15, 2) NOT NULL DEFAULT 0.00 COMMENT '使用金额',
  freezeDate datetime NOT NULL,
  Reason int(11) DEFAULT NULL COMMENT '解冻原因 0:审批通过 1:审批拒绝 2:流程异常 3:流程修复',
  Remark varchar(255) DEFAULT NULL,
  Status int(11) NOT NULL DEFAULT 0 COMMENT '0冻结 1解冻',
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  Ext1 string DEFAULT NULL,
  Ext2 string DEFAULT NULL,
  Ext3 string DEFAULT NULL,
  PRIMARY KEY (FreezeID, OrderID, BalanceID, BalanceLogID),
  INDEX IDX_freezeDate (freezeDate),
  INDEX IDX_Status (Status)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_pay_receiving_address_mangement;

CREATE TABLE logistics_pay_receiving_address_mangement (
  ReceivingID bigint(20) NOT NULL COMMENT 'ID',
  Userid bigint(20) NOT NULL COMMENT '关联用户ID',
  RecipientName varchar(200) NOT NULL COMMENT '收件人姓名',
  ContryID bigint(200) NOT NULL COMMENT '国家ID',
  ContryName bigint(200) NOT NULL COMMENT '国家ID',
  CityName bigint(200) NOT NULL COMMENT '城市ID',
  postalcode varchar(200) NOT NULL COMMENT '邮政编码',
  Tel varchar(200) NOT NULL COMMENT '电话号码',
  Address varchar(2000) NOT NULL COMMENT '地址',
  IsDefault bit(1) NOT NULL COMMENT '是否默认地址',
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (ReceivingID),
  INDEX IDX_receiving (Userid)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_quotation_channel;

CREATE TABLE logistics_quotation_channel (
  TenantID bigint(20) NOT NULL,
  ID bigint(20) NOT NULL,
  Name varchar(255) NOT NULL COMMENT '渠道名称',
  code varchar(255) NOT NULL COMMENT '渠道简称',
  Prescription varchar(200) DEFAULT NULL COMMENT '时效备注',
  Remark text DEFAULT NULL COMMENT '备注',
  Clause longtext DEFAULT NULL COMMENT '条款',
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (TenantID, ID, code),
  INDEX IDX_channel (Name)
)
ENGINE = INNODB
AVG_ROW_LENGTH = 4096
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_quotation_partition;

CREATE TABLE logistics_quotation_partition (
  TenantID bigint(20) NOT NULL,
  ID bigint(20) NOT NULL,
  partitionCode varchar(100) NOT NULL COMMENT '分区code',
  ChannelID bigint(20) NOT NULL DEFAULT 0 COMMENT '渠道ID',
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (TenantID, ID, partitionCode, ChannelID)
)
ENGINE = INNODB
AVG_ROW_LENGTH = 127
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_quotation_partition_country;

CREATE TABLE logistics_quotation_partition_country (
  TenantID bigint(20) NOT NULL,
  ID bigint(20) NOT NULL,
  countryEnglishName varchar(100) NOT NULL COMMENT '国家英文名',
  countryChineseName varchar(100) NOT NULL COMMENT '国家中文名',
  countryCode varchar(50) NOT NULL COMMENT '国家代码code',
  ChannelID bigint(20) NOT NULL DEFAULT 0 COMMENT '渠道ID',
  partitionID bigint(20) NOT NULL COMMENT '分区ID',
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (TenantID, ID, partitionID, countryCode, ChannelID),
  INDEX IDX_country (countryEnglishName, countryChineseName)
)
ENGINE = INNODB
AVG_ROW_LENGTH = 2730
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_quotation_partition_ipf_price;

CREATE TABLE logistics_quotation_partition_ipf_price (
  TenantID bigint(20) NOT NULL,
  ID bigint(20) NOT NULL,
  firstHeavyPrice decimal(15, 2) DEFAULT NULL COMMENT '首重价格',
  continuedHeavyPrice decimal(14, 2) DEFAULT NULL COMMENT '续重价格',
  channelID bigint(20) NOT NULL DEFAULT 0 COMMENT '渠道ID',
  partitionID bigint(20) NOT NULL DEFAULT 0 COMMENT '分区ID',
  beginHeavy decimal(15, 2) DEFAULT NULL COMMENT '起始重量',
  endHeavy decimal(15, 2) DEFAULT NULL COMMENT '结束首重',
  price decimal(15, 2) DEFAULT NULL,
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (TenantID, ID)
)
ENGINE = INNODB
AVG_ROW_LENGTH = 248
CHARACTER SET utf8
COLLATE utf8_general_ci;

DROP TABLE logistics_quotation_partition_price;

CREATE TABLE logistics_quotation_partition_price (
  TenantID bigint(20) NOT NULL,
  ID bigint(20) NOT NULL,
  firstHeavyPrice decimal(15, 2) DEFAULT NULL COMMENT '首重价格',
  continuedHeavyPrice decimal(15, 2) DEFAULT NULL COMMENT '续重价格',
  channelID bigint(20) NOT NULL DEFAULT 0 COMMENT '渠道ID',
  partitionID bigint(20) NOT NULL DEFAULT 0 COMMENT '分区ID',
  beginHeavy decimal(15, 2) DEFAULT 0.00 COMMENT '开始重量',
  endHeavy decimal(15, 2) DEFAULT 0.00 COMMENT '结束重量',
  price decimal(15, 2) DEFAULT NULL COMMENT '价格',
  Created timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3),
  Modified timestamp(3) NOT NULL DEFAULT CURRENT_TIMESTAMP (3) ON UPDATE CURRENT_TIMESTAMP (3),
  CreatedBy bigint(20) NOT NULL,
  ModifiedBy bigint(20) NOT NULL,
  PRIMARY KEY (TenantID, ID)
)
ENGINE = INNODB
AVG_ROW_LENGTH = 214
CHARACTER SET utf8
COLLATE utf8_general_ci;