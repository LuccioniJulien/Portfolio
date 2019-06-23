using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ColorClass { get; set; }
        
        public List<Project_Has_Tags> Taggeds { get; set; }
        
        public Tag (string name, string colorClass) => (Name, ColorClass) = (name, colorClass);
        
        public void Deconstruct (out string name, out string colorClass) => (name, colorClass) = (Name, ColorClass);
    }
}