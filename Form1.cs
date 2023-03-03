using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ejercicio5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Empleado> listaEmpleados = new List<Empleado>();

        //introducir empleado
        private void button1_Click(object sender, EventArgs e)
        {
            string nuevoEmpleado = "empleado" + listaEmpleados.Count.ToString();  //no funciona
            Empleado emp = new Empleado();

            emp.Nombre = Interaction.InputBox("Introduzca el nombre de empleado: ");
            //emp.Edad = int.Parse(Interaction.InputBox("Introduzca su edad: "));            
            listaEmpleados.Add(emp);

            //MessageBox.Show("El empleado " + emp.Nombre + " de " + emp.Edad + " ha sido añadido.");
        }

        //eliminar empleado
        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = Interaction.InputBox("Introducir el nombre de empleado a eliminar: ");
            bool borrado = false;
            int numeroEmpleados = listaEmpleados.Count;

            for (int i = 0; i < numeroEmpleados; i++)
            {
                if (listaEmpleados[i].Nombre == nombre)
                {
                    listaEmpleados.Remove(listaEmpleados[i]);
                    borrado = true;
                    i = numeroEmpleados;
                }
            }
            if (!borrado)
            {
                MessageBox.Show("El empleado " + nombre + " no existe.");

            }

        }

        //mostrar lista empleados
        private void button3_Click(object sender, EventArgs e)
        {
            string texto = "Lista de empleados:";
            if (listaEmpleados.Count == 0)
            {
                MessageBox.Show("No existen empleados.");

            }
            foreach (var empleado in listaEmpleados)
            {
                texto += "\n" + empleado.Nombre;
            }
            MessageBox.Show(texto);
        }

        //ordenar empleados por orden alfabético
        private void button4_Click(object sender, EventArgs e)
        {
            //TODO añadir una función con for o foreach aunque esta funciona bien

            listaEmpleados.Sort(delegate (Empleado uno, Empleado dos)
            {
                return uno.Nombre.CompareTo(dos.Nombre);
            });

        }

        //mostrar datos empleado
        private void button5_Click(object sender, EventArgs e)
        {
            string nombre = Interaction.InputBox("Introducir el nombre de empleado a mostrar: ");
            string texto = "";
            bool encontrado = false;

            foreach (var empleado in listaEmpleados)
            {
                if (empleado.Nombre == nombre)
                {
                    texto = empleado.MostrarEmpleado();
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                texto = "El empleado " + nombre + " no existe.";

            }
            MessageBox.Show(texto);

        }

        //añadir ventas a empleado
        private void button6_Click(object sender, EventArgs e)
        {

            string nombre = Interaction.InputBox("Introducir el nombre de empleado para añadir venta: ");
            bool encontrado = false;

            foreach (var empleado in listaEmpleados)
            {
                if (empleado.Nombre == nombre)
                {
                    double venta = double.Parse(Interaction.InputBox("Introducir la venta en euros: "));
                    empleado.anadirVenta(venta);
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                MessageBox.Show("El empleado " + nombre + " no existe.");

            }
        }

        //mostrar empleado con mayores ventas
        private void button7_Click(object sender, EventArgs e)
        {
            string texto = "Lista:";
            double mayor = 0;
            string nombre = "";
            if (listaEmpleados.Count > 0)
            {

                foreach (var empleado in listaEmpleados)
                {
                    if (empleado.TotalVentas > mayor)
                    {
                        mayor = empleado.TotalVentas;
                        nombre = empleado.Nombre;

                    }
                }
                texto = "El empleado con mayores ventas es " + nombre + " con un total de " + mayor + "€";
            }
            else
            {
                texto = "No existen empleados";
            }
            MessageBox.Show(texto);
        }

        //eliminar las ventas de un empleado
        private void button8_Click(object sender, EventArgs e)
        {
            //TODO salta con get ListaVentas en empleado.cs

            string texto = "";
            string nombre = Interaction.InputBox("Introducir el nombre de empleado para eliminar sus ventas: ");
            bool encontrado = false;

            foreach (var empleado in listaEmpleados)
            {
                if (empleado.Nombre == nombre)
                {
                    empleado.TotalVentas = 0;
                    empleado.ListaVentas.Clear();//TODO salta aqui, linea 49 de clase
                    encontrado = true;
                    texto = "Eliminadas las ventas del empleado " + nombre;
                }
            }
            if (!encontrado)
            {
                texto = "El empleado " + nombre + " no existe.";

            }
            MessageBox.Show(texto);
        }


        //ordenar empleados por ventas
        private void button9_Click(object sender, EventArgs e)
        {
            //TODO no funciona, lo duplica
            int total = listaEmpleados.Count;  

            for (int i = 0; i < listaEmpleados.Count; i++)
            {
                for (int j = 1; j < listaEmpleados.Count - 1; j++)
                {
                    if (listaEmpleados[i].TotalVentas < listaEmpleados[j].TotalVentas)
                    {
                        listaEmpleados.Insert(i, listaEmpleados[j]);
                        listaEmpleados.Remove(listaEmpleados[j]);
                    }

                }
            }
        }
    }
}
