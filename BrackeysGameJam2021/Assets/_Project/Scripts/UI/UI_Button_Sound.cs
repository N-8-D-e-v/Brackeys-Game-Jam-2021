using com.N8Dev.Allete.AudioManagement;
using UnityEngine;

namespace com.N8Dev.Allete.UI
{
    public class UI_Button_Sound : MonoBehaviour
    {
        //Sound
        [SerializeField] private Sound Sound;

        public void PlaySound() =>
            Sound.Play();
    }
}