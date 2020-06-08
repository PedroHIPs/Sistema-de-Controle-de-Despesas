using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trab_4_Bim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FIncluir Incluir = new FIncluir();
            Incluir.Show();
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRelatório Rel = new FRelatório();
            Rel.Show();
        }

        private void despesasPorPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDespesasporPeriodo DesC = new FDespesasporPeriodo();
            DesC.Show();
        }

        private void gráficosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FGrafico Grafico = new FGrafico();
            Grafico.Show();
        }
    }
}
