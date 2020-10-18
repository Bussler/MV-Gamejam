using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemField : MonoBehaviour
{
    public Item itemToBuy;
    public int indexForBuy;
    public bool blinking = false;

    public void showPrice()
    {
        GameObject text = transform.GetChild(0).gameObject;
        text.GetComponent<TextMesh>().text = "Cost: " + itemToBuy.cost;
        text.SetActive(true);

        GameObject NameText = transform.GetChild(1).gameObject;
        NameText.GetComponent<TextMesh>().text = itemToBuy.name;
        NameText.SetActive(true);

        this.GetComponent<SpriteRenderer>().sprite = itemToBuy.image;
    }

    private void OnTriggerEnter2D(Collider2D collision) //buy the item
    {
        if (Shop.ShopInstance.buyItem(indexForBuy))
        {
            Destroy(gameObject);//destroy gameobject after buy
        }
        else
        {
            if (!blinking)
            {
                Debug.Log("Hahaeee");
                StartCoroutine(DoBlinks(2, 0.2f));
                blinking = true;
            }
        }
    }


    IEnumerator DoBlinks(int blinks, float blinkTime)
    {
        bool half = false;
        Color cur = GetComponent<SpriteRenderer>().color;
        Debug.Log("Haha");
        for (int i = 0; i < blinks * 2; i++)
        {
            if (half)
            {
                this.GetComponent<SpriteRenderer>().color = new Color(cur.r, cur.g, cur.b, 1);
                half = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = new Color(cur.r, cur.g, cur.b, 0.3f);
                half = true;
            }
            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
        }

        //make sure renderer is setup when we exit
        this.GetComponent<SpriteRenderer>().color = new Color(cur.r, cur.g, cur.b, 1);
        blinking = false;
    }

}
