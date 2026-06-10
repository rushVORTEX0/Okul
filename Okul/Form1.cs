using MySql.Data.MySqlClient;





namespace Okul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        VeriTabaniIslemleri vtislem = new VeriTabaniIslemleri();
        MySqlConnection baglanti;
        MySqlCommand komut;
        MySqlDataReader oku;
        string komutcumlesi;


        private void button1_Click(object sender, EventArgs e)
        {
            string secilen = comboBox1.SelectedItem.ToString();
            string bolum = secilen.Split("-")[0];
            baglanti = vtislem.bagla();
            if (baglanti.State == System.Data.ConnectionState.Closed)
            {
                baglanti.Open();
            }
            komutcumlesi = "INSERT INTO ogrenci (adi, soyadi, dyeri, bid) Values (@adi, @soyadi, @dyeri, @bid)";
            komut = new MySqlCommand(komutcumlesi, baglanti);


            komut.Parameters.AddWithValue("@adi", textBox1.Text);
            komut.Parameters.AddWithValue("@soyadi", textBox2.Text);
            komut.Parameters.AddWithValue("@dyeri", textBox3.Text);
            komut.Parameters.AddWithValue("@bid", bolum);


            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bolumadi_getir();
        }
        public void bolumadi_getir()
        {
            baglanti = vtislem.bagla();
            if (baglanti.State == System.Data.ConnectionState.Closed)
            {
                baglanti.Open();
            }
            komutcumlesi = "SELECT bid, badi FROM bolum";
            komut = new MySqlCommand(komutcumlesi, baglanti);
            oku = komut.ExecuteReader();
            comboBox1.Items.Clear();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["bid"] + "-" + oku["badi"].ToString());
            }
            oku.Close();
        }

    }
}
