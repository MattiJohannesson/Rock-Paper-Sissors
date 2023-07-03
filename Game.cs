using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Sissors
{

    enum Moves
    {
        rock,
        paper,
        scissors,
        lizard,
        spock
    }

    class Game
    {

        int turns = 0;
        Moves playerValue, player2Value;
        int[] usedMoves = new int[5];
        Random rand = new Random();
        bool moreThanOneMoveUsed = false;

        public void Start()
        {
            turns = 0;
            playerValue = 0;
            usedMoves = new int[5];

            Console.Clear();
            Console.WriteLine("Rock paper scissors lizard spock");
            Console.WriteLine("Enter the number to select the Gamemode");
            Console.WriteLine("1.Player vs Computer");
            Console.WriteLine("2.Player Vs Player");
            ValidateGamemode();
        }

        void ValidateGamemode()
        {
            string? response = Console.ReadLine();
            Console.WriteLine(response);
            if (response != "1" && response != "2")
            {
                Console.WriteLine("Plese enter a valid Gamemode");
                ValidateGamemode();
            }

            switch (response)
            {
                case "1":
                    GamemodePlayerVComputer();
                    return;
                case "2":
                    GamemodePlayerVPlayer();
                    return;
            }
        }

        void GamemodePlayerVComputer()
        {
            Console.Clear();
            turns++;
            Moves computersValue = (Moves)rand.Next(5);
            usedMoves[(int)computersValue]++;
            Console.WriteLine($"Turn {turns}:");
            GetMostUsedMove();
            playerValue = SelectMove();
            Console.WriteLine($"Computer selected {computersValue}");
            Console.WriteLine($"You selected {playerValue}");

            if (computersValue == playerValue)
            {
                Pause();
                GamemodePlayerVComputer();
            }

            switch (playerValue)
            {
                case Moves.rock:
                    if (computersValue == Moves.scissors || computersValue == Moves.lizard)
                    {
                        DisplayWinner("Player Wins");
                    }
                    break;

                case Moves.paper:
                    if (computersValue == Moves.rock || computersValue == Moves.spock)
                    {
                        DisplayWinner("Player Wins");
                    }
                    break;

                case Moves.scissors:
                    if (computersValue == Moves.paper || computersValue == Moves.lizard)
                    {
                        DisplayWinner("Player Wins");
                    }
                    break;

                case Moves.lizard:
                    if (computersValue == Moves.spock || computersValue == Moves.paper)
                    {
                        DisplayWinner("Player Wins");
                    }
                    break;

                case Moves.spock:
                    if (computersValue == Moves.rock || computersValue == Moves.scissors)
                    {
                        DisplayWinner("Player Wins");
                    }
                    break;
            }

            DisplayWinner("Computer Wins");
        }

        void GamemodePlayerVPlayer()
        {
            Console.Clear();
            turns++;
            Console.WriteLine($"Turn {turns}:");
            playerValue = SelectMove("player 1");
            Console.Clear();
            player2Value = SelectMove("player 2");
            Console.Clear();
            Console.WriteLine($"Player 1 selected: {playerValue}");
            Console.WriteLine($"player 2 selected: {player2Value}");

            if (player2Value == playerValue)
            {
                Pause();
                GamemodePlayerVPlayer();
            }

            switch (playerValue)
            {
                case Moves.rock:
                    if (player2Value == Moves.scissors || player2Value == Moves.lizard)
                    {
                        DisplayWinner("Player Wins");
                    }
                    break;

                case Moves.paper:
                    if (player2Value == Moves.rock || player2Value == Moves.spock)
                    {
                        DisplayWinner("Player Wins");
                    }
                    break;

                case Moves.scissors:
                    if (player2Value == Moves.paper || player2Value == Moves.lizard)
                    {
                        DisplayWinner("Player Wins");
                    }
                    break;

                case Moves.lizard:
                    if (player2Value == Moves.spock || player2Value == Moves.paper)
                    {
                        DisplayWinner("Player Wins");
                    }
                    break;

                case Moves.spock:
                    if (player2Value == Moves.rock || player2Value == Moves.scissors)
                    {
                        DisplayWinner("Player Wins");
                    }
                    break;
            }

            DisplayWinner("Player 2 Wins");
        }

        void DisplayWinner(string winner)
        {
            Console.WriteLine(winner);
            Console.WriteLine("--------------------------------");

            if (turns == 1){
                Console.WriteLine($"The game took {turns} turn");
            }
            else{
                Console.WriteLine($"The game took {turns} turns");
            }
            
            string mostUsedMove = GetMostUsedMove();
            if (moreThanOneMoveUsed){
                Console.WriteLine($"The most used moves where {mostUsedMove}"); 
            }
            else{
                Console.WriteLine($"The most used move was {mostUsedMove}");
            }
            Pause();
            Start();
        }

        string GetMostUsedMove()
        {
            string output = "";
            int maxValue = usedMoves.Max();

            for (int i = 0; i < 5; i++)
            {
                if (usedMoves[i] >= maxValue)
                {
                    if (moreThanOneMoveUsed)
                    {
                        output += " and ";
                    }
                    Moves moves = (Moves)i;
                    output += moves;
                    moreThanOneMoveUsed = true;
                }
            }

            return output;
        }

        void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        Moves SelectMove(string player = "")
        {
            Console.WriteLine($"Select rock, paper, scissors, lizard, or spock {player}");
            string? response = Console.ReadLine()?.ToLower();
            if (response != "rock" && response != "paper" && response != "scissors"
                    && response != "lizard" && response != "spock")
            {
                Console.WriteLine("Invalid input");
                SelectMove();
            }

            switch (response)
            {
                case "rock":
                    usedMoves[0]++;
                    return Moves.rock;

                case "paper":
                    usedMoves[1]++;
                    return Moves.paper;

                case "scissors":
                    usedMoves[2]++;
                    return Moves.scissors;

                case "lizard":
                    usedMoves[3]++;
                    return Moves.lizard;

                case "spock":
                    usedMoves[4]++;
                    return Moves.spock;
            }

            return 0;
        }
    }
}
