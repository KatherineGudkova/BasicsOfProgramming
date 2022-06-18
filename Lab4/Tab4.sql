select Edition.NameEdition as [Місто розміщення],
       Request.ReleasedateRequest as [Дата виходу],
       Request.ContentRequest as [Зміст],
	   PriceList.ResultPrice as [Вартість],
	   Request.Payment as [Відмітка про оплату],
	   Products.NameProducts as [Рекламна продукція],
	   Advertisers.Name AS [І'мя рекламодавця],
	   Advertisers.Surname AS [Прізвище рекламодавця]

	   FROM Request
	   INNER JOIN Edition ON Edition.IDEdition = Request.IDEdition
	   INNER JOIN PriceList ON PriceList.IDServices = Request.IDService
	   INNER JOIN Products ON Products.IDProducts = Request.IDProducts 
	   inner join Advertisers on Advertisers.IDAdvertisers = Request.IDAdvertisers
	   
	   where Request.Payment = 1
	   order by Request.ReleasedateRequest