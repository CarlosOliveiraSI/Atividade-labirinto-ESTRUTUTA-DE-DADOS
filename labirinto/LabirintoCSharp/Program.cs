using System;
using System.Collections.Generic;

namespace LabirintoCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] labirinto = new char[limit, limit];
            criaLabirinto(labirinto);
            mostrarLabirinto(labirinto, limit, limit);
            buscarQueijo(labirinto, 1, 1);
            Console.ReadKey();

           

        }

        private const int limit = 15;


        static void mostrarLabirinto(char[,] array, int l, int c)
        {
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < c; j++)
                {
                    Console.Write($" {array[i, j]} ");
                }
            }
            Console.WriteLine();
        }


        static void criaLabirinto(char[,] meuLab)
        {
            Random random = new Random();
            for (int i = 0; i < limit; i++)
            {
                for (int j = 0; j < limit; j++)
                {
                    meuLab[i, j] = random.Next(4) == 1 ? '|' : '.';
                }
            }


            for (int i = 0; i < limit; i++)
            {
                meuLab[0, i] = '*';
                meuLab[limit - 1, i] = '*';
                meuLab[i, 0] = '*';
                meuLab[i, limit - 1] = '*';
            }


            int x = random.Next(limit);
            int y = random.Next(limit);
            meuLab[x, y] = 'Q';
        }

        static void buscarQueijo(char[,] meuLab, int i, int j)
        {
            Stack<(int, int)> minhaPilha = new Stack<(int, int)>();
            bool[,] visitado = new bool[limit, limit];

            do
            {
                meuLab[i, j] = 'v';
                visitado[i, j] = true;

                if (j + 1 < limit && meuLab[i, j + 1] != '*'  && meuLab[i, j + 1] != '|'&& !visitado[i, j + 1])
                    minhaPilha.Push((i, j + 1));

                if (i + 1 < limit && meuLab[i + 1, j] != '*' && meuLab[i + 1, j] != '|'&& !visitado[i + 1, j])
                    minhaPilha.Push((i + 1, j));

                if (j - 1 >= 0 && meuLab[i, j - 1] != '*' && meuLab[i, j - 1] != '|' && !visitado[i, j - 1])
                    minhaPilha.Push((i, j - 1));

                if (i - 1 >= 0 && meuLab[i - 1, j] != '*' && meuLab[i - 1, j] != '|'&& !visitado[i - 1, j])
                    minhaPilha.Push((i - 1, j));

                if (minhaPilha.Count == 0)
                {
                    Console.WriteLine("Queijo nao encontrado");
                    return;

                }

                (i, j) = minhaPilha.Pop();
                System.Threading.Thread.Sleep(200);
                Console.Clear();
                mostrarLabirinto(meuLab, limit, limit);
            } while (meuLab[i, j] != 'Q');
        }


    }
}
