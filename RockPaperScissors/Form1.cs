using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

/// <summary>
/// A rock, paper, scissors game that utilizes basic methods
/// for repetitive tasks.
/// </summary>

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, cpuChoice;

        int wins = 0;
        int losses = 0;
        int ties = 0;
        int choicePause = 1000;
        int outcomePause = 3000;

        Random randGen = new Random();

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        Image rockImage = Properties.Resources.rock168x280;
        Image paperImage = Properties.Resources.paper168x280;
        Image scissorImage = Properties.Resources.scissors168x280;
        Image winImage = Properties.Resources.winTrans;
        Image loseImage = Properties.Resources.loseTrans;
        Image tieImage = Properties.Resources.tieTrans;

        public Form1()
        {
            InitializeComponent();
        }

        private void rockButton_Click(object sender, EventArgs e)
        {
            /// TODO Set the playerchoice value, show the appropriate image,
            /// play a sound, wait for a second; repeat for the computer turn 

            playerChoice = "rock";
            playerImage.BackgroundImage = rockImage;

            CpuTurn();

            DetermineWinner();

            End();
        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            playerImage.BackgroundImage = paperImage;

            CpuTurn();

            DetermineWinner();

            End();
        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            playerChoice = "scissors";
            playerImage.BackgroundImage = scissorImage;

            CpuTurn();

            DetermineWinner();

            End();
        }

        public void CpuTurn() 
        { 
            int randValue = randGen.Next(1, 4);

            if (randValue == 1)
            {
                cpuChoice = "rock";
                cpuImage.BackgroundImage = rockImage;
            }
            else if (randValue == 2)
            {
                cpuChoice = "paper";
                cpuImage.BackgroundImage = paperImage;
            }
            else
            {
                cpuChoice = "scissors";
                cpuImage.BackgroundImage = scissorImage;
            }

            jabPlayer.Play();
            playerImage.Refresh();
            cpuImage.Refresh();
            Thread.Sleep(choicePause);
        }

        public void End()
        {
            gongPlayer.Play();
            resultImage.Refresh();
            Thread.Sleep(outcomePause);

            playerImage.BackgroundImage = null;
            cpuImage.BackgroundImage = null;
            resultImage.BackgroundImage = null;
        }

        public void DetermineWinner()
        {
            if (playerChoice == cpuChoice)
            {
                resultImage.BackgroundImage = tieImage;
                ties++;
                tiesLabel.Text = $"Ties: {ties}";
            }
            else if (playerChoice == "rock" && cpuChoice == "scissors")
            {
                Win();
            }
            else if (playerChoice == "paper" && cpuChoice == "rock")
            {
                Win();
            }
            else if (playerChoice == "scissors" && cpuChoice == "paper")
            {
                Win();
            }
            else
            {
                resultImage.BackgroundImage = loseImage;
                losses++;
                lossesLabel.Text = $"Losses: {losses}";
            }
        }

        public void Win()
        {
            resultImage.BackgroundImage = winImage;
            wins++;
            winsLabel.Text = $"Wins: {wins}";
        }
    }
}