using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Flows
{
    public class UsuarioFlows
    {
        #region Page Object and Constructor
        GerenciarUsuariosPage gerenciarUsuariosPage;
        MainPage mainPage;

        public UsuarioFlows()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
            mainPage = new MainPage();
        }
        #endregion

        string nomeVerdadeiro = "Gabriela Almeida";
        string nivelAcesso = "desenvolvedor";

        public void CriarNovoUsuario(string nomeUsuario, string email)
        {
            mainPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.AbaGerenciarUsuario();
            gerenciarUsuariosPage.ClicarCriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuario(nomeUsuario);
            gerenciarUsuariosPage.PreencherNomeVerdadeiro(nomeVerdadeiro);
            gerenciarUsuariosPage.PreencherEmail(email);
            gerenciarUsuariosPage.SelecionarNivelAcesso(nivelAcesso);
            gerenciarUsuariosPage.ClicarCriarUsuario();
        }
    }
}
