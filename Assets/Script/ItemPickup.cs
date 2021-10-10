using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : InteractiveObject
{
    public Item item;
    public override void interact()
    {
        base.interact();
        pickup();
    }
    void pickup(){
        Destroy(gameObject);
    }
}
