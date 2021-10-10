using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMini : MonoBehaviour
{
    //เก็บตัวละคร Player
    public GameObject player;
    public GameObject Minigame;
    public GameObject Map;
    
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
                Minigame.SetActive(true);
                Map.SetActive(false);
                
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
