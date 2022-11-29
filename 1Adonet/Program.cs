using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Adonet
{
    internal class Program
    {
       static SqlConnection conn = new SqlConnection("Data Source = DESKTOP - BQKD1AR; Initial Catalog = adonet; Persist Security Info = True; User ID = sa Password=1");

        static void Main(string[] args)
        {
            
            kayitlariGetir();

            
        }

        public static void kayitEkle(string kullaniciAdi, string sifre,string yetki)
        {
            conn.Open();
            SqlCommand cmd =new SqlCommand("insert into loginTable")

            conn.Close();


        }

        public static void kayitlariGetir()
        {
            /*
        Windows Authentication
        SqlConnection WindowsConnectionManuel = new SqlConnection("data source =DESKTOP-BQKD1AR;initial catalog = sqldersleri; integrated security=true ");

        SqlConnection WindowsConnectionAuto = new SqlConnection("Data Source=DESKTOP-BQKD1AR;Initial Catalog=sqldersleri;Integrated Security=True");
        //integrated security demek veritabanına windows autonticationa bağlanıyorum demektir
        //data source içinde ters slah/ varsa tırnak öncesine @ işareti konur

        //Sql Server Authentication
        SqlConnection SqlServerAuthentication = new SqlConnection("data source=DESKTOP-BQKD1AR; initial catalog =[sqldersleri];user id=sa;password=1 ");

        SqlConnection SqlServerConnectionAuto = new SqlConnection(" Data Source=DESKTOP-BQKD1AR;Initial Catalog=sqldersleri;Persist Security Info=True;User ID=sa password=1");


        */

            //loginTable tablosundaki kayıtları çekip burada console'a yazdırmaya çalışalım

            List<Musteri> musteriList = new List<Musteri>();


          
            conn.Open();

            // sqlcommand ile sqlden data çekmeye yarar ve bir komut görevi görür
            //sqlDataReader

            SqlCommand cmd = new SqlCommand("select*from loginTable", conn);

            //hazırlanan komutu çalıştırabilmek için reader methodu gerekmektedir.

            SqlDataReader dr = cmd.ExecuteReader();
            //sqlDataReader ile dr içinde kayıtları tutuyoruz.

            while (dr.Read())
            {
                Musteri musteri = new Musteri();
                musteri.id = int.Parse(dr["id"].ToString());
                musteri.kullaniciAdi = dr["kullaniciAdi"].ToString();
                musteri.sifre = dr["sifre"].ToString();
                musteri.yetki = dr["yetki"].ToString();

                musteriList.Add(musteri);

            }

            conn.Close();


            foreach (Musteri musteri in musteriList)
            {
                Console.WriteLine("id: " + musteri.id + " Kullanıcı Adı : " + musteri.kullaniciAdi + " Şifre : " + musteri.sifre + " Yetki :" + musteri.yetki);


            }

            Console.ReadLine();

        }


    }
}
