using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    

    /// <summary>
    /// Главный класс в котором реализуются все функции игры.
    /// </summary>
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();  //создание списка circle для  змейки
        private Circle food = new Circle(); // создание подкласса circle еда


        /// <summary>
        /// Инициализация формы и задание свойств таймера
        /// </summary>
    
        public Form1()
        {
            InitializeComponent();

            new Settings();

            gameTimer.Interval = 1000/Settings.Speed;
            gameTimer.Tick += updateSreen;
            gameTimer.Start();

            startGame();
        }


        /// <summary>
        ///Обновление экрана взависимости от нажатия клавиш
        /// </summary>
        public void updateSreen(object sender, EventArgs e) 
        {
            if (Settings.EndGame == true)
            {
                if (Input.KeyPress (Keys.Enter))
                {
                    startGame();
                }
            }

            else
            {
                if (Input.KeyPress(Keys.Right) && Settings.direction != Directions.Left)
                {
                    Settings.direction = Directions.Right;
                }
                else if (Input.KeyPress(Keys.Left) && Settings.direction != Directions.Right)
                {
                    Settings.direction = Directions.Left;
                }
                else if (Input.KeyPress(Keys.Up) && Settings.direction != Directions.Down)
                {
                    Settings.direction = Directions.Up;
                }
                else if (Input.KeyPress(Keys.Down) && Settings.direction != Directions.Up)
                {
                    Settings.direction = Directions.Down;
                }
                movePlayer();
            }
            pbCanvas.Invalidate();//обновление pbcanvas
        }


        /// <summary>
        ///Движение змейки, столкновение с едой,ограничение поля 
        /// </summary>
        public void movePlayer()
        {
            for (int i = Snake.Count - 1;i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Directions.Right:
                            Snake[i].X++;
                            break;
                        case Directions.Left:
                            Snake[i].X--;
                            break;
                        case Directions.Up:
                            Snake[i].Y--;
                            break;
                        case Directions.Down:
                            Snake[i].Y++;
                            break;
                    }

                    int maxXpos = pbCanvas.Size.Width / Settings.Widht;
                    int maxYpos = pbCanvas.Size.Height / Settings.Height;

                    if (
                        Snake[i].X <0 || Snake[i].Y<0||
                        Snake[i].X >maxXpos|| Snake[i].Y>maxYpos
                        )
                    {
                        die();
                    }

                    for (int j=1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            die();
                        }
                    }

                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        eat();
                    }

                }

                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }


        /// <summary>
        ///Функция определения нажатия клавиши вниз
        /// </summary>
        public void keyisdown(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, true);
        }

        /// <summary>
        ///Функция определения нажатия клавиши вверх
        /// </summary>
        public void keyisup(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, false);
        }

        /// <summary>
        ///Функция графического определения змейки,еды,проигрыша
        /// </summary>
        public void updateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (Settings.EndGame == false)
            {
                Brush snakeColour;

                for (int i=0;i<Snake.Count; i++)
                {
                    if(i == 0)
                    {
                        snakeColour = Brushes.Black;
                    }
                    else
                    {
                        snakeColour = Brushes.DarkViolet;
                    }
                    //рисуем змейку
                    canvas.FillEllipse(snakeColour,
                                        new Rectangle(
                                            Snake[i].X * Settings.Widht,
                                            Snake[i].Y * Settings.Height,
                                            Settings.Widht, Settings.Height
                                            ));

                    canvas.FillEllipse(Brushes.Red,
                                        new Rectangle(
                                            food.X * Settings.Widht,
                                            food.Y * Settings.Height,
                                            Settings.Widht, Settings.Height
                                            ));
                }
            }
            else
            {
                string gameOver = "Вы проиграли :( \n" + "Вы набрали: " + Settings.Score + " очков "+ "\nНажмите Enter,"+ "\nчтобы начать заново \n";
                label3.Text = gameOver;
                label3.Visible = true;
            }


        }


        /// <summary>
        ///Функция  обновления параметров для новой игры
        /// </summary>
        public void startGame()
        {
            label3.Visible = false;
            new Settings();
            Snake.Clear();
            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head);

            label2.Text = Settings.Score.ToString();
            generateFood();
        }


        /// <summary>
        ///Функция рандомного появления еды
        /// </summary>
        public void generateFood()
        {
            int maxXpos = pbCanvas.Size.Width / Settings.Widht;
            int maxYpos = pbCanvas.Size.Height / Settings.Height;

            Random rnd = new Random();
            food = new Circle { X = rnd.Next(0, maxXpos), Y = rnd.Next(0, maxYpos) };//создаем еду с рандомными x,y
        }


        /// <summary>
        ///Функция столкновения змейки с едой
        /// </summary>
        public void eat()
        {
            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            Snake.Add(body);
            Settings.Score += Settings.Point;
            label2.Text = Settings.Score.ToString();
            generateFood();

        }

        /// <summary>
        ///Функция смерти змейки
        /// </summary>
        public void die()
        {
            Settings.EndGame = true;
        }

       
    }


        
}
