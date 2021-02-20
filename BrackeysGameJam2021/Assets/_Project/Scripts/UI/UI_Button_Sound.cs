using com.N8Dev.Brackeys.AudioManagement;
using UnityEngine;

namespace com.N8Dev.Brackeys.UI
{
    public class UI_Button_Sound : MonoBehaviour
    {
        //Sound
        [SerializeField] private Sound Sound;

        public void PlaySound() =>
            Sound.Play();
    }
}