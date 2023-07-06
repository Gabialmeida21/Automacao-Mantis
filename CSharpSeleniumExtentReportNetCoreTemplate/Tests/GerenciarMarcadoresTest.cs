using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.DataBaseSteps;
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
        MarcadoresFlows marcadoresFlows;
        #endregion

        [SetUp]
        public void RealizarLogin()
        {
            LoginFlows loginFlows = new LoginFlows();
            loginFlows.EfetuarLogin("administrator", "administrator");
        }

        #region
        string nomeMarcador = "Marcador Teste de Automação Mantis";
        string descricaoMarcador = "Preencher descrição para criar um marcador no Mantis";
        #endregion

        [Test]
        public void CriarMarcador()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            mainPage = new MainPage();

            MarcadoresDBSteps.DeletarMarcador(nomeMarcador);

            mainPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarAbaMarcador();
            gerenciarMarcadoresPage.clicarCriarMarcador();
            gerenciarMarcadoresPage.PreencherNomeMarcador(nomeMarcador);
            gerenciarMarcadoresPage.PreencherDescricao(descricaoMarcador);
            gerenciarMarcadoresPage.ClicarMenuMarcador2();

            Assert.AreEqual(nomeMarcador, gerenciarMarcadoresPage.ValidarMarcador(nomeMarcador));

            MarcadoresDBSteps.DeletarMarcador(nomeMarcador);
        }

        [Test]
        public void CriarMaisDeUmMarcador()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            mainPage = new MainPage();

            #region Parameters
            string nomeMarcador1 = "Marcador Teste 1";
            string nomeMarcador2 = "Marcador Teste 2";
            #endregion

            MarcadoresDBSteps.DeletarMarcador(nomeMarcador1);
            MarcadoresDBSteps.DeletarMarcador(nomeMarcador2);
            
            mainPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarAbaMarcador();
            gerenciarMarcadoresPage.clicarCriarMarcador();
            gerenciarMarcadoresPage.PreencherNomeMarcador(nomeMarcador1 + ", " + nomeMarcador2);
            gerenciarMarcadoresPage.PreencherDescricao(descricaoMarcador);
            gerenciarMarcadoresPage.ClicarMenuMarcador2();

            Assert.AreEqual(nomeMarcador1, gerenciarMarcadoresPage.ValidarMarcador(nomeMarcador1));
            Assert.AreEqual(nomeMarcador2, gerenciarMarcadoresPage.ValidarMarcador(nomeMarcador2));

            MarcadoresDBSteps.DeletarMarcador(nomeMarcador1);
            MarcadoresDBSteps.DeletarMarcador(nomeMarcador2);
        }

        [Test]
        public void AtualizarNomeMarcador()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            mainPage = new MainPage();
            marcadoresFlows = new MarcadoresFlows();

            #region Parameters
            string nomeMarcadorEditado = "Marcador Teste Editado";
            #endregion

            MarcadoresDBSteps.DeletarMarcador(nomeMarcadorEditado);
            MarcadoresDBSteps.DeletarMarcador(nomeMarcador);
            marcadoresFlows.CriarMarcador(nomeMarcador);

            mainPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarAbaMarcador();
            gerenciarMarcadoresPage.ClicarMarcador(nomeMarcador);
            gerenciarMarcadoresPage.ClicarAtualizarMarcador();
            gerenciarMarcadoresPage.ApagarNomeMarcador();
            gerenciarMarcadoresPage.PreencherNomeMarcador(nomeMarcadorEditado);
            gerenciarMarcadoresPage.ClicarAtualizarMarcador();

            Assert.AreEqual(nomeMarcadorEditado, gerenciarMarcadoresPage.RetornarNomeMarcadorAposEditar(nomeMarcadorEditado));

            MarcadoresDBSteps.DeletarMarcador(nomeMarcadorEditado);
            MarcadoresDBSteps.DeletarMarcador(nomeMarcador);
        }

        [Test]
        public void AtualizarNomeMarcadorComCampoVazio()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            mainPage = new MainPage();
            marcadoresFlows = new MarcadoresFlows();

            #region Parameters
            
            #endregion

            MarcadoresDBSteps.DeletarMarcador(nomeMarcador);
            marcadoresFlows.CriarMarcador(nomeMarcador);

            mainPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarAbaMarcador();
            gerenciarMarcadoresPage.ClicarMarcador(nomeMarcador);
            gerenciarMarcadoresPage.ClicarAtualizarMarcador();
            gerenciarMarcadoresPage.ApagarNomeMarcador();
            gerenciarMarcadoresPage.ClicarAtualizarMarcador();

            Assert.That(gerenciarMarcadoresPage.RetornaMensagemErro().Contains("Nome de marcador não é válido."));
            
            MarcadoresDBSteps.DeletarMarcador(nomeMarcador);
        }

        [Test]
        public void AtualizarDescricaoMarcador()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            mainPage = new MainPage();
            marcadoresFlows = new MarcadoresFlows();

            #region Parameters
            string descricao = "Editar descrição do Marcador";
            #endregion

            MarcadoresDBSteps.DeletarMarcador(nomeMarcador);
            marcadoresFlows.CriarMarcador(nomeMarcador);

            mainPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarAbaMarcador();
            gerenciarMarcadoresPage.ClicarMarcador(nomeMarcador);
            gerenciarMarcadoresPage.ClicarAtualizarMarcador();
            gerenciarMarcadoresPage.ApagarDescricao();
            gerenciarMarcadoresPage.PreencherDescricao(descricao);
            gerenciarMarcadoresPage.ClicarAtualizarMarcador();

            Assert.AreEqual(descricao, gerenciarMarcadoresPage.RetornarDescricaoMarcadorAposEditar(descricao));
            
            MarcadoresDBSteps.DeletarMarcador(nomeMarcador);
        }

        [Test]
        public void ApagarMarcador()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
            mainPage = new MainPage();
            marcadoresFlows = new MarcadoresFlows();

            MarcadoresDBSteps.DeletarMarcador(nomeMarcador);
            marcadoresFlows.CriarMarcador(nomeMarcador);
            
            mainPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarAbaMarcador();
            gerenciarMarcadoresPage.ClicarMarcador(nomeMarcador);
            gerenciarMarcadoresPage.ApagarMarcador();
            gerenciarMarcadoresPage.ApagarMarcador();

            Assert.Null(MarcadoresDBSteps.RetornarMarcador(nomeMarcador));

            MarcadoresDBSteps.DeletarMarcador(nomeMarcador);
        }

    }
}