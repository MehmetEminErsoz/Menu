﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class AdressType : IEntityWithIdName
    {
        public AdressType()
        {
            Adress_C = new HashSet<Adress_C>();
        }
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }
        public string Name { get; set; }
        public ICollection<Adress_C> Adress_C { get; set; }
    }
}
