namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Entidad_SubEntidad_Imagen
    {
        [Key]
        public int id_Entidad_SubEntidad_Imagen { get; set; }

        public int idEntidad_Entidad_SubEntidad_Imagen { get; set; }

        public int idSubEntidad_Entidad_SubEntidad_Imagen { get; set; }

        public int idImagen_Entidad_SubEntidad_Imagen { get; set; }

        public virtual Entidad Entidad { get; set; }

        public virtual Imagen Imagen { get; set; }

        public virtual SubEntidad SubEntidad { get; set; }
    }
}
