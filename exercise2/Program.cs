using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().CreateTable();
            new Program().Insertdata();
        }

        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-5LL6UN5\\REZKAMULYA;database=Exercise_2;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand("Create Table Kue (id_kue char(5) primary key, nama_kue varchar(20), harga money, stok char(10))"
                    + "create table Pembeli(id_pembeli char(5) primary key, id_kue char(5) foreign key references Kue(id_Kue), Nama_pembeli varchar(50), alamat varchar(30),No_Telp char(12))"
                    + "create table Karyawan (id_karyawan char(5) primary key,nama_karyawan varchar(50), email_karyawan varchar(20), no_telp char(12), alamat varchar(30))"
                    + "create table Transaksi (id_transaksi char(5) primary key, id_pembeli char(5) foreign key references Pembeli(id_pembeli), id_karyawan char(5) foreign key references Karyawan(id_karyawan),nama_kue varchar(20),jumlah_kue char(5), harga money, total_harga money, jenis_pembayaran varchar(20), tgl_transaksi date, jam_transaksi time)", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Tabel sukses dibuat!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, sepertinya ada yang salah. " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }

        public void Insertdata()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-5LL6UN5\\REZKAMULYA;database=Exercise_2;Integrated Security = TRUE");
                con.Open();
                SqlCommand cm = new SqlCommand("insert into Kue (id_kue, nama_kue, harga, stok ) values ('KUE01', 'Bolu', '20000', '50')" +
                    "insert into Kue (id_kue, nama_kue, harga, stok ) values ('KUE02', 'Brownis', '30000', '40')" +
                    "insert into Kue (id_kue, nama_kue, harga, stok ) values ('KUE03', 'Kue Tat', '25000', '50')" +
                    "insert into Kue (id_kue, nama_kue, harga, stok ) values ('KUE04', 'Bakpia', '20000', '20')" +
                    "insert into Kue (id_kue, nama_kue, harga, stok ) values ('KUE05', 'Bika Ambon', '20000', '20')" +
                    "insert into Pembeli (id_pembeli, id_kue, Nama_pembeli, alamat,No_Telp)values ('PE001','K01','Nabila','Purworejo','082199789076')" +
                    "insert into Pembeli (id_pembeli, id_kue, Nama_pembeli, alamat,No_Telp)values ('PE002','K05','Raffi','Kulon Progo','082199789999')" +
                    "insert into Pembeli (id_pembeli, id_kue, Nama_pembeli, alamat,No_Telp)values ('PE003','K02','Raden','Bengkulu','082190349076')" +
                    "insert into Pembeli (id_pembeli, id_kue, Nama_pembeli, alamat,No_Telp)values ('PE004','K01','Aulia','Jakarta','082198162346')" +
                    "insert into Pembeli (id_pembeli, id_kue, Nama_pembeli, alamat,No_Telp)values ('PE005','K01','Rezka','Bengkulu','082164738292')" +
                    "insert into Karyawan (id_karyawan,nama_karyawan, email_karyawan, no_telp, alamat) values ('KR001','Udin','udin@gmail.com','082376472834','Bandung')" +
                    "insert into Karyawan (id_karyawan,nama_karyawan, email_karyawan, no_telp, alamat) values ('KR002','Andi','andi@gmail.com','082376472833','Jakarta')" +
                    "insert into Karyawan (id_karyawan,nama_karyawan, email_karyawan, no_telp, alamat) values ('KR003','Siti','siti@gmail.com','082376472999','Yogyakarta')" +
                    "insert into Karyawan (id_karyawan,nama_karyawan, email_karyawan, no_telp, alamat) values ('KR004','Fatimah','fatim@gmail.com','082376666834','Palembang')" +
                    "insert into Karyawan (id_karyawan,nama_karyawan, email_karyawan, no_telp, alamat) values ('KR005','Jamal','jamal@gmail.com','082489572834','Jambi')" +
                    "insert into Transaksi (id_transaksi, id_pembeli, id_karyawan,nama_kue,jumlah_kue, harga, total_harga, jenis_pembayaran, tgl_transaksi, jam_transaksi)" +
                    "values ('TR001','PE001','KR001','Bolu','5','20000','100000','Cash','3/26/2022','11:57')" +
                    "insert into Transaksi(id_transaksi, id_pembeli, id_karyawan, nama_kue, jumlah_kue, harga, total_harga, jenis_pembayaran, tgl_transaksi, jam_transaksi)" +
                    "values ('TR002','PE002','KR001','Brownis','2','30000','60000','Cash','3/20/2022','10:57')" +
                    "insert into Transaksi (id_transaksi, id_pembeli, id_karyawan,nama_kue,jumlah_kue, harga, total_harga, jenis_pembayaran, tgl_transaksi, jam_transaksi)" +
                    "values ('TR003','PE003','KR003','Kue Tat','1','25000','25000','Cash','3/1/2022','09:50')" +
                    "insert into Transaksi(id_transaksi, id_pembeli, id_karyawan, nama_kue, jumlah_kue, harga, total_harga, jenis_pembayaran, tgl_transaksi, jam_transaksi)" +
                    "values ('TR004','PE004','KR004','Bakpia','2','20000','40000','Cash','3/3/2022','11:57')" +
                    "insert into Transaksi(id_transaksi, id_pembeli, id_karyawan, nama_kue, jumlah_kue, harga, total_harga, jenis_pembayaran, tgl_transaksi, jam_transaksi)" +
                    "values ('TR005','PE005','KR005','Bika Ambon','3','20000','60000','Cash','3/26/2022','11:57')", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Sukses Menambahkan Data!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Gagal Menambahkan Data " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }


        }
    }
}
