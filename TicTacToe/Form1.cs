using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace TicTacToe
{
    public partial class Form1 : Form
    {

        public enum Player
        {
            X, O
        }

        Player currentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int cpuWinCount = 0;
        List<Button> buttons;

        [TestClass]
        public class TicTacToeTest
        {
            private Form1 form;
            [TestInitialize]
            public void Setup()
            {
                form = new Form1();
            }

            [TestMethod]
            public void PlayerClickButton_Should_Change_Text_To_X()
            {
                var button = form.button1;
                form.PlayerClickButton(button, EventArgs.Empty);
                Assert.AreEqual("X", button.Text);
            }
        }
        public Form1()
        {
            InitializeComponent();
            ResetGame();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CPUmove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled= false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.Pink;
                buttons.RemoveAt(index);
                CheckGame();    
                CPUtimer.Stop();
                     
            }
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;

            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Cyan;
            buttons.Remove(button);
            CheckGame();
            CPUtimer.Start();
        }



        private void ResetGame(object sender, EventArgs e)
        {
            ResetGame();   
        }

        private void CheckGame()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                CPUtimer.Stop();
                MessageBox.Show("Du Vinner");
                playerWinCount++;
                label1.Text = "Dina Poäng: " + playerWinCount;
                ResetGame();
            }

            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {

                CPUtimer.Stop();
                MessageBox.Show("Datorn Vinner");
                cpuWinCount++;
                label2.Text = "Dator Poäng: " + cpuWinCount;
                ResetGame();
            }
        }

        private void ResetGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            foreach (Button x in buttons)
            { 
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }

        }
    }
}
