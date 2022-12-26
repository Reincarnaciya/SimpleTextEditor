using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryLab13;

namespace TestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            TextFile file1 = new TextFile("1.txt") { Text = "������ ���" };
            TextFile file2 = new TextFile("2.txt") { Text = "��� ������" };
            file1.FileSave();
            file2.FileSave();
            bool actual = (file1 == file2);
            bool expected = true; // ��������� ��������
            Assert.AreEqual(expected, actual, "�������� ��������� ������ ��  ��������� ��������� �� �����! ");
        }

        [TestMethod]
        public void TestMethod2() {
            TextFile file1 = new TextFile("1.txt") { Text = "����������" };
            TextFile file2 = new TextFile("2.txt") { Text = "������ ����" };
            file1.FileSave();
            file2.FileSave();
            bool actual = (file1 != file2);
            bool expected = true; // ��������� ��������
            Assert.AreEqual(expected, actual, "�������� ��������� ������ ��  ��������� ��������� �� �����! ");
        }


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