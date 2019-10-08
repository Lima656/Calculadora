using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        Double valor = 0;
        String operador = "";
        bool operacao_selecionada = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        //Criar Método Genérico Para Reconhecer o o evento de click em cada número
        private void btn_Click(object sender, EventArgs e)
        {
            //Remover o Digito "0" padrão da tela da calculadora quando começar a digitar ou quando for selecionada uma operação
            if ((txt_Visualizar.Text == "0") || (operacao_selecionada))
            txt_Visualizar.Clear();
            //Exibir digito na tela da calculadora
            Button b = (Button)sender;
            txt_Visualizar.Text = txt_Visualizar.Text + b.Text;
        }

        private void btn_apagarUltimoRegistroDigitado_Click(object sender, EventArgs e)
        {
            //Apagar Calculo na Tela e Retornar a Zero
            txt_Visualizar.Text = "0";
        }

        private void operador_Click(object sender, EventArgs e)
        {
            //Após selecionar a operação tranforma a String informada no botão em double
            Button b = (Button)sender;
            operador = b.Text;
            valor = Double.Parse(txt_Visualizar.Text);
            operacao_selecionada = true;
            lbl_equacao.Text = valor + " " + operador;
        }

        private void btn_igual_Click(object sender, EventArgs e)
        {
            //Verificar operação que deve ser calculada
            lbl_equacao.Text = "";
            switch (operador)
            {
                case "+":
                    txt_Visualizar.Text = (valor + double.Parse(txt_Visualizar.Text)).ToString();
                    break;
                case "-":
                    txt_Visualizar.Text = (valor - double.Parse(txt_Visualizar.Text)).ToString();
                    break;
                case "*":
                    txt_Visualizar.Text = (valor * double.Parse(txt_Visualizar.Text)).ToString();
                    break;
                case "/":
                    txt_Visualizar.Text = (valor / double.Parse(txt_Visualizar.Text)).ToString();
                    break;
                default:
                    break;
            }
            operacao_selecionada = false;


        }

        private void btn_limparTela_Click(object sender, EventArgs e)
        {
            txt_Visualizar.Clear();
        }
    }
}
