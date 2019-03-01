using HtmlAgilityPack;
using TarefasIntegradas.Consultas.ConsultaSpecies;

namespace TarefasIntegradas.Utils
{
    public class Robo
    {
        public HtmlDocument GetHtmlDocument(string url)
        {
            var web = new HtmlWeb();
            return web.Load(url);
        }
    }
}
