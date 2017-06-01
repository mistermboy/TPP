using System;
using System.Collections.Generic;
using System.Linq;

namespace ejJoinMSDN
{
    class Modelo
    {
        public Modelo()
        {
            cart.Add(productsWithOutVat[0], 4);
            cart.Add(productsWithOutVat[1], 2);
            cart.Add(productsWithOutVat[3], 3);
        }


        class Product
        {
            public string Name { get; set; }

            public int CategoryID { get; set; }

        }

        class ProductWithOutVat
        {
            public string Name { get; set; }

            public int VatID { get; set; }

            public double Price { get; set; }

            public int CategoryID { get; set; }
            public override string ToString()
            {
                return String.Format("{0} {1} {2} {3}", Name, Price, VatID, CategoryID);
            }
        }

        class Category
        {
            public string Name { get; set; }

            public int ID { get; set; }
        }

        class Vat
        {
            public string Name { get; set; }

            public double Value { get; set; }

            public double VatID { get; set; }
        }
        #region Data
        // Specify the first data source.   CATEGORIAS
        List<Category> categories = new List<Category>()
    { 
        new Category (){Name="Beverages", ID=001},
        new Category (){ Name="Condiments", ID=002},
        new Category (){ Name="Vegetables", ID=003},
        new Category () {  Name="Grains", ID=004},
        new Category () {  Name="Fruit", ID=005},
		new Category () {  Name="Books", ID=006},
		new Category () {  Name="Gadgets", ID=007},	
		
    };


        // VAT  IVA
        List<Vat> currentVat = new List<Vat>()
		{
		new 	Vat{Name="Super Reduced",Value=0.04,VatID=001},
		new 	Vat{Name="Reduced",Value=0.10,VatID=002},
		new 	Vat{Name="General",Value=0.21,VatID=003},	
		};

        // Specify the second data source.
        List<ProductWithOutVat> productsWithOutVat = new List<ProductWithOutVat>()
   {
      new ProductWithOutVat{Name="Cola", Price=1.0, VatID=002, CategoryID=001},
      new ProductWithOutVat{Name="Tea",  Price=2.0, VatID=002, CategoryID=001},
      new ProductWithOutVat{Name="Mustard", Price=3.0, VatID=002, CategoryID=002},
      new ProductWithOutVat{Name="Pickles", Price=1.0, VatID=001, CategoryID=002},
      new ProductWithOutVat{Name="Carrots", Price=2.5, VatID=001, CategoryID=003},
      new ProductWithOutVat{Name="Bread", Price=2.0, VatID=001, CategoryID=003},
      new ProductWithOutVat{Name="Peaches", Price=3.0, VatID=002, CategoryID=005},
      new ProductWithOutVat{Name="Melons", Price=1.5, VatID=002, CategoryID=005},
	  new ProductWithOutVat{Name="Transcendental Crystallography", Price=20.0,VatID=001,CategoryID=006},
	  new ProductWithOutVat{Name="eYePhone", Price=666,VatID=003,CategoryID=007}
    };
        Dictionary<ProductWithOutVat, int> cart = new Dictionary<ProductWithOutVat, int>();

        #endregion
        //1)
        private void ej1()
        {
            var consulta = productsWithOutVat.Where(x => x.Price < 2.0);
            foreach (var item in consulta )
                Console.WriteLine(item.Name);

            //si se ha definido ForEach como método extensor de IEnumerable se puede hacer así:
            //productsWithVat.Where(x => x.Price < 2.0).Select(p=>p.Name).ForEach(Console.WriteLine);
        }

        private void ej2()
        {
            var consulta = productsWithOutVat.Join(currentVat, p => p.VatID, c => c.VatID,(p,c)=> new {nombre=p.Name,precio=p.Price,iva=c.Value});
            foreach (var item in consulta)
                Console.WriteLine("{0} {1} {2}",item.nombre,item.precio,item.iva);
        }

        private void ej3()
        {
            var consulta = productsWithOutVat.Join(currentVat, p => p.VatID, c => c.VatID, (p, c) => new { nombre = p.Name, precio = p.Price*(1 + c.Value) });
            foreach (var item in consulta)
                Console.WriteLine("{0} {1}", item.nombre, item.precio);
        }

        private void ej4()
        {
            var consulta = productsWithOutVat.Join(currentVat,p => p.VatID, c => c.VatID, 
                (p, c) => new { nombre = p.Name,nombreIVA=c.Name,catID=p.CategoryID})
                .Join(categories, x => x.catID, c => c.ID, (x, c) => new {nombre=x.nombre, nombreCat = c.Name,nombreIva=x.nombreIVA });

            foreach (var item in consulta)
                Console.WriteLine("{0} {1} {2}", item.nombre, item.nombreCat,item.nombreIva);
        }

        private void ej5()
        {
            var consulta = productsWithOutVat.Join(currentVat, p => p.VatID, c => c.VatID,
                (p, c) => new { nombre = p.Name, nombreIVA = c.Name, catID = p.CategoryID })
                .Join(categories, x => x.catID, c => c.ID, (x, c) => new { nombre = x.nombre, nombreCat = c.Name, nombreIva = x.nombreIVA }).OrderBy(c => c.nombreCat);

            foreach (var item in consulta)
                Console.WriteLine("{0} {1} {2}", item.nombre, item.nombreCat, item.nombreIva);
        }

        private void ej6()
        {
            var consulta = productsWithOutVat.Join(currentVat, p => p.VatID, c => c.VatID,
                (p, c) => new { nombre = p.Name, nombreIVA = c.Name, catID = p.CategoryID })
                .Join(categories, x => x.catID, c => c.ID, (x, c) => new { nombre = x.nombre, nombreCat = c.Name, nombreIva = x.nombreIVA }
                ).GroupBy(p=>p.nombreIva);

            foreach (var item in consulta)
            {
                Console.WriteLine(item.Key);
                foreach (var y in item) { 
                Console.WriteLine("\t {0} {1}", y.nombre, y.nombreCat);
                }

            }

            //consulta.ForEach(
            //    x =>
            //    {
            //        Console.WriteLine(x.Key);
            //        x.ForEach(
            //            (y) => Console.WriteLine("{0} {1} {2}", y.nombre, y.nombreCat);

            //    });
        }


        private void ej7()
        {
            var consulta = productsWithOutVat.Join(currentVat, p => p.VatID, c => c.VatID,
                (p, c) => new { nombre = p.Name, nombreIVA = c.Name, catID = p.CategoryID })
                .Join(categories, x => x.catID, c => c.ID, (x, c) => new { nombre = x.nombre, nombreCat = c.Name, nombreIva = x.nombreIVA }
                ).GroupBy(p => p.nombreCat);

            foreach (var item in consulta)
            {
                Console.WriteLine("{0} {1}",item.Key,item.Count());  
                foreach (var y in item)
                {
                    Console.WriteLine("\t {0} {1}", y.nombre, y.nombreIva);
                }

            }
        }

        private double ej8()
        {
            var precioMedio = productsWithOutVat.Join(currentVat, p => p.VatID, c => c.VatID, (p, c) => new { nombre = p.Name, precio = p.Price * (1 + c.Value) }).Average(p => p.precio);
            return precioMedio;
        }

        private double ej9()
        {
            var consulta = productsWithOutVat.Join(
                currentVat, p => p.VatID, c => c.VatID, (p, c) => new { nombre = p.Name, precio = p.Price * (1 + c.Value) })
                .Where(p => p.precio < 100)
                .Average(p=>p.precio);
            return consulta;
        }

        private double ej10()
        {
            return productsWithOutVat.Aggregate(
                (acc, x) => x.Price > acc.Price ? x : acc).Price;
        }

        //private double ej10()
        //{
        //    return productsWithOutVat.Aggregate(0.0,
        //        (acc, x) => x.Price > acc ? x.Price : acc);
        //}


        private void ej11()
        {
            var consulta = productsWithOutVat
                .Join(currentVat, p => p.VatID, v => v.VatID,
                (p, v) => new
                {
                    Name = p.Name,
                    PriceWithVat = p.Price * (1 + v.Value),
                    PriceWithOuVat = p.Price
                })
                .Aggregate((acc, x) => x.PriceWithVat < acc.PriceWithVat ? x : acc);
           Console.WriteLine("{0}:{1}",consulta.Name,consulta.PriceWithVat);
        }

        private void ej12(string categ)
        {
            var consulta = productsWithOutVat.Join(categories, p => p.CategoryID, c => c.ID,
                (p, c) => new { producto = p, categoria = c.Name })
                .Where(p => p.categoria.CompareTo(categ) == 0)
                .Select(p => p.producto);
            foreach (var item in consulta)
                Console.WriteLine(item.Name);
        }

        private void ej13()
        {
            var consulta = cart.Join(currentVat, p => p.Key.VatID, v => v.VatID,
                (p, v) => new
                {
                    name = p.Key.Name,
                    PriceWithVat = (1 + v.Value) * p.Key.Price,
                    Quanty = p.Value
                });
            foreach (var x in consulta)
                Console.WriteLine(x);
        }



        static void Main(string[] args)
        {
            Modelo datos = new Modelo();
            Console.WriteLine("####### EJERCICIO 1 #######");
            Console.WriteLine();
            datos.ej1();
            Console.WriteLine();
            Console.WriteLine("####### EJERCICIO 2 #######");
            Console.WriteLine();
            datos.ej2();
            Console.WriteLine();
            Console.WriteLine("####### EJERCICIO 3 #######");
            Console.WriteLine();
            datos.ej3();
            Console.WriteLine();
            Console.WriteLine("####### EJERCICIO 4 #######");
            Console.WriteLine();
            datos.ej4();
            Console.WriteLine();
            Console.WriteLine("####### EJERCICIO 5 #######");
            Console.WriteLine();
            datos.ej5();
            Console.WriteLine();
            Console.WriteLine("####### EJERCICIO 6 #######");
            Console.WriteLine();
            datos.ej6();
            Console.WriteLine();
            Console.WriteLine("####### EJERCICIO 7 #######");
            Console.WriteLine();
            datos.ej7();
            Console.WriteLine();
            Console.WriteLine("####### EJERCICIO 8 #######");
            Console.WriteLine();
            Console.WriteLine("Precio Medio: {0} ",datos.ej8());
            Console.WriteLine();
            Console.WriteLine("####### EJERCICIO 9 #######");
            Console.WriteLine();
            Console.WriteLine("Precio Medio de los productos cuyo precio es menor que 100: {0} ", datos.ej9());
            Console.WriteLine();
            Console.WriteLine("####### EJERCICIO 10 #######");
            Console.WriteLine();
            Console.WriteLine("Valor del precio del producto con el precio más alto: {0} ", datos.ej10());
            Console.WriteLine();
            Console.WriteLine("####### EJERCICIO 11 #######");
            Console.WriteLine();
            datos.ej11();
            Console.WriteLine();
            Console.WriteLine("####### EJERCICIO 12 #######");
            Console.WriteLine();
            datos.ej12("Beverages");
        }
    }
}