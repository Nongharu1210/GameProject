using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemQuestSystem : MonoBehaviour
{
    public GameObject PickupPanel;
    public List<GameObject> ItemQuests = new List<GameObject>();
    static public int ItemQuestCollection;
    public GameObject ItemCounttxt;
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update : "+ItemQuestCollection);
        ItemCounttxt.GetComponent<Text>().text = "ItemQuest" + ItemQuestCollection + "/4";
        
    }

    private void OnTriggerEnter(Collider other) {
        //ถ้าเพย์เยอร์เดินมาชน
        if(other.gameObject.transform.tag == "ItemQuest"){
            //ให้กำหนดว่าทำอะไร
            other.gameObject.GetComponent<ItemQuestSystem>().PickupPanel.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other) {
        //Debug.Log(ItemQuestCollection);
        if (other.gameObject.transform.tag == "ItemQuest"){
            if (Input.GetKeyDown(KeyCode.E)){
                //Debug.Log("Before : "+ItemQuestCollection);
                PickupPanel.SetActive(false);
                ItemQuests.Add(other.gameObject);
                ItemQuestCollection++;
                other.gameObject.SetActive(false);
                //Debug.Log("after : "+ItemQuestCollection);
                Update();
            }
        } 
    }
    
}
