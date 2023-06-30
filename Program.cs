using System.Linq;

int turns = 0, playerValue = 0, player2Value = 0;
string[] gameValue = new string[5]
    {"rock", "paper", "scissors", "lizard", "spock"};
int[] mostUsedMove = new int[5];
Random rand = new Random();

Start();

void Start(){
    turns = 0;
    playerValue = 0;
    mostUsedMove = new int[5];

    Console.Clear();
    Console.WriteLine("Rock paper scissors lizard spock");
    Console.WriteLine("Enter the number to select the Gamemode");
    Console.WriteLine("1.Player vs Computer");
    Console.WriteLine("2.Player Vs Player");
    ValidateGamemode();
}

void ValidateGamemode(){
    string? response = Console.ReadLine();
    Console.WriteLine(response);
    if (response!="1" && response != "2"){
        Console.WriteLine("Plese enter a valid Gamemode");
        ValidateGamemode();
    }

    switch(response){
        case "1":
            GamemodePlayerVComputer();
            return;
        case "2":
            GamemodePlayerVPlayer();
            return;
    }
}

void GamemodePlayerVComputer(){
    Console.Clear();
    turns++;
    int computersValue = rand.Next(5);
    mostUsedMove[computersValue]++;
    Console.WriteLine($"Turn {turns}:");
    GetMostUsedMove();
    playerValue = SelectMove();
    Console.WriteLine($"Computer selected {gameValue[computersValue]}");
    Console.WriteLine($"You selected {gameValue[playerValue]}");

    if (computersValue == playerValue){
        Pause();
        GamemodePlayerVComputer();
    }

    switch (playerValue)
    {
        case 0:
            if (computersValue == 2 || computersValue == 3)
            {
                DisplayWinner("Player Wins");
            }
            break;

        case 1:
            if (computersValue == 0 || computersValue == 4)
            {
                DisplayWinner("Player Wins");
            }
            break;

        case 2:
            if (computersValue == 1 || computersValue == 3)
            {
                DisplayWinner("Player Wins");
            }
            break;

        case 3:
            if (computersValue == 4 || computersValue == 1)
            {
                DisplayWinner("Player Wins");
            }
            break;

        case 4:
            if (computersValue == 0 || computersValue == 2)
            {
                DisplayWinner("Player Wins");
            }
            break;
    }

    DisplayWinner("Computer Wins");
}

void GamemodePlayerVPlayer(){
    Console.Clear();
    turns++;
    Console.WriteLine($"Turn {turns}:");
    playerValue = SelectMove("player 1");
    Console.Clear();
    player2Value = SelectMove("player 2");
    Console.Clear();
    Console.WriteLine($"Player 1 selected {gameValue[playerValue]}");
    Console.WriteLine($"player 2 selected {gameValue[player2Value]}");

    if (player2Value == playerValue){
        Pause();
        GamemodePlayerVPlayer();
    }
    
    switch (playerValue)
    {
        case 0:
            if (player2Value == 2 || player2Value == 3)
            {
                DisplayWinner("Player 2 Wins");
            }
            break;

        case 1:
            if (player2Value == 0 || player2Value == 4)
            {
                DisplayWinner("Player 2 Wins");
            }
            break;

        case 2:
            if (player2Value == 1 || player2Value == 3)
            {
                DisplayWinner("Player 2 Wins");
            }
            break;

        case 3:
            if (player2Value == 4 || player2Value == 1)
            {
                DisplayWinner("Player 2 Wins");
            }
            break;

        case 4:
            if (player2Value == 0 || player2Value == 2)
            {
                DisplayWinner("Player 2 Wins");
            }
            break;
    }

    DisplayWinner("Player 1 Wins");
}

void DisplayWinner(string winner)
{
    Console.WriteLine(winner);
    Console.WriteLine($"The game took {turns} turns");
    Console.WriteLine($"the most used move was {GetMostUsedMove()}");
    Pause();
    Start();
}

string GetMostUsedMove(){
    string output = "";
    int maxValue = mostUsedMove.Max();
    bool moreThanOne = false;

    for (int i = 0; i < 5; i++)
    {
        if (mostUsedMove[i] >= maxValue)
        {
            if (moreThanOne)
            {
                output += " and ";
            }

            output += gameValue[i];
            moreThanOne = true;
        }
    }

    return output;
}

void Pause(){
    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}

int SelectMove(string player = ""){
    Console.WriteLine($"Select rock, paper, scissors, lizard, or spock {player}");
    string? response = Console.ReadLine()?.ToLower();
    if (response != "rock" && response != "paper" && response != "scissors"
            && response != "lizard" && response != "spock"){
        Console.WriteLine("Invalid input");
        SelectMove();
    }

    switch(response){
        case "rock":
            mostUsedMove[0]++;
            return 0;

        case "paper":
            mostUsedMove[1]++;
            return 1;

        case "scissors":
            mostUsedMove[2]++;
            return 2;

        case "lizard":
            mostUsedMove[3]++;
            return 3;

        case "spock":
            mostUsedMove[4]++;
            return 4;
    }

    return 0;
}