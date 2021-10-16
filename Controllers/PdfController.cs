using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.Data;
using WishList.Helpers;
using WishList.Models;

namespace WishList.Controllers
{
    [Route("/[controller]")]

    public class PdfController : Controller
    {
        private readonly WishContext _context;
        public PdfController(WishContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Wish>> PdfCreator()
        {
            var pdfFile = PdfGenerator.GeneratePdf(_context.Wishes.ToList());
            return File(pdfFile, "application/pdf");
        }
    }
}
