using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    public interface ToTranslateControllerInterface
    {
        public bool tryTranslate(); // проерка на подлкючение к сервису
        public FileDataInterface getNewFileData();
        public bool translate(string nameFile);
    }
}
