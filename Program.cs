using TicTacToeBot_EmmaLevi;
using System.Text.Json;
using System.Text.Json.Serialization;

string playerName = "Emvi"; // green with Emvi
bool validInput = false;
APICaller apiCaller = new();

string playerXorO = "y";

while (validInput == false)
{
    Console.WriteLine("Generate or Join game:");
    string generateOrJoin = Console.ReadLine();

    if (generateOrJoin == null)
    {
        generateOrJoin = Console.ReadLine();
    }

    if (generateOrJoin == "generate" || generateOrJoin == "g")
    {
        validInput = true;

        // send generate api call
        var response = await apiCaller.PostGenerate($"GenerateGame/{playerName}");
    }
    else if (generateOrJoin == "join" || generateOrJoin == "j")
    {
        validInput = true;
        Console.WriteLine("Enter room code:");
        string roomCode = Console.ReadLine();

        // send join api call
        var response = await apiCaller.Put($"JoinGame/{roomCode}/{playerName}");
    }
}





