﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProvider.Models
{
    public class Role : IIdentifiable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Reserved { get; set; }
    }
}
