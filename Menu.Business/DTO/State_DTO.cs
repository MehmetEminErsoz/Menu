﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class State_DTO : IDtoWithIdName
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int IdCity { get; set; }


        public int Adress { get; set; }

        public  City_DTO City { get; set; }
    }
}