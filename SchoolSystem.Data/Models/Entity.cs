﻿using SchoolSystem.Data.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
