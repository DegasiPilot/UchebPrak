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
    
    public partial class Sotrudnik
    {
        public int TabNomer { get; set; }
        public string Kafedra_Shifr { get; set; }
        public string Familia { get; set; }
        public string Dolgnost { get; set; }
        public Nullable<int> Zarplata { get; set; }
        public Nullable<int> Shef_Id { get; set; }
    
        public virtual Engineer Engineer { get; set; }
        public virtual Kafedra Kafedra { get; set; }
        public virtual Prepodavatel Prepodavatel { get; set; }
        public virtual Prepodavatel Prepodavatel1 { get; set; }
        public virtual Zav_Kafedra Zav_Kafedra { get; set; }
    }
}
