

namespace Blog.Entity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Makale")]
    public partial class Makale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Makale()
        {
            Yorum = new HashSet<Yorum>();
            Etiket = new HashSet<Etiket>();
        }
       
        public int MakaleId { get; set; }

        [StringLength(250)]
        public string Baslik { get; set; }

        //[UIHint("tinymce_full_compressed"), AllowHtml]
        //[AllowHtml]
        //[UIHint("tinymce_full_compressed")]
        public string Icerik { get; set; }

        public DateTime Tarih { get; set; }

        public int? KategoriID { get; set; }

        public int? UyeID { get; set; }

        [StringLength(500)]
        public string Foto { get; set; }

        public int Okunma { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Uye Uye { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorum> Yorum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Etiket> Etiket { get; set; }
    }
}
