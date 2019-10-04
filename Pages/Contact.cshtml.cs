using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Dao;
using Portfolio.Interfaces;
using Portfolio.Models;
using Portfolio.Utils;

namespace Portfolio.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IDb _db;

        public ContactModel(IDb db) => _db = db;

        [BindProperty]
        public Mailer Mail { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _db.Mailers.Create(Mail);
            if (await MailHelper.Send(Mail))
                Console.WriteLine("Email Sent");

            return RedirectToPage("/success");
        }
    }
}