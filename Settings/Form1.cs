using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StarField;

namespace Settings
{
    public partial class Form1 : Form
    {
        private int [] StarAmount = new int[] 
        { 
            1000, 
            2500, 
            5000, 
            7500, 
            10000, 
            15000, 
            20000 
        };

        private int[] ChangeSpeed = new int[]
        {
            10,
            25,
            50,
            75,
            100
        };

        private Brush[] brushes = new Brush[]
        {
            Brushes.Aqua,
            Brushes.White,
            Brushes.Red,
            Brushes.Orange,
            Brushes.Aquamarine,
            Brushes.Blue,
            Brushes.DeepSkyBlue
        };

        private Random random = new Random();
        private List<Brush> brushesToSend;
        private int starAmountToSend;
        private int changeSpeedToSend;
        public Form1()
        {
            InitializeComponent();
            brushesToSend = new List<Brush>();
            starAmountToSend = StarAmount[random.Next(StarAmount.Length)];
            changeSpeedToSend = ChangeSpeed[random.Next(ChangeSpeed.Length)];
        }

        private void AddOneRandomBrush()
        {
            int randomIndex = random.Next(brushes.Length);
            Brush brush = brushes[randomIndex];
            while (brushesToSend.Contains(brush))
            {
                randomIndex = random.Next(brushes.Length);
                brush = brushes[randomIndex];
            }
            checkedListBox1.SetItemChecked(randomIndex, true);
            brushesToSend.Add(brush);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            starAmountToSend = StarAmount[comboBox1.SelectedIndex];
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeSpeedToSend = ChangeSpeed[comboBox2.SelectedIndex];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedIndices.Count < 1)
            {
                AddOneRandomBrush();
            }
            else
            {
                brushesToSend.Clear();
                foreach (int index in checkedListBox1.CheckedIndices)
                {
                    brushesToSend.Add(brushes[index]);
                }
            }
                
            StarField.Form1 StarField = new StarField.Form1
                (
                starAmountToSend,
                changeSpeedToSend,
                brushesToSend
                );
            brushesToSend.Clear();
            StarField.Show();
        }

    }
}
