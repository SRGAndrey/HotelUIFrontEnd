namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Caracteristica_Tipo_Habitacion
    {
        [Key]
        public int id_Caracteristica_Tipo_Habitacion { get; set; }

        public int idCaracteristica_Caracteristica_Tipo_Habitacion { get; set; }

        [Required]
        [StringLength(20)]
        public string tipo_Habitacion_Caracteristica_Tipo_Habitacion { get; set; }

        public virtual Caracteristica Caracteristica { get; set; }

        public virtual Tipo_Habitacion Tipo_Habitacion { get; set; }
    }
}
