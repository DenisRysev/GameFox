//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameFox
{
    using System;
    using System.Collections.Generic;
    
    public partial class Заявка
    {
        public int Код_заявки { get; set; }
        public Nullable<int> Код_пользователя { get; set; }
        public Nullable<System.DateTime> Возраст { get; set; }
        public Nullable<int> Код_турнира { get; set; }
        public string ФИО { get; set; }
    
        public virtual Пользователь Пользователь { get; set; }
        public virtual Турнир Турнир { get; set; }
    }
}
