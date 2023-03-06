using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float minFov = 15f;
    float maxFov = 90f;

    private float mouseSensitivity = 100;
    private Transform parent;
 
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        Rotate();
        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * 10;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;

    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
      /*  float mouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;*/

        parent.Rotate(Vector3.up, mouseX);
       
    }

}
