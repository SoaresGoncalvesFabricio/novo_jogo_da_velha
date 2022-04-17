namespace Jogo
{
    internal class Class1
    {
        private char[] Posicoes;
        private char Vez;
        private bool Fimjogo;
        private int Quantidadepreenchida;

        public Class1()
        {
            Posicoes = new [] { '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            Vez = 'X';
            Quantidadepreenchida = 0;
            Fimjogo = false;
        }

        public void Inicio()
        {
            while (Fimjogo == false)
            {
                RenderizarTabela();
                Escolhausuario();
                RenderizarTabela();
                Verificafim();
                Mudarvez();
            }
        }

        private void Mudarvez()
        {
            if (Vez == 'X')
                Vez = 'O';
            else
                Vez = 'X';
        }

        private void Escolhausuario()
        {
            Console.WriteLine($"Agora é a vez de {Vez}, escolha uma posição válida entre 1 e 9.");
            bool Posicao = int.TryParse(Console.ReadLine(), out int Posicaoescolhida);
            int Indice = Posicaoescolhida - 1;
            while (Valida(Posicaoescolhida) == false)
            {
                Console.WriteLine("Opção inválida!! escolha uma posição livre entre 1 e 9.");
                Posicao = int.TryParse(Console.ReadLine(), out Posicaoescolhida);
                Indice = Posicaoescolhida - 1;
            }
            Posicoes[Indice] = Vez;
            Quantidadepreenchida++;
        }

        private bool Valida(int Posicaoescolhida)
        {
            int Indice = Posicaoescolhida - 1;
            if (Posicaoescolhida < 1 || Posicaoescolhida > 9 || Posicoes[Indice] == 'X' || Posicoes[Indice] == 'O')
            {
                return false;
            }
            return true;
        }

        private void Verificafim()
        {
            if (Quantidadepreenchida < 5)
                return;
            if (Quantidadepreenchida == 9)
            {
                Console.WriteLine("Empate.");
                Fimjogo = true;
            }
            if (Vitoriahorizontal())
            {
                Console.WriteLine($"Vitoria de {Vez}.");
                Fimjogo = true;
            }
            if (Vitoriavertical())
            {
                Console.WriteLine($"Vitoria de {Vez}.");
                Fimjogo = true;
            }
            if (Vitoriadiagonal())
            {
                Console.WriteLine($"Vitoria de {Vez}.");
                Fimjogo = true;
            }
        }

        private bool Vitoriahorizontal()
            {
                bool Linha1 = Posicoes[0] == Posicoes[1] && Posicoes[0] == Posicoes[2];
                bool Linha2 = Posicoes[3] == Posicoes[4] && Posicoes[3] == Posicoes[5];
                bool Linha3 = Posicoes[6] == Posicoes[7] && Posicoes[6] == Posicoes[8];
                return Linha1 || Linha2 || Linha3;
            }

        private bool Vitoriavertical()
        {
            bool Coluna1 = Posicoes[0] == Posicoes[3] && Posicoes[0] == Posicoes[6];
            bool Coluna2 = Posicoes[1] == Posicoes[4] && Posicoes[1] == Posicoes[7];
            bool Coluna3 = Posicoes[2] == Posicoes[5] && Posicoes[2] == Posicoes[8];
            return Coluna1 || Coluna2 || Coluna3;
        }

        private bool Vitoriadiagonal()
        {
            bool Diagonal1 = Posicoes[0] == Posicoes[4] && Posicoes[0] == Posicoes[8];
            bool Diagonal2 = Posicoes[6] == Posicoes[4] && Posicoes[6] == Posicoes[2];
            return Diagonal1 || Diagonal2;
        }

        private void RenderizarTabela()
        {
            Console.Clear();
            Console.Write(ObterTabela());
        }

        private String ObterTabela()
        {
            return $"__{Posicoes[0]}__|__{Posicoes[1]}__|__{Posicoes[2]}__\n" +
                   $"__{Posicoes[3]}__|__{Posicoes[4]}__|__{Posicoes[5]}__\n" +
                   $"  {Posicoes[6]}  |  {Posicoes[7]}  |  {Posicoes[8]}  \n";
        }
    }
}

