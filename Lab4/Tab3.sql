SELECT Advertisers.Surname AS [Прізвище],
       Advertisers.Name AS [Ім'я],
	   Advertisers.Secname AS [По батькові],
	   Advertisers.Address AS [Адреса],
	   Advertisers.PhoneNumber AS [Номер телефону]
	   FROM Advertisers
	   ORDER BY Advertisers.Surname,Advertisers.Name,Advertisers.Address;