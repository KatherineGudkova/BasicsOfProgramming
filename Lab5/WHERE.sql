SELECT PriceList.IDServices as [№], 
FormatProd.FormatName as [Формат],
TypeEdition.TypeEdition as [Тип видання],
PriceList.ResultPrice AS [Вартість]

FROM PriceList
INNER JOIN TypeEdition ON TypeEdition.IDTypeEdition = PriceList.IDTypeEdition 
INNER JOIN FormatProd ON FormatProd.IDFormat = PriceList.IDFormat
where FormatProd.IDFormat = 2 and TypeEdition.IDTypeEdition = 2;