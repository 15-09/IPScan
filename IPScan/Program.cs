using System;
using System.Net.NetworkInformation;

class IpTarayici
{
    static void Main(string[] args)
    {
        Console.WriteLine("Başlangıç IP adresini girin: ");
        string baIP = Console.ReadLine();

        Console.WriteLine("Bitiş IP adresini girin: ");
        string biIP = Console.ReadLine();

        Console.WriteLine("Tarama başlatılıyor...");

        Ping ping = new Ping();
        PingReply yanit;
        List<string> erisilebilirIpler = new List<string>();

        for (int i = IPtoInteger(baIP); i <= IPtoInteger(biIP); i++)
        {
            string hdfIP = IntegerToIP(i);
            yanit = ping.Send(hdfIP);

            if (yanit.Status == IPStatus.Success)
            {
                erisilebilirIpler.Add(hdfIP);
                Console.WriteLine(hdfIP + " - Aktif");
            }   
            else
            {
                Console.WriteLine(hdfIP + " - İn-aktif");
            }
        }
        Console.WriteLine("Aktif IP Adresleri: " + string.Join(", ", erisilebilirIpler));
        Console.ReadLine();

        Console.ReadLine();
    }

    static int IPtoInteger(string IP)
    {
        string[] parcalar = IP.Split('.');
        int sonuc = 0;

        for (int i = 0; i < parcalar.Length; i++)
        {
            sonuc = sonuc << 8 | int.Parse(parcalar[i]);
        }

        return sonuc;
    }

    static string IntegerToIP(int deger)
    {
        return string.Format("{0}.{1}.{2}.{3}",
            (deger >> 24) & 255, (deger >> 16) & 255,
            (deger >> 8) & 255, deger & 255);
    }
}
