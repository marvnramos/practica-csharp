using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargarInformacion(); 
        }

        public class Alumno
        {
            public string Nombre { get; set; }
            public int Edad { get; set; }
            public string NumeroEstudiante { get; set; }
            public string Correo { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
        }

        public class AlumnosList
        {
            public List<Alumno> Alumnos { get; set; }
        }

        private AlumnosList LeerJson()
        {
            try
            {
                string json = File.ReadAllText("C:\\Users\\PC\\Desktop\\repos\\practica-csharp\\Ejercicio1\\Ejercicio1\\alumnos.json"); // cambiar la ruta de archivo
                AlumnosList alumnosList = JsonConvert.DeserializeObject<AlumnosList>(json);
                return alumnosList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo JSON: " + ex.Message);
                return null;
            }
        }

        private void MostrarInformacionAlumno(Alumno alumno)
        {
            labelNombre.Text = "Nombre: " + alumno.Nombre;
            labelEdad.Text = "Edad: " + alumno.Edad.ToString();
            labelNumeroEstudiante.Text = "Número de Estudiante: " + alumno.NumeroEstudiante;
            labelCorreo.Text = "Correo: " + alumno.Correo;
            labelDireccion.Text = "Dirección: " + alumno.Direccion;
            labelTelefono.Text = "Teléfono: " + alumno.Telefono;
        }


        // Método para cargar y mostrar la información del primer alumno
        private void CargarInformacion()
        {
            AlumnosList listaAlumnos = LeerJson();
            if (listaAlumnos != null && listaAlumnos.Alumnos.Count > 0)
            {
                MostrarInformacionAlumno(listaAlumnos.Alumnos[0]); // Mostramos el primer alumno
            }
            else
            {
                MessageBox.Show("No se encontraron alumnos en el archivo JSON.");
            }
        }
    }
}
