using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;// SISTEMA PARA IMAGENS E DESENHOS
using System.Drawing.Drawing2D;// SISTEMA PARA IMAGENS E DESENHOS
using System.Drawing.Imaging;// SISTEMA PARA IMAGENS E DESENHOS
using System.Drawing.Printing;// SISTEMA PARA IMAGENS E DESENHOS
using System.Drawing.Text;// SISTEMA PARA IMAGENS E DESENHOS
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoImagem
{
    public partial class Form1 : Form
    {
        
        string pasta_imagen = ""; //variavel para criar o caminho da imagem
        //string pasta_imagem2 = "";
        Image img_fundo; //carreguei a imagem dentro dessa string e posso usa-la aonde quiser como img_fundo

        //imagem para o botao (botao personalizado)
        Image img_normal; //imagem do botao normal
        Image img_high; //imagem do botao ao passar o mouse por cima
        Image img_disabled; //imagem do botao quando esta inativo

        //===========================================================

        //*coordenadas para imagem em movimento, utilizando o metodo "Desenhar"
        //int x = 40;

        //*coordenadas para a imagem se movimentar e ao bater nas laterais ela vai para outro lado
        //*igual a tela de DVD
        //int x = 50;
        //int y = 50;
        //int velocidade_x = 10;
        //int velocidade_y = 10;

        //===========================================================

        //*utilizando a cl_bola(classe) para criar o objeto bola
        int largura;
        int altura;
        List<cl_bola> BOLAS = new List<cl_bola>();

        //===========================================================
        public Form1()
        {
            InitializeComponent();//não esquecer de colocar + nome da pasta que esta dentro do debug que contem as imagens @"\imagen\
            pasta_imagen = Application.StartupPath + @"\imagen\"; //aqui o sistema vai pegar a variavel e transformar em caminho para a imagem
                                                                  //com isso acima quando o cliente fazer o dowload nao havera problema com o caminho da imagen

            //pasta_imagem2 = Application.StartupPath + @"\gif\";

            //carregamento da imagem de fundo
            // MessageBox.Show(pasta_foto); // para ver qual é o caminho da pasta que esta dando

            //quando criar um objeto Image não precisar por new image, pode fazer tudo direto
            //não podemos simplesmente por o caminho da pasta ali no FromFile() pois se algum cliente faz o download do projeto a pasta pode nao ser a mesma
            img_fundo = Image.FromFile(pasta_imagen + "foto_1.jpg"); //por o nome exatamente igual
            //this.BackgroundImage = img_fundo; //imagem de fundo do formulario
            //pic_teste.BackgroundImage = img_fundo; //carregar a imagem na picturebox


            //===========================================================
            //*rectangle engloba ponto x e y , altura e largua
            //*para saber a altura, a largua e o ponto x e y
            //Rectangle rec = pic_teste.Bounds;
            //MessageBox.Show(rec.X.ToString() + " - " +
            //rec.Y.ToString() + " - " +
            //rec.Width.ToString() + " - " +
            //rec.Height.ToString());

            //===========================================================
            //* imagem do botao (botao personalizado)
            //* lembrando que não é um botao usado e sim uma picturebox para botao estilizado
            img_normal = Image.FromFile(pasta_imagen + @"btn_normal.png");
            img_high = Image.FromFile(pasta_imagen + @"btn_high.png");
            img_disabled = Image.FromFile(pasta_imagen + @"btn_disabled.png");

             
            //===========================================================
            //*saber altura e largura da imagem
            //int largura = img_fundo.Width;
            //int altura = img_fundo.Height;
            //MessageBox.Show(string.Format("largura: {0} | altura: {1}", largura, altura));


            //*outra forma de saber altura e largura da imagem mais detalhado
            //size = estrutura de valor "inteiro"
            //sizeF = estrutura de valor flutuante (com casa decimais) F de "float"
            //Point = Localização X e Y (location)
            //X = Horizontal -
            //Y = Vertical |

            // SizeF dimensao = img_fundo.PhysicalDimension;
                        
        }
        //===========================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            //não importar imagens pelas propriedades ao lado >>>
            //ir na pasta do projeto e criar uma pasta dentro do bin > Debug > criar pasta "imagens"
            //para assim com o codigo chamar as imagens
            //e o mais correto a fazer 
            //Location o X = é o numero de pixel na horizontal sempre contando do canto superior esquerdo para o direito
            //Location o Y = é o numero de pixel na vertical sempre contando do canto superior esquerdo para baixo


            //Point \/
            //int x = pic_teste.Location.X;
            //int y = pic_teste.Location.Y;

            //MessageBox.Show(string.Format(" X: {0} | Y:{1}", x, y));
            //localizar o x e y da imagem (aonde ela esta exemplo posição x=100, posição y = 50)

            
            //===========================================================

            //*botao personalizado
            btn_teste.BackColor = Color.Transparent; //coloquei aqui o trasnparente pois alterei a cor pra vinho para saber aonde ta a picturebox
            btn_teste.BackgroundImage = img_normal;
            //para que quando o mouse passar por cima fazer um evento "MouseEnter"

            //--------------------------------------------
            //* variaveis da cl_bola para saber altura e largura do picturebox
            //* como eu defini o width e height como pic_teste automaticamente ele vai dar a altura e largura
            largura = pic_teste.Width;
            altura = pic_teste.Height;

                    }
        //===========================================================
        private void pic_teste_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("PictureBox clicada"); //ao clicar na picturebox ela aparece a mensagem
        }
        //===========================================================
        private void pic_teste_MouseClick(object sender, MouseEventArgs e)
        {
            //evento MouseClick
            //para clicar e arrasta e outras funcionalidades
            //e. e veja as funções
        }
        //===========================================================
        private void button1_Click(object sender, EventArgs e)
        {
            //*quando eu clicar no botao ele vai mover a picturebox de lugar (mudar a location)
            //pic_teste.Location = new Point(310, 12); //vai do lado esquerdo para o lado direito


            //*fazer o botao2 ficar certinho em cima da quina do lado esquerdo da picturebox
            //Rectangle r = pic_teste.Bounds;
            //button2.Location = new Point(r.X, r.Y);

            //*fazer o botao2 ficar certinho ao lado da quina do lado diretio da picturebox
            //Rectangle r = pic_teste.Bounds;
            //button2.Location = new Point(r.Right, r.Y);

            //*fazer o botao2 ficar certinho em baixo da quina do lado direito da picturebox
            //Rectangle r = pic_teste.Bounds;
            //button2.Location = new Point(r.Right, r.Bottom);

            //*fazer o botao2 ficar certinho em baixo da quina do lado esquerdo da picturebox
            //Rectangle r = pic_teste.Bounds;
            //button2.Location = new Point(r.X, r.Bottom);

            //*fazer o botao2 ficar centralizado na picturebox
            //Rectangle r_pic = pic_teste.Bounds;
            //Rectangle r_but = button2.Bounds;

            //button2.Location = new Point(r_pic.X + r_pic.Width / 2 - r_but.Width / 2,
            //                             r_pic.Y + r_pic.Height /2 - r_but.Height /2);
            
        }
        //===========================================================
        private void btn_teste_MouseEnter(object sender, EventArgs e)
        {
            //*evento do botao personalizado (evento MouseEnter)
            //*quando o mouse passar por cima do botão ele vai ficar mais com efeito mais claro
            btn_teste.BackgroundImage = img_high;
        }
        //===========================================================
        private void btn_teste_MouseLeave(object sender, EventArgs e)
        {
            //*evento do botao personalizado (evento MouseLeave)
            //*ao tirar o mouse de cima do botão ele deixa de ficar com o efeito claro
            btn_teste.BackgroundImage = img_normal;
        }
        //===========================================================
        private void button3_Click(object sender, EventArgs e)
        {
            //*botão personalizado
            //ativa ou desativa o btn_teste(a picturebox transformada em botao)
            if (btn_teste.Enabled)
                btn_teste.Enabled = false;
            else
                btn_teste.Enabled = true;
        }
        //===========================================================
        private void btn_teste_Click(object sender, EventArgs e)
        {
            //===========================================================
            #region cria o objeto para desenhar e observações importantes
            //*criar uma folha em branco para desenho
            //*Bitmap = imagem livre(sem) de contudo
            //*backbuffer = tecnologia directx é uma imagem que fica na memoria do pc que constroi as imagens para que pc lentos não veja em frames a contrução dela
            //*backbuffer = só quando a imagem é criada em segundo plano que é apresentada para o monitor
            Bitmap imgback = new Bitmap(pic_teste.Width, pic_teste.Height);//imagem que vai ter as mesmas dimensoes que o picturebox pic_teste
            Graphics desenhador = Graphics.FromImage(imgback);// comando para realizar desenho no imgback
            //*coloca uma cor de fundo a imagem
            desenhador.Clear(Color.White);
            #endregion
            //===========================================================

            //===========================================================
            #region observações importantes
            //*desenhar um retangulo na imagem (imagem é a picturebox pic_teste)
            //*Brush = pincel, temos que definir que pincel que é solid ou outro (somente brush da erro)
            //*using que ativa o brush "using System.Drawing.Drawing2D;"
            #endregion
            //===========================================================

            //===========================================================
            #region desenha um quadrado com cor gradiente ou linhas de uma só cor
            //Rectangle rect = new Rectangle(50, 50, 100, 80);

            //*fazer a linha de uma só cor
            //Pen lapis = new Pen(new SolidBrush(Color.Green)); //a linha em volta vai ficar verde (uma só cor)

            //*fazer gradiente (começa vermelho o meio tem laranja e termina no amarelo)
            //Pen lapis = new Pen(new LinearGradientBrush
            //                    (new Point(0,10), //50+80 = 130 (o new point (0,10) é da linha de cima
            //                    new Point(0,140), //porém tem 20 de largura do width 20 o new point(0,140) é da linha debaixo
            //                    Color.Red, //começa vermelho o meio vai ser larajna pela junção do vermeho mais amarelo
            //                    Color.Yellow)); //começa por uma cor o meio tem outra e no final outra (exemplo começa pelo vermelho, no meio tem laranja e no final amarelo)
            //lapis.Width = 20;
            //desenhador.DrawRectangle(lapis, rect);

            #endregion
            //===========================================================

            //===========================================================
            #region desenha um retangulo
            //Pen lapis = new Pen(Color.Black, 3);
            //desenhador.DrawRectangle(lapis, new Rectangle(50, 80, 300, 80));
            //desenhador.DrawRectangle(lapis, new Rectangle(80, 30, 70, 280));
            #endregion
            //===========================================================

            //===========================================================
            #region desenhar uma ciruculo (circunferencia) e um quadrado por cima
            //Pen lapis = new Pen(Color.Black, 3);
            //Pen lapis_vermelho = new Pen(Color.Red, 3);
            //* importante, a ordem que é colocado os desenhos 
            //* no exemplo abaixo vimos o retangulo ficar por cima do circulo

            //desenhador.DrawEllipse(lapis, new Rectangle(100, 10, 200, 200));

            //*para mostrar o circulo dentro de um quadrado
            //desenhador.DrawRectangle(lapis_vermelho, new Rectangle(100, 10, 200, 200));
            #endregion
            //===========================================================

            //===========================================================
            #region desenhar uma linha horizontal
            //*desenhar uma linha (horizontal -)
            //Pen lapis = new Pen(Color.Black, 3);
            //desenhador.DrawLine(lapis, new Point(50, 100), new Point(350, 100));
            //*(50,100) ponto de origem da linha
            //*(350,100) ponto que termina a linha
            //*Y = 100
            //*X = 50/350
            #endregion
            //===========================================================

            //===========================================================
            #region desenhar uma linha vertical
            //*desenha uma linha na vertical |
            //Pen lapis = new Pen(Color.Black, 3);
            //desenhador.DrawLine(lapis, new Point(100, 10), new Point(100, 1500));
            #endregion
            //===========================================================

            //===========================================================
            #region desenhar uma linha obliqua
            //*desenha uma linha obliqua
            //Pen lapis = new Pen(Color.Black, 3);
            //desenhador.DrawLine(lapis, new Point(20, 20), new Point(250, 250));
            #endregion
            //===========================================================

            //===========================================================
            #region usando numeros negativos na linha
            //* é preciso tomar cuidado pois pontos negativos sai fora do picturebox
            //Pen lapis = new Pen(Color.Black, 3);
            //desenhador.DrawLine(lapis, new Point(-80, -180), new Point(200, 200));
            #endregion
            //===========================================================

            //===========================================================
            #region desenhar varias linhas de uma só vez
            //*da para utilizar inteiros e flutuantes
            //*criar um objeto de arrays Point
            //*lembrando que esse sistema de points precisa ser bem calculado para fazer um bom desenho
            //Pen lapis = new Pen(Color.Black, 3);
            //Point[] pontos = new Point[] 
            //{
            //    new Point(50,50), //horizontal - 1ºlinha
            //    new Point(100,80), //horizontal - 2ºlinha
            //    new Point(100,150), //vertical - 3ºlinha
            //    new Point(400,150), //horizontal - 4ºlinha
            //    new Point(200,200), //diagonal para traz - 5ºlinha
            //    new Point(200, 20) //vertical - 6ºlinha

            //};
            //desenhador.DrawLines(lapis, pontos);

            #endregion
            //===========================================================

            //===========================================================
            #region utilizandao o fill (para preencher) (fazendo em gradiente)
            //*brush é um pincel e nos devemos definir qual é (grosso,fino, etc..)
            //Brush pincel = new SolidBrush(Color.Red);

            //Brush pincel1 = new LinearGradientBrush(new Point(0, 10),
            //new Point(0, 120),
            //Color.Red,
            //Color.Yellow);

            //Brush pincel2 = new LinearGradientBrush(new Point(0, 10),
            //new Point(0, 130),
            //Color.Yellow,
            //Color.Red);



            //*preenche todo o quadrado
            //desenhador.FillRectangle(pincel, new Rectangle(50, 50, 100, 100));

            //*faz ficar gradiente
            //desenhador.FillRectangle(pincel1, new Rectangle(0, 10, 1000, 100));
            //desenhador.FillRectangle(pincel2, new Rectangle(0, 140, 1000, 150));

            //--------------------------------------------------------

            //*3 quadrados para faer um efeito gradiente
            //Brush pincel1 = new SolidBrush(Color.Red);
            //Brush pincel2 = new LinearGradientBrush(new Point(150, 50),
            //                                        new Point(250, 50),
            //                                        Color.Red,
            //                                        Color.Yellow);
            //Brush pincel3 = new SolidBrush(Color.Yellow);

            //desenhador.FillRectangle(pincel1, new Rectangle(10, 50, 100, 250));
            //desenhador.FillRectangle(pincel2, new Rectangle(50, 50, 100, 250));
            //desenhador.FillRectangle(pincel3, new Rectangle(150, 50, 100, 250));

            //--------------------------------------------------------

            //*desenha um circulo com seu interior preenchido com a cor escolhida abaixo
            // Brush pincel1 = new SolidBrush(Color.Black);
            // desenhador.FillEllipse(pincel1, new Rectangle(10, 10, 150, 150));
            #endregion
            //===========================================================

            //===========================================================
            #region desenha um retangulo com bordas
            //*desenha um retangulo com bordas
            //Pen lapis = new Pen(Color.Black, 3);
            //Rectangle rec = new Rectangle(10, 10, 150, 150);
            //Brush pincel = new SolidBrush(Color.Blue);
            //desenhador.FillRectangle(pincel, rec);
            //desenhador.DrawRectangle(lapis, rec);
            #endregion
            //===========================================================

            //===========================================================
            #region desenhar texto, desenhar texto com sombra, desenhar um retangulo com texto dentro
            //*desenhar texto
            //*criar variaveis abaixo para facilitar
            //string texto = "Free Society ";
            //Font letra = new Font("Ink Free", 20, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Pixel);
            //Brush cor_principal = new SolidBrush(Color.FromArgb(25,216,249));
            //Brush cor_sombra = new SolidBrush(Color.Black);
            //Point inicio = new Point(10, 10);//2 pontos para as duas cores
            //Point inicio_sombra = new Point(12, 12);//se fosse 1 cor só seria só 1 ponto
            //*se eu quise a sombra com sentido para cima colocar maior que 10 (12)
            //*se eu quise a sombra com sentido para baixo colocar menor que 10 (8)

            //desenhador.DrawString(texto, letra, cor_principal,inicio );
            //desenhador.DrawString(texto, letra, cor_sombra, inicio_sombra);

            //--------------------------------------------------------------

            //*desenhar o texto em varias linhas
            //*cuidado se o retangulo for muito pequeno ele vai cortar o texto.
            //*para alinhar o texto usar stringFormat
            //Pen lapis = new Pen(Color.Black, 3);
            //string texto = "Free Society";
            //Brush cor = new SolidBrush(Color.Black);
            //Font letra = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
            //Rectangle rec = new Rectangle(10, 10, 180, 150);

            //StringFormat formato = new StringFormat();
            //*alinhar o stringFormat na horizontal (near = perto, far = longe, center = centro)
            //formato.Alignment = StringAlignment.Center; //aqui mesmo usando near, ou far, ou center ele vai ficar na linha de cima
            //*para que ele fique alinhado em outras linhas usar esse codigo \/ (vertical)
            //formato.LineAlignment = StringAlignment.Center; //ou seja se eu colocar center nos dois ele fica no meio do retangulo

            //desenhador.DrawRectangle(lapis, rec);
            //desenhador.DrawString(texto, letra, cor, rec,formato); //colocar o formato aqui
            #endregion
            //===========================================================

            //===========================================================
            #region Apresentar, cortar imagens, imagem com fundo transparente
            //*lembrando que o objeto esta criado na 1 region de exemplo
            //*cortar imagem

            //Image original = Image.FromFile(pasta_imagen + "Foto_1.jpg");

            //*cortar e colar uma parte da imagen
            //*destRect = area retangular de destino
            //*srcRect = area do source "fonte"          
            //*10,10 ponto x e y

            //desenhador.DrawImage(original, new Rectangle(10, 10, 100, 200), //100 largura, 200 altura
            //new Rectangle(100, 90, 150, 240), //100 esquerda, 90 embaixo, 150 direta, 240 em cima
            //GraphicsUnit.Pixel);

            //--------------------------------------------------------------------

            //*a imagem da bola tem o fundo transparente !!

            //Image bola = Image.FromFile(pasta_imagen + "bola_pequena.png");
            //desenhador.DrawImage(bola, new Rectangle(100, 100, 50, 50), new Rectangle(0, 0, 50, 50),GraphicsUnit.Pixel);
            #endregion
            //===========================================================

            //===========================================================
            #region apresenta a imagem criada no picturebox
            //*apresenta a imagem final no picturebox
            pic_teste.BackgroundImage = imgback;
            #endregion
            //===========================================================

            
            
        }
        //===========================================================
        private void btn_teste_EnabledChanged(object sender, EventArgs e)
        {
            //*botão personalizado (evento EnableChanged)
            //*sempre que o botão tiver desativado ele vai mostrar a imagem img_disabled
            //*sempre que o botao tiver ativado ele vai mostar a imagem img_high
            if (btn_teste.Enabled)
                btn_teste.BackgroundImage = img_normal;
            else
                btn_teste.BackgroundImage = img_disabled;

        }
        //=================================================================
        private void Desenhar()
        {
            Bitmap imgback = new Bitmap(pic_teste.Width, pic_teste.Height);
            Graphics desenhador = Graphics.FromImage(imgback);
            Image bola = Image.FromFile(pasta_imagen + "bola_pequena.png");

            desenhador.Clear(Color.Black);

            //*faz animaçao com a bola
            //desenhador.DrawImage(bola, new Rectangle(x, 10, 48, 48), new Rectangle(0, 0, 50, 50), GraphicsUnit.Pixel);

            //-------------------------------------------------------------------

            //*faz a bola fica flutuando e ao bater na berada da tela ela vai para outra direção
            //*parecido com o DVD
            //desenhador.DrawImage(bola, new Rectangle(x, y, 50, 50), new Rectangle(0, 0, 50, 50), GraphicsUnit.Pixel);

            //-------------------------------------------------------------------
            //*criando o codigo acima /\ em classe (cl_bola)
            //*cria um ciclo que percorre todas as bolas existente
            foreach(cl_bola bola1 in BOLAS)
            {
                bola1.mover(largura, altura);
                desenhador.DrawImage(bola,
                                     new Rectangle(bola1.x, bola1.y, 50, 50),
                                     new Rectangle(0, 0, 50, 50),
                                     GraphicsUnit.Pixel);
            }


            pic_teste.BackgroundImage = imgback;
        }
        //=================================================================
        private void button4_Click(object sender, EventArgs e)
        {
            //*botão para criar animações com o metodo "desenhar" criado acima
            //*o metodo desenhar ele tem todos os elementos do objeto criado la em cima
            //*coordenadas criada la em cima na "public partial class Form1 : Form"

            //*preciso por o x +=10 pois ele esta criado la em cima como int x = 40;
            //*ou seja sempre que clicar no botao ele vai atribuir +10 e vai fazer a bola "andar"
            //*para alterar a velocidade em que ela anda é só aumentar de 10 para 20 ou para mais
            //x += 10;
            //Desenhar();

            //-------------------------------------------------------------------

            //*fazer a bola andar sem ter que fica clicando
            //*para fazer com que ela ande sem clicar no botão é necessario ir na caixa de ferramentas e incluir o "timer"
            //*timer 1000 milesimos = 1 segundo
            //*clicar no evento "tick" e colocar o codigo x += 10 e o metodo Desenhar

            //tempo.Enabled = true;

            //-------------------------------------------------------------------

            //*faz a bola fica flutuando e ao bater na berada da tela ela vai para outra direção
            //*parecido com o DVD

            //tempo.Enabled = true;

            //------------------------------------------------------------

            //*ao clicar adicionar uma nova bola

            cl_bola b = new cl_bola();
            BOLAS.Add(b);
            tempo.Enabled = true;


        }
        //=================================================================
        private void tempo_Tick(object sender, EventArgs e)
        {
            #region evento que move a imagem clicando no botao
            //*evento que move a imagem de milesimo em milesimo
            //x += 10;
            //Desenhar();

            //*quando chegar nos 500 de largura a bola para (desliga por conta do enabled false)
            //if (x >= 500)
            //tempo.Enabled = false;
            #endregion

            //---------------------------------------------------------------------

            #region evento que faz a imagem ficar batendo nas bordas tipo DVD(sem ter que aperta botao)
            //*faz a bola fica flutuando e ao bater na berada da tela ela vai para outra direção
            //*parecido com o DVD
            //x += velocidade_x;
            //y += velocidade_y;

            //*colisoes (antes verificar qual direção ela esta indo e aonde ela toca primeiro)
            //*detecta colisão com o fundo
            //* 50 = pois é a altura que eu defini ali no rectangle
            
            //if (y + 50 >= pic_teste.Height)
            //velocidade_y = - velocidade_y; //aqui iremos inverter sua tragetoria

            //*detecta a colisao no topo
            //if (y <= 0)
            //velocidade_y = - velocidade_y; //quando a bola subuir com -10,-10, a hora que chegar no topo 0 ele vai bater em outro negativo e vai ficar positivo +10 

            //*detecta a colisao na esquerda
            //if (x <= 0)
            //velocidade_x = - velocidade_x;

            //*detecta a colisao na direita
            //if (x + 50 >= pic_teste.Width)
            //velocidade_x = - velocidade_x;


            //Desenhar();


            //*faz colisao só que com varias bolas e utilizando classe(cl_bola)
            //*da para fazer com 1 bola só tambem




            Desenhar();



            #endregion
        }
    }
}
