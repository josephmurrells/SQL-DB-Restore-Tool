using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R4DBTool
{
    public partial class Form1 : Form
    {
        List<string> DbList { get; set; }
        public Form1()
        {
            InitializeComponent();
            DbList = new List<string>();
        }

        private async void button1_Click(object sender, EventArgs e)
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
                    label3.Text = "Restoring Database...Please wait";
                    label3.Visible = true;
                    var Sql = new SQL(textBox1.Text);
                    DbList.Add(textBox1.Text);
                    await Task.Run(() =>
                    {
                        Sql.RestoreDb(openFileDialog1.FileName, openFileDialog1.SafeFileName, textBox2.Text);
                    });
                    label3.Visible = false;
                }

            }

            button1.Enabled = true;
            if (DbList.Count > 0)
            {
                button2.Enabled = true;
            }

            if (DbList.Count > 1)
            {
                button2.Text = "Drop Databases";
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show($"Are you sure you want to drop databases: {string.Join(", ", DbList.DefaultIfEmpty(textBox1.Text))}?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.No)
            {
                return;
            }
            button1.Enabled = false;
            button2.Enabled = false;
            label3.Text = "Dropping Database...Please wait";
            label3.Visible = true;
            foreach (string dbName in DbList.DefaultIfEmpty(textBox1.Text))
            {
                var Sql = new SQL(dbName);
                await Task.Run(() =>
                {
                    Sql.DropDb();
                });
            }
            label3.Visible = false;
            button1.Enabled = true;
            DbList.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderPath = new();
            DialogResult = folderPath.ShowDialog();
            textBox2.Text = folderPath.SelectedPath;
        }
    }
}