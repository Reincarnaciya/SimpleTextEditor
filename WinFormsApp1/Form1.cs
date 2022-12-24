using LibraryLab13;
using System.Diagnostics;

namespace WinFormsApp1 {
    public partial class Form1 : Form {

        protected TextFile? OpenTextFile;
        private bool _saveFile = false;

        public Form1() {
            OpenTextFile = null;
            InitializeComponent();
        }

        private void FileOpenClick(object sender, EventArgs e) {
            State.Text = "���������: �������� �����";
            openFileDialog1.Filter = "��������� ����(*.txt)|*.txt|���� rtf(*.rtf)|*.rtf|��� �����(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            

            richTextBox1.Clear();
            OpenTextFile = new TextFile(openFileDialog1.FileName);
            //OpenTextFile.FileRead();
            richTextBox1.AppendText(OpenTextFile.Text);

            Debug.WriteLine(OpenTextFile.WordCount());

            NumWords.Text = "����� ���� " + OpenTextFile.WordCount();
            NumChar.Text = "����� ������: " + richTextBox1.TextLength;
            NumStrings.Text = "�����: " + richTextBox1.Lines.Length;
        }

        private void FileSaveClick(object sender, EventArgs e) {
            if (OpenTextFile == null) {
                ErrorOutput(
                    "���� �� ������.\n" +
                    "�������� ���� ����� ��������� ���\n" +
                    "��� ��������� ���� ����� ������� \"��������� ���\""
                );
                return;
            }

            State.Text = "���������: ���������� �����";

            if (!File.Exists(OpenTextFile.FilePath)) {
                saveFileDialog1.Filter = "��������� ����(*.txt)|*.txt|���� rtf(*.rtf)|*.rtf|��� �����(*.*)|*.*";
                saveFileDialog1.Title = "���������";

                OpenTextFile = new TextFile(saveFileDialog1.FileName);
            }
            OpenTextFile.Text = richTextBox1.Text;
            OpenTextFile.FileSave();
            _saveFile = true;
        }

        private void FileSaveAsClick(object sender, EventArgs e) {
            /*if (OpenTextFile == null) {
                ErrorOutput("���� �� ������.\n" +
                    "�������� ���� ����� ��������� ���");
            }*/
            //OpenTextFile.Text = richTextBox1.Text;
            State.Text = "���������: ���������� �����";
            saveFileDialog1.Filter = "��������� ����(*.txt)|*.txt|���� rtf(*.rtf)|*.rtf|��� �����(*.*)|*.*";
            saveFileDialog1.Title = "��������� ���..";

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            

            TextFile OpenTextFile2 = new(saveFileDialog1.FileName);
            OpenTextFile2.Text = richTextBox1.Text;
            OpenTextFile2.FileSave();

            _saveFile = true;
        }

        private void PrintPageClick(object sender, EventArgs e) {
            if (OpenTextFile == null) {
                ErrorOutput("���� �� ������");
                return;
            }
            if (string.IsNullOrEmpty(OpenTextFile.Text)) {
                ErrorOutput("���� ������");
                return;
            }

            State.Text = "���������: ���������� �����";

            try {
                OpenTextFile.PrintPage();
                State.Text = "���������: ����� ������";
            } catch (Exception ex) {
                ErrorOutput(ex.Message);
                State.Text = "���������: ������ �������";
            }
        }

        private void ErrorOutput(string text) {
            MessageBox.Show(
                text,
                "�� ���� �������?",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
            );
        }

        private void SearchFilesTheDirectoryClick(object sender, EventArgs e) {
            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.ShowDialog();

            richTextBox1.Clear();

        }
    }
}