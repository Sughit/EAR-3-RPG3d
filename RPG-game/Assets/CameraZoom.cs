using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    CinemachineComponentBase componentBase;
    float cameraDistance;
    float sensitivity = 3f;

    void Update()
    {
        if(componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }

        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            
        }

        if(virtualCamera.m_Lens.OrthographicSize >= 4 && Input.GetAxis("Mouse ScrollWheel") >0)
        {
            cameraDistance = Input.GetAxis("Mouse ScrollWheel") * sensitivity;

            virtualCamera.m_Lens.OrthographicSize -= cameraDistance;
        }
        else
        if(virtualCamera.m_Lens.OrthographicSize <= 11 && Input.GetAxis("Mouse ScrollWheel") <0)
        {
            cameraDistance = Input.GetAxis("Mouse ScrollWheel") * sensitivity;

            virtualCamera.m_Lens.OrthographicSize -= cameraDistance;
        }
    }
}
