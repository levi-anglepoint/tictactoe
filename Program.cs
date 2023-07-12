using TicTacToeBot_EmmaLevi;

string playerName = "Emvi"; // green with Emvi
string roomCode = "";
bool validInput = false;
APICaller apiCaller = new();

char playerXorO = 'y';

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
            playerXorO = 'O';
        }
        else
        {
            Console.WriteLine("You are player 'X'");
            playerXorO = 'X';
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
            playerXorO = 'O';
        }
        else
        {
            Console.WriteLine("You are player 'X'");
            playerXorO = 'X';
        }
    }
}


string gameStatusUrl = $"/GetGameStatus/{roomCode}";
bool continueGameEndpointHit = false;

while (true)
{
    var gameStatusRes = await apiCaller.Get(gameStatusUrl);
    
    if (gameStatusRes.currentRound > 100)
    {
        break;
    }
    else if (playerXorO == 'X' && gameStatusRes.currentGameStatus == 1)
    {
        continueGameEndpointHit = false; // started a new game, reset continueGameEndpointHit variable

        // todo: get best move

        // todo: post best move
    }
    else if (playerXorO == 'O' && gameStatusRes.currentGameStatus == 2)
    {
        continueGameEndpointHit = false; // started a new game, reset continueGameEndpointHit variable

        // todo: get best move

        // todo: post best move
    }
    else if ((gameStatusRes.currentGameStatus == 0 || gameStatusRes.currentGameStatus == 3) && !continueGameEndpointHit) // game is over OR game is waiting for other playerand have not yet continued the 
    {
        // hit continue game endpoint

        continueGameEndpointHit = true;
    }

    Thread.Sleep(500);
}



var finalGameStatus = await apiCaller.Get(gameStatusUrl);

Console.WriteLine(finalGameStatus.ToString());