using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR

#endif

namespace com.N8Dev.Brackeys.Editor
{
    [ExecuteInEditMode]
    public class CameraTransparencySorting : MonoBehaviour
    {
        private void Awake()
        {
            Sort(GetComponent<Camera>());
            #if UNITY_EDITOR
            foreach (SceneView _sceneView in SceneView.sceneViews)
                Sort(_sceneView.camera);
            #endif
        }

        private static void Sort(Camera _camera)
        {
            _camera.transparencySortMode = TransparencySortMode.CustomAxis;
            _camera.transparencySortAxis = new Vector3(0, 1f, -0.49f);
        }
    }
}
