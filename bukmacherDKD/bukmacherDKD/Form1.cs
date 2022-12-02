using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace bukmacherDKD
{
    public partial class mainForm : Form
    {
        public string label;
        public string saldoAccount;
        public double saldo;
        public bool zgodaNaSending = false;
        public string konto;
        int zlehaslo = 0;

        public SqlConnection sqlConnectionDB1 = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\kacper\Downloads\bukmacherDKDv1v2v1 (1)\bukmacherDKDv1v2v1\bukmacherDKDv1v2\bukmacherDKDv1\bukmacherDKD1\bukmacherDKD\bukmacherDKD\Database1.mdf"";Integrated Security=True");
        public SqlConnection sqlConnectionDB2 = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\kacper\Downloads\bukmacherDKDv1v2v1 (1)\bukmacherDKDv1v2v1\bukmacherDKDv1v2\bukmacherDKDv1\bukmacherDKD1\bukmacherDKD\bukmacherDKD\Database2.mdf"";Integrated Security=True");

        public void mecze(object sender)
        {
            var dyscyplina = sender as Label;
            // Linia 1
            int[] rand = new int[20];
            for (int i = 0; i < rand.Length; i++)
            {
                rand[i] = rnd.Next(1, 18);
                if (i >= 1)
                {
                    if (rand[i] == rand[i - 1])
                    {
                        rand[i] = rnd.Next(1, 18);
                    }
                }
            }

            double bilans1;
            double bilans2;

            //Zakład 1
            label75.Text = GetNazwa(dyscyplina.Name, rand[0]);
            label79.Text = GetNazwa(dyscyplina.Name, rand[1]);

            bilans1 = GetInfo(dyscyplina.Name, "wygrane", rand[0]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[0]) - GetInfo(dyscyplina.Name, "przegrane", rand[0]);
            bilans2 = GetInfo(dyscyplina.Name, "wygrane", rand[1]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[1]) - GetInfo(dyscyplina.Name, "przegrane", rand[1]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2/bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label76.Text = bilans2.ToString("0.00");
            label78.Text = bilans1.ToString("0.00");

            //Zakład 2
            label88.Text = GetNazwa(dyscyplina.Name, rand[2]);
            label84.Text = GetNazwa(dyscyplina.Name, rand[3]);

            bilans1 = GetInfo(dyscyplina.Name, "wygrane", rand[2]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[2]) - GetInfo(dyscyplina.Name, "przegrane", rand[2]);
            bilans2 = GetInfo(dyscyplina.Name, "wygrane", rand[3]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[3]) - GetInfo(dyscyplina.Name, "przegrane", rand[3]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label87.Text = bilans2.ToString("0.00");
            label85.Text = bilans1.ToString("0.00");

            //Zakład 3
            label96.Text = GetNazwa(dyscyplina.Name, rand[4]);
            label92.Text = GetNazwa(dyscyplina.Name, rand[5]);

            bilans1 = GetInfo(dyscyplina.Name, "wygrane", rand[4]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[4]) - GetInfo(dyscyplina.Name, "przegrane", rand[4]);
            bilans2 = GetInfo(dyscyplina.Name, "wygrane", rand[5]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[5]) - GetInfo(dyscyplina.Name, "przegrane", rand[5]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label95.Text = bilans2.ToString("0.00");
            label93.Text = bilans1.ToString("0.00");

            //Zakład 4
            label104.Text = GetNazwa(dyscyplina.Name, rand[6]);
            label100.Text = GetNazwa(dyscyplina.Name, rand[7]);

            bilans1 = GetInfo(dyscyplina.Name, "wygrane", rand[6]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[6]) - GetInfo(dyscyplina.Name, "przegrane", rand[6]);
            bilans2 = GetInfo(dyscyplina.Name, "wygrane", rand[7]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[7]) - GetInfo(dyscyplina.Name, "przegrane", rand[7]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label103.Text = bilans2.ToString("0.00");
            label101.Text = bilans1.ToString("0.00");

            //Zakład 5
            label112.Text = GetNazwa(dyscyplina.Name, rand[8]);
            label108.Text = GetNazwa(dyscyplina.Name, rand[9]);

            bilans1 = GetInfo(dyscyplina.Name, "wygrane", rand[8]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[8]) - GetInfo(dyscyplina.Name, "przegrane", rand[8]);
            bilans2 = GetInfo(dyscyplina.Name, "wygrane", rand[9]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[9]) - GetInfo(dyscyplina.Name, "przegrane", rand[9]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label109.Text = bilans2.ToString("0.00");
            label111.Text = bilans1.ToString("0.00");

            //Zakład 6
            label120.Text = GetNazwa(dyscyplina.Name, rand[10]);
            label116.Text = GetNazwa(dyscyplina.Name, rand[11]);

            bilans1 = GetInfo(dyscyplina.Name, "wygrane", rand[10]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[10]) - GetInfo(dyscyplina.Name, "przegrane", rand[10]);
            bilans2 = GetInfo(dyscyplina.Name, "wygrane", rand[11]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[11]) - GetInfo(dyscyplina.Name, "przegrane", rand[11]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label117.Text = bilans1.ToString("0.00");
            label119.Text = bilans2.ToString("0.00");

            //Zakład 7
            label128.Text = GetNazwa(dyscyplina.Name, rand[12]);
            label124.Text = GetNazwa(dyscyplina.Name, rand[13]);

            bilans1 = GetInfo(dyscyplina.Name, "wygrane", rand[12]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[12]) - GetInfo(dyscyplina.Name, "przegrane", rand[12]);
            bilans2 = GetInfo(dyscyplina.Name, "wygrane", rand[13]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[13]) - GetInfo(dyscyplina.Name, "przegrane", rand[13]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label127.Text = bilans2.ToString("0.00");
            label125.Text = bilans1.ToString("0.00");

            //Zakład 8
            label136.Text = GetNazwa(dyscyplina.Name, rand[14]);
            label132.Text = GetNazwa(dyscyplina.Name, rand[15]);

            bilans1 = GetInfo(dyscyplina.Name, "wygrane", rand[14]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[14]) - GetInfo(dyscyplina.Name, "przegrane", rand[14]);
            bilans2 = GetInfo(dyscyplina.Name, "wygrane", rand[15]) * 2 + GetInfo(dyscyplina.Name, "remis", rand[15]) - GetInfo(dyscyplina.Name, "przegrane", rand[15]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label135.Text = bilans2.ToString("0.00");
            label133.Text = bilans1.ToString("0.00");


            int randgodz = rnd.Next(0, 24);

            label74.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label89.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label97.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label105.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label113.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label121.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label129.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label137.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
        }
        public mainForm()
        {
            InitializeComponent();
        }

        Random rnd = new Random();


        public string GetNazwa(string nazwa, int id)
        {
            string sportdb;
            System.Data.SqlClient.SqlCommand sportcmd = new System.Data.SqlClient.SqlCommand();
            sportcmd.CommandText = "SELECT nazwa FROM " + nazwa + " WHERE id LIKE " + id + "";
            sportcmd.Connection = sqlConnectionDB1;
            sqlConnectionDB1.Open();
            sportdb = (string)sportcmd.ExecuteScalar();
            sqlConnectionDB1.Close();
            return sportdb;
        }


        public string GetSaldo(string konto)
        {
            string konto1;
            System.Data.SqlClient.SqlCommand qst = new System.Data.SqlClient.SqlCommand();
            qst.CommandText = "SELECT zetony FROM [user] WHERE login = '" + Convert.ToString(konto).Trim() + "'";
            qst.Connection = sqlConnectionDB2;
            sqlConnectionDB2.Open();
            konto1 = Convert.ToString(qst.ExecuteScalar()).Trim();
            sqlConnectionDB2.Close();
            return konto1;
        }

        public float GetInfo1(string waluta)
        {
            float kurs;
            System.Data.SqlClient.SqlCommand sportcmd = new System.Data.SqlClient.SqlCommand();
            sportcmd.CommandText = "SELECT Kurs FROM kursyWalut WHERE Waluta = '" + waluta + "'";
            sportcmd.Connection = sqlConnectionDB1;
            sqlConnectionDB1.Open();
            kurs = Convert.ToSingle(sportcmd.ExecuteScalar());
            sqlConnectionDB1.Close();
            return kurs;
        }

        public string getWalutaName(string text)
        {
            string waluta = text.Split('-')[0];
            return waluta;
        }

        public int GetInfo(string nazwa, string rekord, int id)
        {
            int sportdb;
            System.Data.SqlClient.SqlCommand sportcmd = new System.Data.SqlClient.SqlCommand();
            sportcmd.CommandText = "SELECT " + rekord + " FROM " + nazwa + " WHERE id LIKE " + id + "";
            sportcmd.Connection = sqlConnectionDB1;
            sqlConnectionDB1.Open();
            sportdb = (int)sportcmd.ExecuteScalar();
            sqlConnectionDB1.Close();
            return sportdb;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sqlConnectionDB2.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "UPDATE konto SET konto=' ' WHERE Id=1";
            adapter.InsertCommand = new SqlCommand(sql, sqlConnectionDB2);
            adapter.InsertCommand.ExecuteNonQuery();
            sqlConnectionDB2.Close();

            this.Close();


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
       


        private void label139_Click(object sender, EventArgs e)
        {

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            accountLabel.Text = "Nie zalogowano";
            label30.Text = "Nie zalogowano";
            saldo = Convert.ToDouble(saldoAccount);

            var dyscyplina = "pilka_nozna";
            // Linia 1
            int[] rand = new int[20];
            for (int i = 0; i < rand.Length; i++)
            {
                rand[i] = rnd.Next(1, 18);
                if (i >= 1)
                {
                    if (rand[i] == rand[i - 1])
                    {
                        rand[i] = rnd.Next(1, 18);
                    }
                }
            }

            double bilans1;
            double bilans2;

            //Zakład 1
            label75.Text = GetNazwa(dyscyplina, rand[0]);
            label79.Text = GetNazwa(dyscyplina, rand[1]);

            bilans1 = GetInfo(dyscyplina, "wygrane", rand[0]) * 2 + GetInfo(dyscyplina, "remis", rand[0]) - GetInfo(dyscyplina, "przegrane", rand[0]);
            bilans2 = GetInfo(dyscyplina, "wygrane", rand[1]) * 2 + GetInfo(dyscyplina, "remis", rand[1]) - GetInfo(dyscyplina, "przegrane", rand[1]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label76.Text = bilans2.ToString("0.00");
            label78.Text = bilans1.ToString("0.00");

            //Zakład 2
            label88.Text = GetNazwa(dyscyplina, rand[2]);
            label84.Text = GetNazwa(dyscyplina, rand[3]);

            bilans1 = GetInfo(dyscyplina, "wygrane", rand[2]) * 2 + GetInfo(dyscyplina, "remis", rand[2]) - GetInfo(dyscyplina, "przegrane", rand[2]);
            bilans2 = GetInfo(dyscyplina, "wygrane", rand[3]) * 2 + GetInfo(dyscyplina, "remis", rand[3]) - GetInfo(dyscyplina, "przegrane", rand[3]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label87.Text = bilans2.ToString("0.00");
            label85.Text = bilans1.ToString("0.00");

            //Zakład 3
            label96.Text = GetNazwa(dyscyplina, rand[4]);
            label92.Text = GetNazwa(dyscyplina, rand[5]);

            bilans1 = GetInfo(dyscyplina, "wygrane", rand[4]) * 2 + GetInfo(dyscyplina, "remis", rand[4]) - GetInfo(dyscyplina, "przegrane", rand[4]);
            bilans2 = GetInfo(dyscyplina, "wygrane", rand[5]) * 2 + GetInfo(dyscyplina, "remis", rand[5]) - GetInfo(dyscyplina, "przegrane", rand[5]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label95.Text = bilans2.ToString("0.00");
            label93.Text = bilans1.ToString("0.00");

            //Zakład 4
            label104.Text = GetNazwa(dyscyplina, rand[6]);
            label100.Text = GetNazwa(dyscyplina, rand[7]);

            bilans1 = GetInfo(dyscyplina, "wygrane", rand[6]) * 2 + GetInfo(dyscyplina, "remis", rand[6]) - GetInfo(dyscyplina, "przegrane", rand[6]);
            bilans2 = GetInfo(dyscyplina, "wygrane", rand[7]) * 2 + GetInfo(dyscyplina, "remis", rand[7]) - GetInfo(dyscyplina, "przegrane", rand[7]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label103.Text = bilans2.ToString("0.00");
            label101.Text = bilans1.ToString("0.00");

            //Zakład 5
            label112.Text = GetNazwa(dyscyplina, rand[8]);
            label108.Text = GetNazwa(dyscyplina, rand[9]);

            bilans1 = GetInfo(dyscyplina, "wygrane", rand[8]) * 2 + GetInfo(dyscyplina, "remis", rand[8]) - GetInfo(dyscyplina, "przegrane", rand[8]);
            bilans2 = GetInfo(dyscyplina, "wygrane", rand[9]) * 2 + GetInfo(dyscyplina, "remis", rand[9]) - GetInfo(dyscyplina, "przegrane", rand[9]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label109.Text = bilans2.ToString("0.00");
            label111.Text = bilans1.ToString("0.00");

            //Zakład 6
            label120.Text = GetNazwa(dyscyplina, rand[10]);
            label116.Text = GetNazwa(dyscyplina, rand[11]);

            bilans1 = GetInfo(dyscyplina, "wygrane", rand[10]) * 2 + GetInfo(dyscyplina, "remis", rand[10]) - GetInfo(dyscyplina, "przegrane", rand[10]);
            bilans2 = GetInfo(dyscyplina, "wygrane", rand[11]) * 2 + GetInfo(dyscyplina, "remis", rand[11]) - GetInfo(dyscyplina, "przegrane", rand[11]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label117.Text = bilans1.ToString("0.00");
            label119.Text = bilans2.ToString("0.00");

            //Zakład 7
            label128.Text = GetNazwa(dyscyplina, rand[12]);
            label124.Text = GetNazwa(dyscyplina, rand[13]);

            bilans1 = GetInfo(dyscyplina, "wygrane", rand[12]) * 2 + GetInfo(dyscyplina, "remis", rand[12]) - GetInfo(dyscyplina, "przegrane", rand[12]);
            bilans2 = GetInfo(dyscyplina, "wygrane", rand[13]) * 2 + GetInfo(dyscyplina, "remis", rand[13]) - GetInfo(dyscyplina, "przegrane", rand[13]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label127.Text = bilans2.ToString("0.00");
            label125.Text = bilans1.ToString("0.00");

            //Zakład 8
            label136.Text = GetNazwa(dyscyplina, rand[14]);
            label132.Text = GetNazwa(dyscyplina, rand[15]);

            bilans1 = GetInfo(dyscyplina, "wygrane", rand[14]) * 2 + GetInfo(dyscyplina, "remis", rand[14]) - GetInfo(dyscyplina, "przegrane", rand[14]);
            bilans2 = GetInfo(dyscyplina, "wygrane", rand[15]) * 2 + GetInfo(dyscyplina, "remis", rand[15]) - GetInfo(dyscyplina, "przegrane", rand[15]);

            if (bilans1 <= 1)
            {
                bilans1 = 1;
            }
            if (bilans2 <= 1)
            {
                bilans2 = 1;
            }
            if (bilans1 == bilans2)
            {
                bilans1 = 1.5;
                bilans2 = 1.5;
            }

            if (bilans1 < bilans2) { bilans1 = bilans2 / bilans1; bilans2 = 1.2; }
            else if (bilans2 < bilans1) { bilans2 = bilans1 / bilans2; bilans1 = 1.2; ; };

            label135.Text = bilans2.ToString("0.00");
            label133.Text = bilans1.ToString("0.00");


            int randgodz = rnd.Next(0, 24);

            label74.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label89.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label97.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label105.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label113.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label121.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label129.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label137.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

            string kontodb;
            System.Data.SqlClient.SqlCommand sportcmd = new System.Data.SqlClient.SqlCommand();
            sportcmd.CommandText = "SELECT konto FROM konto WHERE Id = 1";
            sportcmd.Connection = sqlConnectionDB2;
            sqlConnectionDB2.Open();
            kontodb = Convert.ToString(sportcmd.ExecuteScalar()).Trim();

            konto = kontodb;

            saldoAccount = Convert.ToString(sportcmd.CommandText = "SELECT zetony FROM user WHERE login = '"+kontodb+"'");
            sqlConnectionDB2.Close();

            accountLabel.Text = kontodb;



            // Linia 1
            int rand1;
            int rand2;
            rand1 = rnd.Next(1, 18);

            do
            {
                rand2 = rnd.Next(1, 18);
            } while (rand1 == rand2);

            label75.Text = GetNazwa("pilka_nozna", rand1);
            label79.Text = GetNazwa("pilka_nozna", rand2);

            int[] teamkurs1 = { GetInfo("pilka_nozna", "wygrane", rand1), GetInfo("pilka_nozna", "przegrane", rand1), GetInfo("pilka_nozna", "remis", rand1) };
            int[] teamkurs2 = { GetInfo("pilka_nozna", "wygrane", rand2), GetInfo("pilka_nozna", "przegrane", rand2), GetInfo("pilka_nozna", "remis", rand2) };

            int teampunkt1 = (teamkurs1[0] * 2) - teamkurs1[1];
            int teampunkt2 = (teamkurs2[0] * 2) - teamkurs2[1];

            int randgodz = rnd.Next(0, 24);

            label74.Text = DateTime.Now.ToString("dd/MM/yyyy " + randgodz + ":00").ToString();
            label76.Text = teampunkt1.ToString();
            label78.Text = teampunkt2.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            mecze(sender);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            mecze(sender);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            mecze(sender);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            mecze(sender);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            mecze(sender);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            mecze(sender);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            mecze(sender);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            mecze(sender);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            mecze(sender);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            mecze(sender);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            mecze(sender);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox2.Text == "0")
            {
                label31.Text = "Wprowadź kwotę";
                textBox2.Text = "0";
            }

            Random random = new Random();
            double por = Convert.ToDouble(saldoAccount);
            double sz1 = Convert.ToDouble(label78.Text) * Convert.ToDouble(100);
            double sz2 = Convert.ToDouble(label76.Text) * Convert.ToDouble(100);
            double wsz = (sz1 + sz2);
            double dal = Convert.ToDouble(textBox2.Text);
            double krs = 0; 
            double asek = random.NextDouble()*(wsz-1);
            int win = 0;

            if (radioButton1.Checked == true)
            {
                win = 1;
                krs = sz2 / 100;
            } else if (radioButton2.Checked == true)
            {
                win = 2;
                krs = sz1 / 100;
            } else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                label31.Text = "Zaznacz drużynę";
            }

            if (asek >= sz1 && win == 1)
            {
                label30.Text = (por-dal).ToString();
            } 
            else if (asek >= sz1 && win == 2)
             {
                label30.Text = (por + (krs*dal)-dal).ToString();
            }
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox3.Text == "0")
            {
                label31.Text = "Wprowadź kwotę";
                textBox3.Text = "0";
            }

            Random random = new Random();
            double por = Convert.ToDouble(saldoAccount);
            double sz1 = Convert.ToDouble(label85.Text) * Convert.ToDouble(100);
            double sz2 = Convert.ToDouble(label87.Text) * Convert.ToDouble(100);
            double wsz = (sz1 + sz2);
            double dal = Convert.ToDouble(textBox3.Text);
            double krs = 0;
            double asek = random.NextDouble() * (wsz - 1);
            int win = 0;

            if (radioButton3.Checked == true)
            {
                win = 1;
                krs = sz2 / 100;
            }
            else if (radioButton4.Checked == true)
            {
                win = 2;
                krs = sz1 / 100;
            }
            else if (radioButton3.Checked == false && radioButton4.Checked == false)
            {
                label31.Text = "Zaznacz drużynę";
            }

            if (asek >= sz1 && win == 1)
            {
                label30.Text = (por - dal).ToString();
            }
            else if (asek >= sz1 && win == 2)
            {
                label30.Text = (por + (krs * dal)-dal).ToString();
            }
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox4.Text == "0")
            {
                label31.Text = "Wprowadź kwotę";
                textBox4.Text = "0";
            }

            Random random = new Random();
            double por = Convert.ToDouble(saldoAccount);
            double sz1 = Convert.ToDouble(label93.Text) * Convert.ToDouble(100);
            double sz2 = Convert.ToDouble(label95.Text) * Convert.ToDouble(100);
            double wsz = (sz1 + sz2);
            double dal = Convert.ToDouble(textBox4.Text);
            double krs = 0;
            double asek = random.NextDouble() * (wsz - 1);
            int win = 0;

            if (radioButton5.Checked == true)
            {
                win = 1;
                krs = sz2 / 100;
            }
            else if (radioButton6.Checked == true)
            {
                win = 2;
                krs = sz1 / 100;
            }
            else if (radioButton5.Checked == false && radioButton6.Checked == false)
            {
                label31.Text = "Zaznacz drużynę";
            }

            if (asek >= sz1 && win == 1)
            {
                label30.Text = (por - dal).ToString();
            }
            else if (asek >= sz1 && win == 2)
            {
                label30.Text = (por + (krs * dal) - dal).ToString();
            }
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox5.Text == "0")
            {
                label31.Text = "Wprowadź kwotę";
                textBox5.Text = "0";
            }

            Random random = new Random();
            double por = Convert.ToDouble(saldoAccount);
            double sz1 = Convert.ToDouble(label101.Text) * Convert.ToDouble(100);
            double sz2 = Convert.ToDouble(label103.Text) * Convert.ToDouble(100);
            double wsz = (sz1 + sz2);
            double dal = Convert.ToDouble(textBox5.Text);
            double krs = 0;
            double asek = random.NextDouble() * (wsz - 1);
            int win = 0;

            if (radioButton9.Checked == true)
            {
                win = 1;
                krs = sz2 / 100;
            }
            else if (radioButton7.Checked == true)
            {
                win = 2;
                krs = sz1 / 100;
            }
            else if (radioButton9.Checked == false && radioButton7.Checked == false)
            {
                label31.Text = "Zaznacz drużynę";
            }

            if (asek >= sz1 && win == 1)
            {
                label30.Text = (por - dal).ToString();
            }
            else if (asek >= sz1 && win == 2)
            {
                label30.Text = (por + (krs * dal) - dal).ToString();
            }
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox6.Text == "0")
            {
                label31.Text = "Wprowadź kwotę";
                textBox6.Text = "0";
            }

            Random random = new Random();
            double por = Convert.ToDouble(saldoAccount);
            double sz1 = Convert.ToDouble(label109.Text) * Convert.ToDouble(100);
            double sz2 = Convert.ToDouble(label111.Text) * Convert.ToDouble(100);
            double wsz = (sz1 + sz2);
            double dal = Convert.ToDouble(textBox6.Text);
            double krs = 0;
            double asek = random.NextDouble() * (wsz - 1);
            int win = 0;

            if (radioButton10.Checked == true)
            {
                win = 1;
                krs = sz2 / 100;
            }
            else if (radioButton8.Checked == true)
            {
                win = 2;
                krs = sz1 / 100;
            }
            else if (radioButton10.Checked == false && radioButton8.Checked == false)
            {
                label31.Text = "Zaznacz drużynę";
            }

            if (asek >= sz1 && win == 1)
            {
                label30.Text = (por - dal).ToString();
            }
            else if (asek >= sz1 && win == 2)
            {
                label30.Text = (por + (krs * dal) - dal).ToString();
            }
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox7.Text == "0")
            {
                label31.Text = "Wprowadź kwotę";
                textBox7.Text = "0";
            }

            Random random = new Random();
            double por = Convert.ToDouble(saldoAccount);
            double sz1 = Convert.ToDouble(label117.Text) * Convert.ToDouble(100);
            double sz2 = Convert.ToDouble(label119.Text) * Convert.ToDouble(100);
            double wsz = (sz1 + sz2);
            double dal = Convert.ToDouble(textBox7.Text);
            double krs = 0;
            double asek = random.NextDouble() * (wsz - 1);
            int win = 0;

            if (radioButton13.Checked == true)
            {
                win = 1;
                krs = sz2 / 100;
            }
            else if (radioButton11.Checked == true)
            {
                win = 2;
                krs = sz1 / 100;
            }
            else if (radioButton13.Checked == false && radioButton11.Checked == false)
            {
                label31.Text = "Zaznacz drużynę";
            }

            if (asek >= sz1 && win == 1)
            {
                label30.Text = (por - dal).ToString();
            }
            else if (asek >= sz1 && win == 2)
            {
                label30.Text = (por + (krs * dal) - dal).ToString();
            }
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox8.Text == "0")
            {
                label31.Text = "Wprowadź kwotę";
                textBox8.Text = "0";
            }

            Random random = new Random();
            double por = Convert.ToDouble(saldoAccount);
            double sz1 = Convert.ToDouble(label125.Text) * Convert.ToDouble(100);
            double sz2 = Convert.ToDouble(label127.Text) * Convert.ToDouble(100);
            double wsz = (sz1 + sz2);
            double dal = Convert.ToDouble(textBox8.Text);
            double krs = 0;
            double asek = random.NextDouble() * (wsz - 1);
            int win = 0;

            if (radioButton14.Checked == true)
            {
                win = 1;
                krs = sz2 / 100;
            }
            else if (radioButton12.Checked == true)
            {
                win = 2;
                krs = sz1 / 100;
            }
            else if (radioButton14.Checked == false && radioButton12.Checked == false)
            {
                label31.Text = "Zaznacz drużynę";
            }

            if (asek >= sz1 && win == 1)
            {
                label30.Text = (por - dal).ToString();
            }
            else if (asek >= sz1 && win == 2)
            {
                label30.Text = (por + (krs * dal) - dal).ToString();
            }
        }

        private void label11_Click_1(object sender, EventArgs e)
        {
            if (textBox9.Text == "" || textBox9.Text == "0")
            {
                label31.Text = "Wprowadź kwotę";
                textBox9.Text = "0";
            }

            Random random = new Random();
            double por = Convert.ToDouble(saldoAccount);
            double sz1 = Convert.ToDouble(label133.Text) * Convert.ToDouble(100);
            double sz2 = Convert.ToDouble(label135.Text) * Convert.ToDouble(100);
            double wsz = (sz1 + sz2);
            double dal = Convert.ToDouble(textBox9.Text);
            double krs = 0;
            double asek = random.NextDouble() * (wsz - 1);
            int win = 0;

            if (radioButton16.Checked == true)
            {
                win = 1;
                krs = sz2 / 100;
            }
            else if (radioButton15.Checked == true)
            {
                win = 2;
                krs = sz1 / 100;
            }
            else if (radioButton16.Checked == false && radioButton15.Checked == false)
            {
                label31.Text = "Zaznacz drużynę";
            }

            if (asek >= sz1 && win == 1)
            {
                label30.Text = (por - dal).ToString();
            }
            else if (asek >= sz1 && win == 2)
            {
                label30.Text = (por + (krs * dal) - dal).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            int kwota = Convert.ToInt32(textBox14.Text);
            if(kwota <= Convert.ToInt32(saldoAccount))
            {
                label14.Visible = false;
                zgodaNaSending = true;

            }
            else
            {
                label14.Visible = true;
            }
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (zgodaNaSending == true)
            {
                double kwota = Convert.ToDouble(textBox14.Text);
                double saldo = Convert.ToDouble(saldoAccount);
                label30.Text = Convert.ToString(saldo - kwota);
                label45.Visible = true;
                int amountOfCoins = Convert.ToInt32(textBox14.Text);
                string login = konto;
                int saldo1 = Convert.ToInt32(saldoAccount);
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = "UPDATE [user] SET zetony=" + (saldo1-amountOfCoins) + " WHERE login = '" + login + "'";


                try
                {
                    sqlConnectionDB2.Open();
                    adapter.InsertCommand = new SqlCommand(sql, sqlConnectionDB2);
                    adapter.InsertCommand.ExecuteNonQuery();
                    sqlConnectionDB2.Close();
                    label30.Text = Convert.ToString(saldo - amountOfCoins);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                label49.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            float amountOfCoins = Convert.ToSingle(textBox16.Text);
            string login = konto;
            int saldo = Convert.ToInt32(saldoAccount);
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "UPDATE [user] SET zetony=" + ((int)saldo + (int)amountOfCoins) + " WHERE login = '" + login + "'";
            

            try
            {
                sqlConnectionDB2.Open();
                adapter.InsertCommand = new SqlCommand(sql, sqlConnectionDB2);
                adapter.InsertCommand.ExecuteNonQuery();
                sqlConnectionDB2.Close();
                label30.Text = Convert.ToString(saldo + amountOfCoins);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            float wlas1 = Convert.ToSingle(textBox17.Text);
            float wlas2 = Convert.ToSingle(label52.Text);
            textBox16.Text = Convert.ToString(wlas1 * wlas2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string login = Convert.ToString(textBox11.Text).Trim();
            string haslo = Convert.ToString(textBox10.Text).Trim();

            string haslodb;
            System.Data.SqlClient.SqlCommand sportcmd = new System.Data.SqlClient.SqlCommand();
            sportcmd.CommandText = "SELECT haslo FROM [user] WHERE login = '" + login + "'";
            sportcmd.Connection = sqlConnectionDB2;
            sqlConnectionDB2.Open();
            haslodb = Convert.ToString(sportcmd.ExecuteScalar()).Trim();



            if (haslo.Equals(haslodb))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = "UPDATE konto SET konto='" + login + "' WHERE Id=1";
                adapter.InsertCommand = new SqlCommand(sql, sqlConnectionDB2);
                adapter.InsertCommand.ExecuteNonQuery();
                sqlConnectionDB2.Close();
                label33.Visible = true;
                konto = login;
                accountLabel.Text = konto;
                saldoAccount = GetSaldo(konto);
                label30.Text = Convert.ToString(saldoAccount);



            }
            else
            {
                konto = "Nie zalogowano";
                label32.Visible = true;
                sqlConnectionDB2.Close();
                label30.Text = konto;
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.TextLength < 8)
            {
                label41.Text = "Hasło zawiera złą ilość znaków!";
                zlehaslo = 1;
            }
            if (textBox12.TextLength >= 8)
            {
                label41.Visible = false;
                zlehaslo = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string login = textBox13.Text;
            string haslo = textBox12.Text;
            
            if (zlehaslo == 0)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = "insert into [user] (login, haslo, zetony) values('" + login + "','" + haslo + "',0)";

                try
                {
                    sqlConnectionDB2.Open();
                    adapter.InsertCommand = new SqlCommand(sql, sqlConnectionDB2);
                    adapter.InsertCommand.ExecuteNonQuery();
                    label39.Visible = true;
                    sqlConnectionDB2.Close();
                }
                catch (Exception ex)
                {
                    label38.Visible = true;
                    MessageBox.Show(ex.ToString());
                }
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string waluta = getWalutaName(comboBox1.SelectedItem.ToString());
            float kurs = GetInfo1(waluta);

            label52.Text = kurs.ToString();

            float wlas1 = Convert.ToSingle(textBox17.Text);
            float wlas2 = Convert.ToSingle(label52.Text);
            textBox16.Text = Convert.ToString(wlas1 * wlas2);
        }
    }
    }

