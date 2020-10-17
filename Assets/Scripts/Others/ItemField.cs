using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemField : MonoBehaviour
{
    public Item itemToBuy;
    public int indexForBuy;

    public void showPrice()
    {
        GameObject text = transform.GetChild(0).gameObject;
        text.GetComponent<TextMesh>().text = "Cost: " + itemToBuy.cost;
        text.SetActive(true);

        this.GetComponent<SpriteRenderer>().sprite = itemToBuy.image;
    }

    private void OnTriggerEnter2D(Collider2D collision) //buy the item
    {
        if (Shop.ShopInstance.buyItem(indexForBuy))
            Destroy(gameObject);//destroy gameobject after buy
    }

}
