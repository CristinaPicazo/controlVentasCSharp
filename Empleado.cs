using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio5
{
    internal class Empleado
    {
        private String nombre;
        private int edad;
        private List<double> listaVentas;
        private double totalVentas;

        //Propiedades
        public String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public int Edad {
            get
            {
                return edad;
            }
            //TODO no dejar introducir número por encima o por debajo;
            set
            {
                if(value >= 0 && value <= 100)
                {
                    edad = value;
                }
            }
        }

        public List<double> ListaVentas {
            get//TODO salta al borrar todas las ventas, no puede estar vacío?
            {
                return ListaVentas;
            }
            set
            {
                listaVentas = value;
            }            
        }

        public double TotalVentas
        {
            get
            {
                return totalVentas;
            }
            set
            {
                totalVentas = value;
            }
        }



        //Constructor
        public Empleado()
        {
            nombre = "";
            edad = 0;
            this.listaVentas = new List<double>();
        }
        public Empleado(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.listaVentas = new  List<double>();
        }        
      
        public void BorrarEmpleado()
        {
            string texto = "Empleado";
            texto += "\n Nombre: " + Nombre;
            texto += "\n Edad: "+ Edad;

            MessageBox.Show("Empleado borrado");
        } 
        
        public string MostrarEmpleado()
        {
            string texto = "Datos de empleado:";

            texto += "\n Nombre: " + Nombre;
            texto += "\n Edad: "+ Edad;
            texto += "\n Ventas: "+MostarVentas();

            return texto;
        }
        
        public void anadirVenta(double venta)
        {
            if(venta > 0)
            {
                listaVentas.Add(venta);
                TotalVentas += venta;

            }
            else
            {
                MessageBox.Show("La cantidad tiene que ser mayor de 0");
            }
        }

        //mostrar venta
        public string MostarVentas()
        {
            string texto = "";
            foreach (var venta in listaVentas)
            {
                texto += "\n\t"+venta.ToString()+ "€";
            }
            texto += "\nTotal: " + TotalVentas + "€";
            return texto;
        }





    }
}
