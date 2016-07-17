merge Person.Address as target 
using (values 
	--(32526, '1970 Napca Ct.', 'Bothell',	79,	'98011'),
	(32530, '9833d Mt. Dias Blv.', 'Bothell',	79,	'98011'),
	(32531, '7484 vRoundtree Drive Rdc', 'Bothell',	79,	'98011')
) as source (AddressId, AddressLine1, City, StateProvinceID, PostalCode)
on source.AddressId = target.AddressId
when matched and 
	BINARY_CHECKSUM (source.AddressId, source.AddressLine1, source.City, source.StateProvinceID, source.PostalCode) !=
	BINARY_CHECKSUM (target.AddressId, target.AddressLine1, target.City, target.StateProvinceID, target.PostalCode)
then update set
	AddressLine1 = source.AddressLine1,
	City = source.City,
	StateProvinceID = source.StateProvinceID,
	PostalCode = source.PostalCode
when not matched by target then insert (AddressLine1, City, StateProvinceID, PostalCode)
	values (source.AddressLine1, source.City, source.StateProvinceID, source.PostalCode)
when not matched by source and target.addressid in (32530,32526,32531) 
then delete;