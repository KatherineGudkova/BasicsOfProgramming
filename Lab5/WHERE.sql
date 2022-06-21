SELECT PriceList.IDServices as [�], 
FormatProd.FormatName as [������],
TypeEdition.TypeEdition as [��� �������],
PriceList.ResultPrice AS [�������]

FROM PriceList
INNER JOIN TypeEdition ON TypeEdition.IDTypeEdition = PriceList.IDTypeEdition 
INNER JOIN FormatProd ON FormatProd.IDFormat = PriceList.IDFormat
where FormatProd.IDFormat = 2 and TypeEdition.IDTypeEdition = 2;