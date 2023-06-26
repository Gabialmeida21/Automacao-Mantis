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
        
        By selecionarProjetoComboBox = By.Id("select-project-id");
        By selecionarProjetoButton = By.XPath("//input[@value='Selecionar Projeto']");
        By categoriaComboBox = By.Id("category_id");
        By atribuirAComboBox = By.Id("handler_id");
        By resumoText = By.Id("summary");
        By descricaoText = By.Id("description");
        By passosParaReproduzirText = By.Id("steps_to_reproduce");
        By criarTarefaButton = By.XPath("//input[@value='Criar Nova Tarefa']");
        By mensagemSucessoTarefa = By.XPath("//div[@class='alert alert-success center']/p");

        #endregion

        public void SelecionarProjeto(String text)

        {
            ComboBoxSelectByVisibleText(selecionarProjetoComboBox, text);
        }
           
                

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

        public string RetornaMensagemSucesso()
        {
            return GetText(mensagemSucessoTarefa);
        }

    }
}
