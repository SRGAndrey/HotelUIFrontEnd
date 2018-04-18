namespace HotelPatito.Models.Tipadas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrador")]
    public partial class Administrador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Administrador()
        {
            HotelAdministrador = new HashSet<HotelAdministrador>();
        }

        [Key]
        public int id_Administrador { get; set; }

        [Required]
        [StringLength(25)]
        public string usuario_Administrador { get; set; }

        [Required]
        [StringLength(25)]
        public string contrasenna_Administrador { get; set; }

        public int rol_Administrador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelAdministrador> HotelAdministrador { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
