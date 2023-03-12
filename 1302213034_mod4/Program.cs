using System;

namespace mod4_1302213034
{
    internal class program
    {
        public enum datakota
        {
            Batununggal,
            Kujangsari,
            Mengger,
            Wates,
            Cijaura,
            Jatisari,
            Margasari,
            Sekejati,
            Kebonwaru,
            Maleer,
            Ssamoja
        };
        public class getkodepos
        {
            public static int getkode(datakota kota)
            {
                int[] kodepos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };
                //list kodepos untuk array
                return kodepos[(int)kota];
            }
        }
        public static void Main(string[] args)
        {
            datakota kota = datakota.Jatisari;
            int kode = getkodepos.getkode(kota);
            Console.WriteLine("kelurahan : " + kota + "\nkodepos : " + kode);
        }
    }
}

