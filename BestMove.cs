namespace TicTacToeBot_EmmaLevi
{
    public class BestMove
    {
        public async Task<int[]> getBestMove(char[][] board, char playerState)
        {
            // temp to see if we can play the game
            // i is the row, j is the column
            for (int i = 0; i < board.Length; i++)
            {
                char[] charArr = board[i];
                for (int j = 0; j < charArr.Length; j++)
                {
                    char character = charArr[j];
                    if (character == '\0')
                    {
                        return new int[] {i, j};
                    }
                }
            }





            int[] bestMove = { 0, 0 };
            /*char [][] possibleWinStates = ['X','']*/

            //check if we can win
            if (
                //top row
                (board[0][0] == playerState && board[0][1] == playerState && board[0][2]== '\0')
                ||
               (board[0][0] == playerState && board[0][1] == '\0' && board[0][2] == playerState)
                ||
                (board[0][0] == '\0'&& board[0][1] == playerState  && board[0][2] == playerState)
                //middle row
                ||
                (board[1][0] == playerState && board[1][1] == playerState && board[1][2] == '\0')
                ||
               (board[1][0] == playerState && board[1][1] == '\0' && board[1][2] == playerState)
                ||
                (board[1][0] == '\0' && board[1][1] == playerState && board[1][2] == playerState)
                //bottom row
                ||
                (board[2][0] == playerState && board[2][1] == playerState && board[2][2] == '\0')
                ||
               (board[2][0] == playerState && board[2][1] == '\0' && board[2][2] == playerState)
                ||
                (board[2][0] == '\0' && board[2][1] == playerState && board[2][2] == playerState)
               )
            {
                return bestMove;
            }
            
            //check if we are a move away from losing

            //go to corner

            return bestMove;
        }
    }
}
