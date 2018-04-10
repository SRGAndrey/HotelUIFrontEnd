namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Facilidad")]
    public partial class Facilidad
    {
        [Key]
        [StringLength(25)]
        public string id_Facilidad { get; set; }

        [Required]
        [StringLength(500)]
        public string descripcion_Facilidad { get; set; }

        [StringLength(25)]
        public string hotel_Facilidad { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
