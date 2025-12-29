using System.Diagnostics;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Data;
using Document = iText.Layout.Document;
using Path = System.IO.Path;
using System.Windows.Forms.Design;

namespace Gerenciador_de_Emprestimos
{
    public class GeradorRelatorio
    {
        public void RelatorioEmprestimoPdf(DataTable tabela)
        {
            var pasta = @"C:\GerenciadorEmprestimos\Gerenciador de Emprestimos\pdf";
            var arquivo = Path.Combine(pasta, "Relatorios.pdf");

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            using (PdfWriter writer = new PdfWriter(arquivo))
            {
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf, PageSize.A4.Rotate());

                document.SetMargins(20, 20, 20, 20);

                document.Add(new Paragraph("RELATÓRIO DE EMPRÉSTIMOS").SetFontSize(16));
                document.Add(new Paragraph("------------------------------------------------------------------------------------------------------------------------------------------------------")
                    .SetFontSize(16));

                document.Add(new Paragraph(" "));

                Table tabelaPdf = new Table(tabela.Columns.Count);
                tabelaPdf.SetWidth(UnitValue.CreatePercentValue(100));

                // Cabeçalho
                foreach (DataColumn coluna in tabela.Columns)
                {
                    tabelaPdf.AddHeaderCell(new Cell().Add(new Paragraph(coluna.ColumnName)));
                }

                // Linhas
                foreach (DataRow linhain in tabela.Rows) 
                {
                    foreach(var item in linhain.ItemArray)
                    {
                        tabelaPdf.AddCell(new Paragraph(item?.ToString()));
                    }
                }

                document.Add(tabelaPdf);
                document.Close();

                if (File.Exists(arquivo))
                {
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = arquivo,
                        UseShellExecute = true
                    });
                }
            }
        }
    }
}
