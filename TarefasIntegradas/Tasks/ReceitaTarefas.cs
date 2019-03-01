﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TarefasIntegradas.Models;
using TarefasIntegradas.Utils;

namespace TarefasIntegradas.Tasks
{
    //public class ReceitaTarefas
    //{
    //    public static List<Receita> ColecaoReceitas = new List<Receita>();

    //    public static void getReceitas(HtmlNode docNode)
    //    {
    //        var receitasPagina = parseReceitas(docNode);

    //        ColecaoReceitas.AddRange(receitasPagina);

    //        var paginacao = docNode.SelectSingleNode("//div[@class='pages']/span/following-sibling::a[1]");

    //        if (paginacao != null)
    //        {
    //            Robo.CarregaPagina("https://pt.petitchef.com" + paginacao.GetAttributeValue("href", string.Empty));

    //            getReceitas(Robo.doc.DocumentNode);
    //        }
    //    }

    //    private static List<Receita> parseReceitas(HtmlNode docNode)
    //    {
    //        var linhas = docNode.SelectNodes("//div[@class='recipe-list']/div/div[@class='i-right']");

    //        List<Receita> receitas = new List<Receita>();

    //        foreach (var item in linhas)
    //        {
    //            if (item.SelectSingleNode("./div[@class='ingredients']/span/text()") != null)
    //            {
    //                Receita receita = new Receita();

    //                receita.Titulo = getTitulo(item);
    //                receita.EnderecoReceita = getEnderecoReceita(item);
    //                receita.Avaliacao = getAvaliacao(item);
    //                receita.QuantidadeVotos = getVotos(item);
    //                receita.QuantidadeComentarios = getComentarios(item);
    //                receita.QuantidadeCurtidas = getCurtidas(item);
    //                receita.TipoReceita = getTipoReceita(item);
    //                receita.Dificuldade = getDificuldade(item);
    //                receita.TempoPreparo = getTempoPreparo(item);
    //                receita.Calorias = getCalorias(item);
    //                receita.Ingredientes = getIngredientes(item);
    //                receita.Cozedura = getCozedura(item);
    //                receita.SemGlutem = getGlutem(item);

    //                receitas.Add(receita);
    //            }
    //        }

    //        return receitas;
    //    }

    //    private static string getAvaliacao(HtmlNode item)
    //    {
    //        var conjunto = "Ainda não há avaliações";

    //        ////conjuntoSocial = Classificação/Avaliações, Votos e Curtidas;
    //        var conjuntoSocial = item.SelectSingleNode("./div/i");

    //        if (conjuntoSocial != null)
    //        {
    //            var match = Regex.Match(conjuntoSocial.GetAttributeValue("title", string.Empty), @"(\d.\d+)");

    //            if (match.Success)
    //                conjunto = match.Value;
    //        }

    //        return conjunto;
    //    }

    //    private static string getVotos(HtmlNode linha)
    //    {
    //        var conjunto = "Ainda não recebeu votos";

    //        ////conjuntoSocial = Classificação/Avaliações, Votos e Curtidas;
    //        var conjuntoSocial = linha.SelectSingleNode("./div/i");

    //        if (conjuntoSocial != null)
    //        {
    //            var match = Regex.Match(conjuntoSocial.GetAttributeValue("title", string.Empty), @"\((\d+)");

    //            if (match.Success)
    //                conjunto = match.Groups[1].Value;
    //        }

    //        return conjunto;
    //    }

    //    private static string getComentarios(HtmlNode linha)
    //    {
    //        var conjunto = "Ainda não recebeu comentários";

    //        ////conjuntoSocial = Classificação/Avaliações, Votos e Curtidas;
    //        var conjuntoSocial = linha.SelectSingleNode("./div/i[2]/following-sibling::text()");

    //        if (conjuntoSocial != null)
    //        {
    //            var match = Regex.Match(conjuntoSocial.InnerText, @"\d+");

    //            if (match.Success)

    //                conjunto = match.Value;
    //        }

    //        return conjunto;
    //    }

    //    private static string getCurtidas(HtmlNode linha)
    //    {
    //        var conjunto = "Ainda não recebeu curtidas";

    //        ////conjuntoSocial = Classificação/Avaliações, Votos e Curtidas;
    //        var conjuntoSocial = linha.SelectSingleNode("./div/i[3]/following-sibling::text()");

    //        if (conjuntoSocial != null)
    //        {
    //            var match = Regex.Match(conjuntoSocial.InnerText, @"\d+");

    //            if (conjuntoSocial != null && match.Success)
    //                conjunto = match.Value;
    //        }

    //        return conjunto;
    //    }

    //    private static string getGlutem(HtmlNode linha)
    //    {
    //        var conjunto = "Não informado";

    //        var informacao = linha.SelectSingleNode("/div[@class='i-right']/div/img/@title");

    //        if (informacao != null)
    //        {
    //            conjunto = informacao.InnerText;
    //        }

    //        return conjunto;
    //    }

    //    private static string getTitulo(HtmlNode linha)
    //    {
    //        var conjunto = "Não informado";

    //        var informacao = linha.SelectSingleNode("./h2/a").InnerText;

    //        if (informacao != null)
    //        {
    //            conjunto = informacao;
    //        }

    //        return conjunto;
    //    }

    //    private static string getEnderecoReceita(HtmlNode linha)
    //    {
    //        var conjunto = "Não informado";

    //        var informacao = linha.SelectSingleNode("./h2/a").GetAttributeValue("href", string.Empty);

    //        if (informacao != null)
    //        {
    //            conjunto = ("https://pt.petitchef.com" + informacao);
    //        }

    //        return conjunto;
    //    }

    //    private static string getTipoReceita(HtmlNode linha)
    //    {
    //        var conjunto = "Não informado";

    //        var informacao = linha.SelectSingleNode("./div[@class='prop']/span/i[@class='fa fa-utensils fa-fw']/following-sibling::text()").InnerText;

    //        if (informacao != null)
    //        {
    //            conjunto = informacao;
    //        }

    //        return conjunto;
    //    }

    //    private static string getDificuldade(HtmlNode linha)
    //    {
    //        var conjunto = "Não informado";

    //        var informacao = linha.SelectSingleNode("./div[@class='prop']/span/i[@class='fa fa-signal fa-fw']/following-sibling::text()").InnerText;

    //        if (informacao != null)
    //        {
    //            conjunto = informacao;
    //        }

    //        return conjunto;
    //    }

    //    private static string getTempoPreparo(HtmlNode linha)
    //    {
    //        var conjunto = "Não informado";

    //        var informacao = linha.SelectSingleNode("./div[@class='prop']/span/i[@class='fa fa-clock fa-fw']/following-sibling::text()").InnerText;

    //        if (informacao != null)
    //        {
    //            conjunto = informacao;
    //        }

    //        return conjunto;
    //    }

    //    private static string getCalorias(HtmlNode linha)
    //    {
    //        var conjunto = "Não informado";

    //        var informacao = linha.SelectSingleNode("./div[@class='prop']/span/i[@class='fa fa-balance-scale fa-fw']/following-sibling::text()");

    //        if (informacao != null)
    //        {
    //            conjunto = informacao.InnerText;
    //        }

    //        return conjunto;
    //    }

    //    private static string getIngredientes(HtmlNode linha)
    //    {
    //        var conjunto = "Não informado";

    //        var informacao = linha.SelectSingleNode("./div[@class='ingredients']/span/following-sibling::text()").InnerText;

    //        if (informacao != null)
    //        {
    //            conjunto = informacao;
    //        }

    //        return conjunto;
    //    }

    //    private static string getCozedura(HtmlNode linha)
    //    {
    //        var conjunto = "Não informado";

    //        var informacao = linha.SelectSingleNode("./div[@class='prop']/span/i[@class='fa fa-fire fa-fw']/following-sibling::text()");

    //        if (informacao != null)
    //        {
    //            conjunto = informacao.InnerText;
    //        }

    //        return conjunto;
    //    }

    //    public static void ImprimeListaReceitas(List<Receita> colecao)
    //    {
    //        foreach (var item in colecao)
    //        {
    //            Console.WriteLine(colecao.IndexOf(item) + " -  " + item.Titulo + " / " + item.Avaliacao + " / " + item.Dificuldade);
    //        }
    //    }
    //}
}
