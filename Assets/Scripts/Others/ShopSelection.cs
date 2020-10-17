using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSelection : MonoBehaviour
{

    [SerializeField]
    GameObject[] ItemFields;

    // Start is called before the first frame update
    void Start()
    {
        List<int> alreadyDrawn = new List<int>();

        for(int i=0; i< ItemFields.Length; i++)
        {

            bool foundLegit = true;
            do
            {
                foundLegit = true;
                int r = (int)Random.Range(0, Shop.ShopInstance.items.Length);

                if (alreadyDrawn.Contains(r))
                {
                    foundLegit = false;
                }
                else
                {
                    ItemFields[i].GetComponent<ItemField>().itemToBuy = Shop.ShopInstance.items[r];
                    ItemFields[i].GetComponent<ItemField>().indexForBuy = r;
                    ItemFields[i].GetComponent<ItemField>().showPrice();
                    alreadyDrawn.Add(r);
                }

            }
            while (!foundLegit);

        }

    }

}
