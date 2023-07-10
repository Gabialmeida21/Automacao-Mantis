using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Flows
{
    public class PerfilGlobaisFlows
    {
        #region Page Object and Constructor
        GerenciarPerfisGlobaisPage gerenciarPerfisGlobaisPage;
        MainPage mainPage;

        public PerfilGlobaisFlows()
        {
            gerenciarPerfisGlobaisPage = new GerenciarPerfisGlobaisPage();
            mainPage = new MainPage();
        }
        #endregion

        #region Parameters
        string nomeSO = "Windows";
        string versaoSO = "Versão 11";
        string descricao = "Descricao Adicional sobre o SO";
        #endregion

        public void CriarNovoPerfil(string nomePlataforma)
        {
            mainPage.ClicarMenuGerenciar();
            gerenciarPerfisGlobaisPage.AbaGerenciarPerfisGlobais();
            gerenciarPerfisGlobaisPage.PreencherNomePlataforma(nomePlataforma);
            gerenciarPerfisGlobaisPage.PreencherNomeSO(nomeSO);
            gerenciarPerfisGlobaisPage.PreencherVersaoSO(versaoSO);
            gerenciarPerfisGlobaisPage.PreencherDescricao(descricao);
            gerenciarPerfisGlobaisPage.ClicarAdcionarPerfil();
        }
    }
}
