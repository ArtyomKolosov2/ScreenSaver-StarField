﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Stars
{ 
    public partial class StartField : Form
    {
        public StartField(int starAmount, int changeSpeed, Brush [] newBrushes)
        {
            stars = new Star[starAmount];
            Speed = changeSpeed;
            brushes = newBrushes;
            InitializeComponent();
        }

        private int Speed { get; set; }

        private Star[] stars;

        private Random random = new Random();

        private Graphics graphics;

        private Brush [] brushes;

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.Black);

            foreach (var star in stars)
            {
                DrawStar(star);
                MoveStar(star);
            }
            pictureBox1.Refresh();

        }

        private void MoveStar(Star star)
        {
            star.Z -= Speed;
            if (star.Z < 0)
            {
                star.X = random.Next(-pictureBox1.Width, pictureBox1.Width);
                star.Y = random.Next(-pictureBox1.Height, pictureBox1.Height);
                star.Z = random.Next(1, pictureBox1.Width);
            }
        }

        private void DrawStar(Star star)
        {
            
            
            float starSize = Map(star.Z, 0, pictureBox1.Width, 7, 0);
            float x = Map(star.X / star.Z, 0, 1, 0, pictureBox1.Width) + pictureBox1.Width / 2;
            float y = Map(star.Y / star.Z, 0, 1, 0, pictureBox1.Height) + pictureBox1.Height / 2;

            graphics.FillEllipse(star.StarBrush, x, y, starSize, starSize);
        }

        private float Map(float n, float start1, float stop1, float start2, float stop2)
        {
            return ((n - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer1.Interval = 20;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
           
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star()
                {
                    X = random.Next(-pictureBox1.Width, pictureBox1.Width),
                    Y = random.Next(-pictureBox1.Height, pictureBox1.Height),
                    Z = random.Next(1, pictureBox1.Width),
                    StarBrush = brushes[random.Next(brushes.Length)]
                };
            }
            timer1.Start();
        }
    }
    public class Star
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Brush StarBrush { get; set; }
    }
}
