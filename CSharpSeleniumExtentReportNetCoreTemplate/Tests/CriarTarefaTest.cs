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
        LoginPage loginPage;
        MainPage mainPage;
        CriarTarefaPage criarTarefaPage;

        #endregion

        [SetUp]
        public void AntesDeComecarOsTestes()
        {
            LoginFlows loginFlows = new LoginFlows();
            loginFlows.EfetuarLogin("administrator", "administrator");

            ProjetoFlows projetoFlows = new ProjetoFlows();
            projetoFlows.CriarNovoProjeto("Teste Automação Mantis Web");
        }

        [Test]
        public void CriarTarefaComSucesso()
        {

            criarTarefaPage = new CriarTarefaPage();
            mainPage = new MainPage();

            #region Parameters
            string mensagemSucesso = "Operação realizada com sucesso.";

            string selecionarProjeto = "Project 46";
            string selecionarCategoria = "[Todos os Projetos] Teste Mantis";
            string atribuicaoNome = "administrator";
            string resumo = "Tarefa de Teste Mantis2";
            string descricao = "Desafio Automação Web";
            string passosReproduzir = "1.Realizar Login";


            #endregion


            mainPage.ClicarSelecionarProjetoGeral();

            mainPage.SelecionarTodosOsProjetos();

            mainPage.ClicarMenuCriarTarefa();

            criarTarefaPage.SelecionarProjeto(selecionarProjeto);

            criarTarefaPage.ClicarBotaoSelecionarProjeto();

            criarTarefaPage.SelecionarCategoria(selecionarCategoria);

            criarTarefaPage.SelecionarAtribuicao(atribuicaoNome);

            criarTarefaPage.PreencherResumo(resumo);

            criarTarefaPage.PreencherDescricao(descricao);

            criarTarefaPage.PreencherPassosParaReproduzir(passosReproduzir);

            criarTarefaPage.ClicarBotaoCriarNovaTarefa();

            Assert.AreEqual(mensagemSucesso, criarTarefaPage.RetornaMensagemSucesso());


        }
    }
}
