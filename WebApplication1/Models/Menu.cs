using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Menu
    {
        public Menu(string name, string url, params Menu[] children)
        {
            this.Name = name;
            this.Url = url;
            this.Children = new List<Menu>(children.Select(c => { c.Parent = this; return c; }));
        }

        public string Name { get; set; }
        public string Url { get; set; }
        public Menu Parent { get; set; }
        public List<Menu> Children { get; set; }
        public int Level
        {
            get {
                int count = 0;
                var current = this;
                while (current.Parent != null)
                {
                    count++;
                    current = current.Parent;
                }
                return count;
            }
        }
    }
}