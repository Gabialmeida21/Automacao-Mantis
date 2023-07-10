using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.DataBaseSteps;
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
    public class GerenciarPerfisGlobaisTest : TestBase
    {
        #region Pages and Flows Objects
        MainPage mainPage;
        GerenciarPerfisGlobaisPage gerenciarPerfisGlobaisPage;
        PerfilGlobaisFlows perfilGlobaisFlows;
        #endregion

        [SetUp]
        public void RealizarLogin()
        {
            LoginFlows loginFlows = new LoginFlows();
            loginFlows.EfetuarLogin("administrator", "administrator");
        }

        #region Parameters
        string nomePlataforma = "Plataforma Teste de Automação";
        string nomeSO = "Windows";
        string versaoSO = "Versão 11";
        string descricao = "Descricao Adicional sobre o SO";
        #endregion

        [Test]
        public void AdicionarPerfil()
        {
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            mainPage = new MainPage();

            

            PerfisGlobaisDBSteps.DeletarPerfisGlobais(nomePlataforma);

            mainPage.ClicarMenuGerenciar();
            gerenciarPerfisGlobaisPage.AbaGerenciarPerfisGlobais();
            gerenciarPerfisGlobaisPage.PreencherNomePlataforma(nomePlataforma);
            gerenciarPerfisGlobaisPage.PreencherNomeSO(nomeSO);
            gerenciarPerfisGlobaisPage.PreencherVersaoSO(versaoSO);
            gerenciarPerfisGlobaisPage.PreencherDescricao(descricao);
            gerenciarPerfisGlobaisPage.ClicarAdcionarPerfil();

            Assert.AreEqual(nomePlataforma, PerfisGlobaisDBSteps.RetornarPerfisGlobais(nomePlataforma));
        }

        [Test]
        public void EditarPerfil()
        {
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            mainPage = new MainPage();
            perfilGlobaisFlows = new PerfilGlobaisFlows();

            #region Parameters
            string nomePlataformaCombo = $"{nomePlataforma} {nomeSO} {versaoSO}";
            string nomePlataformaEditado = "Plataforma Teste de Automação Ed";
            #endregion

            PerfisGlobaisDBSteps.DeletarPerfisGlobais(nomePlataforma);
            PerfisGlobaisDBSteps.DeletarPerfisGlobais(nomePlataformaEditado);
            perfilGlobaisFlows.CriarNovoPerfil(nomePlataforma);
            
            gerenciarPerfisGlobaisPage.ClicarEditarPerfil();
            gerenciarPerfisGlobaisPage.SelecionarPerfil(nomePlataformaCombo);
            gerenciarPerfisGlobaisPage.ClicarEnviar();
            gerenciarPerfisGlobaisPage.ApagarNomePlataforma();
            gerenciarPerfisGlobaisPage.EditarNomePlataforma(nomePlataformaEditado);
            gerenciarPerfisGlobaisPage.ClicarAtualizarPerfil();

            Assert.AreEqual(nomePlataformaEditado, PerfisGlobaisDBSteps.RetornarPerfisGlobais(nomePlataformaEditado));

            PerfisGlobaisDBSteps.DeletarPerfisGlobais(nomePlataforma);
            PerfisGlobaisDBSteps.DeletarPerfisGlobais(nomePlataformaEditado);
        }

        [Test]
        public void ApagarPerfil()
        {
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            mainPage = new MainPage();
            perfilGlobaisFlows = new PerfilGlobaisFlows();

            #region Parameters
            string nomePlataformaCombo = $"{nomePlataforma} {nomeSO} {versaoSO}";
            #endregion

            PerfisGlobaisDBSteps.DeletarPerfisGlobais(nomePlataforma);
            perfilGlobaisFlows.CriarNovoPerfil(nomePlataforma);

            gerenciarPerfisGlobaisPage.ClicarApagarPerfil();
            gerenciarPerfisGlobaisPage.SelecionarPerfil(nomePlataformaCombo);
            gerenciarPerfisGlobaisPage.ClicarEnviar();

            Assert.Null(PerfisGlobaisDBSteps.RetornarPerfisGlobais(nomePlataforma));

            PerfisGlobaisDBSteps.DeletarPerfisGlobais(nomePlataforma);
        }
    }
}
