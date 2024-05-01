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
            string nameDir = @"C:\study";

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
            string nameFile = "CON.pdf";

            List<string> failName = new List<string>() { "CON", "PRN", "AUX", "NUL", "COM0", "COM1", "COM2", "COM3", "COM4",
                "COM5", "COM6", "COM7", "COM8", "COM9", "LPT0", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };

            string expectedExceptionMessage = "���������� ������������ ���� � ����������������� ������.";

            Exception? exception = Assert.Throws<Exception>(() =>
            {
                AddFileForm.checkNameFile(nameFile);
            });

            Assert.IsNotNull(exception);

            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }
    }
}