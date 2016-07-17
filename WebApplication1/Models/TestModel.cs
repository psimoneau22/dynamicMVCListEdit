﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TestBaseModel
    {
        public string Name { get; set; }
        [Required]
        public List<TestModel> Items { get; set; }
    }

    public class TestModel
    {
        [Required]        
        public int Id { get; set; }
        [Required(ErrorMessage ="this is required chump")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "tooshort chump")]
        public string TestString { get; set; }     
        public bool TestBool { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
