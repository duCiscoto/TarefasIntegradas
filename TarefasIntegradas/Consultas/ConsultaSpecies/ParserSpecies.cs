using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using TarefasIntegradas.Models;

namespace TarefasIntegradas.Consultas.ConsultaSpecies
{
    public class ParserSpecies
    {
        private HtmlNode docNode;

        public ParserSpecies(HtmlNode docNode)
        {
            this.docNode = docNode;
        }

        public void ParseData(List<Specie> species)
        {
            HtmlNodeCollection linhas = this.docNode.SelectNodes("//tbody/tr");

            foreach (var item in linhas)
            {
                Specie specie = new Specie();

                specie.commonName = this.GetCommonName(item);
                specie.scientificName = this.GetScientificName(item);
                specie.conservationStatus = this.GetConservationStatus(item);

                species.Add(specie);
            }
        }

        private string GetCommonName(HtmlNode linha)
        {
            if (linha.SelectSingleNode("./td[1]/a") == null)
                throw new Exception("CommonName retornou \"null\"!");

            return linha.SelectSingleNode("./td[1]/a").InnerText;
        }

        private string GetScientificName(HtmlNode linha)
        {
            if (linha.SelectSingleNode("./td[2]/em") == null)
                throw new Exception("ScientificName retornou \"null\"!");

            return linha.SelectSingleNode("./td[2]/em").InnerText;
        }

        private string GetConservationStatus(HtmlNode linha)
        {
            if (linha.SelectSingleNode("./td[3]") == null)
                throw new Exception("ConservationStatus retornou \"null\"!");

            return linha.SelectSingleNode("./td[3]").InnerText;
        }

        public bool HasNextPage(out string url)
        {
            var paginacao = docNode.SelectSingleNode("//li[@class='page active']/following-sibling::li[1]/a");

            url = string.Empty;

            if (paginacao != null)
            {
                url = "https://www.worldwildlife.org" + paginacao.GetAttributeValue("href", string.Empty);
            }

            return paginacao != null;
        }

    }
}
