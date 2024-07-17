using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace telefonkönyv
{

    class Telefon
    {
        public string name;
        public string address;
        public string phone;
        public string email;

        public Telefon(string sor)
        {
            string[] r = sor.Split(',');
            
            this.name = r[0];
            this.address = r[1];
            this.phone = r[2];
            this.email = r[3];
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {

            List<Telefon> list = new List<Telefon>();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                            **************WELCOME TO PHONEBOOK**************\n\n\n");
            Console.WriteLine("                                                  MENU   \n\n");
            

            string a = "1. új konntakt";

            string b = "2. összes";

            string c = "3. kilépés";

            string d = "4. szerkesztés";

            string e = "5. keresés";

            string f = "6. törlés";



            Console.WriteLine($"                    {a}                 {b}             {c}\n");
            Console.WriteLine($"                    {d}                 {e}             {f}");

            string adat = Console.ReadLine();

            if (adat == "1")
            {

                StreamWriter sw = new StreamWriter("d:\\telefon.txt");

                Console.WriteLine("Név:  \r\n");
                string name = Console.ReadLine();
                Console.WriteLine("Cím: \r\n");
                string address = Console.ReadLine();
                Console.WriteLine("Telefonszám:  \r\n");
                string phone = Console.ReadLine();
                Console.WriteLine("email: \r\n");
                string email = Console.ReadLine();
                sw.WriteLine($"{name}, {address}, {phone}, {email}\n");

                sw.Close();
                Console.WriteLine("konntakt mentve");



                StreamReader sr = new StreamReader("d:\\telefon.txt");
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    Telefon telefon = new Telefon(sor);
                    list.Add(telefon);

                }
                sr.Close();

            }

            if (adat == "2")
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    Console.WriteLine($"neve: {list[i].name} telefon: {list[i].phone} cím:{list[i].address} email: {list[i].email}");
                }
            }

            if (adat == "3")
            {
                System.Environment.Exit(0);

            }

            if (adat == "4")
            {
                Console.WriteLine("írd be a konntakt nevét a szerkesztéshez: \r\n");

                string keres = Console.ReadLine();
                for (int i = 0; i < list.Count(); i++)
                {

                    if (list[i].name == keres)
                    {

                        Console.WriteLine(" új cím: \r\n");
                        string uc = Console.ReadLine();
                        Console.WriteLine(" új telszam:: \r\n");
                        string ut = Console.ReadLine();
                        Console.WriteLine(" új emaile-mail: \r\n");
                        string ue = Console.ReadLine();

                        list[i] .address = uc;
                        list[i].phone = ut;
                        list[i].email= ue;
                    }
                }
                    
            }

            if (adat == "6")
            {

                Console.WriteLine("Írd be a törölni kívánt konntakt nevét: ");
                string del = Console.ReadLine();
                for (int i = 0; i < list.Count(); i++)
                {
                    if (list[i].name == del.ToString())
                    {
                        list[i] = null;
                    }
                }
            }


            if (adat == "5")
            {
                Console.WriteLine("írd be a keresendő szemly nevét: ");
                string person = Console.ReadLine();

                for (int i = 0; i < list.Count(); i++)
                {
                    if (list[i].name == person)
                    {

                        Console.WriteLine($" person :{person} found, \n email: {list[i].email} address: {list[i].address} \n phone: {list[i].phone}");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
