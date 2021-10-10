using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	#region Singleton
	public static Inventory instance;
	void Awake ()
	{
		instance = this;
	}
	#endregion

	public delegate void OnItemChanged(); //เมื่อคลิกมีการอัพเดทข้อมูล
	public OnItemChanged onItemChangedCallback;

	public int space = 10;	// Amount of item spaces

	
	public List<Item> items = new List<Item>();

	// ทำการเพิ่ม Item เมื่อมีช่องว่าง
	public void Add (Item item)
	{
		if (item.showInventory) {
			if (items.Count >= space) {
				Debug.Log ("Not enough room.");
				return;
			}
			items.Add (item);
			if (onItemChangedCallback != null){
				onItemChangedCallback.Invoke ();
            }
		}
	}

	// เมื่อใช้ Item แล้ว Item 
	public void Remove (Item item)
	{
		items.Remove(item);
		if (onItemChangedCallback != null){
            onItemChangedCallback.Invoke();
        }
	}
}
