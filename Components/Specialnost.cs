//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UchebPrak.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Specialnost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Specialnost()
        {
            this.Student = new HashSet<Student>();
            this.Zayavka = new HashSet<Zayavka>();
        }
    
        public string Nomer { get; set; }
        public string Napravlenie { get; set; }
        public string Kafedra_Shifr { get; set; }
    
        public virtual Kafedra Kafedra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Student { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zayavka> Zayavka { get; set; }
    }
}