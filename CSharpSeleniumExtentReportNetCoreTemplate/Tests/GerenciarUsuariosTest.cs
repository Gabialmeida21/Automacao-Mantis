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
        public void CriarUsuarioComEmailInvalido()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();

            #region Parameters
            string nomeUsuario = "Gabriela Teste";
            string nomeVerdadeiro = "Gabriela Almeida Teste";
            string email = "email";
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

            Assert.That(gerenciarUsuariosPage.RetornaMensagemErro().Contains("E-mail inválido."));
        }



        [Test]
        public void EditarNivelAcessoUsuarioComSucesso()
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

        [Test]
        public void EditarNomeUsuarioComSucesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();


            #region Parameters
            string nomeUsuario = "Gabriela Teste11";
            string mensagemSucessoEditarUsuario = "Operação realizada com sucesso.";
            string editarNomeUsuario = "Gabriela editado";
            #endregion

            usuarioFlows.CriarNovoUsuario(nomeUsuario);
            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar();
            gerenciarUsuariosPage.ApagarNomeUsuarioAoEditar();
            gerenciarUsuariosPage.EditarNomeUsuario(editarNomeUsuario);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();


            Assert.AreEqual(mensagemSucessoEditarUsuario, gerenciarUsuariosPage.RetornaMensagemSucessoOperacaoRealizada());

        }

        [Test]
        public void EditarNomeUsuarioExistente()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();


            #region Parameters
            string nomeUsuario = "Gabriela Teste11";
            string editarNomeUsuario = "Gabriela Teste9";
            #endregion

            usuarioFlows.CriarNovoUsuario(nomeUsuario);
            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar();
            gerenciarUsuariosPage.ApagarNomeUsuarioAoEditar();
            gerenciarUsuariosPage.EditarNomeUsuario(editarNomeUsuario);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();


            Assert.That(gerenciarUsuariosPage.RetornaMensagemErroUsuarioExistente().Contains("Este nome de usuário já está sendo usado. Por favor, volte e selecione um outro."));

        }

        [Test]
        public void EditarEmailComSucesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();


            #region Parameters
            string nomeUsuario = "Gabriela Teste11";
            string mensagemSucessoEditarUsuario = "Operação realizada com sucesso.";
            string editarEmailUsuario = "gabrielaeditado@gmail.com";
            #endregion

            usuarioFlows.CriarNovoUsuario(nomeUsuario);
            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar();
            gerenciarUsuariosPage.ApagarEmailAoEditar();
            gerenciarUsuariosPage.EditarEmail(editarEmailUsuario);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();


            Assert.AreEqual(mensagemSucessoEditarUsuario, gerenciarUsuariosPage.RetornaMensagemSucessoOperacaoRealizada());

        }

        [Test]
        public void EditarComEmailJaExistente()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();


            #region Parameters
            string nomeUsuario = "Gabriela Teste11";
            string editarEmailUsuarioJaExistente = "gabriela6@teste.com";
            #endregion

            usuarioFlows.CriarNovoUsuario(nomeUsuario);
            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar();
            gerenciarUsuariosPage.ApagarEmailAoEditar();
            gerenciarUsuariosPage.EditarEmail(editarEmailUsuarioJaExistente);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();


            Assert.That(gerenciarUsuariosPage.RetornaMensagemErro().Contains("Este e-mail já está sendo usado. Por favor, volte e selecione outro."));

        }

        [Test]
        public void EditarComEmailInvalido()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();


            #region Parameters
            string nomeUsuario = "Gabriela Teste11";
            string editarEmailInvalido = "email";
            #endregion

            usuarioFlows.CriarNovoUsuario(nomeUsuario);
            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar();
            gerenciarUsuariosPage.ApagarEmailAoEditar();
            gerenciarUsuariosPage.EditarEmail(editarEmailInvalido);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();


            Assert.That(gerenciarUsuariosPage.RetornaMensagemErro().Contains("E-mail inválido."));

        }

        [Test]
        public void EditarNomeVerdadeiroComSucesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();


            #region Parameters
            string nomeUsuario = "Gabriela Teste11";
            string mensagemSucessoEditarUsuario = "Operação realizada com sucesso.";
            string editarNomeVerdadeiro = "Gabriela Nome Verdadeiro";
            #endregion

            usuarioFlows.CriarNovoUsuario(nomeUsuario);
            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar();
            gerenciarUsuariosPage.ApagarNomeVerdadeiro();
            gerenciarUsuariosPage.EditarNomeVerdadeiro(editarNomeVerdadeiro);
            
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();


            Assert.AreEqual(mensagemSucessoEditarUsuario, gerenciarUsuariosPage.RetornaMensagemSucessoOperacaoRealizada());

        }

        [Test]
        public void EditarNivelAcesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();


            #region Parameters
            string nomeUsuario = "Gabriela Teste11";
            string mensagemSucessoEditarUsuario = "Operação realizada com sucesso.";
            string editarNivelAcesso = "gerente";
            #endregion

            usuarioFlows.CriarNovoUsuario(nomeUsuario);
            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar();
            gerenciarUsuariosPage.EditarSelecionarNivelAcesso(editarNivelAcesso);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();
                       
            Assert.AreEqual(mensagemSucessoEditarUsuario, gerenciarUsuariosPage.RetornaMensagemSucessoOperacaoRealizada());

        }

        [Test]
        public void ValidarRedefinirSenha()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string nomeUsuario = "Gabriela Teste11";
            
            
            #endregion

            usuarioFlows.CriarNovoUsuario(nomeUsuario);
            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar();
            gerenciarUsuariosPage.ClicarRedefinirSenha();



            Assert.That(gerenciarUsuariosPage.RetornaMensagemSolicitacaoRedefinirSenha().Contains("Uma solicitação de confirmação foi enviada ao endereço de e-mail do usuário selecionado. Através deste, o usuário será capaz de alterar sua senha."));

        }

        [Test]
        public void ApagarUsuarioComSucesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string nomeUsuario = "Gabriela Teste11";
            string mensagemSucesso = "Operação realizada com sucesso.";

            #endregion

            usuarioFlows.CriarNovoUsuario(nomeUsuario);
            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar();
            gerenciarUsuariosPage.ClicarApagarUsuario();
            gerenciarUsuariosPage.ClicarApagarConta();



            Assert.AreEqual(mensagemSucesso, gerenciarUsuariosPage.RetornaMensagemSucessoOperacaoRealizada());
        }

        [Test]
        public void RepresentarUsuarioComSucesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string nomeUsuario = "Gabriela Teste11";
            

            #endregion

            usuarioFlows.CriarNovoUsuario(nomeUsuario);
            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar();
            gerenciarUsuariosPage.ClicarRepresentarUsuario();
            gerenciarUsuariosPage.ClicarParaProsseguir();



            Assert.AreEqual(nomeUsuario, mainPage.RetornaUsernameDasInformacoesDeLogin());
        }
    }
}
