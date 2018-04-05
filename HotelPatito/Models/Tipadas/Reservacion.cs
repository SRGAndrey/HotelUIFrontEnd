namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservacion")]
    public partial class Reservacion
    {
        [Key]
        public int id_Reservacion { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime fechaLLegada_Reservacion { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime fechaSalida_Reservacion { get; set; }

        public int idHabitacion_Reservacion { get; set; }

        [Required]
        [StringLength(12)]
        public string idCliente_Reservacion { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Habitacion Habitacion { get; set; }
    }
}
