using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Relatório
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            string caminho = @"C:\Users\" + "relatorio.pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            Paragraph titulo = new Paragraph();
            titulo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 40);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("Relatório\n\n");
            doc.Add(titulo);

            Paragraph paragrafo = new Paragraph("", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12));
            string conteudo = "Itextsharp é uma biblioteca de ferramentas avançada que é usada para criar repors pdf complexos. itext é usado por diferentes tecnologias -- Android, .NET, Java e GAE desenvolvedor usá-lo para melhorar seus aplicativos com funcionalidade PDF. Ele cria documentos e relatórios com base em dados de bancos de dados ou arquivos xml e Mescle ou divide páginas de arquivos PDF existentes.";
            paragrafo.Add(conteudo);
            doc.Add(paragrafo);

            PdfPTable table = new PdfPTable(3);
            for(int i = 1; i <= 10; i++)
            {
                table.AddCell("Linha " + i + ", Coluna 1");
                table.AddCell("Linha " + i + ", Coluna 2");
                table.AddCell("Linha " + i + ", Coluna 3");
            }

            doc.Add(table);

            string simg = @"C:\Users\Eduardo Peroni\source\repos\Clinic Solution System\Clinic Solution System\imagens\Logo CSS.jpg";
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(simg);
            img.ScaleAbsolute(100, 130);

            doc.Add(img);

            doc.Close();
            System.Diagnostics.Process.Start(caminho);
        }
    }
}
