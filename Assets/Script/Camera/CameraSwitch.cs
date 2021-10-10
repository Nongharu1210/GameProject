using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cameraOne;
    public GameObject cameraTwo;
    bool CameraCheck = true;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            if(CameraCheck == false){
            cameraOne.SetActive(false);
            cameraTwo.SetActive(true);
            CameraCheck = true;
            }else if(CameraCheck == true){
            cameraOne.SetActive(true);
            cameraTwo.SetActive(false);
            CameraCheck = false;
            }
        }
    }

}
