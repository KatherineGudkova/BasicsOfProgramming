SELECT Edition.NameEdition as [����� �������],
       TypeEdition.TypeEdition as [��� �������]
FROM Edition
INNER JOIN  TypeEdition ON TypeEdition.IDTypeEdition = Edition.IDTypeEdition
ORDER BY TypeEdition.TypeEdition, Edition.NameEdition;