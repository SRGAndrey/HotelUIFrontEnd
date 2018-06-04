namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotelAdministrador")]
    public partial class HotelAdministrador
    {
        [Key]
        public int id_HotelAdministradores { get; set; }

        public int idAdministrador_HotelAdministradores { get; set; }

        [Required]
        [StringLength(25)]
        public string Hotel_HotelAdministradores { get; set; }

        public virtual Administrador Administrador { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
