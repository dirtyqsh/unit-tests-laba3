using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using NUnit.Framework;

namespace UnitTestProject
{
    internal class UiTest
    {
        string PathTestingApp = @"C:\Users\kloun\Desktop\study\ТП\Лаба3\unit-tests-laba3\laba3\bin\Debug\net5.0-windows\laba3.exe";

        int M = 5000;

        const string chooseFileTitleString = "Выбор файла";
        const string fileButtonString = "Выбрать файл";
        const string fileLabelString = "Файл";
        const string errorLabelString = "Некорректный ввод";

        //automatisation-id 
        const string idFileButton = "FileButton";
        const string idFileLabel = "FileLabel";
        const string idErrorLabel = "ErrorLabel";
        const string idFileTextBox = "FileTextBox";

        public T WaitForElement<T>(Func<T> getter)
        {
            var retry = Retry.WhileNull<T>(
            getter,
            TimeSpan.FromMilliseconds(M));
            if (!retry.Success)
            {
                Assert.Fail($"Невозможно найти элемент {M} ms");
            }
            return retry.Result;
        }


        [Test]
        public void T_001_ChooseFile()
        {
            //Step #1
            FlaUI.Core.Application app = FlaUI.Core.Application.Launch(PathTestingApp, "2");
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                string title = window.Title;

                Assert.AreEqual(chooseFileTitleString, title);

                var fileButton = WaitForElement(() => window.FindFirstDescendant(cf => cf.ByAutomationId(idFileButton)).AsButton());

                var fileTextBox = WaitForElement(() => window.FindFirstDescendant(cf => cf.ByAutomationId(idFileTextBox)).AsTextBox());

                var fileLabel = WaitForElement(() => window.FindFirstDescendant(cf => cf.ByAutomationId(idFileLabel)).AsLabel());
                var errorLabel = WaitForElement(() => window.FindFirstDescendant(cf => cf.ByAutomationId(idErrorLabel)).AsLabel());

                Assert.AreEqual(fileButtonString, fileButton.AsLabel().Text);

                Assert.AreEqual(fileLabelString, fileLabel.Text);
                Assert.AreEqual(errorLabelString, errorLabel.Text);

                Assert.AreEqual("", fileTextBox.Text);

                app.Close();
            }
        }
    }
}
