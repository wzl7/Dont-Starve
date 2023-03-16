using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject slotPrefab;
    GameObject[] slots = new GameObject[11];
    //Item[] items= new Item[11];
    Image[] itemImages = new Image[11];
    Text[] qtyText = new Text[11];
   Button[] slotBtn = new Button[11];
    private void Start()
    {
        CreateSlots();
    }
    private void CreateSlots()
    {
        if(slotPrefab != null) 
        {
            for (int i = 0; i < 11; i++)
            {
                GameObject newSlot = Instantiate(slotPrefab);
                newSlot.name = "ItemSlot" + i;
                newSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);
                slots[i] = newSlot;
                itemImages[i] = slots[i].GetComponent<Slot>().item;
                qtyText[i] = slots[i].GetComponent<Slot>().qtyText;
                slotBtn[i] = slots[i].GetComponent<Slot>().slotBtn;

            }
        }
    }
    //public void AddItem(Item itemToAdd)
    //{
    //    for (int i = 0; i < 11; i++)
    //    {
    //        if (items[i] != null && items[i].itemType==itemToAdd.itemType)
    //        {
    //            items[i].quantity += 1;
    //            qtyText[i].text = items[i].quantity.ToString();
    //            return;
    //        }
    //    }
    //    for (int i = 0; i < 11; i++)
    //    {
    //        `
    //    }
    //}
}
