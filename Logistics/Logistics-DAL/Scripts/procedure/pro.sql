USE yungalaxy_z_251;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_base_country_insert$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_base_country_insert(
_TenantID bigint(20),
_ID bigint(20),
_englishName varchar(250),
_code varchar(250),
_chineseName varchar(200),
_CreatedBy bigint,
_ModifiedBy bigint)
BEGIN
	INSERT INTO logistics_base_country(
	TenantID,ID,englishName,code,chineseName,Created,Modified,CreatedBy,ModifiedBy
	)VALUES(
	_TenantID,_ID,_englishName,_code,_chineseName,now(),now(),_CreatedBy,_ModifiedBy
	)ON DUPLICATE KEY UPDATE englishName =_englishName, code =_code, chineseName =_chineseName,Modified = NOW(),ModifiedBy =_ModifiedBy;

end
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_base_role_user_binding_Insert$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_base_role_user_binding_Insert(
_TenantID bigint(20),
_ID bigint(20),
_RoleID bigint(20),
_Userid bigint(20),
_CreatedBy bigint(20),
_ModifiedBy bigint(20))
BEGIN
	INSERT INTO logistics_base_role_user_binding(
	TenantID,ID,RoleID,Userid,Created,Modified,CreatedBy,ModifiedBy
	)VALUES(
	_TenantID,_ID,_RoleID,_Userid,now(),now(),_CreatedBy,_ModifiedBy
	) ON DUPLICATE KEY UPDATE ID =_ID, RoleID =_RoleID, Userid =_Userid,Modified = NOW(),ModifiedBy =_ModifiedBy;

END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_base_sms_validate_check$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_base_sms_validate_check(
 _TenantID bigint(20),
_Tel nvarchar(200),
_Mail nvarchar(200),
_code nvarchar(50),
_startTime datetime,
_endTime datetime)
BEGIN
     select * from logistics_base_sms_validate where tenantID = _TenantID and (Tel=_Tel OR mail =_Mail) and code = _code and (_startTime >= startTime and _endTime <=endTime);
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_base_sms_validate_insert$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_base_sms_validate_insert(_TenantID bigint(20),
_ID bigint(20),
_mail nvarchar(255),
_tel nvarchar(50),
_code nvarchar(50),
_startTime datetime,
_endTime datetime,
_CreatedBy bigint,
_ModifiedBy bigint)
BEGIN
 INSERT INTO logistics_base_sms_validate(
	TenantID,ID,mail,tel,code,startTime,endTime,Created,Modified,CreatedBy,ModifiedBy
	)VALUES(
	_TenantID,_ID,_mail,_tel,_code,_startTime,_endTime,now(),now(),_CreatedBy,_ModifiedBy
	) ON DUPLICATE KEY UPDATE
  mail=_mail,tel=_tel,code = _code,startTime=_startTime,endtime = _endtime,Modified = NOW(),ModifiedBy =_ModifiedBy;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_base_sms_validate_select$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_base_sms_validate_select(
 _TenantID bigint(20),
_Tel nvarchar(200),
  _Mail nvarchar(200))
BEGIN
     SELECT * from logistics_base_sms_validate 
      where tenantID = _TenantID and IF(_Tel IS NULL, 1 = 1, tel = _Tel) AND IF(_Mail IS NULL, 1 = 1, mail = _Mail)
     ORDER BY  Created DESC limit 1;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_base_userinfo_insert$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_base_userinfo_insert(IN _TenantID bigint(20), IN _Userid bigint(20), IN _Email nvarchar(200), IN _Token text, IN _Username nvarchar(200), IN _Pwd blob, IN _Tel nvarchar(200), IN _WebChatID nvarchar(200), IN _MemeberCode nvarchar(200), IN _CreatedBy bigint(20), IN _ModifiedBy bigint(20))
BEGIN

  INSERT INTO logistics_base_userinfo (TenantID
  , Userid
  , Email
  , Token
  , Username
  , pwd
  , Tel
  , WebChatID
  , MemeberCode
  , LastLoginTime
  , Created
  , Modified
  , CreatedBy
  , ModifiedBy)
    VALUES (_TenantID -- TenantID - BIGINT(20) NOT NULL
    , _Userid-- Userid - BIGINT(20) NOT NULL
    , _Email -- Email - VARCHAR(250)
    , _Token -- Token - VARCHAR(200)
    , _Username -- Username - VARCHAR(200)
    , _Pwd -- Pwd - VARCHAR(200)
    , _Tel -- Tel - VARCHAR(200)
    , _WebChatID -- WebChatID - VARCHAR(500)
    , _MemeberCode -- MemeberCode - VARCHAR(200)
    , NOW() -- LastLoginTime - TIMESTAMP
    , NOW() -- Created - TIMESTAMP(3)
    , NOW() -- Modified - TIMESTAMP(3)
    , _CreatedBy -- CreatedBy - BIGINT(20)
    , _ModifiedBy -- ModifiedBy - BIGINT(20)
    ) ON DUPLICATE KEY UPDATE TenantID = _TenantID, Email = _Email, Token = _Token, Username = _Username, pwd = _Pwd, Tel = _Tel,
  WebChatID = _WebChatID, MemeberCode = _MemeberCode, LastLoginTime = NOW(), Modified = NOW(),ModifiedBy =_ModifiedBy;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_base_userinfo_select$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_base_userinfo_select(IN _TenantID bigint(20), IN _User nvarchar(200), IN _Pwd blob)
BEGIN
  SELECT
    *
  FROM yungalaxy_z_251.logistics_base_userinfo
  WHERE (Tel = _User
  OR Email = _User)
  AND TenantID = _TenantID
  AND pwd = _Pwd;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_base_userinfo_update_pwd$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_base_userinfo_update_pwd(IN _TenantID bigint(20), IN _Userid bigint(20), IN _Pwd blob, IN _ModifiedBy bigint(20))
BEGIN
  UPDATE logistics_base_userinfo lbu
  SET lbu.Pwd = _Pwd,
      lbu.ModifiedBy = _ModifiedBy
  WHERE lbu.Userid = _Userid
  AND lbu.TenantID = _TenantID;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_base_userInfo_validate$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_base_userInfo_validate(IN _TenantID bigint(20), IN _User nvarchar(200))
BEGIN
  SELECT
    *
  FROM yungalaxy_z_251.logistics_base_userinfo
  WHERE (Tel = _User
  OR Email = _User)
  AND TenantID = _TenantID ORDER BY Created DESC LIMIT 1;

END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_businessnorule_update_currentNo$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_businessnorule_update_currentNo(IN _DefKey varchar(255), OUT _CurrentNo varchar(500))
BEGIN

  SET @tempNo = 0;
  SET @prefix = '';
  SET @Nolenght = 0;

  UPDATE logistics_businessnorule
  SET CurrentNo = (@tempNo := IF(CurrentNo = 0, StartIndex, CurrentNo + AutoIncrement)),
      Prefix = (@prefix := Prefix),
      CustomLength = (@Nolenght := CustomLength)
  WHERE DefKey = _DefKey;

  IF ROW_COUNT() > 0
  THEN
    WHILE LENGTH(@tempNo) < @Nolenght
      DO
      SET @tempNo = CONCAT('0', @tempNo);
    END WHILE;

    SET _CurrentNo =REPLACE(@prefix,'{index}', @tempNo);
  END IF;

END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_Demo_Delete_By_ID$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_Demo_Delete_By_ID(IN _ID bigint(20),
IN _TenantID bigint)
BEGIN
  DELETE
    FROM yungalaxy_z_251.logistics_demo WHERE ID = _ID AND TenantID = _TenantID;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_Demo_Insert$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_Demo_Insert(_TenantID bigint(20),
_ID bigint(20),
_Name nvarchar(250),
_CreatedBy bigint(20)  )
BEGIN
 INSERT INTO logistics_demo(TenantID,id,name,CreatedBy,ModifiedBy) 
  VALUES(_TenantID,_ID, _Name,_CreatedBy,_CreatedBy) ON DUPLICATE KEY UPDATE
  name=_Name,ModifiedBy=_CreatedBy;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_Demo_Modify_By_ID$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_Demo_Modify_By_ID(IN _ID bigint(20),
IN _TenantID bigint,
  IN _Name nvarchar(250))
BEGIN
  UPDATE
    yungalaxy_z_251.logistics_demo SET
     Name = _Name WHERE ID = _ID AND TenantID = _TenantID;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_Demo_Select_By_ID$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_Demo_Select_By_ID(IN _ID bigint(20),
IN _TenantID bigint)
BEGIN
  SELECT
   * FROM yungalaxy_z_251.logistics_demo WHERE ID = _ID AND TenantID = _TenantID;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_Demo_Select_By_Name$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_Demo_Select_By_Name(IN _Name nvarchar(20),
IN _TenantID bigint,
IN _CreatedBy bigint,
IN _PageIndex int,
IN _PageSize int,
OUT _TotalCount int)
BEGIN
  SET _PageIndex = (_PageIndex - 1) * _PageSize;
  SELECT
    *
  FROM logistics_demo
  WHERE TenantID = _TenantID
  AND IF(_Name != '', Name = _Name, 1 = 1)
  AND CreatedBy = _CreatedBy
  ORDER BY Created DESC LIMIT _PageIndex, _PageSize;

  SET _TotalCount = (SELECT
      COUNT(1)
    FROM logistics_demo
    WHERE TenantID = _TenantID
    AND IF(_Name != '', Name = _Name, 1 = 1)
    AND CreatedBy = _CreatedBy);
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_quotation_channel_select_all$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_quotation_channel_select_all(
 _TenantID bigint(20))
BEGIN
    select * from logistics_quotation_channel where TenantID =_TenantID;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_quotation_country_by_name$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_quotation_country_by_name(_TenantID bigint(20),
_name nvarchar(255))
BEGIN

  SELECT
    *
  FROM logistics_base_country lbc

  WHERE 
   IF(_name IS NULL,1=1,lbc.englishName LIKE CONCAT('%',_name,'%') OR lbc.code LIKE CONCAT('%',_name,'%') OR lbc.chineseName LIKE CONCAT('%',_name,'%')) ;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_quotation_partition_country_insert$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_quotation_partition_country_insert(
_TenantID bigint(20),
_ID bigint(20),
_countryEnglishName varchar(100),
_countryChineseName varchar(100),
_countryCode varchar(50),
_ChannelID bigint(20),
_partitionID bigint(20),
_CreatedBy bigint(20),
_ModifiedBy bigint(20))
BEGIN
  

	INSERT INTO logistics_quotation_partition_country(
	TenantID,ID,countryEnglishName,countryChineseName,countryCode,ChannelID,partitionID,Created,Modified,CreatedBy,ModifiedBy
	)VALUES(
	_TenantID,_ID,_countryEnglishName,_countryChineseName,_countryCode,_ChannelID,_partitionID,NOW(),NOW(),_CreatedBy,_ModifiedBy
	) ON DUPLICATE KEY UPDATE countryEnglishName =_countryEnglishName,countryChineseName = _countryChineseName, countryCode =_countryCode,ChannelID =_ChannelID,partitionID =_partitionID,Modified = NOW(),ModifiedBy =_ModifiedBy;

 END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_quotation_partition_insert$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_quotation_partition_insert(
_TenantID bigint(200),
_ID bigint,
_partitionCode varchar(100),
_ChannelID bigint(200),
_CreatedBy bigint(200),
_ModifiedBy bigint(200))
BEGIN
	INSERT INTO logistics_quotation_partition(
	TenantID,ID,partitionCode,ChannelID,Created,Modified,CreatedBy,ModifiedBy
	)VALUES(
	_TenantID,_ID,_partitionCode,_ChannelID,now(),now(),_CreatedBy,_ModifiedBy
	) ON DUPLICATE KEY UPDATE partitionCode =_partitionCode,ChannelID = _ChannelID,Modified = NOW(),ModifiedBy =_ModifiedBy;

end
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_quotation_partition_ipf_price_Insert$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_quotation_partition_ipf_price_Insert(
_TenantID bigint,
_ID bigint,
_firstHeavyPrice decimal(15,2),
_continuedHeavyPrice decimal(15,2),
_channelID bigint,
_partitionID bigint,
_beginHeavy decimal(15,2),
_endHeavy decimal(15,2),
_price decimal(15,2),
_CreatedBy bigint,
_ModifiedBy bigint)
BEGIN
 	INSERT INTO logistics_quotation_partition_ipf_price(
	TenantID,ID,firstHeavyPrice,continuedHeavyPrice,channelID,partitionID,beginHeavy,endHeavy,price,Created,Modified,CreatedBy,ModifiedBy)
    VALUES(_TenantID,_ID,_firstHeavyPrice,_continuedHeavyPrice,_channelID,_partitionID,_beginHeavy,_endHeavy,_price,NOW(),NOW(),_CreatedBy,_ModifiedBy) ON DUPLICATE KEY UPDATE
   firstHeavyPrice =_firstHeavyPrice,
   continuedHeavyPrice = _continuedHeavyPrice,
   channelID = _channelID,
   partitionID = _partitionID,
   beginHeavy = _beginHeavy,
   endHeavy =_endHeavy,
   price = _price,
   ModifiedBy=_ModifiedBy,
    Modified = NOW();
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_quotation_partition_price_Insert$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_quotation_partition_price_Insert(
_TenantID bigint,
_ID bigint,
_firstHeavyPrice decimal(15,2),
_continuedHeavyPrice decimal(15,2),
_channelID bigint,
_partitionID bigint,
_beginHeavy decimal(15,2),
_endHeavy decimal(15,2),
_price decimal(15,2),
_CreatedBy bigint,
_ModifiedBy bigint)
BEGIN
 	INSERT INTO logistics_quotation_partition_price(
	TenantID,ID,firstHeavyPrice,continuedHeavyPrice,channelID,partitionID,beginHeavy,endHeavy,price,Created,Modified,CreatedBy,ModifiedBy)
    VALUES(_TenantID,_ID,_firstHeavyPrice,_continuedHeavyPrice,_channelID,_partitionID,_beginHeavy,_endHeavy,_price,NOW(),NOW(),_CreatedBy,_ModifiedBy) ON DUPLICATE KEY UPDATE
   firstHeavyPrice =_firstHeavyPrice,
   continuedHeavyPrice = _continuedHeavyPrice,
   channelID = _channelID,
   partitionID = _partitionID,
   beginHeavy = _beginHeavy,
   endHeavy =_endHeavy,
   price = _price,
   ModifiedBy=_ModifiedBy, Modified = NOW();
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_quotation_partition_price_select_by_country$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_quotation_partition_price_select_by_country(
 _TenantID bigint(20),
_partitionID bigint(20))
BEGIN
    
     select * from yungalaxy_z_251.logistics_quotation_partition_price lqpp LEFT JOIN logistics_quotation_partition lqp
      ON lqpp.partitionID = lqp.ID
      
      where lqpp.tenantID = _TenantID and lqpp.partitionID=_partitionID;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_quotation_partition_select_by_Code_channelID$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_quotation_partition_select_by_Code_channelID(
 _TenantID bigint(20),
_code nvarchar(200),
  _channelID bigint(200))
BEGIN
    SELECT * FROM logistics_quotation_partition lqp WHERE lqp.TenantID = _TenantID and lqp.partitionCode = _code and lqp.ChannelID = _channelID;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_quotation_partition_select_by_country$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_quotation_partition_select_by_country(
 _TenantID bigint(20),
_country nvarchar(200),
  _channelID bigint(200))
BEGIN
     select * from yungalaxy_z_251.logistics_quotation_partition_country
     where (countryEnglishName like concat('%',_country,'%') or countryChineseName like concat('%',_country,'%') or  countryCode like concat('%',_country,'%')) AND channelID =_channelID AND TenantID =_TenantID;
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_select_ipf_price_by_partitionid_weight$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_select_ipf_price_by_partitionid_weight(IN _TenantID bigint(20), IN _partitionID bigint(20), IN _weight decimal(15,2))
BEGIN
    
     select * from logistics_quotation_partition_ipf_price lqpp
      where lqpp.tenantID = _TenantID and lqpp.partitionID=_partitionID AND (lqpp.beginHeavy< _weight AND lqpp.endHeavy >= _weight);
END
$$

DELIMITER ;

DELIMITER $$


DROP PROCEDURE IF EXISTS logistics_select_price_by_partitionID_weight$$

CREATE DEFINER = 'admin_test'@'%'
PROCEDURE logistics_select_price_by_partitionID_weight(IN _TenantID bigint(20), IN _partitionID bigint(20), IN _weight decimal(15,2))
BEGIN
    
     select * from logistics_quotation_partition_price lqpp
      where lqpp.tenantID = _TenantID and lqpp.partitionID=_partitionID AND (lqpp.beginHeavy< _weight AND lqpp.endHeavy >= _weight);
END
$$

DELIMITER ;