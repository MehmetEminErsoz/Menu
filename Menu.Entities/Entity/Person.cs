﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Person : IEntityWithIdName 
    {
        
        public Person()
        {
            Adress_C = new HashSet<Adress_C>();
            Customer = new HashSet<Customer>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        public bool Active { get; set; }

        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        public byte AccessFailedCount { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        
        public virtual ICollection<Adress_C> Adress_C { get; set; }

       
        public virtual ICollection<Customer> Customer { get; set; }

       
        public virtual ICollection<User> User { get; set; }
    }
}