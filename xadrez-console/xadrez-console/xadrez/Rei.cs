using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca peca = tab.peca(pos);
            return peca != null && peca is Torre && peca.cor == cor && peca.qteMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //Norte
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Leste
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Sudeste
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Sul
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Sudoeste
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Oeste
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Noroeste
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //#Jogada especial - Roque
            if (qteMovimentos == 0 && !partida.xeque)
            {
                //Roque pequeno
                Posicao posTorre1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreParaRoque(posTorre1))
                {
                    Posicao posicao1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao posicao2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if (tab.peca(posicao1) == null && tab.peca(posicao2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                //Roque grande
                Posicao posTorre2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreParaRoque(posTorre2))
                {
                    Posicao posicao1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao posicao2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao posicao3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tab.peca(posicao1) == null && tab.peca(posicao2) == null && tab.peca(posicao3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
