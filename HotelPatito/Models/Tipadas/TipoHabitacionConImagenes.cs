namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TipoHabitacionConImagenes
    {
        public List<Tipo_Habitacion> tipoHabitacion { get; set; }
        public ImagenesJunior imagenJunior { get; set; }
        public ImagenesStandard imagenStandard { get; set; }
        public ImagenesSuite imagenSuite { get; set; }

        public Tipo_Habitacion tipoHabitacionX { get; set; }
        public byte[] imagenX { get; set; }
        public int idImagen { get; set; }
        public string descripcionImagen { get; set; }
    }
}