namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotelPublicidad")]
    public partial class HotelPublicidad
    {
        [Key]
        public int id_HotelPublicidad { get; set; }

        public int idPublicidad_HotelPublicidad { get; set; }

        [Required]
        [StringLength(25)]
        public string Hotel_HotelPublicidad { get; set; }

        public virtual Hotel Hotel { get; set; }

        public virtual Publicidad Publicidad { get; set; }
    }
}
