using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelPatito.Models.Tipadas
{
    public partial class ClienteReserva
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string nombre_cliente { get; set; }

        public int numero_habitacion { get; set; }
        
        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string mail { get; set; }

    }

}