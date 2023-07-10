using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class GerenciarPerfisGlobaisPage : PageBase
    {
        #region Mapping
        By abaGerenciarPerfisGlobais = By.XPath("//a[@href='/manage_prof_menu_page.php']");
        By nomePlataformaText = By.Id("platform");
        By nomeSOText = By.Id("os");
        By versaoSOText = By.Id("os-version");
        By descricaoAdicionalText = By.Id("description");
        By adicionarPerfilButton = By.XPath("//input[@value='Adicionar Perfil']");
        By editarPerfilRadio = By.XPath("//input[@id='action-edit']/following-sibling::span");
        By apagarPerfilRadio = By.XPath("//input[@id='action-delete']/following-sibling::span");
        By selecionarPerfilCombo = By.Id("select-profile");
        By enviarButton = By.XPath("//input[@value='Enviar']");
        By editarNomePlataformaText = By.Name("platform");
        By atualizarPerfilButton = By.XPath("//input[@value='Atualizar Perfil']");
        #endregion

        public void AbaGerenciarPerfisGlobais()
        {
            Click(abaGerenciarPerfisGlobais);
        }

        public void PreencherNomePlataforma(string nomePlataforma)
        {//input[@value='Atualizar Perfil']
            SendKeys(nomePlataformaText, nomePlataforma);
        }

        public void PreencherNomeSO(string nomeSO)
        {
            SendKeys(nomeSOText, nomeSO);
        }

        public void PreencherVersaoSO(string versaoSO)
        {
            SendKeys(versaoSOText, versaoSO);
        }

        public void PreencherDescricao(string descricao)
        {
            SendKeys(descricaoAdicionalText, descricao);
        }

        public void ClicarAdcionarPerfil()
        {
            Click(adicionarPerfilButton);
        }

        public void ClicarEditarPerfil()
        {
            Click(editarPerfilRadio);
        }

        public void ClicarApagarPerfil()
        {
            Click(apagarPerfilRadio);
        }

        public void SelecionarPerfil(string perfil)
        {
            ComboBoxSelectByVisibleText(selecionarPerfilCombo, perfil);
        }

        public void ClicarEnviar()
        {
            Click(enviarButton);
        }

        public void ApagarNomePlataforma()
        {
            Clear(editarNomePlataformaText);
        }

        public void EditarNomePlataforma(string nomePlataformaEditado)
        {
            SendKeys(editarNomePlataformaText, nomePlataformaEditado);
        }

        public void ClicarAtualizarPerfil()
        {
            Click(atualizarPerfilButton);
        }
    }
}
