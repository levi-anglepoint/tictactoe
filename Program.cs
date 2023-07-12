using TicTacToeBot_EmmaLevi;

string playerName = "Emvi"; // green with Emvi
string roomCode = "";
bool validInput = false;
APICaller apiCaller = new();

string playerXorO = "y";

while (validInput == false)
{
    Console.WriteLine("Generate or Join game:");
    string generateOrJoin = Console.ReadLine();

    if (generateOrJoin == null)
    {
        generateOrJoin = Console.ReadLine().ToLower();
    }

    if (generateOrJoin == "generate" || generateOrJoin == "g")
    {
        validInput = true;

        // send generate api call
        var response = await apiCaller.Post($"GenerateGame/{playerName}");
        if (response is null)
        {
            return;
        }

        roomCode = response.roomCode; // parse room code from response
        //parse player X or O from response
        if (response.playerOName == playerName)
        {
            Console.WriteLine("You are player 'O'");
            playerXorO = "O";
        }
        else
        {
            Console.WriteLine("You are player 'X'");
            playerXorO = "X";
        }
    }
    else if (generateOrJoin == "join" || generateOrJoin == "j")
    {
        validInput = true;
        Console.WriteLine("Enter room code:");
        roomCode = Console.ReadLine();

        // send join api call
        var response = await apiCaller.Put($"JoinGame/{roomCode}/{playerName}");

        // parse player X or O from response
        if (response.playerOName == playerName)
        {
            Console.WriteLine("You are player 'O'");
            playerXorO = "O";
        }
        else
        {
            Console.WriteLine("You are player 'X'");
            playerXorO = "X";
        }
    }
}

while (true)
{
    string gameStatusUrl = $"/GetGameStatus/{roomCode}";
    var gameStatusRes = await apiCaller.Get(gameStatusUrl);
    
    if (gameStatusRes.currentRound > 100) // todo: if gameStatusRes.currentRound > 100 then break while loop
    {
        break;
    }
    else if (playerXorO == "X") // todo: and if gameStatusRes.currentGameStatus == 1
    {

    }
    else if (playerXorO == "O") // todo: and if gameStatusRes.currentGameStatus == 2
    {

    }
    else if (true) // todo: if gameStatusRes.currentGameStatus == 0 || gameStatusRes.currentGameStatus == 3 && have not yet continued
    {

    }
}


