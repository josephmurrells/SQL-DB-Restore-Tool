using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R4DBTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new()
            {
                InitialDirectory = @"C:\",
                Title = "Browse bak Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "bak",
                Filter = "backup files (*.bak)|*.bak",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                if (textBox1.Text == "" || textBox2.Text == "" || !Directory.Exists(textBox2.Text))
                {
                    MessageBox.Show("Invalid database name or output path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var Sql = new SQL(textBox1.Text);
                    Sql.RestoreDb(openFileDialog1.FileName, openFileDialog1.SafeFileName, textBox2.Text);
                }

            }

            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show($"Are you sure you want to drop {textBox1.Text}?", "Continue?", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {
                return;
            }
            button1.Enabled = false;
            button2.Enabled = false;
            var Sql = new SQL(textBox1.Text);
            Sql.DropDb();
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var folderPath = new FolderBrowserDialog();
            DialogResult = folderPath.ShowDialog();
            textBox2.Text = folderPath.SelectedPath;
        }
    }
}