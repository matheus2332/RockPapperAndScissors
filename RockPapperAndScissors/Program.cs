using System;
using System.Collections.Generic;

namespace RockPapperAndScissors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            rps_game_winner();
            Console.WriteLine("--------------------------------------------------------------");
            rps_tournament_winner();
            Console.ReadLine();
        }

        public static void rps_game_winner()
        {
            var jogadorqueVenceu = JogadorQueVenceu(new List<Jogador>
            {
                new Jogador
                {
                    Nome = "Armando",
                    Entrada = "P"
                },
                new Jogador
                {
                    Nome = "Dave",
                    Entrada = "s"
                },
            });

            Console.WriteLine($"O jogador que venceu a primeira partida foi o \"[{jogadorqueVenceu.Nome}, {jogadorqueVenceu.Entrada}]\"");
        }

        public static void rps_tournament_winner()
        {
            var vencedorDoTorneio = Tournament(CriarJogadores());
            Console.WriteLine($"O jogador que venceu o torneio foi o \"[{vencedorDoTorneio.Nome}, {vencedorDoTorneio.Entrada}]\"");
        }

        public static List<Jogador> CriarJogadores()
        {
            return new List<Jogador>
            {
                new Jogador
                {
                    Nome = "Armando",
                    Entrada = "P"
                },
                new Jogador
                {
                    Nome = "Dave",
                    Entrada = "S"
                },
                new Jogador
                {
                    Nome = "Richard",
                    Entrada = "R"
                },
                new Jogador
                {
                    Nome = "Michael",
                    Entrada = "S"
                },
                new Jogador
                {
                    Nome = "Allen",
                    Entrada = "S"
                },
                new Jogador
                {
                    Nome = "Omer",
                    Entrada = "P"
                },
                new Jogador
                {
                    Nome = "David E.",
                    Entrada = "P"
                },
                new Jogador
                {
                    Nome = "Richard X.",
                    Entrada = "s"
                },
            };
        }

        public static Jogador Tournament(List<Jogador> jogadores)
        {
            var vencedorJogo1 = JogadorQueVenceu(new List<Jogador>
            {
                jogadores[0],
                jogadores[1]
            });
            var vencedorJogo2 = JogadorQueVenceu(new List<Jogador>
            {
                jogadores[2],
                jogadores[3],
            });
            var vencedorSemifinal1 = Jogar(vencedorJogo1, vencedorJogo2);

            var vencedorJogo3 = JogadorQueVenceu(new List<Jogador>
            {
                jogadores[4],
                jogadores[5],
            });
            var vencedorJogo4 = JogadorQueVenceu(new List<Jogador>
            {
                jogadores[6],
                jogadores[7],
            });
            var vencedorSemifinal2 = Jogar(vencedorJogo3, vencedorJogo4);

            return Jogar(vencedorSemifinal1, vencedorSemifinal2);
        }

        public static Jogador JogadorQueVenceu(List<Jogador> jogadores)
        {
            if (jogadores.Count != 2) throw new Exception("Quantidade de jogadores não permida");
            var jogador1 = jogadores[0];
            var jogador2 = jogadores[1];

            VerificarEscolha(jogador1, jogador2);
            return Jogar(jogador1, jogador2);
        }

        public static Jogador Jogar(Jogador jogador1, Jogador jogador2)
        {
            var entradaDoJogador1 = new Rock().Converter(jogador1.Entrada);
            var entradaDoJogador2 = new Rock().Converter(jogador2.Entrada);

            return entradaDoJogador1.Ganhou(entradaDoJogador2) ? jogador1 : jogador2;
        }

        private static void VerificarEscolha(Jogador jogador1, Jogador jogador2)
        {
            var escolha = new Rock();
            if (!escolha.VerificarChoose(jogador1.Entrada)) throw new Exception("A entrada do jogador 1 não é permida");
            if (!escolha.VerificarChoose(jogador2.Entrada)) throw new Exception("A entrada do jogador 2 não é permida");

            jogador1.Entrada = escolha.TratarChoose(jogador1.Entrada);
            jogador2.Entrada = escolha.TratarChoose(jogador2.Entrada);
        }
    }
}