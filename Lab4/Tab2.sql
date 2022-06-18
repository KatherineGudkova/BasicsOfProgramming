SELECT Products.IDProducts as [Код продукції],
       Products.NameProducts as [Назва],
	   TypeProducts.TypeProducts as [Вид продукції]

	   FROM Products
	   INNER JOIN TypeProducts ON TypeProducts.IDTypeProducts = Products.IDTypeProducts

	   ORDER BY Products.NameProducts, TypeProducts.TypeProducts;