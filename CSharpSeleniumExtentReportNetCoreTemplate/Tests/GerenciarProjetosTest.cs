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
    public class GerenciarProjetosTest : TestBase
    {

        #region Pages and Flows Objects
        LoginPage loginPage;
        MainPage mainPage;
        GerenciarProjetosPage gerenciarProjetosPage;
        ProjetoFlows projetoFlows;
        #endregion

        [SetUp]
        public void RealizarLogin()
        {
            LoginFlows loginFlows = new LoginFlows();
            loginFlows.EfetuarLogin("administrator", "administrator");
        }

        [Test]
        public void CriarProjetoComSucesso()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();

            #region Parameters
            string nomeProjeto = "Gabriela Teste Automação2";
            string descricaoProjeto = "Teste de automação Web";
            string mensagemSucesso = "Operação realizada com sucesso.";
            #endregion

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.CriarNovoProjeto();
            gerenciarProjetosPage.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.PreencherDescricaoProjeto(descricaoProjeto);
            gerenciarProjetosPage.ClicarAdicionarProjeto();

            Assert.AreEqual(mensagemSucesso, gerenciarProjetosPage.RetornaMensagemSucesso());
        }

        [Test]
        public void CriarProjetoJaExistente()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.CriarNovoProjeto();
            gerenciarProjetosPage.PreencherNomeProjeto("Gabriela Teste Automação");
            gerenciarProjetosPage.PreencherDescricaoProjeto("Teste de automação Web");
            gerenciarProjetosPage.ClicarAdicionarProjeto();

            Assert.That(gerenciarProjetosPage.RetornaMensagemErro().Contains("Um projeto com este nome já existe. Por favor, volte e entre um nome diferente."));
        }

        [Test]
        public void EditarProjetoComSucesso()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();

            string nomeProjetoAposAlterar = "46 teste";

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarNomeProjeto();
            gerenciarProjetosPage.AlterarNomeProjeto(" teste");
            gerenciarProjetosPage.ClicarAtualizarProjeto();

            Assert.AreEqual(nomeProjetoAposAlterar, gerenciarProjetosPage.RetornaNomeProjetoAposAlteracao());
        }

        [Test]
        public void RemoverProjetoComSucesso()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarNomeProjetoParaApagar();
            gerenciarProjetosPage.ApagarProjeto();
            gerenciarProjetosPage.ApagarProjeto();

            //fazer validação no banco de dados
        }

        /*[Test]
        public void AdicionarSubProjeto()
        {

            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
            projetoFlows = new ProjetoFlows();

            #region Parameters
            string nomeProjeto = "Adicionar Sub Projeto Automação";
            string descricaoProjeto = "Teste de automação Web";

            string mensagemSucesso = "Operação realizada com sucesso.";
            #endregion

            projetoFlows.CriarNovoProjeto();
            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.CriarNovoProjeto();
            gerenciarProjetosPage.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.PreencherDescricaoProjeto(descricaoProjeto);
            gerenciarProjetosPage.ClicarAdicionarProjeto();

            Assert.AreEqual(mensagemSucesso, gerenciarProjetosPage.RetornaMensagemSucesso());
        }*/

        [Test]
        public void AdicionarCategoria()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();

            string nomeAposAdicionarCategoria = "Categoria Teste Automação";

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.PreencherNomeCategoria("Categoria Teste Automação");
            gerenciarProjetosPage.ClicarAdicionarCategoria();

            Assert.AreEqual(nomeAposAdicionarCategoria, gerenciarProjetosPage.RetornaNomeCategoria());
                                    
        }

        [Test]
        public void AdicionarCategoriaJaExistente()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();

            
            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.PreencherNomeCategoria("Categoria Teste Automação");
            gerenciarProjetosPage.ClicarAdicionarCategoria();

            Assert.That(gerenciarProjetosPage.RetornaMensagemErroAoNaoPreencherCampo().Contains("Uma categoria com este nome já existe."));

        }

        [Test]
        public void AdicionarCategoriaSemPreencherCampo()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();

            
            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarAdicionarCategoria();

            Assert.That(gerenciarProjetosPage.RetornaMensagemErroAoNaoPreencherCampo().Contains("Um campo necessário 'Categoria' estava vazio. Por favor, verifique novamente suas entradas."));

        }

        [Test]
        public void AdicionarCategoriaEEditarCategoriaSemPreencherCampo()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();


            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.ClicarAdicionarEEditarCategoria();

            Assert.That(gerenciarProjetosPage.RetornaMensagemErroAoNaoPreencherCampo().Contains("Um campo necessário 'Categoria' estava vazio. Por favor, verifique novamente suas entradas."));

        }

        /*public void AlterarCategoria()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();

            string mensagemSucessoAlterarCategoria = "";

            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.PreencherNomeCategoria("Categoria Teste Automação");
            gerenciarProjetosPage.ClicarAdicionarCategoria();

            Assert.AreEqual(nomeAposAdicionarCategoria, gerenciarProjetosPage.RetornaNomeCategoria());

        }*/






    }
}
