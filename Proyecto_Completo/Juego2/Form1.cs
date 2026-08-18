using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Juego2
{
    public partial class Form1 : Form
    {
       
        // FONDO
        

        PictureBox[] stars;
        int backgroundSpeed;


        // PLAYER


        int playerSpeed;


        
        // ALEATORIO
        

        Random rnd;

        // MUNICIONES Etapa 3


        PictureBox[] municiones;
        int municionesSpeed;


        //Etapa 4 Enemigos
        PictureBox[] enemigos;
        int enemigosSpeed;

        // CONSTRUCTOR


        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;

            // Fondo
            MoverBgTimer.Tick -= MoverBgTimer_Tick;
            MoverBgTimer.Tick += MoverBgTimer_Tick;

            // Teclado
            this.KeyDown -= Form1_KeyDown;
            this.KeyDown += Form1_KeyDown;

            this.KeyUp -= Form1_KeyUp;
            this.KeyUp += Form1_KeyUp;

            //Municiones 3


            MoverMunicion.Tick -= MoverMunicion_Tick;
            MoverMunicion.Tick += MoverMunicion_Tick;

            //Enemigos 4
            MoverEnemigos.Tick -= MoverEnemigos_Tick;
            MoverEnemigos.Tick += MoverEnemigos_Tick;
        }


        // INICIO
        

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundSpeed = 4;
            playerSpeed = 5;

            // Velocidad de las municiones
            municionesSpeed = 20;

            //Velocidad de los enemigos
            enemigosSpeed = 3;

            rnd = new Random();

            CrearFondo();

            ConfigurarPlayer();

            // Crear municiones
            CrearMuniciones();

            // Timer del fondo
            MoverBgTimer.Interval = 20;
            MoverBgTimer.Start();

            // Timer de municiones
            MoverMunicion.Interval = 20;
            MoverMunicion.Start();


            //Crear enemigos etapa 4
            CrearEnemigos();

            MoverEnemigos.Interval = 20;
            MoverEnemigos.Start();



        }



        // FONDO


        private void CrearFondo()
        {
            stars = new PictureBox[20];

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();

                stars[i].Size =
                    new Size(3, 3);

                stars[i].BackColor =
                    Color.White;

                stars[i].BorderStyle =
                    BorderStyle.None;

                stars[i].Location =
                    new Point(
                        rnd.Next(
                            0,
                            this.ClientSize.Width
                        ),
                        rnd.Next(
                            0,
                            this.ClientSize.Height
                        )
                    );

                this.Controls.Add(stars[i]);
            }
        }


        // PLAYER
        

        private void ConfigurarPlayer()
        {
            Player.Visible = true;

            Player.BringToFront();
        }


      
        // MOVIMIENTO DEL FONDO
        

        private void MoverBgTimer_Tick(
            object sender,
            EventArgs e)
        {
            for (int i = 0;
                i < stars.Length;
                i++)
            {
                stars[i].Top += backgroundSpeed;

                if (stars[i].Top >=
                    this.ClientSize.Height)
                {
                    stars[i].Top =
                        -stars[i].Height;

                    stars[i].Left =
                        rnd.Next(
                            0,
                            this.ClientSize.Width
                        );
                }
            }

            Player.BringToFront();
        }


        
        // TECLADO
        
        private void Form1_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                DerechaTimer.Start();
            }

            if (e.KeyCode == Keys.Left)
            {
                IzquierdaTimer.Start();
            }

            if (e.KeyCode == Keys.Up)
            {
                ArribaTimer.Start();
            }

            if (e.KeyCode == Keys.Down)
            {
                AbajoTimer.Start();
            }

            //Disparar
            if (e.KeyCode == Keys.Space)
            {
                Disparar();
            }
        }


        private void Form1_KeyUp(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                DerechaTimer.Stop();
            }

            if (e.KeyCode == Keys.Left)
            {
                IzquierdaTimer.Stop();
            }

            if (e.KeyCode == Keys.Up)
            {
                ArribaTimer.Stop();
            }

            if (e.KeyCode == Keys.Down)
            {
                AbajoTimer.Stop();
            }
        }


      
        // DERECHA
      

        private void DerechaTimer_Tick(
            object sender,
            EventArgs e)
        {
            if (Player.Right <
                this.ClientSize.Width)
            {
                Player.Left += playerSpeed;
            }
        }


        
        // IZQUIERDA
       

        private void IzquierdaTimer_Tick(
            object sender,
            EventArgs e)
        {
            if (Player.Left > 0)
            {
                Player.Left -= playerSpeed;
            }
        }


        
        // ARRIBA
       

        private void ArribaTimer_Tick(
            object sender,
            EventArgs e)
        {
            if (Player.Top > 0)
            {
                Player.Top -= playerSpeed;
            }
        }


       
        // ABAJO
        

        private void AbajoTimer_Tick(
            object sender,
            EventArgs e)
        {
            if (Player.Bottom <
                this.ClientSize.Height)
            {
                Player.Top += playerSpeed;
            }
        }

        //MUNICIONES
        private void CrearMuniciones()
        {
            municiones = new PictureBox[3];

            string rutaMunicion =
                Path.Combine(
                    Application.StartupPath,
                    "Asserts",
                    "munition.png"
                );

            Image municionImagen =
                Image.FromFile(rutaMunicion);

            for (int i = 0;
                i < municiones.Length;
                i++)
            {
                municiones[i] =
                    new PictureBox();

                municiones[i].Size =
                    new Size(8, 8);

                municiones[i].Image =
                    municionImagen;

                municiones[i].SizeMode =
                    PictureBoxSizeMode.Zoom;

                municiones[i].BorderStyle =
                    BorderStyle.None;

                municiones[i].Visible =
                    false;

                this.Controls.Add(
                    municiones[i]
                );
            }

            Player.BringToFront();
        }


        //Disparar 3
        private void Disparar()
        {
            for (int i = 0;
                i < municiones.Length;
                i++)
            {
                if (!municiones[i].Visible)
                {
                    municiones[i].Left =
                        Player.Left +
                        Player.Width / 2 -
                        municiones[i].Width / 2;

                    municiones[i].Top =
                        Player.Top -
                        municiones[i].Height;

                    municiones[i].Visible =
                        true;

                    break;
                }
            }
        }


        private void MoverMunicion_Tick(object sender,EventArgs e)
        {
            for (int i = 0;
        i < municiones.Length;
        i++)
            {
                if (municiones[i].Visible)
                {
                    // Mover munición hacia arriba
                    municiones[i].Top -=
                        municionesSpeed;


                    // Si sale de la pantalla
                    if (municiones[i].Bottom < 0)
                    {
                        municiones[i].Visible =
                            false;
                    }
                }
            }


            for (int i = 0;
        i < municiones.Length;
        i++)
            {
                if (municiones[i].Visible)
                {
                 
                    // MOVER MUNICIÓN HACIA ARRIBA
                  

                    municiones[i].Top -=
                        municionesSpeed;


                    
                    // COLISIÓN MUNICIÓN - ENEMIGO
                  

                    for (int j = 0;
                        j < enemigos.Length;
                        j++)
                    {
                        if (
                            municiones[i].Visible &&
                            enemigos[j].Visible &&
                            municiones[i].Bounds.IntersectsWith(
                                enemigos[j].Bounds
                            )
                        )
                        {
                            
                            // OCULTAR MUNICIÓN
                          

                            municiones[i].Visible =
                                false;


                            
                            // OCULTAR ENEMIGO
                            

                            enemigos[j].Visible =
                                false;


                            // REAPARECER ENEMIGO ARRIBA
                      

                            enemigos[j].Top =
                                -enemigos[j].Height;

                            enemigos[j].Left =
                                rnd.Next(
                                    20,
                                    this.ClientSize.Width - 70
                                );


                         
                            // VOLVER A MOSTRAR ENEMIGO
                        

                            enemigos[j].Visible =
                                true;


                            // Salir del ciclo de enemigos
                            break;
                        }
                    }


                 
                    // SI LA MUNICIÓN SALE DE LA PANTALLA
                   

                    if (municiones[i].Bottom < 0)
                    {
                        municiones[i].Visible =
                            false;
                    }
                }
            }
        }




        private void CrearEnemigos()
        {
            enemigos =
                new PictureBox[6];

            Image enemigo1 =
                Image.FromFile(
                    @"Asserts\Boss1.png"
                );

            Image enemigo2 =
                Image.FromFile(
                    @"Asserts\Boss2.png"
                );

            for (int i = 0;
                i < enemigos.Length;
                i++)
            {
                enemigos[i] =
                    new PictureBox();

                enemigos[i].Size =
                    new Size(50, 50);

                if (i % 2 == 0)
                {
                    enemigos[i].Image =
                        enemigo1;
                }
                else
                {
                    enemigos[i].Image =
                        enemigo2;
                }

                enemigos[i].SizeMode =
                    PictureBoxSizeMode.Zoom;

                enemigos[i].Location =
                    new Point(
                        50 + i * 80,
                        -50 - i * 70
                    );

                this.Controls.Add(
                    enemigos[i]
                );
            }

            Player.BringToFront();
        }

        private void MoverEnemigos_Tick(
    object sender,
    EventArgs e)
        {
            for (int i = 0;
        i < enemigos.Length;
        i++)
            {
                if (!enemigos[i].Visible)
                {
                    continue;
                }


       
                // MOVER ENEMIGO HACIA ABAJO
               

                enemigos[i].Top +=
                    enemigosSpeed;


         
                // COLISIÓN ENEMIGO - PLAYER
              

                if (
                    Player.Visible &&
                    enemigos[i].Bounds.IntersectsWith(
                        Player.Bounds
                    )
                )
                {
                    DestruirJugador();

                    return;
                }


              
                // SI EL ENEMIGO SALE DE LA PANTALLA
              

                if (
                    enemigos[i].Top >=
                    this.ClientSize.Height
                )
                {
                    enemigos[i].Top =
                        -enemigos[i].Height;

                    enemigos[i].Left =
                        rnd.Next(
                            20,
                            this.ClientSize.Width - 70
                        );
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void DestruirJugador()
        {
           
            // OCULTAR PLAYER
            

            Player.Visible =
                false;


           
            // DETENER MOVIMIENTO DEL PLAYER
     

            DerechaTimer.Stop();
            IzquierdaTimer.Stop();
            ArribaTimer.Stop();
            AbajoTimer.Stop();


            // DETENER ENEMIGOS
            

            MoverEnemigos.Stop();


            
            // DETENER MUNICIONES
         

            MoverMunicion.Stop();


            
            // DETENER FONDO
            

            MoverBgTimer.Stop();


            
            // GAME OVER
          

            MessageBox.Show(
                "¡Game Over!",
                "Galaga",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

    }




}
