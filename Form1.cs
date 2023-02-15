using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            file.ShowDialog();

            int vysledek = 0;
            int sudy = 0;
            int lichy = 0;

            string cislo;

            StreamReader ctenar = new StreamReader(file.FileName);
            while (!ctenar.EndOfStream)
                {
                    cislo = ctenar.ReadLine();
                    int cislo_ = int.Parse(cislo!);
                    vysledek += cislo_;
                    if ((cislo_) % 2 == 0)
                    {
                        sudy++;
                    }
                    else
                    {
                        lichy++;
                    }
                }
            ctenar.Close();
            File.AppendAllText(file.FileName, "\n" + vysledek.ToString() + "\n" + sudy.ToString() + "\n" + lichy.ToString());
            Process.Start(new ProcessStartInfo(file.FileName) { UseShellExecute = true });
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}