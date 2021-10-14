using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    //เก็บตัวละคร Player
    public GameObject player;
    public GameObject PickupPanel;

    private void OnTriggerEnter(Collider other) {
        //ถ้าเพย์เยอร์เดินมาชน
        if(other.gameObject.transform.tag == "Player"){
            //ให้กำหนดว่าทำอะไร
            other.gameObject.GetComponent<ItemQuestSystem>().PickupPanel.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.transform.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.F)){
                PickupPanel.SetActive(false);
                Destroy(gameObject);
            }
        }
        
    }

    // private void OnTriggerExit(Collider other) {
    //     if(other.gameObject.transform.tag == "Player"){
    //         //ให้กำหนดว่าทำอะไร
    //         other.gameObject.GetComponent<ItemQuestSystem>().PickupPanel.SetActive(false);
    //     }
    // }
    
}
