using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Carro[] carros =
            {
                new Carro("Ferrari", 500_000),
                new Carro("Hilux", 150_000),
                new Carro("Gol", 40_000),
                new Carro("Onix", 40_000),
                new Carro("Mobi", 30_000),
                new Carro("Strada", 45_000),
                new Carro("EcoSport", 71_000)
            };

            Ordena(carros, 0, carros.Length);

            ImprimeCarros(carros, "Carros Ordenados");

            Console.ReadKey();
        }

        private static void Ordena(Carro[] carros, int de, int ate)
        {
            int elementos = ate - de;
            int posicaoPivo;

            if (elementos > 1)
            {
                posicaoPivo = Particiona(carros, de, ate);
                Ordena(carros, de, posicaoPivo);
                Ordena(carros, posicaoPivo + 1, ate);
            }
        }

        private static int Particiona(Carro[] carros, int inicio, int termino)
        {
            int menoresEncontrados = inicio;

            Carro pivo = carros[termino - 1];
            Carro atual;

            for (int analisando = inicio; analisando < termino - 1; analisando++)
            {
                atual = carros[analisando];

                if(atual.Preco <= pivo.Preco)
                {
                    Troca(carros, analisando, menoresEncontrados);
                    menoresEncontrados++;
                }
            }
            
            Troca(carros, termino - 1, menoresEncontrados);
            
            return menoresEncontrados;
        }

        private static void Troca(Carro[] carros, int de, int para)
        {
            Carro carro1 = carros[de];
            Carro carro2 = carros[para];

            carros[para] = carro1;
            carros[de] = carro2;
        }

        private static void ImprimeCarros(Carro[] carros, string titulo)
        {
            Console.WriteLine(titulo);
            Console.WriteLine();
            foreach (var carro in carros)
            {
                Console.WriteLine(carro.ToString());
            }
            Console.WriteLine();
        }
    }
}
