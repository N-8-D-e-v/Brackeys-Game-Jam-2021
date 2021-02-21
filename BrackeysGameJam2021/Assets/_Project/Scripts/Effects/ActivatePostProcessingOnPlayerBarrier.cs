using com.N8Dev.Allete.Utilities;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

namespace com.N8Dev.Allete.Effects
{
    [RequireComponent(typeof(Volume))]
    public class ActivatePostProcessingOnPlayerBarrier : MonoBehaviour
    {
        //Assignables
        private Volume volume;
        
        //Time
        [Range(0, 1f)] [SerializeField] private float Time;

        private void Awake()
        {
            volume = GetComponent<Volume>();
            EventManager.OnPlayerBarrier += Activate;
        }

        private void OnDisable() =>
            EventManager.OnPlayerBarrier -= Activate;

        private void Activate()
        {
            DOTween.To(() => volume.weight, _x => volume.weight = _x, 1f, Time);
            this.Invoke(Deactivate, Time);
        }
        
        private void Deactivate() => 
            DOTween.To(
                () => volume.weight,
                _x => volume.weight = _x, 
                0f, 
                Time);
    }
}