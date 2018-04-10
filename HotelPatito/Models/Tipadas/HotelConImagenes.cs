using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelPatito.Models.Tipadas
{
    public class HotelConImagenes
    {

        [Key]
        [StringLength(25)]
        public string nombre_Hotel { get; set; }

        [Required]
        [StringLength(500)]
        public string descripcion_Hotel { get; set; }

        [Required]
        [StringLength(500)]
        public string sobreNosotros_Hotel { get; set; }

        [Required]
        [StringLength(50)]
        public string latitud_Hotel { get; set; }

        [Required]
        [StringLength(50)]
        public string longitud_Hotel { get; set; }

        [Required]
        [StringLength(350)]
        public string comoLlegar_Hotel { get; set; }

        [Required]
        [StringLength(10)]
        public string telefono_Hotel { get; set; }

        public int? aptoPostal_Hotel { get; set; }

        [Required]
        [StringLength(50)]
        public string email_Hotel { get; set; }

        public List<Imagen> imagenes { get; set; }
    }
}