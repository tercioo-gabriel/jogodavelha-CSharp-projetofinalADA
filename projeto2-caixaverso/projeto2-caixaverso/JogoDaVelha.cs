using System;

namespace projeto2_caixaverso {
    public class JogoDaVelha
    {
        private Tabuleiro _tabuleiro;
        private char _jogadorAtual;

        public JogoDaVelha()
        {
            _tabuleiro = new Tabuleiro();
            _jogadorAtual = 'X';
        }

        public void IniciarJogo()
        {
            bool jogoTerminou = false;

            while (!jogoTerminou)
            {
                _tabuleiro.ExibirTabuleiro();

                Console.WriteLine($"\nÉ a vez do jogador {_jogadorAtual}. Digite a linha e a coluna (ex: 1 2): ");

                int linha = -1, coluna = -1;
                bool entradaValida = false;

                while (!entradaValida)
                {
                    string entrada = Console.ReadLine();
                    string[] partes = entrada.Trim().Split(' ');

                    if (partes.Length == 2 && int.TryParse(partes[0], out linha) && int.TryParse(partes[1], out coluna))
                    {
                        entradaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Formato de entrada incorreto. Tente novamente (ex: 1 2).");
                    }
                }

                bool jogadaValida = _tabuleiro.MarcarPosicao(linha, coluna, _jogadorAtual);

                if (jogadaValida)
                {
                    if (_tabuleiro.VerificarVitoria(_jogadorAtual))
                    {
                        _tabuleiro.ExibirTabuleiro();
                        Console.WriteLine($"\nParabéns! O jogador {_jogadorAtual} venceu!");
                        jogoTerminou = true;
                    }
                    else if (_tabuleiro.EstaCheio())
                    {
                        _tabuleiro.ExibirTabuleiro();
                        Console.WriteLine("\nO jogo terminou em empate!");
                        jogoTerminou = true;
                    }
                    else
                    {
                        TrocarJogador();
                    }
                }
                else
                {
                    Console.WriteLine("Jogada inválida! Posição fora dos limites ou já ocupada.");
                    Console.ReadKey();
                }
            }
        }

        private void TrocarJogador()
        {
            _jogadorAtual = (_jogadorAtual == 'X') ? 'O' : 'X';
        }
    }
}