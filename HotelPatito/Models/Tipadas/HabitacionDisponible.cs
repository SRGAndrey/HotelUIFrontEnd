using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelPatito.Models.Tipadas
{
    public class HabitacionDisponible
    {
        public Habitacion habitacion { get; set; }
        public Tipo_Habitacion tipoHabitacion { get; set; }
        public ImagenesJunior imagenJunior { get; set; }
        public ImagenesStandard imagenStandard { get; set; }
        public ImagenesSuite imagenSuite { get; set; }
        public string mensaje { get; set; }
        public System.DateTime fechaInic { get; set; }
        public System.DateTime fechaFin { get; set; }
    }
}