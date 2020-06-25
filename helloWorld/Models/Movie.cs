﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace helloWorld.Models
{
    [Table("Movie", Schema="public")]
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}