using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private List<Circle> snake = new List<Circle>();
        private Circle food = new Circle();
        public Form1()
        {
            InitializeComponent();

            gameScreen.SizeMode = PictureBoxSizeMode.StretchImage;

            new InitialSettings();

            gameTimer.Interval = 1000 / InitialSettings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            StartGame();
        }

        private void StartGame()
        {
            labelGameOver.Visible = false;

            new InitialSettings();

            snake.Clear();
            Circle head = new Circle();
            head.X = 10;
            head.Y = 5;
            snake.Add(head);

            labelScore.Text = InitialSettings.Score.ToString();
            labelHScore.Text = InitialSettings.HighestScore.ToString();
            GenerateFood();
        }

        private void GenerateFood()
        {
            int maxXPos = gameScreen.Size.Width / InitialSettings.Width;
            int maxYPos = gameScreen.Size.Height / InitialSettings.Height;

            Random random = new Random();
            food = new Circle();
            food.X = random.Next(0, maxXPos);
            food.Y = random.Next(0, maxYPos);
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            if (InitialSettings.GameOver == true)
            {
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
                else if (Input.KeyPressed(Keys.Escape))
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                if (Input.KeyPressed(Keys.Right) && InitialSettings.direction != Direction.Left)
                {
                    InitialSettings.direction = Direction.Right;
                }
                else if (Input.KeyPressed(Keys.Left) && InitialSettings.direction != Direction.Right)
                {
                    InitialSettings.direction = Direction.Left;
                }
                else if (Input.KeyPressed(Keys.Up) && InitialSettings.direction != Direction.Down)
                {
                    InitialSettings.direction = Direction.Up;
                }
                else if (Input.KeyPressed(Keys.Down) && InitialSettings.direction != Direction.Up)
                {
                    InitialSettings.direction = Direction.Down;
                }

                MovePlayer();
            }

            gameScreen.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!InitialSettings.GameOver)
            {
                Brush snakeColour;

                for (int i = 0; i < snake.Count; i++)
                {
                    if (i == 0)
                    {
                        snakeColour = Brushes.Black;
                    }
                    else
                    {
                        snakeColour = Brushes.Red;
                    }

                    canvas.FillEllipse(snakeColour, new Rectangle(snake[i].X * InitialSettings.Width,
                        snake[i].Y * InitialSettings.Height,
                        InitialSettings.Width,
                        InitialSettings.Height));


                    canvas.FillEllipse(Brushes.Yellow, new Rectangle(food.X * InitialSettings.Width,
                        food.Y * InitialSettings.Height,
                        InitialSettings.Width,
                        InitialSettings.Height));
                }
            }
            else
            {
                string gameOver = $"Game Over!\r\nYour final score is: {InitialSettings.Score}\r\nPress Enter to try again or Escape to exit!";
                labelGameOver.Text = gameOver;
                labelGameOver.Visible = true;
            }
        }
        public void MovePlayer()
        {
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (InitialSettings.direction)
                    {
                        case Direction.Up:
                            snake[i].Y--;
                            break;
                        case Direction.Down:
                            snake[i].Y++;
                            break;
                        case Direction.Left:
                            snake[i].X--;
                            break;
                        case Direction.Right:
                            snake[i].X++;
                            break;
                    }

                    int maxXPos = gameScreen.Size.Width / InitialSettings.Width;
                    int maxYPos = gameScreen.Size.Height / InitialSettings.Height;

                    if (snake[i].X < 0 || snake[i].Y < 0 || snake[i].X >= maxXPos || snake[i].Y >= maxYPos)
                    {
                        End();
                    }

                    for (int j = 1; j < snake.Count; j++)
                    {
                        if (snake[i].X == snake[j].X && snake[i].Y == snake[j].Y)
                        {
                            End();
                        }
                    }

                    if (snake[0].X == food.X && snake[0].Y == food.Y)
                    {
                        Eat();
                    }
                }
                else
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }
        }

        private void End()
        {
            InitialSettings.GameOver = true;
        }
        private void Eat()
        {
            Circle food = new Circle();
            food.X = snake[snake.Count - 1].X;
            food.Y = snake[snake.Count - 1].Y;

            snake.Add(food);

            InitialSettings.Score += InitialSettings.Points;
            if (InitialSettings.HighestScore < InitialSettings.Score)
            {
                InitialSettings.HighestScore = InitialSettings.Score;

            }
            labelScore.Text = InitialSettings.Score.ToString();
            labelHScore.Text = InitialSettings.HighestScore.ToString();

            GenerateFood();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeSttae(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeSttae(e.KeyCode, false);
        }

        private void gameScreen_Click(object sender, EventArgs e)
        {

        }
    }
}
