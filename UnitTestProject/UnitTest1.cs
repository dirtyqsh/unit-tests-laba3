using NUnit.Framework;
using laba3;
using System.Collections.Generic;
using System;

namespace UnitTestProject
{
    public class Tests
    {

        ///<summary>
        ///���������� �������� ��� AddFileForm.
        ///� ������� �������� ��� ���������� � ��� �����.
        ///</summary>
        [Test]
        public void T_001_clickFile_BaseFlow()
        {
            string nameFile = "completecode.pdf";
            string nameDir = @"C:\";

            // ���������
            bool expectedReturnValue = true;

            // ���������� ��� ����������� ��������
            bool actualReturnValue = false;

            Assert.DoesNotThrow(() =>
            {
                actualReturnValue = AddFileForm.clickFile(nameFile, nameDir);
            });
            // ��� �������� ���������� � ����������� ��������
            Assert.AreEqual(expectedReturnValue, actualReturnValue);
        }

        /// <summary>
        /// ����������������� ��� �����.
        /// ������������ ������ ���� � ������������������ ������.
        /// </summary>
        [Test]
        public void T_002_clickFile_NameReserv()
        {
            string nameFile = "CON"; // pdf?

            string expectedExceptionMessage = AddFileForm.ExceptionStrings.NameReserv;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                AddFileForm.checkNameFile(nameFile);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// ����������������� ������.
        /// ������������ ������ ���� � �������� �������� ���������� �����������������.
        /// </summary>
        [Test]
        public void T_003_clickFile_SymbolReserv()
        {
            string nameFile = "complete*code";

            string expectedExceptionMessage = AddFileForm.ExceptionStrings.SymbolReserv;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                AddFileForm.checkNameFile(nameFile);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// ����� ����� ������ 25 ��������.
        /// ������������ ������ ���� � ������ ����� ������ 25 ��������.
        /// </summary>
        [Test]
        public void T_004_clickFile_Lenght()
        {
            string nameFile = "completecodecompletecodecode";

            string expectedExceptionMessage = AddFileForm.ExceptionStrings.Lenght;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                AddFileForm.checkNameFile(nameFile);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// ��������� ����� � �������.
        /// ������������ ��������� ����, �� ������� �� ������� ���������.
        /// </summary>
        [Test]
        public void T_005_checkList_CleanQueue()
        {
            List<bool> queue = new List<bool>() { true, true, true, true, true };

            string expectedExceptionMessage = AddFileForm.ExceptionStrings.CleanQueue;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                AddFileForm.checkList(queue);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// �������������� ����������.
        /// ������������ �������� �������������� ����������.
        /// </summary>
        [Test]
        public void T_006_clickFile_NameDir()
        {
            string nameFile = "completecode.pdf";
            string nameDir = @"hello:\hellooo-!";

            string expectedExceptionMessage = AddFileForm.ExceptionStrings.NameDir;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                AddFileForm.clickFile(nameFile, nameDir);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        public class MockFileData : FileDataInterface
        {
            public string NameFile { get; set; }
        }

        public class MockToTranslateController_NoConnection : ToTranslateControllerInterface
        {
            public FileDataInterface getNewFileData() { throw new NotImplementedException(); }

            public bool tryTranslate() { return false; }

            public bool translate(string nameFile) { throw new NotImplementedException(); }

        }

        public class MockToTranslateController_OK : ToTranslateControllerInterface
        {
            public FileDataInterface getNewFileData() { return new MockFileData() { NameFile = "completecode.pdf" }; }

            public bool tryTranslate() { return true; }

            public bool translate(string nameFile) { return true; }

        }

        /// <summary>
        /// ���� ��������� �� �������.
        /// ������� �������� � �������� ��������.
        /// </summary>
        [Test]
        public void T_007_clickToTranslate_BasicFlow()
        {
            string nameFile = "completecode.pdf";

            AddFileForm addFileForm = new AddFileForm();
            addFileForm.controllerInterface = new MockToTranslateController_OK();
            FileDataInterface fileData = null;

            Assert.DoesNotThrow(() =>
            {
                fileData = addFileForm.clickToTranslate(nameFile);
            });

            Assert.IsNotNull(fileData);

            Assert.AreEqual(fileData.NameFile, nameFile);
        }

        /// <summary>
        /// ��� ����������� � �������.
        /// ���������� ��������� ����.
        /// </summary>
        [Test]
        public void T_008_clickToTranslate_NoConnection()
        {
            string nameFile = "completecode.pdf";

            AddFileForm addFileForm = new AddFileForm();
            addFileForm.controllerInterface = new MockToTranslateController_NoConnection();
            String expectedExceptionMessage = AddFileForm.ExceptionStrings.NoConnection;

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                addFileForm.clickToTranslate(nameFile);
            });


            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }
    }
}