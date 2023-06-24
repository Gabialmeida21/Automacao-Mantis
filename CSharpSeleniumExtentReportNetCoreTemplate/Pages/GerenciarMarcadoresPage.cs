using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class GerenciarMarcadoresPage : PageBase
    {
        #region Mapping
        
        By abaGerenciarMarcadorButton = By.XPath("//a[@href='/manage_tags_page.php']");
        By criarMarcadorButton = By.XPath("//a[@href='#tagcreate']");
        By nomeMarcadorText = By.Id("tag-name");
        By descricaoMarcadorText = By.Id("tag-description");
        By criarMarcadorButton2 = By.XPath("//input[@value='Criar Marcador']");
        By validarMarcadorCriado = By.XPath("//a[text()='Teste Gabriela2']");
        By apagarMarcadorButton = By.XPath("//input[@value='Apagar Marcador']");
        #endregion
                        

        public void ClicarAbaMarcador()
        {
            Click(abaGerenciarMarcadorButton);
        }

        public void clicarCriarMarcador()
        {
            Click(criarMarcadorButton);
        }

        public void PreencherNomeMarcador(string nomeMarcador)
        {
            SendKeys(nomeMarcadorText, nomeMarcador);
        }

        public void PreencherDescricao(string descricaoMarcador)
        {
            SendKeys(descricaoMarcadorText, descricaoMarcador);
        }

        public void ClicarMenuMarcador2()
        {
            Click(criarMarcadorButton2);
        }

        public string ValidarMarcador()
        {
            return GetText(validarMarcadorCriado);
        }

        public void ClicarMarcador()
        {
            Click(validarMarcadorCriado);
        }

        public void ApagarMarcador()
        {
            Click(apagarMarcadorButton);
        }
    }
}
