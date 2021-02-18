namespace com.N8Dev.Brackeys.GameState
{
    public static class GameStateManager
    {
        //Game State
        private static GameStates gameState = GameStates.Pause;

        public static GameStates GetGameState() => gameState;

        public static void StartGame() => 
            gameState = GameStates.Play;

        public static void PauseGame() => 
            gameState = GameStates.Pause;
    }

    public enum GameStates
    {
        Play,
        Pause
    }
}