//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace esoft
{
    using System;
    using System.Collections.Generic;
    
    public partial class DemandLand
    {
        public int id { get; set; }
        public Nullable<double> MinArea { get; set; }
        public Nullable<double> MaxArea { get; set; }
        public Nullable<int> DemandId { get; set; }
    
        public virtual Demand Demand { get; set; }
    }
}
