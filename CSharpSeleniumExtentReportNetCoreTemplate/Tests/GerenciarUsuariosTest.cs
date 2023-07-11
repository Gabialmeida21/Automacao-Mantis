using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.DataBaseSteps;
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

        #region Parameters
        string nomeUsuario = "Gabriela";
        string nomeVerdadeiro = "Gabriela Almeida";
        string email = "gabrielaalmeida@teste.com";
        string nivelAcesso = "desenvolvedor";
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
            string nomeVerdadeiro = "Gabriela Almeida";
            string nivelAcesso = "desenvolvedor";
            #endregion

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.ClicarCriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuariosPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuariosPage.PreencherEmail(email);
            gerenciarUsuariosPage.SelecionarNivelAcesso(nivelAcesso);
            gerenciarUsuariosPage.ClicarCriarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemSucesso().Contains("criado com um nível de acesso de desenvolvedor"));

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
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
            usuarioFlows = new UsuarioFlows();

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            usuarioFlows.CriarNovoUsuario(nomeUsuario, email);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.ClicarCriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuariosPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuariosPage.PreencherEmail(email);
            gerenciarUsuariosPage.SelecionarNivelAcesso(nivelAcesso);
            gerenciarUsuariosPage.ClicarCriarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemErroUsuarioExistente().Contains("Este nome de usuário já está sendo usado. Por favor, volte e selecione um outro."));

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }

        [Test]
        public void CriarUsuarioSemPreencherNomeVerdadeiro()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.ClicarCriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuariosPage.PreencherEmail(email);
            gerenciarUsuariosPage.SelecionarNivelAcesso(nivelAcesso);
            gerenciarUsuariosPage.ClicarCriarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemSucesso().Contains("criado com um nível de acesso de desenvolvedor"));

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }

        [Test]
        public void CriarUsuarioSemPreencherEmail()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.ClicarCriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuariosPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuariosPage.SelecionarNivelAcesso(nivelAcesso);
            gerenciarUsuariosPage.ClicarCriarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemSucesso().Contains("criado com um nível de acesso de desenvolvedor"));

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }

        [Test]
        public void CriarUsuarioComEmailJaExistente()
        {
            
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string nomeUsuarioNovo = "Gabriela Teste Email Ja Utilizado";
            #endregion

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            usuarioFlows.CriarNovoUsuario(nomeUsuario, email);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.ClicarCriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuarioNovo);
            gerenciarUsuariosPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuariosPage.PreencherEmail(email);
            gerenciarUsuariosPage.SelecionarNivelAcesso(nivelAcesso);
            gerenciarUsuariosPage.ClicarCriarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemErro().Contains("Este e-mail já está sendo usado. Por favor, volte e selecione outro."));

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }

        [Test]
        public void CriarUsuarioComEmailInvalido()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();

            #region Parameters
            string emailInvalido = "email";
            #endregion

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.ClicarCriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuariosPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuariosPage.PreencherEmail(emailInvalido);
            gerenciarUsuariosPage.SelecionarNivelAcesso(nivelAcesso);
            gerenciarUsuariosPage.ClicarCriarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemErro().Contains("E-mail inválido."));

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }

        [Test]
        public void EditarNivelAcessoUsuarioComSucesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string nivelAcessoEdicao = "gerente";
            string mensagemSucessoEditarUsuario = "Operação realizada com sucesso.";
            #endregion

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            usuarioFlows.CriarNovoUsuario(nomeUsuario, email);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar(nomeUsuario);
            gerenciarUsuariosPage.SelecionarNivelAcessoAoEditar(nivelAcessoEdicao);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();

            Assert.AreEqual(mensagemSucessoEditarUsuario, gerenciarUsuariosPage.RetornaMensagemSucessoOperacaoRealizada());

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }

        [Test]
        public void EditarNomeUsuarioComSucesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string mensagemSucessoEditarUsuario = "Operação realizada com sucesso.";
            string editarNomeUsuario = "Gabriela editado";
            #endregion

            UsuariosDBSteps.DeletarUsuarioCriado(editarNomeUsuario);
            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            usuarioFlows.CriarNovoUsuario(nomeUsuario, email);
            
            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar(nomeUsuario);
            gerenciarUsuariosPage.ApagarNomeUsuarioAoEditar();
            gerenciarUsuariosPage.EditarNomeUsuario(editarNomeUsuario);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();

            Assert.AreEqual(mensagemSucessoEditarUsuario, gerenciarUsuariosPage.RetornaMensagemSucessoOperacaoRealizada());
           
            UsuariosDBSteps.DeletarUsuarioCriado(editarNomeUsuario);
            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }

        [Test]
        public void EditarNomeUsuarioExistente()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string nomeUsuarioExistente = "Gabriela editado nome existente";
            string emailUsuarioExistente = "gabrielaalmeida2@teste.com";
            #endregion

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuarioExistente);
            usuarioFlows.CriarNovoUsuario(nomeUsuario, email);
            usuarioFlows.CriarNovoUsuario(nomeUsuarioExistente, emailUsuarioExistente);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar(nomeUsuario);
            gerenciarUsuariosPage.ApagarNomeUsuarioAoEditar();
            gerenciarUsuariosPage.EditarNomeUsuario(nomeUsuarioExistente);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemErroUsuarioExistente().Contains("Este nome de usuário já está sendo usado. Por favor, volte e selecione um outro."));

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuarioExistente);
        }

        [Test]
        public void EditarEmailComSucesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string mensagemSucessoEditarUsuario = "Operação realizada com sucesso.";
            string editarEmailUsuario = "gabrielaeditado@gmail.com";
            #endregion

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            usuarioFlows.CriarNovoUsuario(nomeUsuario, email);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar(nomeUsuario);
            gerenciarUsuariosPage.ApagarEmailAoEditar();
            gerenciarUsuariosPage.EditarEmail(editarEmailUsuario);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();

            Assert.AreEqual(mensagemSucessoEditarUsuario, gerenciarUsuariosPage.RetornaMensagemSucessoOperacaoRealizada());

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }

        [Test]
        public void EditarComEmailJaExistente()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string nomeUsuario2 = "Gabriela Com email existente";
            string emailUsuario2 = "gabriela@teste.com";
            string emailExistente = "gabriela@teste.com";
            #endregion

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario2);
            usuarioFlows.CriarNovoUsuario(nomeUsuario, email);
            usuarioFlows.CriarNovoUsuario(nomeUsuario2, emailUsuario2);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar(nomeUsuario);
            gerenciarUsuariosPage.ApagarEmailAoEditar();
            gerenciarUsuariosPage.EditarEmail(emailExistente);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemErro().Contains("Este e-mail já está sendo usado. Por favor, volte e selecione outro."));

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario2);
        }

        [Test]
        public void EditarComEmailInvalido()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string emailInvalido = "email";
            #endregion

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            usuarioFlows.CriarNovoUsuario(nomeUsuario, email);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar(nomeUsuario);
            gerenciarUsuariosPage.ApagarEmailAoEditar();
            gerenciarUsuariosPage.EditarEmail(emailInvalido);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemErro().Contains("E-mail inválido."));

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }

        [Test]
        public void EditarNomeVerdadeiroComSucesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string mensagemSucessoEditarUsuario = "Operação realizada com sucesso.";
            string editarNomeVerdadeiro = "Gabriela Nome Verdadeiro";
            #endregion

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            usuarioFlows.CriarNovoUsuario(nomeUsuario, email);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar(nomeUsuario);
            gerenciarUsuariosPage.ApagarNomeVerdadeiro();
            gerenciarUsuariosPage.EditarNomeVerdadeiro(editarNomeVerdadeiro);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();

            Assert.AreEqual(mensagemSucessoEditarUsuario, gerenciarUsuariosPage.RetornaMensagemSucessoOperacaoRealizada());

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }

        [Test]
        public void EditarNivelAcesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string mensagemSucessoEditarUsuario = "Operação realizada com sucesso.";
            string editarNivelAcesso = "gerente";
            #endregion

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            usuarioFlows.CriarNovoUsuario(nomeUsuario, email);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar(nomeUsuario);
            gerenciarUsuariosPage.EditarSelecionarNivelAcesso(editarNivelAcesso);
            gerenciarUsuariosPage.ClicarBotaoAtualizarUsuario();
                       
            Assert.AreEqual(mensagemSucessoEditarUsuario, gerenciarUsuariosPage.RetornaMensagemSucessoOperacaoRealizada());

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }

        [Test]
        public void ValidarRedefinirSenha()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            usuarioFlows.CriarNovoUsuario(nomeUsuario, email);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar(nomeUsuario);
            gerenciarUsuariosPage.ClicarRedefinirSenha();

            Assert.That(gerenciarUsuariosPage.RetornaMensagemSolicitacaoRedefinirSenha().Contains("Uma solicitação de confirmação foi enviada ao endereço de e-mail do usuário selecionado. Através deste, o usuário será capaz de alterar sua senha."));

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }


        [Test]
        public void ApagarUsuarioComSucesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            #region Parameters
            string mensagemSucesso = "Operação realizada com sucesso.";
            #endregion

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            usuarioFlows.CriarNovoUsuario(nomeUsuario, email);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar(nomeUsuario);
            gerenciarUsuariosPage.ClicarApagarUsuario();
            gerenciarUsuariosPage.ClicarApagarConta();

            Assert.AreEqual(mensagemSucesso, gerenciarUsuariosPage.RetornaMensagemSucessoOperacaoRealizada());

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }

        [Test]
        public void RepresentarUsuarioComSucesso()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
            usuarioFlows = new UsuarioFlows();

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
            usuarioFlows.CriarNovoUsuario(nomeUsuario, email);

            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.PreencherFiltroPesquisarUsuario(nomeUsuario);
            gerenciarUsuariosPage.ClicarAplicarFiltro();
            gerenciarUsuariosPage.ClicarUsuarioParaAlterar(nomeUsuario);
            gerenciarUsuariosPage.ClicarRepresentarUsuario();
            gerenciarUsuariosPage.ClicarParaProsseguir();

            Assert.AreEqual(nomeUsuario, mainPage.RetornaUsernameDasInformacoesDeLogin());

            UsuariosDBSteps.DeletarUsuarioCriado(nomeUsuario);
        }
    }
}
