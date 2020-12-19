using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoImagem
{
    //=================================================================
    //*classe para criar as colisoes, localização e velocidade da bola
    public class cl_bola
    {
        public int x = 50;
        public int y = 50;
        public int velocidade_x = 10;
        public int velocidade_y = 10;

        //=================================================================
        public void mover(int largura, int altura)
        {
            x += velocidade_x;
            y += velocidade_y;

            //----------------------------
            //*detecta colisoes

            //*direita
            if (x + 50 >= largura)
                velocidade_x = -velocidade_x;

            //*esquerda
            if (x <= 0)
                velocidade_x = -velocidade_x;

            //*topo
            if (y <= 0)
                velocidade_y = -velocidade_y;

            //*baixo
            if (y + 50 >= altura)
                velocidade_y = -velocidade_y;



        }
    }
}
