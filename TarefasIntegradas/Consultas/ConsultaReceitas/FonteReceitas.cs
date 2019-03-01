using System;
using System.Collections.Generic;
using TarefasIntegradas.Models;
using TarefasIntegradas.Utils;

namespace TarefasIntegradas.Consultas.ConsultaReceitas
{
    class FonteReceitas : Robo
    {
        public static List<Receita> ColecaoReceitas = new List<Receita>();

        public void GetData()
        {
            var parser = NavegaPagina("https://pt.petitchef.com/receitas/rapida");

            parser.ParseData(ColecaoReceitas);

            string url;

            while (parser.HasNextPage(out url))
            {
                parser = NavegaPagina(url);

                parser.ParseData(ColecaoReceitas);
            }
        }

        private ParserReceitas NavegaPagina(string url)
        {
            var docNode = this.GetHtmlDocument(url).DocumentNode;

            return new ParserReceitas(docNode);
        }

        public void ImprimeListaReceitas()
        {
            foreach (var item in ColecaoReceitas)
            {
                Console.WriteLine(ColecaoReceitas.IndexOf(item) + " -  " + item.Titulo + " / " + item.TipoReceita + " / " + item.EnderecoReceita);
            }
        }

    }
}
