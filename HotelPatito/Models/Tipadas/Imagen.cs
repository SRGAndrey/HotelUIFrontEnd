namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Imagen")]
    public partial class Imagen
    {
        [Key]
        [Column(Order = 0)]
        public int id_Imagen { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEntidad_Imagen { get; set; }

        [StringLength(25)]
        public string descripcion_Imagen { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid fileID_Imagen { get; set; }

        public byte[] imagen_Imagen { get; set; }
    }
}
