using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace TagProcess
{
    /// <summary>
    /// 產生郵寄用標籤的相關程式
    /// </summary>
    public partial class Core
    {
        public void gen_mail_pdf()
        {
            var doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream("mail.pdf", FileMode.Create));
            doc.Open();
            PdfPTable table = new PdfPTable(2);

            PdfPCell cell = new PdfPCell(new Phrase(""));
            cell.FixedHeight = 150;
            cell.Border = Rectangle.RECTANGLE;

            int count = 0;
            foreach (var p in participants)
            {
                string content = String.Format("收件者：\n郵遞區號{0}\n地址{1}\n姓名{2}\n電話{3}",p.zipcode,p.address,p.name,p.phone);
                cell.Phrase = new Phrase(content);
                table.AddCell(cell);
                count++;
            }
            if (count % 2 == 1)
            {
                cell.Phrase = new Phrase("以下空白");
                table.AddCell(cell);
            }
            doc.Add(table);
            doc.Close();

            Process.Start("mail.pdf");
        }
    }
}
