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
        By usuarioLink = By.XPath("//a[text()='Gabriela Teste10']");
        By atualizarUsuarioButton = By.XPath("//input[@value='Atualizar Usuário']");
        By mensagemConfirmarEditarUsuario = By.XPath("//div[@class='alert alert-success center']/p");
        By nivelAcessoEditarDropDown = By.Id("edit-access-level");


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

        public void ClicarUsuarioParaAlterar()
        {
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




    }




    
}
