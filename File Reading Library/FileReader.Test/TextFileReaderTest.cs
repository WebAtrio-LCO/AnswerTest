using FileReader.Reader;
using FileReader.Test.Common;
using NUnit.Framework;
using SimplisticImplementation.Utility;
using System;
using System.IO;
using System.Reflection;

namespace FileReader.Test
{
    /// <summary>
    /// Description résumée pour TextFileReaderTest
    /// </summary>
    [TestFixture]
    public class TextFileReaderTest
    {
        protected Assembly ResourceAssembly => Assembly.GetExecutingAssembly();
        public TextFileReaderTest()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        ///
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #region Nominal Working
        [CrucialTest]
        [Test]
        [TestCase(@"\Resources\MdFile.md")]
        public void TestReadValidMd(string fileName)
        {
            string fullPath = string.Concat(Path.GetDirectoryName(ResourceAssembly.Location), "\\" , fileName);

            //Test the file reading Library
            AFileReader textFileReader = new TextFileReader(FileExtention.fileExtensions);
            var result = textFileReader.ReadFile(fullPath);

            Assert.IsNotEmpty(result);
            Assert.IsNotNull(result);
            Assert.AreEqual("This is an md file", result);
        }

        [CrucialTest]
        [Test]
        [TestCase(@"\Resources\EmptyMdFile.md")]
        public void TestReadEmptyMd(string fileName)
        {
            string fullPath = string.Concat(Path.GetDirectoryName(ResourceAssembly.Location), "\\", fileName);

            //Test the file reading Library
            AFileReader textFileReader = new TextFileReader(FileExtention.fileExtensions);
            var result = textFileReader.ReadFile(fullPath);

            Assert.IsEmpty(result);
            Assert.IsNotNull(result);
        }

        [CrucialTest]
        [Test]
        [TestCase(@"\Resources\LogFile.log")]
        public void TestReadLogFile(string fileName)
        {
            string fullPath = string.Concat(Path.GetDirectoryName(ResourceAssembly.Location), "\\", fileName);

            //Test the file reading Library
            AFileReader textFileReader = new TextFileReader(FileExtention.fileExtensions);
            var result = textFileReader.ReadFile(fullPath);

            Assert.IsNotEmpty(result);
            Assert.IsNotNull(result);
            Assert.AreEqual("This is a log file", result);
        }

        [CrucialTest]
        [Test]
        [TestCase(@"\Resources\EmptyLogFile.log")]
        public void TestReadEmptyLogFile(string fileName)
        {
            string fullPath = string.Concat(Path.GetDirectoryName(ResourceAssembly.Location), "\\", fileName);

            //Test the file reading Library
            AFileReader textFileReader = new TextFileReader(FileExtention.fileExtensions);
            var result = textFileReader.ReadFile(fullPath);

            Assert.IsEmpty(result);
            Assert.IsNotNull(result);
        }

        [CrucialTest]
        [Test]
        [TestCase(@"\Resources\TxtFile.txt")]
        public void TestReadTxtFile(string fileName)
        {
            string fullPath = string.Concat(Path.GetDirectoryName(ResourceAssembly.Location), "\\", fileName);

            //Test the file reading Library
            AFileReader textFileReader = new TextFileReader(FileExtention.fileExtensions);
            var result = textFileReader.ReadFile(fullPath);

            Assert.IsNotEmpty(result);
            Assert.IsNotNull(result);
            Assert.AreEqual("This is a txt file", result);
        }

        [CrucialTest]
        [Test]
        [TestCase(@"\Resources\EmptyTxtFile.txt")]
        public void TestReadEmptyTxtFile(string fileName)
        {
            string fullPath = string.Concat(Path.GetDirectoryName(ResourceAssembly.Location), "\\", fileName);

            //Test the file reading Library
            AFileReader textFileReader = new TextFileReader(FileExtention.fileExtensions);
            var result = textFileReader.ReadFile(fullPath);

            Assert.IsEmpty(result);
            Assert.IsNotNull(result);
        }

        #endregion

        #region Exception handling
        [Test]
        [TestCase(@"\Resources\")]
        public void TestReadInvalidPath(string fileName)
        {
            string fullPath = string.Concat(Path.GetDirectoryName(ResourceAssembly.Location), "\\", fileName);

            //Test the file reading Library
            AFileReader textFileReader = new TextFileReader(FileExtention.fileExtensions);
            Assert.Throws<ArgumentException>(() => textFileReader.ReadFile(fullPath), "The requested path is not a file");
        }

        [Test]
        [TestCase(@"\Resources\failedtest")]
        public void TestReadNotExist(string fileName)
        {
            string fullPath = string.Concat(Path.GetDirectoryName(ResourceAssembly.Location), "\\", fileName);

            //Test the file reading Library
            AFileReader textFileReader = new TextFileReader(FileExtention.fileExtensions);
            Assert.Throws<FileNotFoundException>(() => textFileReader.ReadFile(fullPath), string.Format("Text File {0} does not exist", fullPath));
        }

        [Test]
        [TestCase(@"\Resources\NotSupported.err")]
        public void TestReadNotSupported(string fileName)
        {
            string fullPath = string.Concat(Path.GetDirectoryName(ResourceAssembly.Location), "\\", fileName);

            //Test the file reading Library
            TextFileReader textFileReader = new TextFileReader();
            Assert.Throws<ArgumentOutOfRangeException>(() => textFileReader.ReadTextFile(fullPath), "Specified type is not supported");
        }

        #endregion


    }
}
