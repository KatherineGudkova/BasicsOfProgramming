select Edition.NameEdition as [̳��� ���������],
       Request.ReleasedateRequest as [���� ������],
       Request.ContentRequest as [����],
	   PriceList.ResultPrice as [�������],
	   Request.Payment as [³����� ��� ������],
	   Products.NameProducts as [�������� ���������],
	   Advertisers.Name AS [�'�� ������������],
	   Advertisers.Surname AS [������� ������������]

	   FROM Request
	   INNER JOIN Edition ON Edition.IDEdition = Request.IDEdition
	   INNER JOIN PriceList ON PriceList.IDServices = Request.IDService
	   INNER JOIN Products ON Products.IDProducts = Request.IDProducts 
	   inner join Advertisers on Advertisers.IDAdvertisers = Request.IDAdvertisers
	   
	   where Request.Payment = 1
	   order by Request.ReleasedateRequest