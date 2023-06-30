int turns = 0, playerValue = 0, player2Value = 0, 
    rock = 0, paper = 0, scissors = 0;
string[] gameValue = new string[3]
    {"rock", "paper", "scissors"};
Random rand = new Random();

Start();

void Start(){
    turns = 0;
    playerValue = 0;
    rock = 0;
    paper = 0;
    scissors = 0;

    Console.WriteLine("Rock paper scissors");
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
    int computersValue = rand.Next(3);
    Console.WriteLine($"Turn {turns}:");
    playerValue = SelectMove();
    Console.WriteLine($"Computer selected {gameValue[computersValue]}");
    Console.WriteLine($"You selected {gameValue[playerValue]}");

    if (computersValue == playerValue){
        Pause();
        GamemodePlayerVComputer();
    }
    
    if (playerValue == computersValue+1%3){
        Console.WriteLine("Player Wins");
        Console.WriteLine($"The game took {turns} turns");
        Console.WriteLine($"the most used move was {MostUsedMove()}");
        Pause();
        Start();
    }

    Console.WriteLine("Computer Wins");
    Console.WriteLine($"The game took {turns} turns");
    Console.WriteLine($"the most used move was {MostUsedMove()}");
    Pause();
    Start();
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
    
    if (playerValue == player2Value+1%3){
        Console.WriteLine("Player 1 Wins");
        Console.WriteLine($"The game took {turns} turns");
        Console.WriteLine($"the most used move was {MostUsedMove()}");
        Pause();
        Start();
    }

    Console.WriteLine("player 2 Wins");
    Console.WriteLine($"The game took {turns} turns");
    Console.WriteLine($"the most used move was {MostUsedMove()}");
    Pause();
    Start();
}

string MostUsedMove(){
    string output = "";
    bool moreThanOne = false;

    if (rock >= paper){
        output += "rock";
        moreThanOne = true;
    }

    if (paper >= scissors){
        if (moreThanOne){
            output += " and ";
        }
        output += "paper";
        moreThanOne = true;
    }

    if (scissors >= rock){
        if (moreThanOne){
            output += " and ";
        }
        output += "scissors";
    }

    return output;
}

void Pause(){
    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}

int SelectMove(string player = ""){
    Console.WriteLine($"Select rock, paper, or scissors {player}");
    string? response = Console.ReadLine()?.ToLower();
    if (response != "rock" && response != "paper" && response != "scissors"){
        Console.WriteLine("Invalid input");
        SelectMove();
    }

    switch(response){
        case "rock":
            rock++;
            return 0;

        case "paper":
            paper++;
            return 1;

        case "scissors":
            scissors++;
            return 2;
    }

    return 0;
}