using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryLab13;

namespace TestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethodSearchWordEnding() {
            List<string> expected = new() { "asd", "rthtjasd" };
            TextFile textFile = new("test.txt") {
                Text = "rhr. hrthtj. asd. thtjergr. rthtjasd."
            };
            List<string> actual = textFile.WordsEndingWithSyllable("asd");
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void TextMethodWordCount() {
            TextFile file = new("test1.txt", "� ����� 4 �����");
            int expected = 4;
            Assert.AreEqual(file.WordCount(), expected);
        }


    }
   



}