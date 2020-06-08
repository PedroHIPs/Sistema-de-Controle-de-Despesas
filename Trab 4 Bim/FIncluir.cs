
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
    public partial class FIncluir : Form
    {
        public FIncluir()
        {
            InitializeComponent();
            this.cmbTipo.Items.Add("IMPORTANTE");
            this.cmbTipo.Items.Add("DISPENSAVEL");
            this.btnConsultar.PerformClick();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LPATrabEntities context; //Objeto GRUD
            despesa obj; //classe de dados
            try
            {
                context = new LPATrabEntities();
                obj = new despesa();
                obj.descr = this.txtDescr.Text;
                obj.valor = Convert.ToDouble(this.txtValor.Text);
                obj.dia = this.dtpDia.Value;
                obj.tipo = this.cmbTipo.Text;
                context.despesa.Add(obj); //inclui
                context.SaveChanges(); //salva as mudanças
                this.btnConsultar.PerformClick();
                MessageBox.Show("Incluido com sucesso");
                this.txtDescr.Clear();
                this.txtValor.Clear();
                this.txtCod.Clear();
                this.cmbTipo.ResetText();
                this.txtDescr.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            LPATrabEntities contexto;
            IEnumerable<despesa> lista;
            try
            {
                contexto = new LPATrabEntities();
                lista = from c in contexto.despesa select c;
                this.dgvDespesas.DataSource = lista.ToList();

                //foreach (despesa a in lista)
                //{
                //    this.txtLista.AppendText(a.nome + " " + a.nota1 + " " + a.nota2 + " " + a.dataNascimento.ToString() + Environment.NewLine);
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            LPATrabEntities context; //Objeto GRUD
            despesa obj; //classe de dados
            int cod;
            try
            {
                cod = Convert.ToInt32(this.txtCod.Text);
                context = new LPATrabEntities();
                obj = context.despesa.First(c => c.codigo == cod);
                if (obj != null)
                {
                    obj.descr = this.txtDescr.Text;
                    obj.valor = Convert.ToDouble(this.txtValor.Text);
                    obj.dia = this.dtpDia.Value;
                    obj.tipo = this.cmbTipo.Text;
                    context.SaveChanges(); //salva as mudanças
                    MessageBox.Show("Alterado com sucesso");
                    this.btnConsultar.PerformClick();
                }
                else
                {
                    MessageBox.Show("Não encontrado");
                }
                this.txtDescr.Clear();
                this.txtValor.Clear();
                this.txtCod.Clear();
                this.cmbTipo.ResetText();
                this.txtDescr.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            LPATrabEntities context; //Objeto GRUD
            despesa obj; //classe de dados
            int cod;
            try
            {
                cod = Convert.ToInt32(this.txtCod.Text);
                context = new LPATrabEntities();
                obj = context.despesa.First(c => c.codigo == cod);
                if (obj != null)
                {
                    context.despesa.Remove(obj); //Remove
                    context.SaveChanges(); //salva as mudanças
                    MessageBox.Show("Removido com sucesso");
                }
                else
                {
                    MessageBox.Show("Não encontrado");
                }
                this.txtDescr.Clear();
                this.txtValor.Clear();
                this.txtCod.Clear();
                this.cmbTipo.ResetText();
                this.txtDescr.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void FIncluir_Load(object sender, EventArgs e)
        {
            this.btnConsultar.PerformClick();
        }
    }
}
