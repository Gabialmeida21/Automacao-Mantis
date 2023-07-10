using CSharpSeleniumExtentReportNetCoreTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.DataBaseSteps
{
    public class PerfisGlobaisDBSteps
    {
        public static string RetornarPerfisGlobais(string namePlatform)
        {

            string queryFile = GeneralHelpers.GetProjectPath() + @"Queries/PerfisGlobais/RetornarPerfisGlobais.sql";

            string query = GeneralHelpers.ReplaceValueInFile(queryFile, "{platform}", namePlatform);

            List<string> dadosQuery = DataBaseHelpers.RetornaDadosQuery(query);

            return dadosQuery.FirstOrDefault();
        }

        public static void DeletarPerfisGlobais(string namePlatform)
        {
            string queryFile = GeneralHelpers.GetProjectPath() + @"Queries/PerfisGlobais/DeletarPerfisGlobais.sql";

            string query = GeneralHelpers.ReplaceValueInFile(queryFile, "{platform}", namePlatform);

            DataBaseHelpers.ExecuteQuery(query);
        }
    }
}
