using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraControl : MonoBehaviour
{
    float rotationSpeed = 1;
    public Transform  Player;
    float mouseX, mouseY;

    public Transform Camera;
    Transform target;
    RaycastHit[] hits = new RaycastHit[0];
    float camToPlayerDistance;
    float camToWallDistance;
    float offset = 10f;
    public Transform Obstruction;
   // float zoomSpeed = 2f;
    
    void Start()
    {
        Obstruction = target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CamControl();
        ViewObstructed();
    }
    

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(target);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
    

    void ViewObstructed()
    {
        // IF WALL(S) NO LONGER BLOCKING, RE-ENABLE MESH RENDERER
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider && hit.collider.tag == "Wall")
                    hit.transform.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }

            camToPlayerDistance = Vector3.Distance(Camera.position, target.position);

            Vector3 camToPlayerDirection = target.position - Camera.position;
            Ray ray = new Ray(Camera.position, camToPlayerDirection);

            hits = Physics.RaycastAll(Camera.position, camToPlayerDirection, camToPlayerDistance);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.tag != "Wall")
                    return;

                camToWallDistance = Vector3.Distance(Camera.position, hit.transform.position);

                // KEEP SHADOW BEFORE DISABLING MESH RENDERER TO GIVE ILLUSION THAT WALL IS STILL THERE
                if (camToWallDistance >= camToPlayerDistance - offset)
                    hit.transform.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
    }
}

