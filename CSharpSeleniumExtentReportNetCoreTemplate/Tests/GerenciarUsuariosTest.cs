using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.Flows;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
{
    [TestFixture]
    public class GerenciarUsuariosTest : TestBase
    {
        #region Pages and Flows Objects
        MainPage mainPage;
        GerenciarUsuariosPage gerenciarUsuariosPage;
        UsuarioFlows usuarioFlows;
        #endregion

        [SetUp]
        public void RealizarLogin()
        {
            LoginFlows loginFlows = new LoginFlows();
            loginFlows.EfetuarLogin("administrator", "administrator");
        }

        [Test]
        public void CriarUsuarioComSucesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();

            #region Parameters
            string nomeUsuario = "Gabi";
            string nomeVerdadeiro = "Gabriela Almeida";
            string email = "gabriela@teste.com";
            string nivelAcesso = "desenvolvedor";

            #endregion

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.ClicarCriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuariosPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuariosPage.PreencherEmail(email);
            gerenciarUsuariosPage.SelecionarNivelAcesso(nivelAcesso);
            gerenciarUsuariosPage.ClicarCriarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemSucesso().Contains("criado com um nível de acesso de desenvolvedor"));

        }

        [Test]
        public void ClicarCriarUsuarioSemPreencherCampos()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();



            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.ClicarCriarNovaConta();
            gerenciarUsuariosPage.ClicarCriarUsuario();
            gerenciarUsuariosPage.RetornaMensagemErro();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemErro().Contains("O nome de usuário não é inválido. Nomes de usuário podem conter apenas letras, números, espaços, hífens, pontos, sinais de mais e sublinhados."));

        }

        [Test]
        public void CriarUsuarioComUsuarioJaExistente()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();

            #region Parameters
            string nomeUsuario = "Gabi";
            string nomeVerdadeiro = "Gabriela Almeida";
            string email = "gabriela@teste.com";
            string nivelAcesso = "desenvolvedor";

            #endregion

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.ClicarCriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuariosPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuariosPage.PreencherEmail(email);
            gerenciarUsuariosPage.SelecionarNivelAcesso(nivelAcesso);
            gerenciarUsuariosPage.ClicarCriarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemErroUsuarioExistente().Contains("Este nome de usuário já está sendo usado. Por favor, volte e selecione um outro."));
        }

        [Test]
        public void CriarUsuarioSemPreencherNome()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string nomeUsuario = "Gabriela";
            string email = "gabriela2@teste.com";
            string nivelAcesso = "desenvolvedor";

            #endregion

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.ClicarCriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuariosPage.PreencherEmail(email);
            gerenciarUsuariosPage.SelecionarNivelAcesso(nivelAcesso);
            gerenciarUsuariosPage.ClicarCriarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemSucesso().Contains("criado com um nível de acesso de desenvolvedor"));

        }

        [Test]
        public void CriarUsuarioSemPreencherEmail()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();

            #region Parameters
            string nomeUsuario = "Gabriela";
            string nomeVerdadeiro = "Gabriela Almeida";
            string nivelAcesso = "desenvolvedor";

            #endregion

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.ClicarCriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuariosPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuariosPage.SelecionarNivelAcesso(nivelAcesso);
            gerenciarUsuariosPage.ClicarCriarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemSucesso().Contains("criado com um nível de acesso de desenvolvedor"));

        }

        [Test]
        public void CriarUsuarioComEmailJaExistente()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();

            #region Parameters
            string nomeUsuario = "Gabriela Teste";
            string nomeVerdadeiro = "Gabriela Almeida Teste";
            string email = "gabriela@teste.com";
            string nivelAcesso = "desenvolvedor";

            #endregion

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.ClicarCriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuariosPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuariosPage.PreencherEmail(email);
            gerenciarUsuariosPage.SelecionarNivelAcesso(nivelAcesso);
            gerenciarUsuariosPage.ClicarCriarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemErro().Contains("Este e-mail já está sendo usado. Por favor, volte e selecione outro."));
        }

        [Test]
        public void EditarUsuarioComSucesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();


            #region Parameters
            string nomeUsuario = "Gabriela Teste10";
            string nivelAcesso = "gerente";
            string mensagemSucessoEditarUsuario = "Operação realizada com sucesso.";
            #endregion

            usuarioFlows.CriarNovoUsuario(nomeUsuario);
            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar();
            gerenciarUsuariosPage.SelecionarNivelAcessoAoEditar(nivelAcesso);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();


            Assert.AreEqual(mensagemSucessoEditarUsuario, gerenciarUsuariosPage.RetornaMensagemSucessoOperacaoRealizada());


        }
    }
}
