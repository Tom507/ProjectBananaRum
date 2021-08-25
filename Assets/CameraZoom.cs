using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomRange = 20f;
    public float zoomStart = 70f;
    public void ChangeZoom(float zoomPartial)
    {
        GetComponent<Camera>().fieldOfView = zoomStart + (zoomRange* zoomPartial);
    }
}
