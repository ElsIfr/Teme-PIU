using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMasini1
{
    internal class Masini
    {
        public enum valabilitate ///// LAB_5 - exercitiul 2;
        {
            True = 1,
            False = 2
        };

        public enum marcaMasina ///// LAB_5 - exercitiul 2;
        {
            Audi = 3,
            BMW = 5,
            Tesla = 4,
            Volvo = 3,
            Volkswagen = 5
            
        }

        private const char SEPARATOR = ';';

        private const int MARCA = 0;
        private const int ANFABRICATIE = 1;
        private const int KMPARCURSI =2;
        private const int CULOARE = 3;
        private const int MARCAMASINA = 4;
        private const int VALABILITATE = 4;




        public string Marca { get; set; } ///// LAB_5 - exercitiul 1;
        public int KmParcursi { get; set; } ///// LAB_5 - exercitiul 1;
        public int AnFabricatie { get; set; } ///// LAB_5 - exercitiul 1;
        public string Culoare { get; set; } ///// LAB_5 - exercitiul 1;

        public string MarcaMasina { get; set; } ///// LAB_5 - exercitiul 1;
        public bool Valabilitate { get; set; } ///// LAB_5 - exercitiul 1;



        public Masini() //Constructor implicit
        {
            Marca = Culoare = MarcaMasina = string.Empty;
            AnFabricatie = KmParcursi = 0;
            Valabilitate = false;
        }

        /*internal Masini CitesteMasinaTastatura()
        {
            throw new NotImplementedException();
        }*/

        public Masini(string marca, string culoare, int anFabricatie, string marcaMasina, bool valabilitate, int kmParcursi) //Constructor cu parametrii
        {
            Marca = marca;
            Culoare = culoare;
            AnFabricatie = anFabricatie;
            MarcaMasina = marcaMasina;
            KmParcursi = kmParcursi;
            Valabilitate = valabilitate;
        }

        public Masini(string linieFisier) //Constructor folosind datele din fisier
        {
            var dateFisier = linieFisier.Split(SEPARATOR);
            Marca = dateFisier[MARCA];
            KmParcursi = Convert.ToInt16(dateFisier[KMPARCURSI]);
            AnFabricatie = Convert.ToInt16(dateFisier[ANFABRICATIE]);
            Culoare = dateFisier[CULOARE];
            //MarcaMasina = dateFisier[MARCAMASINA];
            Valabilitate = Convert.ToBoolean(dateFisier[VALABILITATE].ToLower());///// false trebuie mereu sa 
        }

        
        public void AfiseazaMasina() ///// LAB_3 - afisarea datelor de la tastatura;
        {
            string stringPentruAfisare = string.Format("Informatiile despre masina sunt urmatoarele:\n" +
                "Marca: {0}\t AnFabricatie: {1}\t KmParcursi: {2}\t Culoare: {3}\t Valabilitate: {4}\t",
                GetMarca(),
                GetAnFabricatie(),
                GetKmParcursi(),
                GetValabilitate(),
                GetCuloare());

            Console.WriteLine(stringPentruAfisare);
        }

        public string Info()
        {
            string info = string.Format("Marca: {0} AnFabricatie: {1} KmParcursi: {2} Culoare: {3} Valabilitate: {4}",
                GetMarca(),
                GetAnFabricatie(),
                GetKmParcursi(),
                GetValabilitate(),
                GetCuloare());
            return info;
        }

        public string ConversieLaSirPentruFisier() ///// LAB_3 - conversia datelor la string pentru scrierea in fisier
        {
            string stringPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}",
                SEPARATOR,
                GetMarca(),
                GetAnFabricatie(),
                GetKmParcursi(),
                GetCuloare(),
                GetValabilitate());
            return stringPentruFisier;
        }

        public string GetMarca()
        {
            return Marca;
        }

        public string GetCuloare()
        {
            return Culoare;
        }

        public int GetAnFabricatie()
        {
            return AnFabricatie;
        }

        public int GetKmParcursi()
        {
            return KmParcursi;
        }

        public bool GetValabilitate()
        {
            return Valabilitate;
        }

        public Masini CitesteMasinaTastatura() ///// LAB_3 - citirea datelor de la tastatura;
        {
            Console.WriteLine("Introduceti marca masinii:");
            string marca = Console.ReadLine();

            Console.WriteLine("Introduceti culoarea masinii:");
            string culoare = Console.ReadLine();

            Console.WriteLine("Introduceti anul fabricarii:");
            int anFabricatie = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti km parcursi:");
            int kmParcursi = int.Parse(Console.ReadLine());

            string marcaMasina = SetMarcaMasina();

            //Console.WriteLine("Introduceti valabilitatea masinii (true/false):");
            bool valabilitate = SetValabilitate();

            return new Masini(marca, culoare, anFabricatie, marcaMasina, valabilitate, kmParcursi);
        }

        static bool SetValabilitate() ///// LAB_5 - exercitiul 2;
        {
            valabilitate valabil = valabilitate.False;

            int optiune;
            do
            {
                Console.WriteLine("Alegeti valabilitatea pentru masina introdusa:");
                Console.WriteLine("1 - true \n2 - false");
                optiune = Convert.ToInt32(Console.ReadLine());
                switch (optiune)
                {
                    case 1:
                        valabil = valabilitate.True;
                        Console.WriteLine("Masina introdusa este disponibila");

                        break;
                    case 2:
                        valabil = valabilitate.False;
                        Console.WriteLine("Masina introdusa nu este disponibila");

                        break;
                    default:
                        Console.WriteLine("Optiune invalida, Va rugam incercati din nou");

                        break;

                }
            } while (optiune != 1 && optiune != 2);
            string s = Convert.ToString(valabil);
            bool output = Convert.ToBoolean(s.ToLower());

            return output;
        }

        static string SetMarcaMasina() ///// LAB_5 - exercitiul 2;
        {
            marcaMasina marca = marcaMasina.Audi;
            int optiune;
            do
            {
                Console.WriteLine("Alegeti marca pentru masina introdusa:");
                Console.WriteLine("1 - Audi\n" +
                                  "2 - BMW\n" +
                                  "3 - Tesla\n" +
                                  "4 - Volvo\n" +
                                  "5 - Volkswagen\n");
                optiune = Convert.ToInt32(Console.ReadLine());
                switch (optiune)
                {
                    case 1:
                        marca = marcaMasina.Audi;
                        Console.WriteLine("Masina are marca {0}", marca);

                        break;
                    case 2:
                        marca = marcaMasina.BMW;
                        Console.WriteLine("Masina are marca {0}", marca);

                        break;
                    case 3:
                        marca = marcaMasina.Tesla;
                        Console.WriteLine("Masina are marca {0}", marca);

                        break;
                    case 4:
                        marca = marcaMasina.Volvo;
                        Console.WriteLine("Masina are marca {0}", marca);

                        break;
                    case 5:
                        marca = marcaMasina.Volkswagen;
                        Console.WriteLine("Masina are marca {0}", marca);

                        break;
                    
                    default:
                        optiune = 0;

                        break;
                }
            } while (optiune == 0);

            return Convert.ToString(marca);
        }
    }
}
