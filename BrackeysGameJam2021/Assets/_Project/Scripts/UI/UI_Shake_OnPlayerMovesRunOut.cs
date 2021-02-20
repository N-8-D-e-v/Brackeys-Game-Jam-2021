using com.N8Dev.Allete.Utilities;

namespace com.N8Dev.Allete.UI
{
    public class UI_Shake_OnPlayerMovesRunOut : UI_Shake
    {
        private void Awake() =>
            EventManager.OnPlayerMovesRunOut += Shake;

        private void OnDisable() =>
            EventManager.OnPlayerMovesRunOut -= Shake;
    }
}