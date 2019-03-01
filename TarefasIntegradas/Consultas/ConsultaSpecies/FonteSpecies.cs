using System;
using System.Collections.Generic;
using TarefasIntegradas.Models;
using TarefasIntegradas.Utils;

namespace TarefasIntegradas.Consultas.ConsultaSpecies
{
    public class FonteSpecies : Robo
    {
        public static List<Specie> ColecaoSpecies = new List<Specie>();

        public void GetData()
        {
            var parser = NavegaPagina("https://www.worldwildlife.org/species/directory?sort=name&direction=");

            parser.ParseData(ColecaoSpecies);

            string url;

            while (parser.HasNextPage(out url))
            {
                parser = NavegaPagina(url);

                parser.ParseData(ColecaoSpecies);
            }
        }

        private ParserSpecies NavegaPagina(string url)
        {
            var docNode = this.GetHtmlDocument(url).DocumentNode;

            return new ParserSpecies(docNode);
        }

        public void ImprimeListaSpecies()
        {
            foreach (var item in ColecaoSpecies)
            {
                Console.WriteLine(ColecaoSpecies.IndexOf(item) + " -  " + item.commonName + " / " + item.scientificName + " / " + item.conservationStatus);
            }
        }

    }
}
