using TarefasIntegradas.Consultas.ConsultaReceitas;
using TarefasIntegradas.Consultas.ConsultaSpecies;
using TarefasIntegradas.Tasks;
using TarefasIntegradas.Utils;

namespace TarefasIntegradas
{
    class Program
    {
        static void Main(string[] args)
        {

            //FonteSpecies fonteSpecies = new FonteSpecies();

            //fonteSpecies.GetData();

            //fonteSpecies.ImprimeListaSpecies();

            
            FonteReceitas fonteReceitas = new FonteReceitas();

            fonteReceitas.GetData();

            fonteReceitas.ImprimeListaReceitas();

        }
    }
}
