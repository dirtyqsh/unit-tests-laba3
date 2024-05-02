using NUnit.Framework;
using laba3;
using System.Collections.Generic;
using System;

namespace UnitTestProject
{
    public class Tests
    {

        ///<summary>
        ///Правильные значения для AddFileForm.
        ///В функцию переданы имя директории и имя файла.
        ///</summary>
        [Test]
        public void T_001_clickFile_BaseFlow()
        {
            string nameFile = "completecode.pdf";
            string nameDir = @"C:\study";

            // ожидаемое
            bool expectedReturnValue = true;

            // подготовка для полученного значения
            bool actualReturnValue = false;

            Assert.DoesNotThrow(() =>
            {
                actualReturnValue = AddFileForm.clickFile(nameFile, nameDir);
            });
            // для проверки ожидаемого и полученного значения
            Assert.AreEqual(expectedReturnValue, actualReturnValue);
        }

        /// <summary>
        /// Зарезервированное имя файла.
        /// Пользователь выбрал файл с зарезервированными именем.
        /// </summary>
        [Test]
        public void T_002_clickFile_NameReserv()
        {
            string nameFile = "CON.pdf";

            List<string> failName = new List<string>() { "CON", "PRN", "AUX", "NUL", "COM0", "COM1", "COM2", "COM3", "COM4",
                "COM5", "COM6", "COM7", "COM8", "COM9", "LPT0", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };

            string expectedExceptionMessage = "Невозможно использовать файл с зарезервированным именем.";

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                AddFileForm.checkNameFile(nameFile);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// Зарезервированный символ.
        /// Пользователь выбрал файл в названии которого содержится зарезервированный.
        /// </summary>
        [Test]
        public void T_003_clickFile_SymbolReserv()
        {
            string nameFile = "complete*code.pdf";

            List<string> failSymbol = new List<string>() { "/", @"\", "|", "*", ":", "?", @"""", "<", ">" };

            string expectedExceptionMessage = "Невозможно использовать файл с зарезервированным символом в названии.";

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                AddFileForm.checkNameFile(nameFile);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// Длина файла больше 25 символов.
        /// Пользователь выбрал файл с длиной имени больше 25 символов.
        /// </summary>
        [Test]
        public void T_004_clickFile_Lenght()
        {
            string nameFile = "completecodecompletecodecode.pdf";

            int max_lenght = 25;

            string expectedExceptionMessage = "Невозможно выбрать файл с длиной имени больше 25 символов.";

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                AddFileForm.checkNameFile(nameFile);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// Свободное место в очереди.
        /// Пользователь добавляет файл, но очередь на перевод заполнена.
        /// </summary>
        [Test]
        public void T_005_checkList_CleanQueue()
        {
            List<bool> queue = new List<bool>() { true, true, true, true, true };

            string expectedExceptionMessage = "Невозможно добавить файл в очередь.";

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                AddFileForm.checkList(queue);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// Несуществующая директория.
        /// Пользователь выбирает несуществующую директорию.
        /// </summary>
        [Test]
        public void T_006_clickFile_NameDir()
        {
            List<bool> queue = new List<bool>() { true, true, true, true, true };

            string expectedExceptionMessage = "Невозможно добавить файл в очередь.";

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                AddFileForm.checkList(queue);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }
    }
}