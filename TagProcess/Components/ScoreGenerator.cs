using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace TagProcess.Components
{
    public class ScoreGenerator
    {
        public class ScoreArguments
        {
            public string date;
            public string name;
            public string group;
            public string subject;
            public string total_rank;
            public string subject_rank;
            public string batch_run_time;
            public string tag_run_time;
        }

        public static void exportScoreToPDF(ScoreArguments args)
        {
            var doc = new Document(PageSize.A4, 3, 3, 3, 3);
            var writer = PdfWriter.GetInstance(doc, new FileStream("score.pdf", FileMode.Create));
            string chFontPath = "c:\\windows\\fonts\\KAIU.TTF";
            BaseFont chBaseFont = BaseFont.CreateFont(chFontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font textFont = new Font(chBaseFont, 16);

            Image bg = Image.GetInstance("a.jpg");
            bg.Alignment = Image.UNDERLYING;
            bg.ScaleToFit(doc.PageSize.Width - 6, doc.PageSize.Height - 6);
            bg.SetAbsolutePosition(3, 3);

            doc.Open();
            doc.Add(bg);

            ColumnText ct = new ColumnText(writer.DirectContent);
            Phrase myText = new Phrase(args.name, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 685, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase(args.date, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 635, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase(args.group, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 585, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase("項目", textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 535, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase(args.batch_run_time, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 475, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase(args.tag_run_time, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 425, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase("總名次", textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 375, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase("分組名次", textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 325, 15, Element.ALIGN_LEFT);
            ct.Go();

            doc.Close();

            Process.Start("score.pdf");
        }
    }
}
