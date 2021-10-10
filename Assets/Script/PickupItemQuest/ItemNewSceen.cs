using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemNewSceen : MonoBehaviour
{
    //เก็บตัวละคร Player
    public GameObject player;
    public GameObject PickupPanel;
    public string sceneName;

    private void OnTriggerEnter(Collider other) {
        //ถ้าเพย์เยอร์เดินมาชน
        if(other.gameObject.transform.tag == "Player"){
            //ให้กำหนดว่าทำอะไร
            other.gameObject.GetComponent<ItemQuestSystem>().PickupPanel.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.transform.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.E)){
                SceneManager.LoadScene(sceneName);
                
            }
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.transform.tag == "Player"){
            //ให้กำหนดว่าทำอะไร
            other.gameObject.GetComponent<ItemQuestSystem>().PickupPanel.SetActive(false);
        }
    }
    
}

