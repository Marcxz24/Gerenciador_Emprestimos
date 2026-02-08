using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Document = iText.Layout.Document;
using Path = System.IO.Path;

namespace Gerenciador_de_Emprestimos.Services
{
    public class GeradorRelatorio
    {
        // --- PROPRIEDADES: Armazenam os totais calculados para serem exibidos no rodapé do relatório ---
        public decimal ValorTotalReceber { get; set; }
        public int NumeroDeRegistros { get; set; }
        public decimal ValorTotalEmprestado { get; set; }

        // --- MÉTODO: Gera o relatório geral de empréstimos ---
        public void RelatorioEmprestimoPdf(DataTable tabela)
        {
            // Define o caminho onde o PDF será salvo
            var pastaRaiz = AppDomain.CurrentDomain.BaseDirectory;
            var pasta = Path.Combine(pastaRaiz, "pdf");
            var arquivo = Path.Combine(pasta, "Relatorios.pdf");

            // Verifica se a pasta existe; caso contrário, a cria
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            // Inicia a escrita do arquivo PDF
            using (PdfWriter writer = new PdfWriter(arquivo))
            {
                PdfDocument pdf = new PdfDocument(writer);
                // Define o tamanho A4 com orientação Paisagem (Rotate) para caber mais colunas
                Document document = new Document(pdf, PageSize.A4.Rotate());

                document.SetMargins(20, 20, 20, 20);

                // --- CABEÇALHO DO DOCUMENTO ---
                document.Add(new Paragraph("RELATÓRIO DE EMPRÉSTIMOS").SetFontSize(16).SetTextAlignment(TextAlignment.CENTER).SetMarginBottom(20));
                document.Add(new LineSeparator(new SolidLine()).SetMarginTop(5).SetMarginBottom(10));
                document.Add(new Paragraph("Listagem de empréstimos gerados no Sistema").SetFontSize(11).SetTextAlignment(TextAlignment.CENTER));

                var dataGeracao = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                document.Add(new Paragraph($"Relatório Gerado em: {dataGeracao}").SetFontSize(9));
                document.Add(new Paragraph(" "));

                // --- CRIAÇÃO DA TABELA DE DADOS ---
                Table tabelaPdf = new Table(tabela.Columns.Count);
                tabelaPdf.SetWidth(UnitValue.CreatePercentValue(100)); // Ocupa 100% da largura da página

                // Percorre as colunas do DataTable para criar o cabeçalho da tabela no PDF
                foreach (DataColumn coluna in tabela.Columns)
                {
                    tabelaPdf.AddHeaderCell(new Cell().Add(new Paragraph(coluna.ColumnName)));
                }

                // Percorre as linhas do DataTable para preencher os dados
                foreach (DataRow linha in tabela.Rows)
                {
                    foreach (var item in linha.ItemArray)
                    {
                        tabelaPdf.AddCell(new Paragraph(item?.ToString()));
                    }
                }

                // Adiciona a tabela ao documento
                document.Add(tabelaPdf);

                document.Add(new Paragraph(" "));

                // --- RODAPÉ COM RESUMO FINANCEIRO ---
                document.Add(new Paragraph($"Total de Registros Listados: {NumeroDeRegistros}"));
                document.Add(new LineSeparator(new SolidLine()).SetMarginTop(5).SetMarginBottom(10));

                // Exibe os valores formatados como moeda (:c) e com fundo cinza para destaque
                document.Add(new Paragraph($"Valor total a Receber: {ValorTotalReceber:c}").SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                document.Add(new LineSeparator(new SolidLine()).SetMarginTop(5).SetMarginBottom(10));
                document.Add(new Paragraph($"Valor total Emprestado: {ValorTotalEmprestado:c}").SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                document.Add(new LineSeparator(new SolidLine()).SetMarginTop(5).SetMarginBottom(10));

                document.Add(new Paragraph("Relatório Gerado automaticamente pelo Sistema Gerenciador de Empréstimos").SetFontSize(9));

                // Fecha o documento para salvar as alterações
                document.Close();

                // Abre o PDF automaticamente no leitor padrão do Windows após a geração
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

        // --- MÉTODO: Gera o relatório específico de parcelas ---
        public void RelatorioParcelas(DataTable dataTable)
        {
            // Lógica idêntica ao método anterior, mas personalizada para o contexto de parcelas
            var pastaRaiz = AppDomain.CurrentDomain.BaseDirectory;
            var pasta = Path.Combine(pastaRaiz, "pdf");
            var arquivo = Path.Combine(pasta, "Relatorios.pdf");

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            using (PdfWriter escrever = new PdfWriter(arquivo))
            {
                PdfDocument pdfParcela = new PdfDocument(escrever);
                // Define o tamanho A4 com orientação Paisagem (Rotate) para caber mais colunas
                Document doc = new Document(pdfParcela, PageSize.A4.Rotate());

                doc.SetMargins(20, 20, 20, 20);

                // --- CABEÇALHO DO DOCUMENTO ---
                doc.Add(new Paragraph("RELATÓRIO DAS PARCELAS DO EMPRÉSTIMO").SetFontSize(16).SetTextAlignment(TextAlignment.CENTER).SetMarginBottom(20));
                doc.Add(new LineSeparator(new SolidLine()).SetMarginTop(5).SetMarginBottom(10));
                doc.Add(new Paragraph("Listagem de Parcelas registradas no Sistema").SetFontSize(11).SetTextAlignment(TextAlignment.CENTER));

                var dataGeracao = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                doc.Add(new Paragraph($"Relatório Gerado em: {dataGeracao}").SetFontSize(9));
                doc.Add(new Paragraph(" "));

                // --- CRIAÇÃO DA TABELA DE DADOS ---
                Table tabelaParcelas = new Table(dataTable.Columns.Count);
                tabelaParcelas.SetWidth(UnitValue.CreatePercentValue(100));

                tabelaParcelas.SetFixedLayout(); // Garante que as colunas tenham largura fixa para melhor formatação

                // Percorre as colunas do DataTable para criar o cabeçalho da tabela no PDF
                foreach (DataColumn coluna in dataTable.Columns)
                {
                    tabelaParcelas.AddHeaderCell(new Cell().Add(new Paragraph(coluna.ColumnName)));
                }

                // Percorre as linhas do DataTable para preencher os dados
                foreach (DataRow linha in dataTable.Rows)
                {
                    foreach (var item in linha.ItemArray)
                    {
                        tabelaParcelas.AddCell(new Paragraph(item?.ToString()));
                    }
                }

                // Adiciona a tabela ao documento
                doc.Add(tabelaParcelas);

                // --- RODAPÉ COM RESUMO FINANCEIRO ---
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph($"Total de Registros Listados: {NumeroDeRegistros}"));
                doc.Add(new LineSeparator(new SolidLine()).SetMarginTop(5).SetMarginBottom(10));

                // Exibe os valores formatados como moeda (:c) e com fundo cinza para destaque
                doc.Add(new Paragraph($"Soma de Todas as Parcelas: {ValorTotalReceber:c}").SetBackgroundColor(ColorConstants.LIGHT_GRAY));

                doc.Add(new Paragraph("Relatório Gerado automaticamente pelo Sistema Gerenciador de Empréstimos").SetFontSize(9));

                // Fecha o documento para salvar as alterações
                doc.Close();

                // Abre o PDF automaticamente no leitor padrão do Windows após a geração
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