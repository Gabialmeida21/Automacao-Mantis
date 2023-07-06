using CSharpSeleniumExtentReportNetCoreTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.DataBaseSteps
{
    public class MarcadoresDBSteps
    {
        public static void DeletarMarcador(string name)
        {
            string queryFile = GeneralHelpers.GetProjectPath() + @"Queries/Marcadores/DeletarMarcador.sql";

            string query = GeneralHelpers.ReplaceValueInFile(queryFile, "{name}", name);

            DataBaseHelpers.ExecuteQuery(query);
        }

        public static string RetornarMarcador(string name)
        {

            string queryFile = GeneralHelpers.GetProjectPath() + @"Queries/Marcadores/RetornarMarcador.sql";

            string query = GeneralHelpers.ReplaceValueInFile(queryFile, "{name}", name);

            List<string> dadosQuery = DataBaseHelpers.RetornaDadosQuery(query);

            return dadosQuery.FirstOrDefault();
        }

    }
}
