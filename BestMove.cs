namespace TicTacToeBot_EmmaLevi
{
    public class BestMove
    {
        public async Task<int[]> getBestMove(char[][] board, char playerState)
        {
            int[] bestMove;
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
                return bestMove
            }
            
            //check if we are a move away from losing

            //go to corner

            return bestMove;
        }
    }
}
