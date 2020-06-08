using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Trab_4_Bim
{
    public partial class FGrafico : Form
    {
        public FGrafico()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void mostrarDia()
        {
            LPATrabEntities contexto;

            contexto = new LPATrabEntities();
            var lista = from d in contexto.despesa where d.dia >= this.dtp1.Value.Date && d.dia <= this.dtp2.Value.Date group d by new { d.tipo, d.dia.Value.Day } into g
            select new
            {
                    Tipo = g.Key.tipo.ToString(),
                    Dia = g.Key.Day.ToString(),
                    Preço = g.Sum(t => t.valor).ToString(),
                    Quantidade = g.Count().ToString()
            };
            this.chart1.Series.Clear();
            this.chart1.Series.Add(new Series());
            this.chart1.Series.Add(new Series());
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("Despesas por dia");
            this.chart1.Series[0].Name = "Importante";
            this.chart1.Series[1].Name = "Fundamental";
            this.chart1.ChartAreas[0].AxisX.Title = "Dia";
            this.chart1.ChartAreas[0].AxisY.Title = "Valor";
            foreach(var obj in lista.ToList())
            {
                if(obj.Tipo.CompareTo("IMPORTANTE")==0)
                {
                    this.chart1.Series[0].Points.Add(new DataPoint
                    {
                        YValues = new double[] { (double)Convert.ToDouble(obj.Preço) },
                        AxisLabel = obj.Dia.ToString()
                    });
                }

                if (obj.Tipo.CompareTo("DISPENSAVEL") == 0)
                {
                    this.chart1.Series[1].Points.Add(new DataPoint
                    {
                        YValues = new double[] { (double)Convert.ToDouble(obj.Preço) },
                        AxisLabel = obj.Dia.ToString()
                    });
                }
            }

        }

        public void mostrarMes()
        {
            LPATrabEntities contexto;

            contexto = new LPATrabEntities();
            var lista = from d in contexto.despesa
                        where d.dia >= this.dtp1.Value.Date && d.dia <= this.dtp2.Value.Date
                        group d by new { d.tipo, d.dia.Value.Month } into g
                        select new
                        {
                            Tipo = g.Key.tipo.ToString(),
                            Mes = g.Key.Month.ToString(),
                            Preço = g.Sum(t => t.valor).ToString(),
                            Quantidade = g.Count().ToString()
                        };
            this.chart1.Series.Clear();
            this.chart1.Series.Add(new Series());
            this.chart1.Series.Add(new Series());
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("Despesas por Mês");
            this.chart1.Series[0].Name = "Importante";
            this.chart1.Series[1].Name = "Fundamental";
            this.chart1.ChartAreas[0].AxisX.Title = "Mês";
            this.chart1.ChartAreas[0].AxisY.Title = "Valor";
            foreach (var obj in lista.ToList())
            {
                if (obj.Tipo.CompareTo("IMPORTANTE") == 0)
                {
                    this.chart1.Series[0].Points.Add(new DataPoint
                    {
                        YValues = new double[] { (double)Convert.ToDouble(obj.Preço) },
                        AxisLabel = obj.Mes.ToString()
                    });
                }

                if (obj.Tipo.CompareTo("DISPENSAVEL") == 0)
                {
                    this.chart1.Series[1].Points.Add(new DataPoint
                    {
                        YValues = new double[] { (double)Convert.ToDouble(obj.Preço) },
                        AxisLabel = obj.Mes.ToString()
                    });
                }
            }

        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            bool escolha = false;
            if (rdbDia.Checked)
            {
                mostrarDia();
                rdbDia.Checked = false;
                escolha = true;
            }
            if (rdbMes.Checked)
            {
                mostrarMes();
                rdbMes.Checked = false;
                escolha = true;
            }
            if (!escolha)
            {
                MessageBox.Show("Nenhum tipo de agrupamento de dados foi selecionado");
            }
        }
    }
}
