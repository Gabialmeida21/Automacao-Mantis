using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class CriarTarefaPage : PageBase
    {
        #region Mapping
        By menuCriarTarefaButton = By.XPath("//a[@href='/bug_report_page.php']");
        By selecionarProjetoComboBox = By.Id("select-project-id");
        By selecionarProjetoButton = By.XPath("//input[@value='Selecionar Projeto']");
        By categoriaComboBox = By.Id("category_id");
        By atribuirAComboBox = By.Id("handler_id");
        By resumoText = By.Id("summary");
        By descricaoText = By.Id("description");
        By passosParaReproduzirText = By.Id("steps_to_reproduce");
        By criarTarefaButton = By.XPath("//input[@value='Criar Nova Tarefa']");
        By selecionarProjetoGeral = By.Id("dropdown_projects_menu");
        By selecionarTodosOsProjetosButton = By.XPath("//a[@href='/set_project.php?project_id=0']");


        #endregion

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

        public void SelecionarProjeto(String text)

        {
            ComboBoxSelectByVisibleText(selecionarProjetoComboBox, text);
        }

        /*public void SelecionarProjetoComboBox(string text)
        {
            ComboBoxSelectByVisibleText(selecionarProjetoComboBox, text);
        }*/             
                

        public void ClicarBotaoSelecionarProjeto()
        {
            Click(selecionarProjetoButton);
        }


        public void SelecionarCategoria(string text)
        {
            ComboBoxSelectByVisibleText(categoriaComboBox, text);
        }

        public void SelecionarAtribuicao(String text)
        {
            ComboBoxSelectByVisibleText(atribuirAComboBox, text);
        }

        public void PreencherResumo(string text)
        {
            SendKeys(resumoText, text);
        }

        public void PreencherDescricao(String text)
        {
            SendKeys(descricaoText, text);
        }

        public void PreencherPassosParaReproduzir(string text)
        {
            SendKeys(passosParaReproduzirText, text);
        }

        public void ClicarBotaoCriarNovaTarefa()
        {
            Click(criarTarefaButton);
        }

    }
}
