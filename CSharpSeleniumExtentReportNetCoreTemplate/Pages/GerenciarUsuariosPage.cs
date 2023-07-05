using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class GerenciarUsuariosPage : PageBase
    {
        #region Mapping
        By abaGerenciarUsuarios = By.XPath("//a[@href='/manage_user_page.php']");
        By criarNovaContaButton = By.XPath("//a[@class='btn btn-primary btn-white btn-round btn-sm']");
        By nomeUsuarioText = By.Id("user-username");
        By nomeVerdadeiroText = By.Id("user-realname");
        By emailText = By.Id("email-field");
        By nivelAcessoDropDown = By.Id("user-access-level");
        By habilitadoCheckBox = By.Id("user-enabled");
        By ProtegidoCheckBox = By.Id("user-protected");
        By criarUsuarioButton = By.XPath("//input[@value='Criar Usuário']");
        By mensagemSucesso = By.XPath("//div[@class='alert alert-success center']");
        By mensagemErro = By.XPath("//div[@class='alert alert-danger']/p[2]");
        By mensagemErroUsuarioExistente = By.XPath("//div[@class='alert alert-danger']/p[2]");
        By filtroUsuarioText = By.XPath("//input[@class='input-sm']");
        By aplicarFiltroButton = By.XPath("//input[@value='Aplicar Filtro']");
        By atualizarUsuarioButton = By.XPath("//input[@value='Atualizar Usuário']");
        By mensagemConfirmarEditarUsuario = By.XPath("//div[@class='alert alert-success center']/p");
        By nivelAcessoEditarDropDown = By.Id("edit-access-level");
        By editarNomeUsuarioText = By.Id("edit-username");
        By editarNomeVerdadeiroText = By.Id("edit-realname");
        By editarNivelAcessoDropDown = By.Id("edit-access-level");
        By redefinirSenhaButton = By.XPath("//input[@value='Redefinir Senha']");
        By mensagemRedefinirSenha = By.XPath("//div[@class='alert alert-success center']/p");
        By apagarUsuarioButton = By.XPath("//input[@value='Apagar Usuário']");
        By apagarContaButton = By.XPath("//input[@value='Apagar Conta']");
        By representarUsuarioButton = By.XPath("//input[@value='Representar Usuário']");
        By cliqueAquiParaProsseguirButton = By.XPath("//a[@href='my_view_page.php']");
        

        #endregion

        public void AbaGerenciarUsuario()
        {
            Click(abaGerenciarUsuarios);
        }

        public void ClicarCriarNovaConta()
        {
            Click(criarNovaContaButton);
        }

        public void PreencherNomeUsuario(string text)
        {
            SendKeys(nomeUsuarioText, text);
        }

        public void PreencherNomeVerdadeiro(string text)
        {
            SendKeys(nomeVerdadeiroText, text);
        }

        public void PreencherEmail(string text)
        {
            SendKeys(emailText, text);
        }

        public void SelecionarNivelAcesso(string text)
        {
            ComboBoxSelectByVisibleText(nivelAcessoDropDown, text);
        }

        public void ClicarHabilitado()
        {
            Click(habilitadoCheckBox);
        }

        public void ClicarProtegido()
        {
            Click(ProtegidoCheckBox);
        }

        public void ClicarCriarUsuario()
        {
            Click(criarUsuarioButton);
        }

        public string RetornaMensagemSucesso()
        {
            return GetText(mensagemSucesso);
        }

        public string RetornaMensagemErro()
        {
            return GetText(mensagemErro);
        }

        public string RetornaMensagemErroUsuarioExistente()
        {
            return GetText(mensagemErroUsuarioExistente);
        }

        public void ClicarCampoPreencherFiltro()
        {
            Click(filtroUsuarioText);
        }
        public void PreencherFiltroPesquisarUsuario(string text)
        {
            SendKeys(filtroUsuarioText, text);
        }

        public void ClicarAplicarFiltro()
        {
            Click(aplicarFiltroButton);
        }
        //Interpolação de String
        public void ClicarUsuarioParaAlterar(string nomeUsuario)
        {
            By usuarioLink = By.XPath($"//a[text()='{nomeUsuario}']");
            Click(usuarioLink);
        }

        public void ClicarBotaoAtualizarUsuario()
        {
            Click(atualizarUsuarioButton);
        }

        public string RetornaMensagemSucessoOperacaoRealizada()
        {
            return GetText(mensagemConfirmarEditarUsuario);
        }

        public void SelecionarNivelAcessoAoEditar(string text)
        {
            ComboBoxSelectByVisibleText(nivelAcessoEditarDropDown, text);
        }

        public void ApagarNomeUsuarioAoEditar()
        {
            Clear(editarNomeUsuarioText);
        }

        public void EditarNomeUsuario(string text)
        {
            SendKeys(editarNomeUsuarioText, text);
        }

        public void ApagarEmailAoEditar()
        {
            Clear(emailText);
        }

        public void EditarEmail(string text)
        {
            SendKeys(emailText, text);
        }

        public void ApagarNomeVerdadeiro()
        {
            Clear(editarNomeVerdadeiroText);
        }

        public void EditarNomeVerdadeiro(string text)
        {
            SendKeys(editarNomeVerdadeiroText, text);
        }

        public void EditarSelecionarNivelAcesso(string text)
        {
            ComboBoxSelectByVisibleText(editarNivelAcessoDropDown, text);
        }

        public void ClicarRedefinirSenha()
        {
            Click(redefinirSenhaButton);
        }

        public string RetornaMensagemSolicitacaoRedefinirSenha()
        {
            return GetText(mensagemRedefinirSenha);
        }

        public void ClicarApagarUsuario()
        {
            Click(apagarUsuarioButton);
        }

        public void ClicarApagarConta()
        {
            Click(apagarContaButton);
        }

        public void ClicarRepresentarUsuario()
        {
            Click(representarUsuarioButton);
        }

        public void ClicarParaProsseguir()
        {
            Click(cliqueAquiParaProsseguirButton);
        }


    }




    
}
