using System;

namespace projeto2_caixaverso {
    public class Tabuleiro
    {
        private char[,] _tabuleiro;

        public Tabuleiro()
        {
            _tabuleiro = new char[3, 3];
            InicializarTabuleiro();
        }

        private void InicializarTabuleiro()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _tabuleiro[i, j] = ' ';
                }
            }
        }

        public void ExibirTabuleiro()
        {
            Console.Clear();
            Console.WriteLine("  0   1   2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(_tabuleiro[i, j]);
                    if (j < 2)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
                if (i < 2)
                {
                    Console.WriteLine("  --+---+--");
                }
            }
        }

        public bool MarcarPosicao(int linha, int coluna, char marcador)
        {
            if (linha < 0 || linha > 2 || coluna < 0 || coluna > 2)
            {
                return false;
            }

            if (_tabuleiro[linha, coluna] != ' ')
            {
                return false;
            }

            _tabuleiro[linha, coluna] = marcador;
            return true;
        }

        public bool VerificarLinhas(char marcador)
        {
            for (int i = 0; i < 3; i++)
            {
                if (_tabuleiro[i, 0] == marcador && _tabuleiro[i, 1] == marcador && _tabuleiro[i, 2] == marcador)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificarColunas(char marcador)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_tabuleiro[0, j] == marcador && _tabuleiro[1, j] == marcador && _tabuleiro[2, j] == marcador)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificarDiagonais(char marcador)
        {
            if ((_tabuleiro[0, 0] == marcador && _tabuleiro[1, 1] == marcador && _tabuleiro[2, 2] == marcador) ||
                (_tabuleiro[0, 2] == marcador && _tabuleiro[1, 1] == marcador && _tabuleiro[2, 0] == marcador))
            {
                return true;
            }
            return false;
        }

        public bool VerificarVitoria(char marcador)
        {
            return VerificarLinhas(marcador) || VerificarColunas(marcador) || VerificarDiagonais(marcador);
        }

        public bool EstaCheio()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_tabuleiro[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
