namespace TicTacToeBot_EmmaLevi
{
    internal class ResponseObject
    {
        public string? PlayerXName { get; set; }
        public string? PlayerOName { get; set; }
        public string? RoomCode { get; set; }
        public int CurrentGameStatus { get; set; }
        public string? WinnerStatus { get; set; }
        public string? CurrentTauntFromX { get; set; }
        public string? CurrentTauntFromO { get; set; }
        public int PlayerXVictoryCount { get; set; }
        public int PlayerOVictoryCount { get; set; }
        public int PlayerXForfeitCount { get; set; }
        public int PlayerOForfeitCount { get; set; }
        public int TieGameCount { get; set; }
        public int CurrentRound { get; set; }
        public char[][] GameBoard { get; set; }
    }
}
