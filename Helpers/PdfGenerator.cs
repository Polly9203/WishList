using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using WishList.Models;

namespace WishList.Helpers
{
    public static class PdfGenerator
    {
        public static byte[] GeneratePdf(List<Wish> Wishes)
        {
            var memoryStream = new MemoryStream();
            var document = new Document(PageSize.A4, 20, 20, 20, 20);
            var writer = PdfWriter.GetInstance(document, memoryStream);

            document.AddTitle("Wishes list");
            document.Open();

            var wishTable = new PdfPTable(3);
            var headerCell = new PdfPCell(new Phrase($"Your wishes:"))
            {
                Colspan = 3,
                Border = 0,
                BorderWidthBottom = 1,
                PaddingBottom = 10f,
                PaddingTop = 5f,
                HorizontalAlignment = Element.ALIGN_CENTER
            };
            wishTable.AddCell(headerCell);

            foreach (Wish wish in Wishes)
            {
                var nameCell = new PdfPCell(new Phrase($"{wish.Name}"))
                {
                    Border = 0,
                    BorderWidthBottom = 1,
                    PaddingBottom = 10f,
                    PaddingTop = 5f,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                wishTable.AddCell(nameCell);

                var priceCell = new PdfPCell(new Phrase($"{wish.Price}"))
                {
                    Border = 0,
                    BorderWidthBottom = 1,
                    PaddingBottom = 10f,
                    PaddingTop = 5f,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                wishTable.AddCell(priceCell);

                var linkCell = new PdfPCell(new Phrase($"{wish.Link}"))
                {
                    Border = 0,
                    BorderWidthBottom = 1,
                    PaddingBottom = 10f,
                    PaddingTop = 5f,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                wishTable.AddCell(linkCell);
            }
            document.Add(wishTable);

            document.Close();
            writer.Close();

            return memoryStream.ToArray();
        }
    }
}
