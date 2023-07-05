using CSharpSeleniumExtentReportNetCoreTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.DataBaseSteps
{
    public class ProjetosDBSteps
    {
        public static void DeletarProjeto(string name)
        {
            string queryFile = GeneralHelpers.GetProjectPath() + @"Queries/Projetos/DeletarProjeto.sql";

            string query = GeneralHelpers.ReplaceValueInFile(queryFile, "{name}", name);

            DataBaseHelpers.ExecuteQuery(query);
        }

        public static string RetornarProjeto(string name)
        {

            string queryFile = GeneralHelpers.GetProjectPath() + @"Queries/Projetos/RetornarProjeto.sql";

            string query = GeneralHelpers.ReplaceValueInFile(queryFile, "{name}", name);

            List <string> dadosQuery = DataBaseHelpers.RetornaDadosQuery(query);

            return dadosQuery.FirstOrDefault();
        }

        public static string RetornarEstadoProjeto(string name)
        {

            string queryFile = GeneralHelpers.GetProjectPath() + @"Queries/Projetos/RetornaEstadoProjeto.sql";

            string query = GeneralHelpers.ReplaceValueInFile(queryFile, "{name}", name);

            List<string> dadosQuery = DataBaseHelpers.RetornaDadosQuery(query);

            return dadosQuery.FirstOrDefault();
        }

        public static void DeletarCategoria(string nameCategory)
        {
            string queryFile = GeneralHelpers.GetProjectPath() + @"Queries/Projetos/DeletarCategoria.sql";

            string query = GeneralHelpers.ReplaceValueInFile(queryFile, "{name}", nameCategory);

            DataBaseHelpers.ExecuteQuery(query);
        }

        public static string RetornarCategoria(string nameCategory)
        {

            string queryFile = GeneralHelpers.GetProjectPath() + @"Queries/Projetos/RetornarCategoria.sql";

            string query = GeneralHelpers.ReplaceValueInFile(queryFile, "{name}", nameCategory);

            List<string> dadosQuery = DataBaseHelpers.RetornaDadosQuery(query);

            return dadosQuery.FirstOrDefault();
        }
    }
}
