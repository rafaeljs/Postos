namespace Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Posto")]
    public class Posto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Posto()
        {
            PostoCombustivel = new HashSet<PostoCombustivel>();
        }

        [Key]
        public int PostoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Latitude { get; set; }
        [Required]
        public decimal Longitude { get; set; }

        public DateTime DataInclusao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostoCombustivel> PostoCombustivel { get; set; }
    }
}
