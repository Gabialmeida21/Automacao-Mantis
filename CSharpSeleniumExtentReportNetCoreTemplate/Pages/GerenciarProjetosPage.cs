using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class GerenciarProjetosPage : PageBase
    {
        #region Mapping
        By abaGerenciarProjetos = By.XPath("//a[@href='/manage_proj_page.php']");
        By criarNovoProjetoButton = By.XPath("//button[@class='btn btn-primary btn-white btn-round']");
        By nomeProjetoText = By.Id("project-name");
        By descricaoProjetoText = By.Id("project-description");
        By adicionarProjetoButton = By.XPath("//input[@value='Adicionar projeto']");
        By mensagemConfirmarCriacaoProjeto = By.XPath("//div[@class='alert alert-success center']/p");
        By mensagemErro = By.XPath("//div[@class='alert alert-danger']");
        By nomeCategoriaText = By.XPath("//input[@class='input-sm']");
        By adicionarCategoriaButton = By.XPath("//input[@value='Adicionar Categoria']");
        By validarCategoriaAposAdicionar = By.XPath("//div[@id='categories']//table[@class='table table-striped table-bordered table-condensed table-hover']//td[contains(text(), 'Categoria Teste Automação')]");
        By nomeProjetoLink = By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']//td//a[text()='46']");
        By alterarNomeProjetoText = By.XPath("//input[@id='project-name']");
        By nomeProjetoAposAlteracaoLink = By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']//td//a[text()='46 teste']");
        By atualizarProjetoButton = By.XPath("//input[@value='Atualizar Projeto']");
        By removerProjetoButton = By.XPath("//input[@value='Apagar Projeto']");
        By nomeProjetoParaSerRemovido = By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']//td//a[text()='Projeto para ser removido']");
        By mensagemErroAoAdicionarCategoriaSemPreencherCampo = By.XPath("//div[@class='alert alert-danger']/p[2]");
        By adicionarEEditarCategoriaSemPreencherCampoButton = By.XPath("//input[@value='Adicionar e editar Categoria']");

        #endregion

        public void AbaGerenciarProjetos()
        {
            Click(abaGerenciarProjetos);
        }

        public void CriarNovoProjeto()
        {
            Click(criarNovoProjetoButton);
        }

        public void PreencherNomeProjeto(string text)
        {
            SendKeys(nomeProjetoText, text);
        }

        public void PreencherDescricaoProjeto(string text)
        {
            SendKeys(descricaoProjetoText, text);
        }

        public void ClicarAdicionarProjeto()
        {
            Click(adicionarProjetoButton);
        }

        public string RetornaMensagemSucesso()
        {
            return GetText(mensagemConfirmarCriacaoProjeto);
        }

        public string RetornaMensagemErro()
        {
            return GetText(mensagemErro);
        }

        public void PreencherNomeCategoria(string text)
        {
            SendKeys(nomeCategoriaText, text);
        }

        public void ClicarAdicionarCategoria()
        {
            Click(adicionarCategoriaButton);
        }

        public string RetornaNomeCategoria()
        {
            return GetText(validarCategoriaAposAdicionar);
        }

        public void ClicarNomeProjeto()
        {
            Click(nomeProjetoLink);
        }

        public void AlterarNomeProjeto(string text)
        {
            SendKeys(alterarNomeProjetoText, text);
        }

        public void ClicarAtualizarProjeto()
        {
            Click(atualizarProjetoButton);
        }

        public string RetornaNomeProjetoAposAlteracao()
        {
            return GetText(nomeProjetoAposAlteracaoLink);
        }

        public void ApagarProjeto()
        {
            Click(removerProjetoButton);
        }

        public void ClicarNomeProjetoParaApagar()
        {
            Click(nomeProjetoParaSerRemovido);
        }

        public string RetornaMensagemErroAoNaoPreencherCampo()
        {
            return GetText(mensagemErroAoAdicionarCategoriaSemPreencherCampo);

        }

        public void ClicarAdicionarEEditarCategoria()
        {
            Click(adicionarEEditarCategoriaSemPreencherCampoButton);
        }


    }
}
