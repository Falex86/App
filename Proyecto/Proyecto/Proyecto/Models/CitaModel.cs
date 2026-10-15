using System;
namespace Proyecto.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PacienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Consultorio { get; set; }
    }
}

