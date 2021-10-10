using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    // Start is called before the first frame update    
    public float radius = 3f;//ระยะการมองเห็น
    public Transform player;
    public Transform interactItem;
    bool hasInteract = false; //เช็ตการชน


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position,interactItem.position);
        if(distance<=radius && !hasInteract){
            hasInteract = true;
            interact();
        }
    }

    public virtual void interact(){
        Debug.Log("Active");
    }
    //สร้างขอบเขตการชน
    private void OnDrawGizmosSelected() {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(interactItem.position,radius);
    }
    
}
