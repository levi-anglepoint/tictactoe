﻿namespace TicTacToeBot_EmmaLevi
{
    public class ResponseObject
    {
        public string? playerXName { get; set; }
        public string? playerOName { get; set; }
        public string? roomCode { get; set; }
        public int currentGameStatus { get; set; }
        public string? winnerStatus { get; set; }
        public string? currentTauntFromX { get; set; }
        public string? currentTauntFromO { get; set; }
        public int playerXVictoryCount { get; set; }
        public int playerOVictoryCount { get; set; }
        public int playerXLandmineVictoryCount { get; set; }
        public int playerOLandmineVictoryCount { get; set; }
        public int playerXForfeitCount { get; set; }
        public int playerOForfeitCount { get; set; }
        public int tieGameCount { get; set; }
        public int currentRound { get; set; }
        public char[][] gameBoard { get; set; }

        public override string ToString()
        {
            return $"[roomCode {roomCode}] [PlayerX {playerXName} {playerXVictoryCount} {playerXLandmineVictoryCount}] [PlayerO {playerOName} {playerOVictoryCount} {playerOLandmineVictoryCount}] ";
        }
    }

    public class PlayerMove
    {
        public bool DoesTauntOpponent { get; set; }
        public int[] Coordinate { get; set; }
        public string CustomTaunt { get; set; }
    }
    public class Landmine
    {
        public int[] Coordinate { get; set; }
    }
}
