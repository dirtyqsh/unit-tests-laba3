using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba3
{
    public partial class AddFileForm : Form
    {
        public AddFileForm()
        {
            InitializeComponent();

            controllerInterface = ManageClass.GetControllerInterface();
        }

        public static class ExceptionStrings
        {
            public const string NameReserv = "Невозможно использовать файл с зарезервированным именем.";
            public const string SymbolReserv = "Невозможно использовать файл с зарезервированным символом в названии.";
            public const string Lenght = "Невозможно выбрать файл с длиной имени больше 25 символов.";
            public const string CleanQueue = "Невозможно добавить файл в очередь.";
            public const string NameDir = "Неверное имя директории.";
            public const string NoConnection = "Невозможно передать файл.";
            public const string EmptyEnter = "Неверное имя директории.";
        }

        public static bool clickFile(string nameFile, string nameDir)
        {
            if (!Directory.Exists(nameDir))
            {
                throw new Exception(ExceptionStrings.NameDir);
            }

            return true;
        }

        public static bool checkNameFile(string fullPath)
        {
            List<string> failName = new List<string>() { "CON", "PRN", "AUX", "NUL", "COM0", "COM1", "COM2", "COM3", "COM4",
                "COM5", "COM6", "COM7", "COM8", "COM9", "LPT0", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };

            List<string> failSymbol = new List<string>() { "|", ":", "*", "?", @"""", "<", ">" };

            int maxLenghtName = 25;

            string nameFile = Path.GetFileName(fullPath);
            string nameDir = Path.GetDirectoryName(fullPath);

            if (failName.Any(nameFile.Contains))
            {
                throw new Exception(ExceptionStrings.NameReserv);
            }

            if (failSymbol.Any(nameFile.Contains))
            {
                throw new Exception(ExceptionStrings.SymbolReserv);
            }

            if (nameFile.Length >= maxLenghtName)
            {
                throw new Exception(ExceptionStrings.Lenght);
            }

            if (!Directory.Exists(nameDir))
            {
                throw new Exception(ExceptionStrings.NameDir);
            }

            return true;
        }

        public static bool checkList(List<bool> queue)
        {
            int maxLenghtQueue = 5;

            if (queue.Count(item => item == true) >= maxLenghtQueue)
            {
                throw new Exception(ExceptionStrings.CleanQueue);
            }

            return true;
        }

        public ToTranslateControllerInterface controllerInterface = null;

        public FileDataInterface clickToTranslate(string nameFile)
        {
            if (checkNameFile(nameFile))
            {
                if (controllerInterface.tryTranslate())
                {
                    FileDataInterface fileData = controllerInterface.getNewFileData();

                    controllerInterface.translate(fileData.NameFile);

                    return fileData;
                }
                else
                {
                    throw new Exception(ExceptionStrings.NoConnection);
                }
            }

            return null;
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";

            try
            {
                string file = FileTextBox.Text;
                FileDataInterface fileData = clickToTranslate(file);

                ErrorLabel.Text = "Выбран файл " + fileData.NameFile;
                if (MessageBox.Show("Выбран файл " + fileData.NameFile, "Внимание!") == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                ErrorLabel.Text = exception.Message;
            }
        }
        }


    }
