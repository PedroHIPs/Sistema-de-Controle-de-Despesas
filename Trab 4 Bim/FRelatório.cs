using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trab_4_Bim
{
    public partial class FRelatório : Form
    {
        PrintDocument document = new PrintDocument();
        PrintDialog dialog = new PrintDialog();

        Font fonte;
        String texto;
        public FRelatório()
        {
            InitializeComponent();
            dialog = new PrintDialog();
            document = new PrintDocument();
            Relatorio();
            texto = this.txtRelatorio.Text;
            fonte = new Font("Arial", 12, FontStyle.Regular);
            this.txtRelatorio.Font = fonte;
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
        }

        public void Relatorio()
        {
            
        }

        private void FRelatório_Load(object sender, EventArgs e)
        {
            LPATrabEntities contexto;
            IEnumerable<despesa> lista;
            double total = 0;
            try
            {
                contexto = new LPATrabEntities();
                lista = from c in contexto.despesa where c.dia >= this.dtpInicio.Value.Date && c.dia <= this.dtpTermino.Value.Date select c;

                this.txtRelatorio.Clear();

                foreach (despesa a in lista)
                {
                    total = total + a.valor;
                    this.txtRelatorio.AppendText("Descrição: "+ a.descr + " " + "Data: " +  a.dia + " " + "Valor: " + a.valor + " " + Environment.NewLine);
                }
                this.txtRelatorio.AppendText(Environment.NewLine + "Total: "+ total);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            int caracterPorPagina = 0;
            int linhasPorPagina = 0;

            e.Graphics.DrawString("Relatório", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 20, 20);

            // configura os caracteres por página
            e.Graphics.MeasureString(texto, fonte, e.MarginBounds.Size, StringFormat.GenericTypographic,
                out caracterPorPagina, out linhasPorPagina);

            // Gera a impressão da página
            e.Graphics.DrawString(texto, fonte, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            // retira o que já foi impresso do texto
            if (caracterPorPagina < texto.Length)
                texto = texto.Substring(caracterPorPagina);
            else
                texto = "";
            // Check to see if more pages are to be printed cause i'm bilingual and talk english and portuguese at same tempo 2.
            e.HasMorePages = (texto.Length > 0);
        }

        private void btnCunsulRela_Click(object sender, EventArgs e)
        {
            LPATrabEntities contexto;
            IEnumerable<despesa> lista;
            double total = 0;
            try
            {
                contexto = new LPATrabEntities();
                lista = from c in contexto.despesa where c.dia >= this.dtpInicio.Value.Date  && c.dia <= this.dtpTermino.Value.Date select c;

                this.txtRelatorio.Clear();

                foreach (despesa a in lista)
                {
                    total = total + a.valor;
                    this.txtRelatorio.AppendText("Descrição: " + a.descr + " " + "Data: " + a.dia + " " + "Valor: " + a.valor + " " + Environment.NewLine);
                }
                this.txtRelatorio.AppendText(Environment.NewLine + "Total: " + total);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            texto = this.txtRelatorio.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dialog.Document = document;
                document.Print();
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printDialog = new PrintPreviewDialog();
            texto = this.txtRelatorio.Text;
            printDialog.Document = document;
            printDialog.ShowDialog();
        }

        private void btnFonte_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                fonte = fontDialog1.Font;
                this.txtRelatorio.Font = fonte;
            }
        }
    }
}
