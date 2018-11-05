using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using CEP.Servico.Modelo;
using Newtonsoft.Json;


namespace CEP.Servico
{
    public class ViaCEPServico
    {
        private static string URL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEndereco(string cep)
        {
            string NovaURL = string.Format(URL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovaURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return end;
        }
    }
}
