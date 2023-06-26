using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Flows;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using NUnit.Framework;

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
        public void CriarMarcador()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            mainPage = new MainPage();

            #region Parameters
            string nomeMarcador = "Teste Gabriela2";
            string descricaoMarcador = "Preencher descrição para criar um marcador no Mantis";
            string nomeAposCadastrarMarcador ="Teste Gabriela2";
            #endregion

            mainPage.ClicarMenuGerenciar();

            gerenciarMarcadoresPage.ClicarAbaMarcador();

            gerenciarMarcadoresPage.clicarCriarMarcador();

            gerenciarMarcadoresPage.PreencherNomeMarcador(nomeMarcador);

            gerenciarMarcadoresPage.PreencherDescricao(descricaoMarcador);

            gerenciarMarcadoresPage.ClicarMenuMarcador2();

            Assert.AreEqual(nomeAposCadastrarMarcador, gerenciarMarcadoresPage.ValidarMarcador());


        }
        [Test]
        public void ApagarMarcador()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            mainPage = new MainPage();

            
            mainPage.ClicarMenuGerenciar();

            gerenciarMarcadoresPage.ClicarAbaMarcador();

            gerenciarMarcadoresPage.clicarCriarMarcador();

            gerenciarMarcadoresPage.ApagarMarcador();

            gerenciarMarcadoresPage.ApagarMarcador();

            //fazer validação pelo banco de dados


        }

    }
}