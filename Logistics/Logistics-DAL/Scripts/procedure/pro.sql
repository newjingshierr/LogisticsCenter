CREATE DEFINER = 'admin_test'@'%'
PROCEDURE yungalaxy_z_251.logistics_Demo_Select_By_Name (IN _Name nvarchar(20),
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



CREATE DEFINER = 'admin_test'@'%'
PROCEDURE yungalaxy_z_251.logistics_Demo_Insert(_TenantID bigint(20),
_Name nvarchar(250),
_CreatedBy bigint  )
BEGIN
 INSERT INTO logistics_demo(TenantID,name,CreatedBy,ModifiedBy) 
  VALUES(_TenantID,_Name,_CreatedBy,_CreatedBy) ON DUPLICATE KEY UPDATE
  name=_Name,ModifiedBy=_CreatedBy;
END
