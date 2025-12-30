using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Data;
using System.Diagnostics;
using Document = iText.Layout.Document;
using Path = System.IO.Path;

namespace Gerenciador_de_Emprestimos
{
    public class GeradorRelatorio
    {
        public decimal ValorTotalReceber { get; set; }
        public int NumeroDeRegistros { get; set; }
        public decimal ValorTotalEmprestado { get; set; }

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

                document.Add(new Paragraph("RELATÓRIO DE EMPRÉSTIMOS").SetFontSize(16).SetTextAlignment(TextAlignment.CENTER).SetMarginBottom(20));
                document.Add(new LineSeparator(new SolidLine()).SetMarginTop(5).SetMarginBottom(10));
                document.Add(new Paragraph("Listagem de empréstimos gerados no Sistema").SetFontSize(11).SetTextAlignment(TextAlignment.CENTER));

                var dataGeracao = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                document.Add(new Paragraph($"Relatório Gerado em: {dataGeracao}").SetFontSize(9));

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

                // Adiciona o Data Grid.
                document.Add(tabelaPdf);

                document.Add(new Paragraph(" "));

                document.Add(new Paragraph($"Total de Registros Listados: {NumeroDeRegistros}"));

                document.Add(new LineSeparator(new SolidLine()).SetMarginTop(5).SetMarginBottom(10));

                document.Add(new Paragraph($"Valor total a Receber: {ValorTotalReceber:c}").SetBackgroundColor(ColorConstants.LIGHT_GRAY));

                document.Add(new LineSeparator(new SolidLine()).SetMarginTop(5).SetMarginBottom(10));

                document.Add(new Paragraph($"Valor total Emprestado: {ValorTotalEmprestado:c}").SetBackgroundColor(ColorConstants.LIGHT_GRAY));

                document.Add(new LineSeparator(new SolidLine()).SetMarginTop(5).SetMarginBottom(10));

                document.Add(new Paragraph("Relatório Gerado automaticamente pelo Sistema Gerenciador de Empréstimos").SetFontSize(9));

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
