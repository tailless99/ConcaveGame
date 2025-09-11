using UnityEngine;

public static class TicTacToeAI {
    // 현재 상태를 전달하면 다음 최적의 수를 반환하는 메서드
    public static (int row, int col)? GetBestMove(Constants.PlayerType[,] board) {
        float bestScore = -1000;
        (int row, int col) movePosition = (-1, -1);

        for(var row = 0; row < board.GetLength(0); row++) {
            for(var col = 0; col < board.GetLength(1); col++) {
                if (board[row, col] == Constants.PlayerType.None) {
                    board[row, col] = Constants.PlayerType.PlayerB;
                    var score = TicTacToeAI.DoMiniMax(board, 0, false);
                    board[row, col] = Constants.PlayerType.None;
                    if(score > bestScore) {
                        bestScore = score;
                        movePosition = (row, col);
                    }
                }
            }
        }

        if(movePosition != (-1, -11)) {
            return (movePosition.row, movePosition.col);
        }

        return null;
    }

    private static float DoMiniMax(Constants.PlayerType[,] board, int depth, bool isMaximizing) {
        // 게임 종료 상태 체크
        if (CheckGameWin(Constants.PlayerType.PlayerA, board))
            return -10 + depth;
        if (CheckGameWin(Constants.PlayerType.PlayerB, board))
            return 10 - depth;
        if (CheckGameDraw(board))
            return 0;

        if (isMaximizing) {
            var bestScore = float.MinValue;
            for (var row = 0; row < board.GetLength(0); row++) {
                for (var col = 0; col < board.GetLength(0); col++) {
                    if (board[row, col] == Constants.PlayerType.None) {
                        board[row, col] = Constants.PlayerType.PlayerB;
                        var score = DoMiniMax(board, depth + 1, false);
                        board[row, col] = Constants.PlayerType.None;
                        bestScore = Mathf.Max(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
        else {
            var bestScore = float.MaxValue;
            for (var row = 0; row < board.GetLength(0); row++) {
                for (var col = 0; col < board.GetLength(1); col++) {
                    if (board[row, col] == Constants.PlayerType.None) {
                        board[row, col] = Constants.PlayerType.PlayerA;
                        var score = DoMiniMax(board, depth + 1, true);
                        board[row, col] = Constants.PlayerType.None;
                        bestScore = Mathf.Min(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
    }

    // 비겼는지 확인
    public static bool CheckGameDraw(Constants.PlayerType[,] board) {
        for (var row = 0; row < board.GetLength(0); row++) {
            for (var col = 0; col < board.GetLength(1); col++) {
                if (board[row, col] == Constants.PlayerType.None) return false;
            }
        }
        return true;
    }

    // 게임 승리 확인
    public static bool CheckGameWin(Constants.PlayerType playerType, Constants.PlayerType[,] board) {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        // 가로, 세로, 대각선 방향으로 5개 연속인지 확인
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (board[r, c] != playerType)
                    continue;

                // 1. 가로
                if (c + 4 < cols &&
                    board[r, c + 1] == playerType &&
                    board[r, c + 2] == playerType &&
                    board[r, c + 3] == playerType &&
                    board[r, c + 4] == playerType)
                    return true;

                // 2. 세로
                if (r + 4 < rows &&
                    board[r + 1, c] == playerType &&
                    board[r + 2, c] == playerType &&
                    board[r + 3, c] == playerType &&
                    board[r + 4, c] == playerType)
                    return true;

                // 3. 우하향 대각선
                if (r + 4 < rows && c + 4 < cols &&
                    board[r + 1, c + 1] == playerType &&
                    board[r + 2, c + 2] == playerType &&
                    board[r + 3, c + 3] == playerType &&
                    board[r + 4, c + 4] == playerType)
                    return true;

                // 4. 좌하향 대각선
                if (r + 4 < rows && c - 4 >= 0 &&
                    board[r + 1, c - 1] == playerType &&
                    board[r + 2, c - 2] == playerType &&
                    board[r + 3, c - 3] == playerType &&
                    board[r + 4, c - 4] == playerType)
                    return true;
            }
        }

        return false;
    }
}
