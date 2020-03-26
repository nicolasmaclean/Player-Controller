using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListManager : MonoBehaviour
{
    public ShoppingListItem[] shoppingListItems;
    public GameObject itemPrefab;
    public VerticalLayoutGroup verticalLayoutGroup;
    public GameObject[] items;

    void Start()
    {
        items = new GameObject[shoppingListItems.GetLength(0)];
        for(int i = 0; i < items.GetLength(0); i++) {
            ShoppingListItem x = shoppingListItems[i];
            GameObject item = Instantiate(itemPrefab, Vector3.zero, new Quaternion(0,0,0,0));
            item.transform.SetParent(verticalLayoutGroup.transform);
            item.GetComponent<Toggle>().isOn = false;
            item.GetComponentInChildren<Text>().text = x.ItemName + "(" + x.currentAmount + "/" + x.ItemAmount + ")";
            items[i] = item;
        }
    }

    void updateItems()
    {
        for(int i = 0; i < items.GetLength(0); i++) {
            ShoppingListItem x = shoppingListItems[i];
            GameObject item = items[i];
            item.transform.SetParent(verticalLayoutGroup.transform);
            item.GetComponent<Toggle>().isOn = false;
            item.GetComponentInChildren<Text>().text = x.ItemName + "(" + x.currentAmount + "/" + x.ItemAmount + ")";
        }
    }
}
