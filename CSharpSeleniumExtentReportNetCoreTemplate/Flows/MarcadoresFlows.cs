using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Flows
{
    public class MarcadoresFlows
    {
        #region Page Object and Constructor
        GerenciarMarcadoresPage gerenciarMarcadoresPage;
        MainPage mainPage;

        public MarcadoresFlows()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            mainPage = new MainPage();
        }
        #endregion

        #region  Parameters
        string descricaoMarcador = "Preencher descrição para criar um marcador no Mantis";
        #endregion

        public void CriarMarcador(string nomeMarcador)
        {
            mainPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarAbaMarcador();
            gerenciarMarcadoresPage.clicarCriarMarcador();
            gerenciarMarcadoresPage.PreencherNomeMarcador(nomeMarcador);
            gerenciarMarcadoresPage.PreencherDescricao(descricaoMarcador);
            gerenciarMarcadoresPage.ClicarMenuMarcador2();
        }

    }
}
