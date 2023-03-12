using System;
using System.Security.Cryptography.X509Certificates;



namespace mod4_1302213034
{
    internal class program
    {
        public enum datakota//daftar nama kota dibuat enum
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
            datakota kota = datakota.Jatisari;//memilih kota yagn ingin dimunculkan
            int kode = getkodepos.getkode(kota);//menampilkan kodepos sesuai dengan index pada arry dan enum
            Console.WriteLine("kelurahan : " + kota + "\nkodepos : " + kode);
            
            doormachine pintu = new doormachine();
            pintu.trigerAktif(trigger.pintuKunci);
            pintu.trigerAktif(trigger.pintuBuka);
            pintu.trigerAktif(trigger.pintuKunci);
            pintu.trigerAktif(trigger.pintuBuka);
            Console.ReadKey();
        }
    }



    public enum pintu
    {
        terkunci,
        terbuka
    }

    public enum trigger
    {
        pintuBuka,
        pintuKunci
    }
    public class doormachine
    {
        public pintu currentstate = pintu.terkunci;
        public class transisi
        {
            public pintu stateawal;
            public pintu stateakhir;
            public trigger Trigger;
            internal pintu stateAkhir;

            public transisi(pintu stateawal, pintu stateakhir, trigger trigger)
            {
                this.stateawal = stateawal;
                this.stateakhir = stateakhir;
                Trigger = trigger;
            }
        }
        transisi[] transisi2 =
        {
            new transisi (pintu.terkunci, pintu.terbuka, trigger.pintuBuka),
            new transisi (pintu.terbuka, pintu.terkunci, trigger.pintuKunci),
            new transisi (pintu.terbuka, pintu.terbuka, trigger.pintuBuka),
            new transisi(pintu.terkunci, pintu.terkunci, trigger.pintuKunci)
        };
        private pintu getstateselanjutnya(pintu stateAwal, trigger Trigger)
        {
            pintu stateAkhir = stateAwal;
            for (int i = 0; i < transisi2.Length; i++)
            {
                transisi perubahan = transisi2[i];
                if (stateAwal == perubahan.stateawal && Trigger == perubahan.Trigger)
                {
                    stateAkhir = perubahan.stateAkhir;
                }
            }
        }   
        public void trigerAktif(trigger trigger)
        {
            currentstate = getstateselanjutnya(currentstate, trigger);
            Console.WriteLine("state sekarang adalah " + currentstate);
            if(currentstate == pintu.terkunci)
            {
                Console.WriteLine("pintu sedang terkunci");
            }else if (currentstate == pintu.terbuka)
            {
                Console.WriteLine("pintu sedang terbuka");
            }
        }
    }
}


