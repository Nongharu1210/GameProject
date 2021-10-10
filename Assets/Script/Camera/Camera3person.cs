using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3person : MonoBehaviour
{
[SerializeField] private Transform target;
public float rotSpeed = 1.5f;
private float vertRotY;
private float horiRotX;
private Vector3 offSet;

// Start is called before the first frame update
void Start()
{
    vertRotY = transform.eulerAngles.y;
    offSet = target.position - transform.position;
}

void FixedUpdate()
{
    RaycastHit hit;
    if (Physics.Raycast(transform.position, Vector3.forward, out hit, 100f))
    {
      hit.transform.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
    }
}

private void OnTriggerEnter(Collider other)
{
    if (other.tag == "Wall")
    {
        print("touching wall");
    }
}

// Update is called once per frame
void LateUpdate()
{
    float horiInput = Input.GetAxisRaw("Horizontal");
    float vertInput = Input.GetAxisRaw("Vertical");
    if (horiInput != 0)
    {
        vertRotY += horiInput * rotSpeed;
        
    }
    else
    {
        vertRotY += Input.GetAxis("Mouse X") * rotSpeed * 3;

    }

    if (vertInput == 0)
    {
        horiRotX += Input.GetAxis("Mouse Y") * rotSpeed * 3;
        horiRotX = Mathf.Clamp(horiRotX, -45f, 20f);
    }

    Quaternion rotation = Quaternion.Euler(-horiRotX, vertRotY, 0);
    transform.position = target.position - (rotation * offSet);
    
    //transform.Rotate(rotation.eulerAngles);
    transform.LookAt(target);
    //transform.RotateAround(target.transform.position, Vector3.up, vertRotY);
    //transform.RotateAround(target.transform.position, Vector3.left, rotSpeed * 3);
}
}