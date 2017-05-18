﻿using System;
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
            var doc = new Document(PageSize.A4, 1, 1, 3, 1);
            PdfWriter.GetInstance(doc, new FileStream("mail.pdf", FileMode.Create));
            string chFontPath = "c:\\windows\\fonts\\KAIU.TTF";
            BaseFont chBaseFont = BaseFont.CreateFont(chFontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font textFont = new Font(chBaseFont, 12);

            doc.Open();
            PdfPTable table = new PdfPTable(2);

            PdfPCell cell = new PdfPCell(new Phrase(""));
            cell.FixedHeight = 80;
            cell.Border = Rectangle.RECTANGLE;

            int count = 0;
            foreach (var p in participants)
            {
                string content = String.Format("收件者：\n{0}\n{1}\n{2}\n",p.zipcode,p.address,p.name);
                cell.Phrase = new Phrase(content, textFont);
                table.AddCell(cell);
                count++;
            }
            if (count % 2 == 1)
            {
                cell.Phrase = new Phrase("以下空白", textFont);
                table.AddCell(cell);
            }
            doc.Add(table);
            doc.Close();

            Process.Start("mail.pdf");
        }
    }
}
