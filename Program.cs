using TicTacToeBot_EmmaLevi;

string playerName = "Emvi"; // green with Emvi
string roomCode = "";
bool validInput = false;
APICaller apiCaller = new();
BestMove bestMoveFinder = new();
bool useMines = true;
Landmine currentMine = null;

char playerXorO = 'y';
string generateUrl = $"GenerateGame/{playerName}";

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
        ResponseObject response = null;
        if (useMines)
        {
            Landmine mine = bestMoveFinder.GetRandomLandmine();
            currentMine = mine;
            response = await apiCaller.Post(generateUrl, mine);
        }
        else
        {
            response = await apiCaller.Post(generateUrl);
        }
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

        string joinUrl = $"JoinGame/{roomCode}/{playerName}";
        // send join api call
        ResponseObject response = null;
        if (useMines)
        {
            Landmine mine = bestMoveFinder.GetRandomLandmine();
            currentMine = mine;
            response = await apiCaller.Put(joinUrl, mine);
        }
        else
        {
            response = await apiCaller.Put(joinUrl);
        }

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
        int[] bestMoveArr = null;
        if (useMines && currentMine != null)
        {
            bestMoveArr = bestMoveFinder.landmineMode(gameStatusRes.gameBoard, currentMine.Coordinate);
        }
        else
        {
            // get best move
            bestMoveArr = await bestMoveFinder.getBestMove(gameStatusRes.gameBoard, playerXorO);
        }

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
            currentMine = mine;
            continueResponse = await apiCaller.Post(continueUrl, mine);
        }
        else
        {
            continueResponse = await apiCaller.Post(continueUrl);
        }
        if (continueResponse != null)
        {
            currentRound++;
            Console.WriteLine("Continue new game");
            Console.WriteLine(continueResponse.ToString());
        }
        continuedThisRound = true;
    }

    Thread.Sleep(250);
}



var finalGameStatus = await apiCaller.Get(gameStatusUrl);

Console.WriteLine(finalGameStatus.ToString());