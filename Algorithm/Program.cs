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
            List<string> daftarBuku = getDaftarBuku();
            DateOnly tanggalPinjam = getTanggalPinjam();
            List<DateOnly> tanggalPengembalian = getTanggalPengembalian(tanggalPinjam, daftarBuku);
            int batasMaxPinjaman = 14;
            int dendaHarian = 1000;

            Console.WriteLine("=========================================");
            int[] dendaPerBuku = dendaKeterlambatan(daftarBuku, tanggalPinjam, tanggalPengembalian, batasMaxPinjaman, dendaHarian);
            int totalDenda = 0;

            Console.WriteLine("Denda Per-Buku :");
            for (int i = 0; i < dendaPerBuku.Length; i++)
            {
                int j = i + 1;
                Console.WriteLine(j + ". Buku " + daftarBuku[i] + " mempunyai denda : " + dendaPerBuku[i]);
                totalDenda = totalDenda + dendaPerBuku[i];
            }
            Console.WriteLine("Total Denda : "+ totalDenda);

        }

        public static int[] dendaKeterlambatan(List<string> daftarBuku, DateOnly tanggalPinjam, List<DateOnly> tanggalPengembalian, int batasMaxPinjaman, int dendaHarian)
        {
            int totalBuku = daftarBuku.Count;
            int dendaBuku = 0;
            List<int> totalHariPeminjamanPerBuku = new List<int>();
            int[] dendaPerBuku = new int[0];

            for (int i = 0; i < totalBuku; i++)
            {
                int totalPeminjaman = tanggalPengembalian[i].DayNumber - tanggalPinjam.DayNumber;
                totalHariPeminjamanPerBuku.Add(totalPeminjaman);
            }

            for (int i = 0; i < totalBuku; i++)
            {
                if (totalHariPeminjamanPerBuku[i] > 14)
                {
                    dendaBuku = (totalHariPeminjamanPerBuku[i] - 14) * dendaHarian;
                    dendaPerBuku = dendaPerBuku.Append(dendaBuku).ToArray();
                }
                else if (totalHariPeminjamanPerBuku[i] < 14)
                {
                    dendaBuku = 0;
                    dendaPerBuku = dendaPerBuku.Append(dendaBuku).ToArray();
                }
            }

            return dendaPerBuku;
        }

        public static List<string> getDaftarBuku()
        {
            string[] arrayBuku = { "Naruto", "OnePiece", "Hunter X Hunter", "Fire Force", "Look Back", "Goodbye Eri", "Dandandan", "Shibatarian", "Chainsaw-Man", "Fire Fly", "Bleach" };
            List<string> daftarBuku = new List<string>();
            Console.WriteLine("---Daftar Buku yang dipinjam---");
            for (int i = 0; i < arrayBuku.Length; i++)
            {
                int j = i + 1;
                Console.WriteLine(j + ". " + arrayBuku[i]);
            }
            Console.WriteLine("Sebutkan jumlah buku yang dipinjam");
            int jumlahPinjamanBuku = int.Parse(Console.ReadLine());
            bool bukuNotExceed = false;
            while (bukuNotExceed == false)
            {
                if (jumlahPinjamanBuku < 1 || jumlahPinjamanBuku > arrayBuku.Length)
                {
                    Console.WriteLine("Jumlah Buku yang dipinjam hanya 1 - " + arrayBuku.Length);
                    jumlahPinjamanBuku = int.Parse(Console.ReadLine());
                }
                else
                {
                    bukuNotExceed = true;
                }

            }

            Console.WriteLine("Sebutkan nomor buku yang dipinjam : ");
            int temp = -1;
            for (int i = 0; i < jumlahPinjamanBuku; i++)
            {
                int j = i + 1;
                Console.Write(j + ". Buku nomor : ");
                int nomorBuku = int.Parse(Console.ReadLine());
                if (daftarBuku.Contains(arrayBuku[nomorBuku - 1]))
                {
                    Console.WriteLine("Buku nomor " + i + " telah dipinjam. Silahkan pilih buku yang lain!");
                    temp = i;
                    i = temp - 1;
                    continue;
                }
                else
                {
                    daftarBuku.Add(arrayBuku[nomorBuku - 1]);
                }
            }

            return daftarBuku;
        }

        public static DateOnly getTanggalPinjam()
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

            return tanggalPinjam;
        }

        public static List<DateOnly> getTanggalPengembalian(DateOnly tanggalPinjam, List<string> daftarBuku)
        {
            //Mendapatkan Tanggal Pengembalian
            List<DateOnly> tanggalPengembalianPerBuku = new List<DateOnly>();
            for (int i = 0; i < daftarBuku.Count; i++)
            {
                int j = i + 1;
                Console.WriteLine("---Tanggal Pengembalian Buku " + j + "---");
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
                tanggalPengembalianPerBuku.Add(tanggalPengembalian);
            }
            return tanggalPengembalianPerBuku;
        }

    }
}