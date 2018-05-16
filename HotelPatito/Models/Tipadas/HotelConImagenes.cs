using HotelPatito.Models.Tipadas;
namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;


    public class HotelConImagenes
    {
        public Hotel hotel { get; set; }

        public List<ImagenesDescripcion> imagenesDescripcion { get; set; }

        public List<ImagenesSobreNosotros> galeria { get; set; }


    }
}
