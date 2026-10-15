using System;
namespace Proyecto.Models
{
    public class Paciente
    {
        public int Id { get; set; }            
        public string Nombre { get; set; }      
        public DateTime FechaNacimiento { get; set; } 
        public string Telefono { get; set; }    
        public string Email { get; set; }       
        public string Direccion { get; set; }   
        public DateTime FechaRegistro { get; set; }

    }

}

