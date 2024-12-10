using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guessing_game
{
    public partial class FGuessingGame : Form
    {
        static Random random = new Random();
        int randomNumber;
        int attempts;
        bool winner = false;

        public FGuessingGame()
        {
            InitializeComponent();
        }

        private void FGuessingGame_Load(object sender, EventArgs e)
        {
            randomNumber = random.Next(1, 101);
            lblResult.ForeColor = Color.White;
            lblWinner.ForeColor = Color.White;
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            if (winner == false)
            {
                if (int.TryParse(txtGuess.Text, out int guess))
                {
                    attempts++;

                    if (guess > randomNumber)
                    {
                        lblResult.Text = $"Nice try! The number is below your guess";
                        lblResult.ForeColor = Color.Black;
                    }
                    else if (guess < randomNumber)
                    {
                        lblResult.Text = $"Nice try! The number is above your guess";
                        lblResult.ForeColor = Color.Black;
                    }
                    else
                    {
                        lblWinner.Text = $"Congratulations! You guessed the number in {attempts} attempts!";
                        lblWinner.ForeColor = Color.Black;
                        lblResult.ForeColor = Color.White;

                        winner = true;
                        btnGuess.Enabled = false;
                    }
                }
                else
                {
                    lblResult.Text = "Please enter a valid number!";
                    lblResult.ForeColor = Color.Red;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblResult.Text = "Game reset! Try to guess the new number.";
            lblResult.ForeColor = Color.Black;
            lblWinner.Text = string.Empty;
            txtGuess.Clear();
            attempts = 0;
            randomNumber = random.Next(1, 101);
            winner = false;
            btnGuess.Enabled = true;
        }

        private void txtGuess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
