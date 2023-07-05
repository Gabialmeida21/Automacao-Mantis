using CSharpSeleniumExtentReportNetCoreTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.DataBaseSteps
{
    public class TarefasDBSteps
    {
        public static void DeletarTarefa(string name)
        {
            string queryFile = GeneralHelpers.GetProjectPath() + @"Queries/Tarefas/DeletarTarefa.sql";

            string query = GeneralHelpers.ReplaceValueInFile(queryFile, "{summary}", name);

            DataBaseHelpers.ExecuteQuery(query);
        }
    }
}
