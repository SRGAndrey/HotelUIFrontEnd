namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImagenesSuite")]
    public partial class ImagenesSuite
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string descripcion_Entidad { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string descripcion_SubEntidad { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string descripcion_Imagen { get; set; }

        public byte[] imagen_Imagen { get; set; }
    }
}
