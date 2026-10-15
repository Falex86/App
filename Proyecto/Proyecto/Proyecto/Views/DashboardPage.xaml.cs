using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Proyecto.Models;

namespace HelloWorldMVVM.Views
{
    public partial class DashboardPage : ContentPage
    {
        private string _role;

        public DashboardPage(string role)
        {
            InitializeComponent();
            _role = role;

            // Lógica para llenar los Picker de doctores y pacientes desde la base de datos.
            CargarDoctores();
            CargarPacientes();
        }

        private async void CargarDoctores()
        {
            // Conectar con MySQL y cargar la lista de doctores
            // Aquí deberías obtener los datos de la base de datos
            var doctores = await ObtenerDoctores();

            doctorPicker.ItemsSource = doctores;
            doctorPicker.SelectedIndex = 0; // Seleccionar el primer doctor por defecto
        }

        private async void CargarPacientes()
        {
            // Conectar con MySQL y cargar la lista de pacientes
            // Aquí deberías obtener los datos de la base de datos
            var pacientes = await ObtenerPacientes();

            pacientePicker.ItemsSource = pacientes;
            pacientePicker.SelectedIndex = 0; // Seleccionar el primer paciente por defecto
        }

        private async void OnCrearDoctorClicked(object sender, EventArgs e)
        {
            // Lógica para crear un doctor
            await DisplayAlert("Crear Doctor", "Formulario para crear doctor", "OK");
        }

        private async void OnCrearPacienteClicked(object sender, EventArgs e)
        {
            // Lógica para crear un paciente
            await DisplayAlert("Crear Paciente", "Formulario para crear paciente", "OK");
        }

        private async void OnCrearCitaClicked(object sender, EventArgs e)
        {
            // Lógica para crear una cita
            await DisplayAlert("Crear Cita", "Formulario para crear cita", "OK");
        }

        private async void OnFiltrarAnunciosClicked(object sender, EventArgs e)
        {
            var selectedDoctor = (Doctor)doctorPicker.SelectedItem;
            var selectedPaciente = (Paciente)pacientePicker.SelectedItem;
            var selectedDate = fechaPicker.Date;

            // Lógica para filtrar los anuncios (conectar a la base de datos)
            var anuncios = await ObtenerAnuncios(selectedDoctor, selectedPaciente, selectedDate);
            anunciosListView.ItemsSource = anuncios;
        }

        private async Task<List<Doctor>> ObtenerDoctores()
        {
            // Aquí deberías implementar la conexión a la base de datos para obtener la lista de doctores
            // Ejemplo con datos dummy
            return new List<Doctor>
            {
                new Doctor { Id = 1, Nombre = "Dr. Juan Pérez", Especialidad = "Cardiología" },
                new Doctor { Id = 2, Nombre = "Dr. María López", Especialidad = "Pediatría" }
            };
        }

        private async Task<List<Paciente>> ObtenerPacientes()
        {
            // Aquí deberías implementar la conexión a la base de datos para obtener la lista de pacientes
            // Ejemplo con datos dummy
            return new List<Paciente>
            {
                new Paciente { Id = 1, Nombre = "Carlos García", FechaNacimiento = new DateTime(1985, 5, 15) },
                new Paciente { Id = 2, Nombre = "Ana Martínez", FechaNacimiento = new DateTime(1992, 8, 20) }
            };
        }

        private async Task<List<Anuncio>> ObtenerAnuncios(Doctor doctor, Paciente paciente, DateTime fecha)
        {
            // Conectar con MySQL y obtener los anuncios filtrados
            // Este es un ejemplo con datos ficticios
            return new List<Anuncio>
            {
                new Anuncio { Texto = "Consulta disponible con Dr. Juan Pérez", FechaPublicacion = DateTime.Now },
                new Anuncio { Texto = "Consulta disponible con Dr. María López", FechaPublicacion = DateTime.Now }
            };
        }
    }
}


