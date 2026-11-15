using System;

namespace ControlInventario
{
    // Clase Producto
    class Producto
    {
        // Estos son los campos privados
        private string codigo;
        private string nombre;
        private decimal precio;
        private int cantidad;

        // Propiedad Codigo
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        // Propiedad Nombre
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "El nombre no puede estar vacío."
                    );
                }

                nombre = value;
            }
        }

        // Propiedad Precio
        public decimal Precio
        {
            get { return precio; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El precio debe ser mayor que cero."
                    );
                }

                precio = value;
            }
        }

        // Propiedad Cantidad
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "La cantidad no puede ser negativa."
                    );
                }

                cantidad = value;
            }
        }

        // Propiedad de solo lectura
        public decimal ValorTotal
        {
            get { return Precio * Cantidad; }
        }

        // Constructor
        public Producto(string codigo, string nombre,
                        decimal precio, int cantidad)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        // Método 
        public void MostrarInfo()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.WriteLine("      INFORMACION DEL PRODUCTO");
            Console.WriteLine("");
            Console.WriteLine("Codigo: " + Codigo);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Precio: " + Precio.ToString("N2"));
            Console.WriteLine("Cantidad: " + Cantidad);
            Console.WriteLine("Valor Total: " + ValorTotal.ToString("N2"));
            Console.WriteLine("-------------------------------------");
        }
    }

    // Clase principal
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("   INVENTARIO DE TECNOPUNTO");
            Console.WriteLine("--------------------------------------");

            // Crear los tres objetos
            Producto producto1 = RegistrarProducto(1);

            Producto producto2 = RegistrarProducto(2);

            Producto producto3 = RegistrarProducto(3);

            // Mostrar los resultados
            Console.WriteLine("-------- INVENTARIO FINAL -------");

            producto1.MostrarInfo();

            producto2.MostrarInfo();

            producto3.MostrarInfo();

            Console.WriteLine("\nTodos los productos fueron registrados.");
            Console.WriteLine("Presione una tecla para salir.");

            Console.ReadKey();
        }

        // Este seria el metodo de todo eso para registrar los productos
        static Producto RegistrarProducto(int numero)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nRegistro del producto #" + numero);

                    Console.Write("Ingrese el codigo: ");
                    string codigo = Console.ReadLine() ?? "";

                    Console.Write("Ingrese el nombre: ");
                    string nombre = Console.ReadLine() ?? "";

                    Console.Write("Ingrese el precio: ");
                    decimal precio;

                    if (!decimal.TryParse(Console.ReadLine(), out precio))
                    {
                        throw new ArgumentException(
                            "Debe ingresar un precio valido."
                        );
                    }

                    Console.Write("Ingrese la cantidad: ");
                    int cantidad;

                    if (!int.TryParse(Console.ReadLine(), out cantidad))
                    {
                        throw new ArgumentException(
                            "Debe ingresar una cantidad valida."
                        );
                    }

                    // Aqui creamos el objeto
                    Producto nuevoProducto = new Producto(
                        codigo, nombre, precio, cantidad
                    );

                    Console.WriteLine(
                        "\nProducto registrado correctamente."
                    );

                    return nuevoProducto;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("\nERROR: " + ex.Message);
                    Console.WriteLine("Por favor, intente nuevamente.");
                }
            }
        }
    }
}