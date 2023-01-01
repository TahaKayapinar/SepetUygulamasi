using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepetUygulamasi
{
    internal class Program
    {

        /*
         
         catch (Exception ex)
            {
                Console.WriteLine("Program hata ile karşılaştı, lütfen tekrar programı çalıştırıp teker teker giriş yapınız...");
                Console.ReadKey();
            }
    */
    static void Main(string[] args)
        {
            //Ürün ekleme
            //Ürün listeleme
            //Ürün seçme
            //Sepete ekleme
            //Sipariş tamamlama

            string[] products = new string[0];            //ürünün isimlerini tutmak için kullanılacak dizi
            decimal[] productPrises = new decimal[0];     // ürünün fiyatları için kullanılacak dizi
            int[] basket = new int[0];                    //sepet için kullanılacak dizi

        Main:
            do
            {
                Console.Clear();
                Console.WriteLine("Aldı Alıyor....");
                Console.WriteLine("1- Yeni ürün Ekleme İşlemleri");
                Console.WriteLine("2- Ürün Listeleme");
                Console.WriteLine("3- Ürün Seçme ve Sepete Ekleme");
                Console.WriteLine("4- Satın Alma");

                Console.Write("Lütfen seçim yapınız");
                int secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        {
                            goto productAdd;

                        }
                    case 2:
                        {
                            goto productList;
                        }
                    case 3:
                        {
                           goto productSelectAndBasket;
                        }
                    
                }




            } while (true);






        productAdd:

            ConsoleKey productAddKey;
            do
            {
                Console.Clear();
                Console.Write("Lütfen ürün adı girişi yapınız...:");
                string productName = Console.ReadLine();

                Console.Write("Lütfen ürün fiyarı giriniz...:");
                decimal productPrice = Convert.ToDecimal(Console.ReadLine());

                Array.Resize(ref products, products.Length + 1);
                products[products.Length - 1] = productName;


                Array.Resize(ref productPrises, productPrises.Length + 1);
                productPrises[productPrises.Length - 1] = productPrice;

                Console.Write("Başka ürün eklemek istermisiniz?   Yes için y,   no için n    başka tuşa basma");
                productAddKey = Console.ReadKey().Key;


            } while (productAddKey != ConsoleKey.N);

            Console.ReadKey();
            goto Main;



        productList:
            Console.Clear();
            for (int i = 0; i < products.Length; i++)
            {
                string name = products[i];
                decimal price = productPrises[i];
                Console.WriteLine($"{i + 1} {name} ({price})");


            }
            Console.ReadKey();
            goto Main;







        productSelectAndBasket:
            do
            {
                Console.Clear();

                Console.WriteLine("***Sepet******************************************************************");
                decimal basketTotal = 0;
                for (int i = 0; i < basket.Length; i++)
                {
                    int selectedProductIndex = basket[i];
                    string name = products[selectedProductIndex];
                    decimal price = productPrises[selectedProductIndex];
                    Console.WriteLine($"{i + 1} {name} ({price})");
                    basketTotal += price;
                }
                Console.WriteLine($"Sepet toplamı => {basketTotal}\n");


                Console.WriteLine("*******Ürün Listesi*********");

                for (int i = 0; i < products.Length; i++)
                {
                    string name = products[i];
                    decimal price = productPrises[i];
                    Console.WriteLine($"{i + 1} {name} ({price})");

                }
                Console.Write("L Ü T F E N ürün seçimi yapınız....:");
                int secim = Convert.ToInt32(Console.ReadLine());

                if (secim > 0 && secim <= products.Length)
                {
                    //Seçim doğrudur sepete ekleme işlemi yapalım
                    Array.Resize(ref basket, basket.Length + 1);
                    basket[basket.Length - 1] = (secim - 1);               // kullanıcının seçtiği ürünün index kaydediyoruz. Yani kullanıcı 3 e bastoysa aslında 2.index i istiyor
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Seçim anlaşılamadı, lütfen bir tuşa basun ve tekrar seçim yapınız");
                    Console.ReadKey();
                    goto productSelectAndBasket;
                }


                Console.WriteLine("Başka bir ürün seçimi yapmak istiyormusunuz.... yes y    no için n");
                ConsoleKey questionProductResult = Console.ReadKey().Key;
                if (questionProductResult == ConsoleKey.N)
                {
                    goto Main;
                }
                


            } while (true);



            // productSatinAlma:???????????????????????????????????????????????????????????????????????????

            // sepetteki ürünleri listele, satın almak istiyormusun diye soru sor yes derse tebrikler şu kadar fiyata satın aldınız de  ve sepet dizisini tekrardan sıfır elemanlı diziye çevir, satın alma işlemi bittikten sonra kullanıcıyı tekrar en başa yönlendir, yeniden ürün satın alabilmek için
        }
    }
}
