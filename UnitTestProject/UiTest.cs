using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using laba3;
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
        const string errorLabelString = "Неверное имя директории.";

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


                //Step #2
                fileButton.Click();
                System.Threading.Thread.Sleep(1000);
                window.CaptureToFile("EmptyEnter.png");

                var retry = Retry.WhileException(() =>
                {
                    Assert.AreEqual(AddFileForm.ExceptionStrings.EmptyEnter, errorLabel.Text);
                }, TimeSpan.FromMilliseconds(M));

                if (!retry.Success)
                {
                    Assert.AreEqual(AddFileForm.ExceptionStrings.EmptyEnter, errorLabel.Text);
                }

                //Step #3
                fileTextBox.Enter(@"C:\CON.pdf");

                fileButton.Click();
                System.Threading.Thread.Sleep(1000);
                window.CaptureToFile("NameReserv.png");

                retry = Retry.WhileException(() =>
                {
                    Assert.AreEqual(AddFileForm.ExceptionStrings.NameReserv, errorLabel.Text);
                }, TimeSpan.FromMilliseconds(M));

                if (!retry.Success)
                {
                    Assert.AreEqual(AddFileForm.ExceptionStrings.NameReserv, errorLabel.Text);
                }

                //Step #4
                fileTextBox.Enter(@"C:\complete*code.pdf");

                fileButton.Click();
                System.Threading.Thread.Sleep(1000);
                window.CaptureToFile("SymbolReserv.png");

                retry = Retry.WhileException(() =>
                {
                    Assert.AreEqual(AddFileForm.ExceptionStrings.SymbolReserv, errorLabel.Text);
                }, TimeSpan.FromMilliseconds(M));

                if (!retry.Success)
                {
                    Assert.AreEqual(AddFileForm.ExceptionStrings.SymbolReserv, errorLabel.Text);
                }

                //Step #5
                fileTextBox.Enter(@"C:\completecodecompletecodecode.pdf");

                fileButton.Click();
                System.Threading.Thread.Sleep(1000);
                window.CaptureToFile("Lenght.png");

                retry = Retry.WhileException(() =>
                {
                    Assert.AreEqual(AddFileForm.ExceptionStrings.Lenght, errorLabel.Text);
                }, TimeSpan.FromMilliseconds(1000));

                if (!retry.Success)
                {
                    Assert.AreEqual(AddFileForm.ExceptionStrings.Lenght, errorLabel.Text);
                }

                //Step #7
                fileTextBox.Enter(@"hello:\completecode.pdf");

                fileButton.Click();
                System.Threading.Thread.Sleep(1000);
                window.CaptureToFile("NameDir.png");

                retry = Retry.WhileException(() =>
                {
                    Assert.AreEqual(AddFileForm.ExceptionStrings.NameDir, errorLabel.Text);
                }, TimeSpan.FromMilliseconds(M));

                if (!retry.Success)
                {
                    Assert.AreEqual(AddFileForm.ExceptionStrings.NameDir, errorLabel.Text);
                }

                //Step #8
                fileTextBox.Enter(@"C:\completecode.pdf");

                fileButton.Click();
                System.Threading.Thread.Sleep(1000);
                window.CaptureToFile("ok.png");

                retry = Retry.WhileException(() =>
                {
                    var msg = window.ModalWindows.FirstOrDefault().AsWindow();

                    Assert.NotNull(msg);

                    var message = msg.FindFirstChild(cf => cf.ByText("Выбран файл " + @"C:\completecode.pdf")).AsLabel();

                    Assert.NotNull(message);

                    //Step #9
                    var yesButton = msg.FindFirstChild(cf => cf.ByName("ОК")).AsButton();

                    Assert.NotNull(yesButton);

                    msg.CaptureToFile("okdialog.png");

                    yesButton.Click();

                }, TimeSpan.FromMilliseconds(5000));

                if (!retry.Success)
                {
                    Assert.Fail("Нет диалогового окна!");
                }

                app.Close();
            }
        }
        [Test]
        public void T_002_ChooseFile()
        {
            //Step #1
            FlaUI.Core.Application app = FlaUI.Core.Application.Launch(PathTestingApp, "1");
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

                //Step #2
                fileTextBox.Enter(@"C:\completecode.pdf");

                fileButton.Click();
                System.Threading.Thread.Sleep(1000);
                window.CaptureToFile("NoConnection.png");

                var retry = Retry.WhileException(() =>
                {
                    Assert.AreEqual(AddFileForm.ExceptionStrings.NoConnection, errorLabel.Text);
                }, TimeSpan.FromMilliseconds(M));

                if (!retry.Success)
                {
                    Assert.AreEqual(AddFileForm.ExceptionStrings.NoConnection, errorLabel.Text);
                }

                app.Close();
            }
        }
    }
}
