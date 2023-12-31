﻿using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Flows
{
    public class ProjetoFlows
    {
        #region Page Object and Constructor
        GerenciarProjetosPage gerenciarProjetosPage;
        MainPage mainPage;
        public ProjetoFlows()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
            mainPage = new MainPage();
        }
        #endregion

        #region Parameteres
        public string descricaoProjeto = "Teste de automação Mantis";
        #endregion

        public void CriarNovoProjeto(string nomeProjeto)
        {
            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.CriarNovoProjeto();
            gerenciarProjetosPage.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.PreencherDescricaoProjeto(descricaoProjeto);
            gerenciarProjetosPage.ClicarAdicionarProjeto();
        }

        public void CriarCategoria(string nomeCategoria)
        {
            mainPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.AbaGerenciarProjetos();
            gerenciarProjetosPage.PreencherNomeCategoria(nomeCategoria);
            gerenciarProjetosPage.ClicarAdicionarCategoria();
        }

        
    }
}
