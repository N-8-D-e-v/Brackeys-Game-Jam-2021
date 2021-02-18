using com.N8Dev.Brackeys.GameData;

namespace com.N8Dev.Brackeys.UI
{
    public class UI_UpdateText_PlayerMoves : UI_UpdateText
    {
        protected override string GetText() => LevelData.GetMovesRemaining().ToString();
    }
}