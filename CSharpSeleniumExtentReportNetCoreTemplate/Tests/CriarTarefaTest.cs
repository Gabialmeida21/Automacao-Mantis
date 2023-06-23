using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Flows;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V112.Debugger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
{
    [TestFixture]
    public class CriarTarefaTest : TestBase
    {
        #region Pages and Flows Objects
        CriarTarefaPage criarTarefaPage;
        #endregion

        [SetUp]
        public void RealizarLogin()
        {
            LoginFlows loginFlows = new LoginFlows();
            loginFlows.EfetuarLogin("administrator", "administrator");
        }

        [Test]
        public void CriarTarefaComSucesso()
        {

            criarTarefaPage = new CriarTarefaPage();

            criarTarefaPage.ClicarSelecionarProjetoGeral();

            criarTarefaPage.SelecionarTodosOsProjetos();

            criarTarefaPage.ClicarMenuCriarTarefa();
            
            criarTarefaPage.SelecionarProjeto("Project 46");

            criarTarefaPage.ClicarBotaoSelecionarProjeto();

            criarTarefaPage.SelecionarCategoria("[Todos os Projetos] Teste Mantis");

            criarTarefaPage.SelecionarAtribuicao("administrator");

            criarTarefaPage.PreencherResumo("Tarefa de Teste Mantis2");

            criarTarefaPage.PreencherDescricao("Desafio Automação Web");

            criarTarefaPage.PreencherPassosParaReproduzir("1.Realizar Login");

            criarTarefaPage.ClicarBotaoCriarNovaTarefa();
            
            
            
        }
    }
}
