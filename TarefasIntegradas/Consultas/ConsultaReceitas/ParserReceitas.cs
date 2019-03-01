using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TarefasIntegradas.Models;

namespace TarefasIntegradas.Consultas.ConsultaReceitas
{
    public class ParserReceitas
    {

        private HtmlNode docNode;

        public ParserReceitas(HtmlNode docNode)
        {
            this.docNode = docNode;
        }

        private bool IsReceita(HtmlNode node)
        {
            return node.SelectSingleNode("./div[@class='ingredients']/span/text()") != null;
        }

        public void ParseData(List<Receita> receitas)
        {
            HtmlNodeCollection linhas = this.docNode.SelectNodes("//div[@class='recipe-list']/div/div[@class='i-right']");

            foreach (var linha in linhas)
            {
                if (IsReceita(linha))
                {
                    Receita receita = new Receita();

                    receita.Titulo = this.getTitulo(linha);
                    receita.EnderecoReceita = this.getEnderecoReceita(linha);
                    receita.Avaliacao = this.getAvaliacao(linha);
                    receita.QuantidadeVotos = this.getVotos(linha);
                    receita.QuantidadeComentarios = this.getComentarios(linha);
                    receita.QuantidadeCurtidas = this.getCurtidas(linha);
                    receita.TipoReceita = this.getTipoReceita(linha);
                    receita.Dificuldade = this.getDificuldade(linha);
                    receita.TempoPreparo = this.getTempoPreparo(linha);
                    receita.Calorias = this.getCalorias(linha);
                    receita.Ingredientes = this.getIngredientes(linha);
                    receita.Cozedura = this.getCozedura(linha);
                    receita.SemGlutem = this.getGlutem(linha);

                    receitas.Add(receita);
                }
            }
        }

        private string getAvaliacao(HtmlNode linha)
        {
            var conjunto = "Ainda não há avaliações";

            ////conjuntoSocial = Classificação/Avaliações, Votos e Curtidas;
            var conjuntoSocial = linha.SelectSingleNode("./div/i");

            if (conjuntoSocial != null)
            {
                var match = Regex.Match(conjuntoSocial.GetAttributeValue("title", string.Empty), @"(\d.\d+)");

                if (match.Success)
                    conjunto = match.Value;
            }

            return conjunto;
        }

        /// <summary>
        /// Captura, caso haja, a quantidade de avaliações
        /// </summary>
        /// <param name="linha"></param>
        /// <returns>votos</returns>
        private string getVotos(HtmlNode linha)
        {
            var conjunto = "Ainda não recebeu votos";

            ////conjuntoSocial = Classificação/Avaliações, Votos e Curtidas;
            var conjuntoSocial = linha.SelectSingleNode("./div/i");

            if (conjuntoSocial != null)
            {
                var match = Regex.Match(conjuntoSocial.GetAttributeValue("title", string.Empty), @"\((\d+)");

                if (match.Success)
                    conjunto = match.Groups[1].Value;
            }

            return conjunto;
        }

        /// <summary>
        /// Captura, caso haja, a quantidade de comentários sobre a receita
        /// </summary>
        /// <param name="linha"></param>
        /// <returns>comentários</returns>
        private string getComentarios(HtmlNode linha)
        {
            var conjunto = "Ainda não recebeu comentários";

            ////conjuntoSocial = Classificação/Avaliações, Votos e Curtidas;
            var conjuntoSocial = linha.SelectSingleNode("./div/i[2]/following-sibling::text()");

            if (conjuntoSocial != null)
            {
                var match = Regex.Match(conjuntoSocial.InnerText, @"\d+");

                if (match.Success)

                    conjunto = match.Value;
            }

            return conjunto;
        }

        /// <summary>
        /// Captura, caso haja, a quantidade de curtidas da receita
        /// </summary>
        /// <param name="linha"></param>
        /// <returns>curtidas</returns>
        private string getCurtidas(HtmlNode linha)
        {
            var conjunto = "Ainda não recebeu curtidas";

            ////conjuntoSocial = Classificação/Avaliações, Votos e Curtidas;
            var conjuntoSocial = linha.SelectSingleNode("./div/i[3]/following-sibling::text()");

            if (conjuntoSocial != null)
            {
                var match = Regex.Match(conjuntoSocial.InnerText, @"\d+");

                if (conjuntoSocial != null && match.Success)
                    conjunto = match.Value;
            }

            return conjunto;
        }

        /// <summary>
        /// Captura, caso haja, se a receita é "sem Glúten"
        /// </summary>
        /// <param name="linha"></param>
        /// <returns></returns>
        private string getGlutem(HtmlNode linha)
        {
            var conjunto = "Não informado";

            var informacao = linha.SelectSingleNode("/div[@class='i-right']/div/img/@title");

            if (informacao != null)
            {
                conjunto = informacao.InnerText;
            }

            return conjunto;
        }

        /// <summary>
        /// Captura o título da receita
        /// </summary>
        /// <param name="linha"></param>
        /// <returns>título</returns>
        private string getTitulo(HtmlNode linha)
        {
            var conjunto = "Não informado";

            var informacao = linha.SelectSingleNode("./h2/a").InnerText;

            if (informacao != null)
            {
                conjunto = informacao;
            }

            return conjunto;
        }

        /// <summary>
        /// Captura o endereço da receita (URL)
        /// </summary>
        /// <param name="linha"></param>
        /// <returns>endereçoReceita</returns>
        private string getEnderecoReceita(HtmlNode linha)
        {
            var conjunto = "Não informado";

            var informacao = linha.SelectSingleNode("./h2/a").GetAttributeValue("href", string.Empty);

            if (informacao != null)
            {
                conjunto = ("https://pt.petitchef.com" + informacao);
            }

            return conjunto;
        }

        /// <summary>
        /// Captura, caso haja, o tipo da receita
        /// </summary>
        /// <param name="linha"></param>
        /// <returns>tipoReceita</returns>
        private string getTipoReceita(HtmlNode linha)
        {
            var conjunto = "Não informado";

            var informacao = linha.SelectSingleNode("./div[@class='prop']/span/i[@class='fa fa-utensils fa-fw']/following-sibling::text()");

            if (informacao != null)
            {
                conjunto = informacao.InnerText;
            }

            return conjunto;
        }

        /// <summary>
        /// Captura, caso haja, o nível de dificuldade no preparo da receita
        /// </summary>
        /// <param name="linha"></param>
        /// <returns>dificuldade</returns>
        private string getDificuldade(HtmlNode linha)
        {
            var conjunto = "Não informado";

            var informacao = linha.SelectSingleNode("./div[@class='prop']/span/i[@class='fa fa-signal fa-fw']/following-sibling::text()").InnerText;

            if (informacao != null)
            {
                conjunto = informacao;
            }

            return conjunto;
        }

        /// <summary>
        /// Captura, caso haja, o tempo de preparao da receita
        /// </summary>
        /// <param name="linha"></param>
        /// <returns>tempoPreparo</returns>
        private string getTempoPreparo(HtmlNode linha)
        {
            var conjunto = "Não informado";

            var informacao = linha.SelectSingleNode("./div[@class='prop']/span/i[@class='fa fa-clock fa-fw']/following-sibling::text()").InnerText;

            if (informacao != null)
            {
                conjunto = informacao;
            }

            return conjunto;
        }

        /// <summary>
        /// Captura, caso haja, as calorias da receita
        /// </summary>
        /// <param name="linha"></param>
        /// <returns>calorias</returns>
        private string getCalorias(HtmlNode linha)
        {
            var conjunto = "Não informado";

            var informacao = linha.SelectSingleNode("./div[@class='prop']/span/i[@class='fa fa-balance-scale fa-fw']/following-sibling::text()");

            if (informacao != null)
            {
                conjunto = informacao.InnerText;
            }

            return conjunto;
        }

        /// <summary>
        /// Captura os ingredientes apresentados na linha (bloco de dados)
        /// </summary>
        /// <param name="linha"></param>
        /// <returns>ingredientes</returns>
        private string getIngredientes(HtmlNode linha)
        {
            var conjunto = "Não informado";

            var informacao = linha.SelectSingleNode("./div[@class='ingredients']/span/following-sibling::text()").InnerText;

            if (informacao != null)
            {
                conjunto = informacao;
            }

            return conjunto;
        }

        /// <summary>
        /// Captura, caso haja, o tempo de cozedura da receita
        /// </summary>
        /// <param name="linha"></param>
        /// <returns>cozedura</returns>
        private string getCozedura(HtmlNode linha)
        {
            var conjunto = "Não informado";

            var informacao = linha.SelectSingleNode("./div[@class='prop']/span/i[@class='fa fa-fire fa-fw']/following-sibling::text()");

            if (informacao != null)
            {
                conjunto = informacao.InnerText;
            }

            return conjunto;
        }

        public bool HasNextPage(out string url)
        {
            var paginacao = docNode.SelectSingleNode("//div[@class='pages']/span/following-sibling::a[1]");

            url = string.Empty;

            if (paginacao != null)
            {
                url = "https://pt.petitchef.com" + paginacao.GetAttributeValue("href", string.Empty);
            }

            return paginacao != null;
        }

    }
}
