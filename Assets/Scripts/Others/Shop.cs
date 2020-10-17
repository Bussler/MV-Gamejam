using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
     public static Shop ShopInstance { get; private set; }
     
     
     public Item[] items = new Item[5];
     
     private void Awake()
     {
         if (ShopInstance == null)
         {
             ShopInstance = this;
             DontDestroyOnLoad(gameObject);
         }
         else if (ShopInstance != this)
         {
             Destroy(ShopInstance);
         }
     }

     private void buyItem(int index)
     {
         Item item = items[index];
         if (StatManager.StatManagerInstance.GetNectarAmount() >= item.cost)
         {
             StatManager.StatManagerInstance.DecreaseNectarAmount(item.cost);
             item.ApplyEffects();
         }
         else
         {
             Debug.Log("Could not buy item " + items[index].name + " because not enough nectar is available.");
             return;
         }
     }
}