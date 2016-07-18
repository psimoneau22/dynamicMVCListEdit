using System;
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

        [Required]
        public List<TestModel> Data { get; set; }

        [Required]
        public List<TestModel2> List { get; set; }
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

    public class TestModel2
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "this is required chump")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "tooshort chump")]
        public string SomeDescription { get; set; }
        public int SomeNumber { get; set; }
        public TestModel3 Child { get; set; }
    }

    public class TestModel3
    {
        public string xxx { get; set; }
        public string yyy { get; set; }
    }
}
