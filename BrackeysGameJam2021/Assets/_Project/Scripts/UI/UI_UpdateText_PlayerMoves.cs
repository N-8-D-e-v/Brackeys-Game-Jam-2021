using com.N8Dev.Allete.GameData;

namespace com.N8Dev.Allete.UI
{
    public class UI_UpdateText_PlayerMoves : UI_UpdateText
    {
        protected override string GetText() => 
            LevelData.GetMovesRemaining().ToString();
    }
}