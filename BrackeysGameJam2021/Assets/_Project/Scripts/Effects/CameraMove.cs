using DG.Tweening;
using UnityEngine;

namespace com.N8Dev.Allete.Effects
{
    public class CameraMove : MonoBehaviour
    {
        //Assignables
        private new Transform transform;
        
        //Effect
        [Range(0.1f, 10f)] [SerializeField] private float Radius = 1f;
        [Range(0.1f, 600)] [SerializeField] private float Time = 15f;
        [Range(1, 60)] [SerializeField] private int Points = 8;
        private Vector3[] path;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            path = new Vector3[Points];
            for (int _i = 0; _i < Points; _i++)
                path[_i] = Random.insideUnitCircle * Radius;
            for (int _i = 0; _i < path.Length; _i++)
                path[_i] += transform.position;
        }

        private void Start() => 
            transform.DOPath(path, Time, PathType.CatmullRom).SetLoops(-1);

    }
}