using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Models
{
    public class Study
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public void Deconstruct(out string name, out DateTime dateDebut, out DateTime dateFin, out string description)
        {
            name = Name;
            dateDebut = DateDebut;
            dateFin = DateFin;
            description = Description;
        }
    }
}