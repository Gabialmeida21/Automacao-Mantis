using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Pages
{
    public class VerTarefasPage : PageBase
    {
        #region Mapping
        By verTarefaButton = By.XPath("//a[@href='/view_all_bug_page.php']");
        
        #endregion

        public void ClicarMenuVerTarefa()
        {
            Click(verTarefaButton);
        }

    }

}
