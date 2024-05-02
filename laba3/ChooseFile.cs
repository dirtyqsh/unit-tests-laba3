using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        public static class ExceptionStrings
        {
            public const string NameReserv = "Невозможно использовать файл с зарезервированным именем.";
            public const string SymbolReserv = "Невозможно использовать файл с зарезервированным символом в названии.";
            public const string Lenght = "Невозможно выбрать файл с длиной имени больше 25 символов.";
            public const string CleanQueue = "Невозможно добавить файл в очередь.";
            public const string NameDir = "Неверное имя директории.";
        }

        public static bool clickFile(string nameFile, string nameDir)
        {
            return true;
        }

        public static bool checkNameFile(string nameFile)
        {
            throw new NotImplementedException();
        }

        public static bool checkList(List<bool> queue)
        {
            throw new NotImplementedException();
        }
    }

    
}
