namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Promocion")]
    public partial class Promocion
    {
        [Key]
        public int id_Promocion { get; set; }

        [Column(TypeName = "date")]
        public DateTime inicio_Promocion { get; set; }

        [Column(TypeName = "date")]
        public DateTime fin_Promocion { get; set; }

        public int descuento_Promocion { get; set; }

        public int estado_Promocion { get; set; }

        [Required]
        [StringLength(20)]
        public string tipo_Habitacion_Promocion { get; set; }

        public virtual Tipo_Habitacion Tipo_Habitacion { get; set; }
    }
}
