using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Management;

namespace ProiectMasini1
{
     class Program
    {
        public static void Main()
        {
            Masini masina = new Masini();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            AdministrareMasini_FisierText adminMasini = new AdministrareMasini_FisierText(numeFisier);
            int nrMasini = 0;
            adminMasini.GetMasini(out nrMasini);

            string optiune;
            do
            {
                Console.WriteLine("I. Introducere informatii despre masina de la tastatura");
                Console.WriteLine("A. Afisare ultimele informatii intruduse despre o masina");
                Console.WriteLine("F. Afisare masini din fisier");
                Console.WriteLine("S. Salvare masina in fisier");
                Console.WriteLine("C. Cauta o masina dupa un anumit criteriu");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "I":
                        //masina = masina.CitesteMasinaTastatura();
                        masina = masina.CitesteMasinaTastatura();

                        break;
                    case "A":
                        masina.AfiseazaMasina();

                        break;
                    case "F":
                        Masini[] masini = adminMasini.GetMasini(out nrMasini);
                        AfisareMasina(masini, nrMasini);

                        break;
                    case "S":
                        adminMasini.AddMasina(masina);

                        nrMasini = nrMasini + 1;

                        break;
                    case "C":
                        Masini[] Masini = adminMasini.GetMasini(out nrMasini);
                        Console.WriteLine("Aveti de ales dintre urmatoarele optiuni:" +
                            "   Marca   AnFabricatie   KmParcursi   Culoare  Valabilitate");
                        CautaMasina(Console.ReadLine(), nrMasini, Masini);

                        break;
                    case "X":

                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");

                        break;
                }
            } while (optiune.ToUpper() != "X");
            Console.ReadKey();
        }

        

        private static bool SetValabilitate()
        {
            throw new NotImplementedException();
        }

        private static string SetMarcaMasina()
        {
            throw new NotImplementedException();
        }

        public static void AfisareMasina(Masini masina) ///// LAB_3 - afisare date din fisier
        {
            string infoMasina = string.Format("Marca: {0} AnFabricatie: {1} KmParcursi: {2} Culoare: {3} Valabilitate: {4} ",
                masina.GetMarca(),
                masina.GetAnFabricatie(),
                masina.GetKmParcursi(),
                masina.GetCuloare(),
                masina.GetValabilitate());
            Console.WriteLine(infoMasina);
        }

        public static void AfisareMasina(Masini[] masina, int nrMasini) ///// LAB_3 - afisare date din fisier
        {
            Console.WriteLine("Masinile sunt : ");
            for (int contor = 0; contor < nrMasini; contor++)
            {
                AfisareMasina(masina[contor]);
            }
        }

        public static void CautaMasina(string criteriu, int nrMasini, Masini[] masina) ///// LAB_3 - căutarea după anumite criterii
        {

            switch (criteriu)
            {
                case "Marca":
                    Console.WriteLine("Introduceti datele pe care doriti sa le cautati");
                    string date_cerute = Console.ReadLine();
                    Console.WriteLine("Pentru datele introduse am gasit in fisier urmatoarele similaritati");
                    for (int contor = 0; contor < nrMasini; contor++)
                        if (masina[contor].GetMarca() == date_cerute)
                            Console.WriteLine(masina[contor].Info());

                    break;
                case "KmParcursi":
                    Console.WriteLine("Introduceti datele pe care doriti sa le cautati");
                    date_cerute = Console.ReadLine();
                    Console.WriteLine("Pentru datele introduse am gasit in fisier urmatoarele similaritati");
                    for (int contor = 0; contor < nrMasini; contor++)
                        if (masina[contor].GetKmParcursi() == Convert.ToInt16(date_cerute))
                            Console.WriteLine(masina[contor].Info());

                    break;
                case "AnFabricatie":
                    Console.WriteLine("Introduceti datele pe care doriti sa le cautati");
                    date_cerute = Console.ReadLine();
                    Console.WriteLine("Pentru datele introduse am gasit in fisier urmatoarele similaritati");
                    for (int contor = 0; contor < nrMasini; contor++)
                        if (masina[contor].GetAnFabricatie() == Convert.ToInt16(date_cerute))
                            Console.WriteLine(masina[contor].Info());

                    break;
                case "Culoare":
                    Console.WriteLine("Introduceti datele pe care doriti sa le cautati");
                    date_cerute = Console.ReadLine();
                    Console.WriteLine("Pentru datele introduse am gasit in fisier urmatoarele similaritati");
                    for (int contor = 0; contor < nrMasini; contor++)
                        if (masina[contor].GetCuloare() == date_cerute)
                            Console.WriteLine(masina[contor].Info());

                    break;
                default:
                    Console.WriteLine("Optiune inexistenta");

                    break;
            }
        }

    }
}
