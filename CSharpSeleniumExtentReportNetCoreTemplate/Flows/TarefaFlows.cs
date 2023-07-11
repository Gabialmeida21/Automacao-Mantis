using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Flows
{
    public class TarefaFlows
    {
        #region Page Object and Construtor
        CriarTarefaPage criarTarefaPage;
        MainPage mainPage;
        #endregion

        public TarefaFlows()
        {
            criarTarefaPage = new CriarTarefaPage();
            mainPage = new MainPage();
        }
        
        public string atribuicaoNome = "administrator";
        public string resumo = "Tarefa de Teste Mantis2";
        public string descricao = "Desafio Automação Web";
        public string passosReproduzir = "1.Realizar Login";


        public void CriarNovaTarefa(string nomeProjeto, string nomeCategoria)
        {
            mainPage.ClicarSelecionarProjetoGeral();
            mainPage.SelecionarTodosOsProjetos();
            mainPage.ClicarMenuCriarTarefa();
            criarTarefaPage.SelecionarProjeto(nomeProjeto);
            criarTarefaPage.ClicarBotaoSelecionarProjeto();
            criarTarefaPage.SelecionarCategoria(nomeCategoria);
            criarTarefaPage.SelecionarAtribuicao(atribuicaoNome);
            criarTarefaPage.PreencherResumo(resumo);
            criarTarefaPage.PreencherDescricao(descricao);
            criarTarefaPage.PreencherPassosParaReproduzir(passosReproduzir);
            criarTarefaPage.ClicarBotaoCriarNovaTarefa();
        }


    }
}
