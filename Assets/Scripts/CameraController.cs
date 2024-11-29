using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [System.Serializable]
    public class CameraBinding
    {
        public KeyCode key;    // The key to activate this camera
        public Camera camera;  // The camera to activate
    }

    [Header("Camera Key Bindings")]
    public CameraBinding[] cameraBindings;

    private void Start()
    {
        // Ensure only one camera is active at the start
        DeactivateAllCameras();
        if (cameraBindings.Length > 0 && cameraBindings[0].camera != null)
        {
            cameraBindings[0].camera.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        foreach (var binding in cameraBindings)
        {
            if (Input.GetKeyDown(binding.key))
            {
                SwitchToCamera(binding.camera);
            }
        }
    }

    private void SwitchToCamera(Camera targetCamera)
    {
        if (targetCamera == null) return;

        DeactivateAllCameras();
        targetCamera.gameObject.SetActive(true);
    }

    private void DeactivateAllCameras()
    {
        foreach (var binding in cameraBindings)
        {
            if (binding.camera != null)
            {
                binding.camera.gameObject.SetActive(false);
            }
        }
    }
}
