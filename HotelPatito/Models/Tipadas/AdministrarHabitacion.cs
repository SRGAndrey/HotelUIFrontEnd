using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelPatito.Models.Tipadas
{
    public partial class AdministrarHabitacion
    {
        [StringLength(20)]
        public string nombre_Tipo_Habitacion { get; set; }

        public List<Habitacion> habitaciones { get; set; }
    }
}