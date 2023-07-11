using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.DataBaseSteps;
using CSharpSeleniumExtentReportNetCoreTemplate.Helpers;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {

        #region Pages and Flows Objects
        LoginPage loginPage;
        MainPage mainPage;
        #endregion

        #region Data Driven Providers
        public static IEnumerable Login()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.GetProjectPath() + "DataDriven\\Login.csv");
        }
        #endregion

        [Test]
        public void RealizarLoginComSucesso()
        {
            loginPage = new LoginPage();
            mainPage = new MainPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "administrator";
            #endregion

            loginPage.PreencherUsuarioJS(usuario);
            loginPage.ClicarEmLoginJS();
            loginPage.PreencherSenhaJS(senha);
            loginPage.ClicarEmLoginJS();

            Assert.AreEqual(usuario, mainPage.RetornaUsernameDasInformacoesDeLogin());
        }

        [Test, TestCaseSource("Login")]
        public void RealizarLoginComSucessoUsandoDataDriven(ArrayList testData)
        {
            loginPage = new LoginPage();
            mainPage = new MainPage();

            #region Parameters
            string usuario = testData[0].ToString();
            string senha = "administrator";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarEmLogin();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();

            Assert.AreEqual(usuario, mainPage.RetornaUsernameDasInformacoesDeLogin());
        }

        [Test]
        public void RealizarLoginComSenhaIncorreta()
        {
            loginPage = new LoginPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "1234";
            string mensagemErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarEmLogin();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();
            loginPage.RetornaMensagemDeErro();

            Assert.AreEqual(mensagemErro, loginPage.RetornaMensagemDeErro());
        }

        [Test]
        public void RealizarLoginComUsuarioIncorreto()
        {
            loginPage = new LoginPage();

            #region Parameters
            string usuario = "teste";
            string senha = "administrator";
            string mensagemErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarEmLogin();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();
            loginPage.RetornaMensagemDeErro();

            Assert.AreEqual(mensagemErro, loginPage.RetornaMensagemDeErro());
        }

        [Test]
        public void ClicarNoBotaoEntrarSemPreencherUsuario()
        {
            loginPage = new LoginPage();

            #region Parameters
      
            string mensagemErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion
            
            loginPage.ClicarEmLogin();

            Assert.AreEqual(mensagemErro, loginPage.RetornaMensagemDeErro());
        }

        [Test]
        public void ClicarNoBotaoEntrarSemPreencherSenha()
        {
            loginPage = new LoginPage();

            #region Parameters
            string usuario = "teste";
            string mensagemErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarEmLogin();
            loginPage.ClicarEmLogin();

            Assert.AreEqual(mensagemErro, loginPage.RetornaMensagemDeErro());
        }
    }
}
