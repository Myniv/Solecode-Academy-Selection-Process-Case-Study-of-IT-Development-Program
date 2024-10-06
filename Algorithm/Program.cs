using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Mendapatkan Tanggal Peminjaman
            Console.WriteLine("---Tanggal Peminjaman---");
            Console.Write("Masukkan Tahun Peminjaman :");
            int tahunPinjam = int.Parse(Console.ReadLine());
            Console.Write("Masukkan Bulan Peminjaman dengan angka :");
            int bulanPinjam = int.Parse(Console.ReadLine());
            bool bulanPinjamTidakMelebihi = false;
            while (bulanPinjamTidakMelebihi == false)
            {
                if (bulanPinjam > 12 || bulanPinjam < 1)
                {
                    Console.WriteLine("Input Salah! Jumlah bulan hanya dari 1 - 12!");
                    Console.Write("Masukkan kembali Bulan Peminjaman dengan angka : ");
                    bulanPinjam = int.Parse(Console.ReadLine());
                }
                else
                {
                    bulanPinjamTidakMelebihi = true;
                }
            }
            Console.Write("Masukkan Tanggal Hari Peminjaman dengan angka:");
            int hariPinjam = int.Parse(Console.ReadLine());
            int totalHariDiBulanPeminjaman = DateTime.DaysInMonth(tahunPinjam, bulanPinjam);
            bool hariPinjamTidakMelebihi = false;
            while (hariPinjamTidakMelebihi == false)
            {
                if (hariPinjam < 0 || hariPinjam > totalHariDiBulanPeminjaman)
                {
                    Console.WriteLine("Input Salah! Jumlah hari pada tahun " + tahunPinjam + " dan bulan " + bulanPinjam + " adalah 1 - " + totalHariDiBulanPeminjaman);
                    Console.Write("Masukkan kembali Tanggal Hari Peminjaman dengan angka: ");
                    hariPinjam = int.Parse(Console.ReadLine());
                }
                else
                {
                    hariPinjamTidakMelebihi = true;
                }
            }
            DateOnly tanggalPinjam = new DateOnly(tahunPinjam, bulanPinjam, hariPinjam);


            //Mendapatkan Tanggal Pengembalian
            Console.WriteLine("---Tanggal Pengembalian---");
            Console.Write("Masukkan Tahun Pengembalian :");
            int tahunPengembalian = int.Parse(Console.ReadLine());
            bool tahunPengembalianTidakMelebihi = false;
            while (tahunPengembalianTidakMelebihi == false)
            {
                if (tahunPengembalian < tanggalPinjam.Year)
                {
                    Console.WriteLine("Input Salah! Tahun Pengembalian tidak boleh kurang dari tahun pinjam (" + tanggalPinjam.Year + ")!");
                    Console.Write("Masukkan Kembali Tahun Pengembalian dengan angka : ");
                    tahunPengembalian = int.Parse(Console.ReadLine());
                }
                else
                {
                    tahunPengembalianTidakMelebihi = true;
                }
            }
            Console.Write("Masukkan Bulan Pengembalian :");
            int bulanPengembalian = int.Parse(Console.ReadLine());
            bool bulanPengembalianTidakMelebihi = false;
            while (bulanPengembalianTidakMelebihi == false)
            {
                if (tahunPengembalian == tanggalPinjam.Year)
                {
                    if (bulanPengembalian < tanggalPinjam.Month || bulanPengembalian > 12)
                    {
                        Console.WriteLine("Input Salah! Bulan Pengembalian tidak boleh kurang dari bulan pinjam (" + tanggalPinjam.Month + ") Pada Tahun Yang Sama dan Tidak Boleh Lebih Dari 12!");
                        Console.Write("Masukkan Kembali Bulan Peminjaman dengan angka : ");
                        bulanPengembalian = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        bulanPengembalianTidakMelebihi = true;

                    }
                }
                else if (tahunPengembalian != tanggalPinjam.Year)
                {
                    if (bulanPengembalian > 12 || bulanPengembalian < 1)
                    {
                        Console.WriteLine("Input Salah! Jumlah bulan hanya dari 1 - 12!");
                        Console.Write("Masukkan kembali Bulan Pengembalian dengan angka : ");
                        bulanPengembalian = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        bulanPengembalianTidakMelebihi = true;

                    }
                }
            }
            Console.Write("Masukkan Tanggal Hari Pengembalian :");
            int hariPengembalian = int.Parse(Console.ReadLine());
            bool hariPengembalianTidakMelebihi = false;
            int totalHariDiBulanPengembalian = DateTime.DaysInMonth(tahunPengembalian, bulanPengembalian);
            while (hariPengembalianTidakMelebihi == false)
            {
                if (bulanPengembalian == tanggalPinjam.Month)
                {
                    if (hariPengembalian < tanggalPinjam.Day || hariPengembalian > totalHariDiBulanPengembalian)
                    {
                        Console.WriteLine("Input Salah! Hari Pengembalian tidak boleh kurang dari hari pinjam (" + tanggalPinjam.Day + ") Pada bulan yang sama dan tidak boleh lebih dari" + totalHariDiBulanPengembalian + "!");
                        Console.Write("Masukkan Kembali hari Pegembalian dengan angka : ");
                        hariPengembalian = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        hariPengembalianTidakMelebihi = true;

                    }
                }
                else if (bulanPengembalian != tanggalPinjam.Month)
                {
                    if (hariPengembalian > totalHariDiBulanPengembalian || hariPengembalian < 1)
                    {
                        Console.WriteLine("Input Salah! Jumlah hari pada tahun " + tahunPengembalian + " dan bulan " + bulanPengembalian + " adalah 1 - " + totalHariDiBulanPengembalian);
                        Console.Write("Masukkan kembali Tanggal Hari Peminjaman dengan angka: ");
                        hariPengembalian = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        hariPengembalianTidakMelebihi = true;

                    }
                }
            }
            DateOnly tanggalPengembalian = new DateOnly(tahunPengembalian, bulanPengembalian, hariPengembalian);

            Console.WriteLine("=================");
            Console.WriteLine("Tanggal Pinjam : " + tanggalPinjam);
            Console.WriteLine("Tanggal Pengembalian : " + tanggalPengembalian);
            Console.WriteLine("=================");


        }

        public void checkBulan(int bulan)
        {
            if (bulan > 12 || bulan < 1)
            {
                Console.WriteLine("Input Salah! Jumlah Bulan Hanya dari 1 - 12!");
            }
        }


    }
}