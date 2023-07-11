using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.DataBaseSteps;
using CSharpSeleniumExtentReportNetCoreTemplate.Flows;
using CSharpSeleniumExtentReportNetCoreTemplate.Helpers;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V112.Debugger;
using System;
using System.Collections;
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
        MainPage mainPage;
        CriarTarefaPage criarTarefaPage;
        ProjetoFlows projetoFlows;
        #endregion

        #region Data Driven Providers
        public static IEnumerable Tarefa()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.GetProjectPath() + "DataDriven\\CriarTarefa.csv");
        }
        #endregion

        [SetUp]
        public void AntesDeComecarOsTestes()
        {
            LoginFlows loginFlows = new LoginFlows();
            loginFlows.EfetuarLogin("administrator", "administrator");
        }

        [Test]
        public void CriarTarefaComSucesso()
        {

            criarTarefaPage = new CriarTarefaPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();

            #region Parameters
            string mensagemSucesso = "Operação realizada com sucesso.";
            string selecionarProjeto = "Teste Automação Mantis Web";
            string selecionarCategoria = "Teste Mantis";
            string atribuicaoNome = "administrator";
            string resumo = "Tarefa de Teste Mantis";
            string descricao = "Desafio Automação Web";
            string passosReproduzir = "1.Realizar Login";
            #endregion

            ProjetosDBSteps.DeletarProjeto(selecionarProjeto);
            ProjetosDBSteps.DeletarCategoria(selecionarCategoria);
            TarefasDBSteps.DeletarTarefa(resumo);
            projetoFlows.CriarCategoria(selecionarCategoria);
            projetoFlows.CriarNovoProjeto(selecionarProjeto);

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

            TarefasDBSteps.DeletarTarefa(resumo);
            ProjetosDBSteps.DeletarProjeto(selecionarProjeto);
            ProjetosDBSteps.DeletarCategoria(selecionarCategoria);
        }

        [Test, TestCaseSource("Tarefa")]
        public void CriarTarefaComSucessoUsandoDataDriven(ArrayList testData)
        {

            criarTarefaPage = new CriarTarefaPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();

            #region Parameters
            string mensagemSucesso = "Operação realizada com sucesso.";
            string selecionarProjeto = "Teste Automação Mantis Web";
            string selecionarCategoria = "Teste Mantis";
            string atribuicaoNome = "administrator";
            string resumo = testData[0].ToString();
            string descricao = "Desafio Automação Web";
            string passosReproduzir = "1.Realizar Login";
            #endregion

            ProjetosDBSteps.DeletarProjeto(selecionarProjeto);
            ProjetosDBSteps.DeletarCategoria(selecionarCategoria);
            TarefasDBSteps.DeletarTarefa(resumo);
            projetoFlows.CriarCategoria(selecionarCategoria);
            projetoFlows.CriarNovoProjeto(selecionarProjeto);

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

            TarefasDBSteps.DeletarTarefa(resumo);
            ProjetosDBSteps.DeletarProjeto(selecionarProjeto);
            ProjetosDBSteps.DeletarCategoria(selecionarCategoria);
        }
    }
}
