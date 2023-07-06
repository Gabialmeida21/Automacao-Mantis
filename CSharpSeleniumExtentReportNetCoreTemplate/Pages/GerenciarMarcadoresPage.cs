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
        By apagarMarcadorButton = By.XPath("//input[@value='Apagar Marcador']");
        By atualizarMarcadorButton = By.XPath("//input[@value='Atualizar Marcador']");
        By mensagemErro = By.XPath("//div[@class='alert alert-danger']/p[2]");
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

        public string ValidarMarcador(string nomeMarcador)
        {
            By validarMarcadorCriado = By.XPath($"//a[text()='{nomeMarcador}']");
            return GetText(validarMarcadorCriado);
        }

        public void ClicarMarcador(string nomeMarcador)
        {
            By validarMarcadorCriado = By.XPath($"//a[text()='{nomeMarcador}']");
            Click(validarMarcadorCriado);
        }

        public void ApagarMarcador()
        {
            Click(apagarMarcadorButton);
        }

        public void ClicarAtualizarMarcador()
        {
            Click(atualizarMarcadorButton);
        }

        public void ApagarNomeMarcador()
        {
            Clear(nomeMarcadorText);
        }

        public string RetornarNomeMarcadorAposEditar(string nomeMarcadorEditado)
        {
            By nomeMarcadorAposAtualizar = By.XPath($"//td[text()='{nomeMarcadorEditado}']");
            return GetText(nomeMarcadorAposAtualizar);
        }

        public void ApagarDescricao()
        {
            Clear(descricaoMarcadorText);
        }

        public string RetornarDescricaoMarcadorAposEditar(string descricaoEditada)
        {
            By descricaoAposAtualizar = By.XPath($"//td[text()='{descricaoEditada}']");
            return GetText(descricaoAposAtualizar);
        }

        public string RetornaMensagemErro()
        {
            return GetText(mensagemErro);
        }
    }
}
