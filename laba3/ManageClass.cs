using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    public static class ManageClass
    {
        public static int index = 3;

        public static ToTranslateControllerInterface GetControllerInterface()
        {
#if DEBUG
            switch (index)
            {
                case 0: throw new NotImplementedException(); break;
                case 1: return new MockToTranslateController_NoConnection(); break;
                case 2: return new MockToTranslateController_OK(); break;
            }
            return null;
#else
            throw new NotImplementedException();
#endif

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
            MockFileData fileData;

            public FileDataInterface getNewFileData() { return fileData; }

            public bool tryTranslate() { return true; }

            public bool translate(string nameFile) { fileData = new MockFileData() { NameFile = "completecode.pdf" }; return true; }

        }
    }
}
