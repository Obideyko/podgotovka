//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectPodgotovka
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tour
    {
        public int ID { get; set; }
        public int TicketsCount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] ImagePreview { get; set; }
        public decimal Price { get; set; }
        public bool IsActual { get; set; }
    }
}
