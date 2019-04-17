using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCep;           
		}            

        private void BuscarCep(object sender, EventArgs args)
        {
            //codigo

            //validações
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {

                try
                {

                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {

                        RESULTADO.Text = string.Format("Endereço:{0}, Uf:{1}, Rua:{2}", end.localidade, end.uf, end.logradouro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o cep informado" + cep, "OK");
                    }
                }

                catch(Exception e)
                {
                    DisplayAlert("ERRO CRITICO", e.Message, "OK");
                }
            }

        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if(cep.Length !=8)
            {
                DisplayAlert("ERRO", "CEP invalido! O CEP deve conter 8 caracteres.", "OK");

                valido = false;
            }
            

            int NovoCEP = 0;

            if(int.TryParse(cep, out NovoCEP))

            {
                DisplayAlert("ERRO", "CEP INVALIDO! O CEP deve conter apenas numeros.", "OK");

                valido = false;
            }

            return valido;
        }


    }
}
