SELECT Products.IDProducts as [��� ���������],
       Products.NameProducts as [�����],
	   TypeProducts.TypeProducts as [��� ���������]

	   FROM Products
	   INNER JOIN TypeProducts ON TypeProducts.IDTypeProducts = Products.IDTypeProducts

	   ORDER BY Products.NameProducts, TypeProducts.TypeProducts;