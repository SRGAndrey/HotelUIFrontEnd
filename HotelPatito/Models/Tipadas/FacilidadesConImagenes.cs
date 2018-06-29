

namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public partial class FacilidadesConImagenes
    {
        public List<Facilidad> facilidades { get; set; }
        public List<ImagenesBar> imagenesBar { get; set; }
        public List<ImagenesCafeteria> imagenesCafeteria { get; set; }
        public List<ImagenesInfantiles> imagenesInfantil { get; set; }
        public List<ImagenesJacuzzi> imagenesJacuzzi { get; set; }
        public List<ImagenesPiscina> imagenesPiscina { get; set; }
        public List<ImagenesRestaurante> imagenesRestaurante { get; set; }
        public List<ImagenesTenis> imagenesTenis { get; set; }
    }
}