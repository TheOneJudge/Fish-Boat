using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCameraBase[] cameras; // Array of virtual cameras

    private int currentCameraIndex = 0;

    void Start()
    {
        // Activate the initial virtual camera
        SwitchCamera(currentCameraIndex);
    }

    void Update()
    {
        // Check for the F key press to switch cameras
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Switch to the next virtual camera
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
            SwitchCamera(currentCameraIndex);
        }
    }

    void SwitchCamera(int index)
    {
        // Deactivate all cameras
        foreach (var camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }

        // Activate the selected camera
        cameras[index].gameObject.SetActive(true);
    }
}

