select * from [User]

select * from Classification

select * from Client

select * from Region

go;
--Classification, Name, Phone, Gender, City, Region, Last Purchase and Seller
--create view ClientList as
--select class.ClassificationName as Classification, client.Name, client.Phone, client.Gender, city.CityName as City, region.RegionName as Region, client.LastPurchase, seller.Name as Seller, seller.Email as Email
--	from Client client
--	inner join Classification class
--		on client.ClassificationId = class.ClassificationId
--	inner join [User] seller
--		on seller.UserId = client.SellerId
--	inner join Region region
--		on client.RegionId = region.RegionId
--	inner join City city
--		on region.CityId = city.CityId

select * from ClientList