using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Flows;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
{
    [TestFixture]
    public class GerenciarMarcadoresTest : TestBase
    {
        #region Pages and Flows Objects
        GerenciarMarcadoresPage gerenciarMarcadoresPage;
        MainPage mainPage;
        #endregion

        [SetUp]
        public void RealizarLogin()
        {
            LoginFlows loginFlows = new LoginFlows();
            loginFlows.EfetuarLogin("administrator", "administrator");
        }

        [Test]
        public void VerTarefasComSucesso()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();

            mainPage = new MainPage();

            mainPage.ClicarMenuGerenciar();

            gerenciarMarcadoresPage.ClicarAbaMarcador();

            gerenciarMarcadoresPage.clicarCriarMarcador();

            gerenciarMarcadoresPage.PreencherNomeMarcador("Teste Gabriela");

            gerenciarMarcadoresPage.PreencherDescricao("Preencher descrição para criar um marcador no Mantis");

            gerenciarMarcadoresPage.ClicarMenuMarcador2();


        }
    }
}