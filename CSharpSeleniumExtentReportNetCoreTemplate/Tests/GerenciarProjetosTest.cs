using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.DataBaseSteps;
using CSharpSeleniumExtentReportNetCoreTemplate.Flows;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V112.Cast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
{
    [TestFixture]
    public class GerenciarProjetosTest : TestBase
    {
        #region Pages and Flows Objects
        MainPage mainPage;
        GerenciarProjetosPage gerenciarProjetosPage;
        ProjetoFlows projetoFlows;
        TarefaFlows tarefaFlows;
        #endregion

        [SetUp]
        public void RealizarLogin()
        {
            LoginFlows loginFlows = new LoginFlows();
            loginFlows.EfetuarLogin("administrator", "administrator");
        }

        #region Parameters
        string nomeProjeto = "Teste de Automação Mantis";
        string descricaoProjeto = "Teste de automação Web";
        string mensagemSucesso = "Operação realizada com sucesso.";
        string nomeCategoria = "Categoria Teste Automação";
        #endregion

        [Test]
        public void CriarProjetoComSucesso()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.CriarNovoProjeto();
            gerenciarProjetosPage.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.PreencherDescricaoProjeto(descricaoProjeto);
            gerenciarProjetosPage.ClicarAdicionarProjeto();

            Assert.AreEqual(mensagemSucesso, gerenciarProjetosPage.RetornaMensagemSucesso());

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
        }

        [Test]
        public void CriarProjetoJaExistente()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
            projetoFlows.CriarNovoProjeto(nomeProjeto);

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.CriarNovoProjeto();
            gerenciarProjetosPage.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.PreencherDescricaoProjeto(descricaoProjeto);
            gerenciarProjetosPage.ClicarAdicionarProjeto();

            Assert.That(gerenciarProjetosPage.RetornaMensagemErro().Contains("Um projeto com este nome já existe. Por favor, volte e entre um nome diferente."));

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
        }

        [Test]
        public void EditarProjetoComSucesso()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();

            string nomeProjetoAposAlterar = "Teste Alteração Projeto";

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
            ProjetosDBSteps.DeletarProjeto(nomeProjetoAposAlterar);
            projetoFlows.CriarNovoProjeto(nomeProjeto);

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.ApagarNomeProjeto();
            gerenciarProjetosPage.AlterarNomeProjeto(nomeProjetoAposAlterar);
            gerenciarProjetosPage.ClicarAtualizarProjeto();

            Assert.AreEqual(nomeProjetoAposAlterar, gerenciarProjetosPage.RetornaNomeProjetoAposAlteracao(nomeProjetoAposAlterar));

            ProjetosDBSteps.DeletarProjeto(nomeProjetoAposAlterar);
            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
        }

        [Test]
        public void AlterarEstadoProjetoParaEstavel()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();

            #region Parameters
            string estado = "estável";
            string idEstado = "50";
            #endregion

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
            projetoFlows.CriarNovoProjeto(nomeProjeto);

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.PreencherEstadoProjeto(estado);
            gerenciarProjetosPage.ClicarAtualizarProjeto();

            Assert.AreEqual(idEstado, ProjetosDBSteps.RetornarEstadoProjeto(nomeProjeto));

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
        }

        [Test]
        public void AlterarEstadoProjetoParaRelease()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();

            #region Parameters
            string estado = "release";
            string idEstado = "30";
            #endregion

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
            projetoFlows.CriarNovoProjeto(nomeProjeto);

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.PreencherEstadoProjeto(estado);
            gerenciarProjetosPage.ClicarAtualizarProjeto();

            Assert.AreEqual(idEstado, ProjetosDBSteps.RetornarEstadoProjeto(nomeProjeto));

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
        }

        [Test]
        public void AlterarEstadoProjetoParaObsoleto()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();

            #region Parameters
            string estado = "obsoleto";
            string idEstado = "70";
            #endregion

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
            projetoFlows.CriarNovoProjeto(nomeProjeto);

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.PreencherEstadoProjeto(estado);
            gerenciarProjetosPage.ClicarAtualizarProjeto();

            Assert.AreEqual(idEstado, ProjetosDBSteps.RetornarEstadoProjeto(nomeProjeto));

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
        }

        [Test]
        public void RemoverProjetoComSucesso()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
            projetoFlows.CriarNovoProjeto(nomeProjeto);

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarNomeProjetoParaApagar(nomeProjeto);
            gerenciarProjetosPage.ApagarProjeto();
            gerenciarProjetosPage.ApagarProjeto();

            Assert.Null(ProjetosDBSteps.RetornarProjeto(nomeProjeto));

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
        }

        [Test]
        public void AdicionarSubProjeto()
        {

            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();

            #region Parameters
            string nomeSubProjeto = "SubProjeto Automação Mantis";
            #endregion

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
            ProjetosDBSteps.DeletarProjeto(nomeSubProjeto);
            projetoFlows.CriarNovoProjeto(nomeProjeto);

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.ClicarCriarNovoSubprojeto();
            gerenciarProjetosPage.PreencherNomeProjeto(nomeSubProjeto);
            gerenciarProjetosPage.PreencherDescricaoProjeto(descricaoProjeto);
            gerenciarProjetosPage.ClicarAdicionarProjeto();

            Assert.AreEqual(mensagemSucesso, gerenciarProjetosPage.RetornaMensagemSucesso());

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
            ProjetosDBSteps.DeletarProjeto(nomeSubProjeto);
        }

        [Test]
        public void CadastrarCategoria()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
            
            ProjetosDBSteps.DeletarCategoria(nomeCategoria);
            
            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.PreencherNomeCategoria(nomeCategoria);
            gerenciarProjetosPage.ClicarAdicionarCategoria();

            Assert.AreEqual(nomeCategoria, ProjetosDBSteps.RetornarCategoria(nomeCategoria));
        }

        [Test]
        public void AdicionarCategoriaJaExistente()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();

            ProjetosDBSteps.DeletarCategoria(nomeCategoria);
            projetoFlows.CriarCategoria(nomeCategoria);

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.PreencherNomeCategoria(nomeCategoria);
            gerenciarProjetosPage.ClicarAdicionarCategoria();

            Assert.That(gerenciarProjetosPage.RetornaMensagemErroAoNaoPreencherCampo().Contains("Uma categoria com este nome já existe."));

            ProjetosDBSteps.DeletarCategoria(nomeCategoria);
        }

        [Test]
        public void AdicionarCategoriaSemPreencherCampo()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();

            ProjetosDBSteps.DeletarCategoria(nomeCategoria);

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarAdicionarCategoria();

            Assert.That(gerenciarProjetosPage.RetornaMensagemErroAoNaoPreencherCampo().Contains("Um campo necessário 'Categoria' estava vazio. Por favor, verifique novamente suas entradas."));

            ProjetosDBSteps.DeletarCategoria(nomeCategoria);
        }

        [Test]
        public void AdicionarCategoriaEEditarCategoriaSemPreencherCampo()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();

            ProjetosDBSteps.DeletarCategoria(nomeCategoria);

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarAdicionarEEditarCategoria();

            Assert.That(gerenciarProjetosPage.RetornaMensagemErroAoNaoPreencherCampo().Contains("Um campo necessário 'Categoria' estava vazio. Por favor, verifique novamente suas entradas."));

            ProjetosDBSteps.DeletarCategoria(nomeCategoria);
        }

        [Test]
        public void ApagarCategoriaVinculadaATarefa()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();
            tarefaFlows = new TarefaFlows();

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
            ProjetosDBSteps.DeletarCategoria(nomeCategoria);
            projetoFlows.CriarNovoProjeto(nomeProjeto);
            projetoFlows.CriarCategoria(nomeCategoria);
            tarefaFlows.CriarNovaTarefa(nomeProjeto, nomeCategoria);

            
            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarApagarCategoria(nomeCategoria);

            Assert.That(gerenciarProjetosPage.RetornaMensagemErroAoNaoPreencherCampo().Contains($"Categoria \"{nomeCategoria}\" não pode ser deletada, pois está associada com outro ou mais problemas."));

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
            ProjetosDBSteps.DeletarCategoria(nomeCategoria);
        }

        [Test]
        public void AlterarCategoria()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();
            tarefaFlows = new TarefaFlows();

            #region Parameters
            string nomeTarefa = "Tarefa de Teste Mantis2";
            string nomeCategoriaAposEditar = "Categoria Teste Automação Edição";
            #endregion

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
            ProjetosDBSteps.DeletarCategoria(nomeCategoria);
            TarefasDBSteps.DeletarTarefa(nomeTarefa);
            projetoFlows.CriarNovoProjeto(nomeProjeto);
            projetoFlows.CriarCategoria(nomeCategoria);
            tarefaFlows.CriarNovaTarefa(nomeProjeto, nomeCategoria);

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarEditarCategoria(nomeCategoria);
            gerenciarProjetosPage.ApagarNomeCategoriaEditar();
            gerenciarProjetosPage.PreencherNomeCategoriaEditar(nomeCategoriaAposEditar);
            gerenciarProjetosPage.ClicarAtualizarCategoria();

            Assert.AreEqual(mensagemSucesso, gerenciarProjetosPage.RetornaMensagemSucesso());

            ProjetosDBSteps.DeletarProjeto(nomeProjeto);
            ProjetosDBSteps.DeletarCategoria(nomeCategoriaAposEditar);
            TarefasDBSteps.DeletarTarefa(nomeTarefa);
        }
    }
}
