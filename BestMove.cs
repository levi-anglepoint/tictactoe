﻿namespace TicTacToeBot_EmmaLevi
{
    public class BestMove
    {
        public async Task<int[]> getBestMove(char[][] board, char playerState)
        {
            char opState;
            if (playerState == 'X')
            {
                opState = 'O';
            }
            else
            {
                opState = 'X';
            }
            bool isFirstPlayer = CheckFirstPlayer(board, playerState);
            int[] bestMove;
      
            //check if we can win
            bestMove = CheckWin(board, playerState);            
            if(bestMove != null)
            {
                return bestMove;
            }

            //check if we are a move away from losing
            bestMove = CheckWin(board, opState);
            if (bestMove != null)
            {
                return bestMove;
            }

            if(isFirstPlayer)
            {
                return MovementFirstPlayer(board);
            }
            else
            {
                return MovementSecondPlayer(board);
            }
        }

        private static int[] CheckWin(char[][] board, char playerState)
        {
            int[] bestMove;
            //top row
            if (board[0][0] == playerState && board[0][1] == playerState && board[0][2] == '\0')
            {
                return (new int[] { 0, 2 });
            }
            else if (board[0][0] == playerState && board[0][1] == '\0' && board[0][2] == playerState)
            {
                return (new int[] { 0, 1 });
            }
            else if (board[0][0] == '\0' && board[0][1] == playerState && board[0][2] == playerState)
            {
                return (new int[] { 0, 0 });
            }
            //middle row
            else if (board[1][0] == playerState && board[1][1] == playerState && board[1][2] == '\0')
            {
                return (new int[] { 1, 2 });
            }
            else if (board[1][0] == playerState && board[1][1] == '\0' && board[1][2] == playerState)
            {
                return (new int[] { 1, 1 });
            }
            else if (board[1][0] == '\0' && board[1][1] == playerState && board[1][2] == playerState)
            {
                return (new int[] { 1,0 });
            }
            //bottom row
            else if (board[2][0] == playerState && board[2][1] == playerState && board[2][2] == '\0')
            {
                return (new int[] { 2, 2 });
            }
            else if (board[2][0] == playerState && board[2][1] == '\0' && board[2][2] == playerState)
            {
                return (new int[] { 2, 1 });
            }
            else if (board[2][0] == '\0' && board[2][1] == playerState && board[2][2] == playerState)
            {
                return (new int[] { 2, 0 });
            }
            //diagonal down to right
            else if (board[0][0] == playerState && board[1][1] == playerState && board[2][2] == '\0')
            {
                return (new int[] { 2, 2 });
            }
            else if (board[0][0] == playerState && board[1][1] == '\0' && board[2][2] == playerState)
            {
                return (new int[] { 1, 1 });
            }
            else if (board[0][0] == '\0' && board[1][1] == playerState && board[2][2] == playerState)
            {
                return (new int[] { 0, 0 });
            }
            //diagonal up toright
            else if (board[2][0] == playerState && board[1][1] == playerState && board[0][2] == '\0')
            {
                return (new int[] { 0, 2 });
            }
            else if (board[2][0] == playerState && board[1][1] == '\0' && board[0][2] == playerState)
            {
                return (new int[] { 1, 1 });
            }
            else if (board[2][0] == '\0' && board[1][1] == playerState && board[0][2] == playerState)
            {
                return (new int[] { 2, 0 });
            }
            else if//first col
            (board[0][0] == playerState && board[1][0] == playerState && board[2][0] == '\0')
            {
                return (new int[] { 2, 0 });
            }
            else if (board[0][0] == playerState && board[1][0] == '\0' && board[2][0] == playerState)
            {
                return (new int[] { 1, 0 });
            }
            else if (board[0][0] == '\0' && board[1][0] == playerState && board[2][0] == playerState)
            {
                return (new int[] { 0, 0 });
            }
            //second col
            else if (board[0][1] == playerState && board[1][1] == playerState && board[2][1] == '\0')
            {
                return (new int[] { 2, 1 });
            }
            else if (board[0][1] == playerState && board[1][1] == '\0' && board[2][1] == playerState)
            {
                return (new int[] { 1, 1 });
            }
            else if (board[0][1] == '\0' && board[1][1] == playerState && board[2][1] == playerState)
            {
                return (new int[] { 0, 1 });
            }
            //last col
            else if (board[0][2] == playerState && board[1][2] == playerState && board[2][2] == '\0')
            {
                return (new int[] { 2, 2 });
            }
            else if (board[0][2] == playerState && board[1][2] == '\0' && board[2][2] == playerState)
            {
                return (new int[] { 1, 2 });
            }
            else if (board[0][2] == '\0' && board[1][2] == playerState && board[2][2] == playerState)
            {
                return (new int[] { 0, 2 });
            }
            else
            {
                return null;
            }
        }
        private static bool CheckFirstPlayer(char[][] board, char ourChar)
        {
            char theirChar;
            if (ourChar == 'X')
            {
                theirChar = 'O';
            }
            else 
            {
                theirChar = 'X';
            }
            int mySquares=0;
            int theirSquares=0;
            for (int i = 0; i < board.Length; i++)
            {
                char[] charArr = board[i];
                for (int j = 0; j < charArr.Length; j++)
                {
                    char character = charArr[j];

                    if (character == ourChar)
                    {
                        mySquares ++;
                    }
                    else if(character == theirChar){
                        theirSquares ++;
                    }
                }
            }
            return mySquares == theirSquares;
        }
        private static int[] MovementFirstPlayer(char[][] board)
        {
            int[] bestMove;
            bestMove = CornerStrat(board);
            return bestMove;

        }
        private static int[] MovementSecondPlayer(char[][] board)
        {
            int[] bestMove;
            if (board[0][0] =='\0' && board[0][2] == '\0' && board[2][0] == '\0' && board[2][2] == '\0')
            {
                bestMove = CornerStrat(board);
            }
            else
            {
                bestMove = SecondPlayerStrat(board);
            }
            return bestMove;
        }
        private static int[] CornerStrat(char[][] board)
        {
            //bottom left corner first
            if (board[2][0] == '\0' && board[1][0] == '\0' && board[2][1] == '\0')
            {
                return (new int[] { 2, 0 });
            }
            //bottom right corner, we'll get this if they didn't try and block us last time in 2,1
            else if (board[2][2] == '\0' && board[2][1] == '\0' && board[1][2] == '\0')
            {
                return (new int[] { 2, 2 });
            }
            //top left corner
            else if (board[0][0] == '\0' && board[0][1] == '\0' && board[1][0] == '\0')
            {
                return (new int[] { 2, 2 });
            }
            //top right corner 
            else if (board[0][2] == '\0' && board[0][1] == '\0' && board[1][2] == '\0')
            {
                return (new int[] { 0, 2 });
            }
            //just bottom right corner empty
            else if (board[2][2] == '\0')
            {
                return (new int[] { 2, 2 });
            }
            //just top left corner empty
            else if (board[0][0] == '\0')
            {
                return (new int[] { 0, 0 });
            }
            //just top right corner empty
            else if (board[0][2] == '\0')
            {
                return (new int[] { 0, 2 });
            }
            //just bottom left
            else if (board[2][0] == '\0')
            {
                return (new int[] { 2, 0 });
            }
            else
            {
                List<int[]> empties = GetEmptySquares(board);
                Random rnd = new Random();
                return empties[rnd.Next(empties.Count)];
            }

        }
        private static int[] SecondPlayerStrat(char[][] board)
        {
            if (board[1][1] == '\0')
            {
                return new int[] { 1, 1 };
            }
            else
            {
                List<int[]> empties = GetEmptySquares(board);
                Random rnd = new Random();
                return empties[rnd.Next(empties.Count)];
            }
        }
        private static List<int[]> GetEmptySquares(char[][] board)
        {
            List<int[]> emptySquares = new List<int[]>();
            for (int i = 0; i < board.Length; i++)
            {
                char[] charArr = board[i];
                for (int j = 0; j < charArr.Length; j++)
                {
                    char character = charArr[j];

                    if (character == '\0')
                    {
                         emptySquares.Add(new int[] { i, j });
                    }
                }
            }
            return emptySquares;
        }
    }
}