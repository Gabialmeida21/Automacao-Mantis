using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class LoginPage : PageBase
    {
        #region Mapping
        By usernameField = By.Name("username");
        By passwordField = By.Name("password");
        By loginButton = By.XPath("//input[@type='submit']");
        By mensagemErroTextArea = By.XPath("//div[@class='alert alert-danger']/p"); //exemplo de mapping incorreto
        #endregion

        #region Actions
        public void PreencherUsuario(string usuario)
        {
            SendKeys(usernameField, usuario);
        }

        public void PreencherSenha(string senha)
        {
            SendKeys(passwordField, senha);
        }

        public void ClicarEmLogin()
        {
            Click(loginButton);
        }

        public string RetornaMensagemDeErro()
        {
            return GetText(mensagemErroTextArea);
        }

        public void PreencherUsuarioJS(string usuario)
        {
            SendKeysJavaScript(usernameField, usuario);
        }

        public void PreencherSenhaJS(string senha)
        {
            SendKeysJavaScript(passwordField, senha);
        }

        public void ClicarEmLoginJS()
        {
            ClickJavaScript(loginButton);
        }
        #endregion
    }
}
