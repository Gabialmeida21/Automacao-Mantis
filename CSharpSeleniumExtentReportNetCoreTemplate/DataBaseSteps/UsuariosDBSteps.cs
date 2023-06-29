using CSharpSeleniumExtentReportNetCoreTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.DataBaseSteps
{
    public class UsuariosDBSteps
    {
        public static void DeletarUsuarioCriado(string username)
        {
            string queryFile = GeneralHelpers.GetProjectPath() + @"Queries/Usuarios/DeletarUsuario.sql";

            string query = GeneralHelpers.ReplaceValueInFile(queryFile, "{username}", username);

            DataBaseHelpers.ExecuteQuery(query);
        }

        


    }
}
