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
    
    public partial class Kafedra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kafedra()
        {
            this.Disciplina = new HashSet<Disciplina>();
            this.Specialnost = new HashSet<Specialnost>();
            this.Sotrudnik = new HashSet<Sotrudnik>();
        }
    
        public string Shifr { get; set; }
        public string Nazvanie { get; set; }
        public string Fakultet_Abbr { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disciplina> Disciplina { get; set; }
        public virtual Fakultet Fakultet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specialnost> Specialnost { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sotrudnik> Sotrudnik { get; set; }
    }
}
