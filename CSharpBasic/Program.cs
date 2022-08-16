using System;

namespace CSharpBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //int a = 123;
            //double b = 567.123;
            //Console.WriteLine($"Bien a = {a}, bien b = {b}, tich a*b = {a * b}");

            //string userLogin;
            //Console.WriteLine("Moi nhap user name: ");
            //userLogin = Console.ReadLine();
            //Console.WriteLine($"User name: {userLogin}");

            //Console.WriteLine("Nhap vao mot so thuc: ");
            //double doubleInput = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine($"So thuc: {doubleInput}");

            //const double pi = 3.14;
            //Console.WriteLine($"pi = {pi}");

            //string[] studentName = new string[2] { "chichay", "joaquin" };
            //Console.WriteLine(studentName[1]);

            //var sungLuc = new VuKhi();
            //sungLuc.name = "Sung luc";
            //sungLuc.doSatThuong = 3;

            //VuKhi sungTruong = new VuKhi();
            //sungTruong.name = "Sung truong";
            //sungTruong.SetDoSatThuong(20);

            //sungLuc.TanCong();
            //sungTruong.TanCong();

            //Product product1 = new Product();
            //Product product2 = new Product("Dien thoai", 1000);
            //Product product3 = new Product("May tinh", 5000);

            //Console.WriteLine($"Product 1: {product1.Name} - {product1.Price}");
            //Console.WriteLine($"Product 2: {product2.Name} - {product2.Price}");
            //Console.WriteLine($"Product 3: {product3.Name} - {product3.Price}");

            var key = "b14ca5898a4e4133bbce2ea2315a1916";

            //Console.WriteLine("Please enter a secret key for the symmetric algorithm.");  
            //var key = Console.ReadLine();  

            Console.WriteLine("Please enter a string for encryption");
            var str = Console.ReadLine();
            var encryptedString = AesOperation.EncryptString(key, str);
            Console.WriteLine($"encrypted string = {encryptedString}");

            var decryptedString = AesOperation.DecryptString(key, encryptedString);
            Console.WriteLine($"decrypted string = {decryptedString}");

            Console.ReadKey();
        }
    }
}
