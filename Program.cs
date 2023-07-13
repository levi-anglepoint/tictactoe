using TicTacToeBot_EmmaLevi;

string playerName = "Emvi"; // green with Emvi
string roomCode = "";
bool validInput = false;
APICaller apiCaller = new();
BestMove bestMoveFinder = new();

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

Console.WriteLine($"Room Code: {roomCode}");


string gameStatusUrl = $"GetGameStatus/{roomCode}";
string playMoveUrl = $"SetMove/{roomCode}/{playerName}";
string continueUrl = $"Continue/{roomCode}/{playerName}";

int currentRound = 0;
bool continuedThisRound = true;

bool useMines = true;

while (true)
{
    var gameStatusRes = await apiCaller.Get(gameStatusUrl);
    
    if (gameStatusRes.currentRound > 100)
    {
        break;
    }
    else if ((playerXorO == 'X' && gameStatusRes.currentGameStatus == 1) || (playerXorO == 'O' && gameStatusRes.currentGameStatus == 2))
    {
        continuedThisRound = false;
        // get best move
        int[] bestMoveArr = await bestMoveFinder.getBestMove(gameStatusRes.gameBoard, playerXorO);

        // create move obj
        PlayerMove bestPM = new();
        bestPM.DoesTauntOpponent = true;
        bestPM.CustomTaunt = "Thy foes have bested thee in tic tac toe";
        bestPM.Coordinate = bestMoveArr;

        Console.WriteLine($"[{bestPM.Coordinate[0]}, {bestPM.Coordinate[1]}]");

        // post best move
        var postMove = await apiCaller.Post(playMoveUrl, bestPM);
        if (postMove is null || postMove.roomCode is null)
        {
            Console.WriteLine("Failed to post move");
        }
    }
    else if (gameStatusRes.currentGameStatus == 3 || (gameStatusRes.currentGameStatus == 0 && !continuedThisRound))
    {
        ResponseObject continueResponse = null;
        // hit continue game endpoint
        if (useMines)
        {
            Landmine mine = bestMoveFinder.GetRandomLandmine();
            continueResponse = await apiCaller.Post(continueUrl, mine);
        }
        else
        {
            continueResponse = await apiCaller.Post(continueUrl);
        }
        if (continueResponse != null)
        {
            currentRound++;
        }
        continuedThisRound = true;
    }

    Thread.Sleep(500);
}



var finalGameStatus = await apiCaller.Get(gameStatusUrl);

Console.WriteLine(finalGameStatus.ToString());