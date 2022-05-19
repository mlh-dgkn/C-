using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;//SQl Ba�lant�
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;//Text Yazd�rma
using System.Data.SqlClient;//SQl Ba�lant�
namespace Kullanici_Giris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-4F37LKP\\;Initial Catalog=Kullanici_Giris;Integrated Security=True");//SQL Ba�lant�
        private void button1_Click(object sender, EventArgs e)
        {

            try//Butona bas�ld���nda bu blok �al���r
            {
                con.Open();//ba�lant�y� a�
                string sql_sorgu = "Select * from Giris where Kullanici_Adi = @kullanici AND Sifre =@sifre";//SQL sorgu komutu
                SqlParameter prmtr1 = new SqlParameter("kullanici", tb1_Kullanici.Text);//Sorgu komutlar�nda ki paremetreleri ba�lad�m
                SqlParameter prmtr2 = new SqlParameter("sifre", tb2_Sifre.Text);//Sorgu komutlar�nda ki paremetreleri ba�lad�m
                SqlCommand cmd = new SqlCommand(sql_sorgu, con);//Sql ba�lant� ile yapt�rd�m
                cmd.Parameters.Add(prmtr1);//paremetreleri sorgular�n yerine koydum
                cmd.Parameters.Add(prmtr2);//paremetreleri sorgular�n yerine koydum
                DataTable dt=new DataTable();//sanal datatable olu�turdum
                SqlDataAdapter da = new SqlDataAdapter(cmd);//referans verildi
                da.Fill(dt);//gelen verileri tablolara y�kleme i�lemi yapar

                if (dt.Rows.Count > 0)//Gelen veri olursa dt 1 artt��� i�in bu blok �al���r
                {
                        MessageBox.Show("Ba�ar�l� Giri�");//ekrana ��kt� verir
                }
                else//e�er veri taban�ndan girilen bilgilerle veri gelmediyse blok �al���r
                {
                    MessageBox.Show("Yanl�� Kullan�c� Ad� Veya �ifre ");//Ekrana messagebox a� ve ��kt� ver
                    StreamWriter Yaz1 = File.AppendText("C:\\Users\\USER\\Desktop\\Basarisiz_Deneme.txt");//Konuma git ve dosya var i�ine gir yoksa olu�tur
                    Yaz1.WriteLine("Basarisiz Deneme");//dosyan�n i�ine yaz
                    DateTime date = new DateTime();//referans verildi
                    Yaz1.WriteLine(date);//dosyaya date yaz
                    Yaz1.WriteLine("");//Bo�luk B�rak
                    Yaz1.Close();//Dosyadan Kapat
                }
                con.Close();//Ba�lant�y� Kapat
            }
            catch (Exception hata)//TRY blok hata al�rsa bu blok �al���r
            {
                MessageBox.Show("Beklenmedik Bir Hata Tekrar Deneyiniz");//messagebox a� ve ekrana ��kt� ver
                StreamWriter Yaz1 = File.AppendText("C:\\Users\\USER\\Desktop\\Hatalar.txt");//dosya konumuna git dosya varsa gir yoksa olu�tur
                Yaz1.WriteLine(hata.Message);//hatay� log ile gir
                DateTime date = new DateTime();//referans verildi
                Yaz1.WriteLine(date);//tarihi yazd�r
                Yaz1.WriteLine("");//bo�luk b�rak
                Yaz1.Close ();//Dosyay� kapat
            }
    }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
        }
    }
}