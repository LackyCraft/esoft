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
    
    public partial class Houses
    {
        public int id { get; set; }
        public Nullable<int> ObjectNmoblesId { get; set; }
        public Nullable<int> CountFloor { get; set; }
        public Nullable<int> CountRoom { get; set; }
        public Nullable<double> Area { get; set; }
    
        public virtual ObjectNmobles ObjectNmobles { get; set; }
    }
}
