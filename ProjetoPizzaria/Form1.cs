using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPizzaria
{
    public partial class Form1 : Form
    {   // Instanciando a classe conexão
        Conexao con = new Conexao();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTamanhoPizza.Items.Add("Pequena- R$ 20,00");
            cmbTamanhoPizza.Items.Add("Média- R$ 30,00");
            cmbTamanhoPizza.Items.Add("Grande- R$ 50,00");

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Declarando as variáveis

            double valorPizza = 0, valorOpcao = 0, valorTotal = 0;
            if (cmbTamanhoPizza.SelectedIndex == 0)
            {
                valorPizza = 20;
            }
            else if (cmbTamanhoPizza.SelectedIndex == 1)
            {
                valorPizza = 30;
            }
            else if (cmbTamanhoPizza.SelectedIndex == 2)
            {
                valorPizza = 50;
            }
            if (chkBorda.Checked == true)
            {
                valorOpcao = valorOpcao + 5;
            }
            if (chkTempero.Checked == true)
            {
                valorOpcao = valorOpcao + 6;
            }
            if (chkCebola.Checked == true)
            {
                valorOpcao = valorOpcao + 3;
            }
            if (chkCatupiry.Checked == true)
            {
                valorOpcao = valorOpcao + 4;
            }
            else
            {

            }
            valorTotal = valorPizza + valorOpcao;
            txtValorPizza.Text = Convert.ToString(valorPizza);
            txtValorOpcionais.Text = Convert.ToString(valorOpcao);
            txtTotalPagar.Text = Convert.ToString(valorTotal);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //verifica os campos
            if (txtValorPizza.Text == "")
            {
                MessageBox.Show("Campo Obrigatório");
                txtValorPizza.Focus();
            }
            else if (txtValorOpcionais.Text == "")
            {
                MessageBox.Show("Campo Obrigatório");
                txtValorOpcionais.Focus();
            }
            else if (txtTotalPagar.Text == "")
            {
                MessageBox.Show("Campo Obrigatório");
                txtTotalPagar.Focus();
            }
            else
            {
                //tratamento de erros
                try
                {
                    //inserindo dados no banco de dados
                    string sql = "insert into tbPedido(tipoPizza,valorPizza,valorOpcao,valorTotal) values(@pizza,@vpizza,@vopcao,@total)";
                    MySqlCommand cmd = new MySqlCommand(sql, con.ConnectarBD());
                    cmd.Parameters.Add("@pizza", MySqlDbType.Text).Value = cmbTamanhoPizza.Text;
                    cmd.Parameters.Add("@vpizza", MySqlDbType.Text).Value = txtValorPizza.Text;
                    cmd.Parameters.Add("@vopcao", MySqlDbType.Text).Value = txtValorOpcionais.Text;
                    cmd.Parameters.Add("@total", MySqlDbType.Text).Value = txtTotalPagar.Text;
                    cmd.ExecuteNonQuery(); //Guarda/grava os dados no banco

                    MessageBox.Show("Dados cadastrados com Sucesso !!!");
                    cmbTamanhoPizza.Text = "";
                    txtValorPizza.Text = "";
                    txtValorOpcionais.Text = "";
                    txtTotalPagar.Text = "";
                    cmbTamanhoPizza.Focus();
                    con.DesConnectarBD();

                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }
    }
}

