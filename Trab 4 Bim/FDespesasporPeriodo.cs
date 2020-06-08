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
    public partial class FDespesasporPeriodo : Form
    {
        public FDespesasporPeriodo()
        {
            InitializeComponent();
        }

        private void btnConsulDesp_Click(object sender, EventArgs e)
        {
            LPATrabEntities contexto;
            IEnumerable<despesa> lista;
            double total = 0;
            try
            {
                contexto = new LPATrabEntities();
                lista = from c in contexto.despesa where c.dia >= this.dtpComeco.Value.Date && c.dia <= this.dtpFim.Value.Date select c;
                this.dgvPeriodo.DataSource = lista.ToList();
                foreach (despesa a in lista)
                {
                    total = total + a.valor;
                }
                this.txtTotal.Text = total.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
