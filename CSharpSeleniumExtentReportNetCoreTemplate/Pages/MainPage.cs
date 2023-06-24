using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class MainPage : PageBase
    {
        #region Mapping
        By usernameLoginInfoTextArea = By.XPath("//span[@class='user-info']");
        By reportIssueLink = By.XPath("//a[@href='/bug_report_page.php']");
        By menuGerenciarLink = By.XPath("//a[@href='/manage_overview_page.php']");
        By selecionarProjetoGeral = By.Id("dropdown_projects_menu");
        By selecionarTodosOsProjetosButton = By.XPath("//a[@href='/set_project.php?project_id=0']");
        By menuCriarTarefaButton = By.XPath("//a[@href='/bug_report_page.php']");
        By menuVerTarefaButton = By.XPath("//a[@href='/view_all_bug_page.php']");
        #endregion

        #region Actions
        public string RetornaUsernameDasInformacoesDeLogin()
        {
            return GetText(usernameLoginInfoTextArea);
        }

        public void ClicarEmReportIssue()
        {
            Click(reportIssueLink);
        }

        public void ClicarMenuGerenciar()
        {
            Click(menuGerenciarLink);
        }

        public void ClicarSelecionarProjetoGeral()
        {
            Click(selecionarProjetoGeral);
        }

        public void SelecionarTodosOsProjetos()
        {
            Click(selecionarTodosOsProjetosButton);
        }

        public void ClicarMenuCriarTarefa()
        {
            Click(menuCriarTarefaButton);
        }
        public void ClicarMenuVerTarefa()
        {
            Click(menuVerTarefaButton);
        }
        #endregion


    }
}
