using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.EntityFrameworkCore.Internal;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portfolio.Models
{
    [Table("Mail")]
    public class Mailer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'email est requis.")]
        public string From { set; get; }

        [NotMapped]
        public string Status { set; get; }

        [NotMapped]
        private EmailAddress Mail => new EmailAddress(From);

        [Required(ErrorMessage = "Le contenu du mail ne peut pas être vide.")]
        [MinLength(5, ErrorMessage = "Le contenu du mail ne peut pas faire moins de 5 lettres.")]
        [MaxLength(250, ErrorMessage = "Le contenu du mail ne peut pas faire plus de 250 lettres.")]
        public string Message { get; set; }

        public void Deconstruct(out string from, out EmailAddress mail, out string message)
        {
            from = From;
            message = Message;
            mail = Mail;
        }

    }
}