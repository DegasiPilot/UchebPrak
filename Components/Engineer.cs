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
    
    public partial class Engineer
    {
        public int TabNomer { get; set; }
        public string Specialnost { get; set; }
    
        public virtual Sotrudnik Sotrudnik { get; set; }
    }
}
