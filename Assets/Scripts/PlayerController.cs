using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// To control the player
/// </summary>
public class PlayerController : MonoBehaviour
{
    float cameraXRotation = 0;
    float playerYRotaion = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        MouseRotation();
    }

    void MouseRotation()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        cameraXRotation -= MouseY;
        playerYRotaion += MouseX;
        cameraXRotation = Mathf.Clamp(cameraXRotation, -45, 45);
        playerYRotaion = Mathf.Clamp(playerYRotaion, -30, 30);
        Camera.main.transform.localRotation = Quaternion.Euler(cameraXRotation, Camera.main.transform.localRotation.y, Camera.main.transform.localRotation.z);
        transform.rotation = Quaternion.Euler(transform.rotation.x, playerYRotaion, transform.rotation.z);
    }

    void Fire()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
        if(isHit)
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponentInParent<Target>();
            if(target!=null)
            {
                target.IsHit();
            }
        }
    }
}
