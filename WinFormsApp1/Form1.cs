using LibraryLab13;
using System.Windows.Forms;

namespace WinFormsApp1 {
    public partial class Form1 : Form {

        protected TextFile? OpenTextFile;

        public bool SaveFile = false;

#pragma warning disable CS8618 // ����, �� ����������� �������� NULL, ������ ��������� ��������, �������� �� NULL, ��� ������ �� ������������. ��������, ����� �������� ���� ��� ����������� �������� NULL.
        public Form1() {
            OpenTextFile = null;
            InitializeComponent();
        }
#pragma warning restore CS8618 // ����, �� ����������� �������� NULL, ������ ��������� ��������, �������� �� NULL, ��� ������ �� ������������. ��������, ����� �������� ���� ��� ����������� �������� NULL.

        private void FileOpenClick(object sender, EventArgs e) {
            OpenTextFile?.Close();
            State.Text = "���������: �������� �����";
            openFileDialog1.Filter = "��������� ����(*.txt)|*.txt|���� rtf(*.rtf)|*.rtf|��� �����(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) {
                return;
            }

            richTextBox1.Clear();
            OpenTextFile = new TextFile(openFileDialog1.FileName);
            //OpenTextFile.FileRead();
            richTextBox1.AppendText(OpenTextFile.Text);
 
            NumWords.Text = "����� ���� " + OpenTextFile.WordCount();
            NumChar.Text = "����� ������: " + richTextBox1.TextLength;
            NumStrings.Text = "�����: " + richTextBox1.Lines.Length;
        }

        private void FileSaveClick(object sender, EventArgs e) {
            if (OpenTextFile == null) {
                return;
            }
            OpenTextFile.Text = richTextBox1.Text;

            State.Text = "���������: ���������� �����";

            OpenTextFile.FileSave();

            SaveFile = true;
        }

        private void SaveFileClick(object sender, EventArgs e) {
            if (OpenTextFile == null) {
                return;
            }

        }
    }
}