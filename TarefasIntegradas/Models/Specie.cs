using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Classe de espécies para ser usada com o WWF
/// </summary>
namespace TarefasIntegradas.Models
{
    public class Specie
    {
        public string commonName { get; set; }

        public string scientificName { get; set; }

        public string conservationStatus { get; set; }
    }
}
