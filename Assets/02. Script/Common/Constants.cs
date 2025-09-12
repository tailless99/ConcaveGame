public static class Constants {
    public enum GameType { SinglePlay, DualPlay, MultiPlay }
    public enum PlayerType { None, PlayerA, PlayerB }

    public const int BlockColumnCount = 15;

    public const int GameWinCount = 5;

    // 티어별 요구 경험치
    public const int minTierExp = 3;       // 하위 티어 요구 경험치
    public const int middleTierExp = 5;    // 중간 티어 요구 경험치
    public const int maxTierExp = 10;      // 상위 티어 요구 경험치
}
