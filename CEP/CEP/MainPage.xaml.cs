using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CEP.Servico.Modelo;
using CEP.Servico;


namespace CEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnBuscarCep.Clicked += BuscarEndereco;
        }

        private void BuscarEndereco(object sender, EventArgs e)
        {
            string cep = txtCep.Text.Trim();

            if (IsValid(cep))
            {
                try
                {
                    Endereco endereco = ViaCEPServico.BuscarEndereco(cep);

                    if(endereco.cep != null)
                    {
                        lblCep.Text = "CEP: " + endereco.cep;
                        lblLogradouro.Text = "Logradouro: " + endereco.logradouro;
                        lblBairro.Text = "Bairro: " + endereco.bairro;
                        lblCidade.Text = "Cidade: " + endereco.localidade;
                        lblEstado.Text = "Estado: " + endereco.uf;

                        txtCep.Text = "";
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O não foi encontrado endereço para o CEP: " + cep, "OK");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
            }
        }

        private bool IsValid(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "O CEP deve conter 8 caracteres", "OK");

                valido = false;
            }

            if(!int.TryParse(cep, out int NovoCep))
            {
                DisplayAlert("ERRO", "O CEP deve conter somente números", "OK");

                valido = false;
            }

            return valido;
        }
    }
}
