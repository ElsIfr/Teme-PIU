using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ProiectMasini1
{
    class AdministrareMasini_FisierText
    {
        private const int NR_MAX_MASINI = 20;
        private string numeFisier;

        public AdministrareMasini_FisierText(string numeFisier) ///// LAB_2 - deschiderea unui fisier text in modul open or create
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddMasina(Masini masina) ///// LAB_2 - salvarae datelor intr-un fisier text(in mod append)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(masina.ConversieLaSirPentruFisier());
            }
        }

        public Masini[] GetMasini(out int nrMasini) ///// LAB_2 - preluarea datelor dintr-un fisier text
        {
            Masini[] masini = new Masini[NR_MAX_MASINI];

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrMasini = 0;
                //Citeste cate o linie si creeaza cate un obiect de tip masina
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    masini[nrMasini++] = new Masini(linieFisier);
                }
            }
            return masini;
        }

    }
}

