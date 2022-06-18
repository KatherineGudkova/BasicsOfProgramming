SELECT Edition.NameEdition as [Назва видання],
       TypeEdition.TypeEdition as [Тип видання]
FROM Edition
INNER JOIN  TypeEdition ON TypeEdition.IDTypeEdition = Edition.IDTypeEdition
ORDER BY TypeEdition.TypeEdition, Edition.NameEdition;