using System;

namespace MyDictionaryOdev
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<String, String> sinifOgretmenleri = new MyDictionary<string, string>();
            DictionaryResult dictionaryResult;

            dictionaryResult = sinifOgretmenleri.Add("9-A", "Tarık Akan");
            Console.WriteLine(dictionaryResult.Message);

            dictionaryResult = sinifOgretmenleri.Add("9-B", "Türkan Şoray");
            Console.WriteLine(dictionaryResult.Message);

            dictionaryResult = sinifOgretmenleri.Add("10-A", "Şener Şen");
            Console.WriteLine(dictionaryResult.Message);

            dictionaryResult = sinifOgretmenleri.Add("10-B", "İlyas Salman");
            Console.WriteLine(dictionaryResult.Message);

            dictionaryResult = sinifOgretmenleri.Add("9-B", "Filiz Akın");
            Console.WriteLine(dictionaryResult.Message);

            //Eleman sayısını yazdırma
            Console.WriteLine("MyDictionary örneğinin eleman sayısı: {0}", sinifOgretmenleri.Length);

            //Key değerlerini yazdırma
            Console.WriteLine("KEYS: \n");
            string[] keys = sinifOgretmenleri.Keys;
            foreach (var key in keys)
            {
                Console.WriteLine(key+"\n");
            }

            //value değerlerini yazdırma
            Console.WriteLine("VALUES: \n");
            string[] values = sinifOgretmenleri.Values;
            foreach (var value in values)
            {
                Console.WriteLine(value + "\n");
            }


            //Doğrudan atama ile ekleme
            sinifOgretmenleri["9-C"] = "Yadigar Ejder";


            //Bir key ile kaydedilmiş value değerini yazdırma
            Console.WriteLine("9-A Sınıf Öğretmeni: {0}\n", sinifOgretmenleri["9-A"]);
            Console.WriteLine("*** 9-A Sınıf öğretmeni değiştirildi ***\n");
            
            //Güncelleme
            sinifOgretmenleri["9-A"] = "Aliye Rona";
            
            Console.WriteLine("9-A Sınıf Öğretmeni: " + sinifOgretmenleri["9-A"]);

            //Sınıf ve sınıf öğretmenleri listesi
            Console.WriteLine("SINIF ÖĞRETMENLERİ: \n");
            foreach (var key in keys)
            {
                Console.WriteLine("{0} Sınıf Öğretmeni => {1} \n",key,sinifOgretmenleri[key]);
            }

            int count = sinifOgretmenleri.Length;
            Console.WriteLine("Toplam tanımılı sınıf öğretmeni sayısı: " + count);

            sinifOgretmenleri.Remove("9-B");
            count = sinifOgretmenleri.Length;
            Console.WriteLine("Toplam tanımılı sınıf öğretmeni sayısı: " + count);

        }
    }
}
