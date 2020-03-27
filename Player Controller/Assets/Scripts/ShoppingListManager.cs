using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListManager : MonoBehaviour
{
    public List<ShoppingListItem> shoppingListItems;
    public bool autoPopulateShoppingList;
    public VerticalLayoutGroup verticalLayoutGroup;
    public GameObject shoppingListPanel;
    public GameObject winPanel;
    public GameObject itemPrefab;
    
    GameObject[] items;

    void Start()
    {
        if(autoPopulateShoppingList) {
            shoppingListItems = new List<ShoppingListItem>();

            foreach(Item item in FindObjectsOfType<Item>()) {
                bool needToAdd = true;

                foreach(ShoppingListItem itemInList in shoppingListItems) {
                    if(item.itemName.Equals(itemInList.ItemName)) {
                        itemInList.ItemAmount++;
                        needToAdd = false;
                    }
                }

                if(needToAdd) {
                    ShoppingListItem tempItem = new ShoppingListItem();
                    tempItem.ItemName = item.itemName;
                    tempItem.ItemAmount++;
                    shoppingListItems.Add(tempItem);
                }
            }
        }

        items = new GameObject[shoppingListItems.Count];
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
        bool won = true;
        for(int i = 0; i < items.GetLength(0); i++) {
            ShoppingListItem x = shoppingListItems[i];
            GameObject item = items[i];

            if(x.currentAmount < x.ItemAmount) {
                won = false;
                item.GetComponent<Toggle>().isOn = false;
            }
            else {
                item.GetComponent<Toggle>().isOn = true;
            }

            item.transform.SetParent(verticalLayoutGroup.transform);
            item.GetComponentInChildren<Text>().text = x.ItemName + " (" + x.currentAmount + "/" + x.ItemAmount + ")";
        }

        if(won)
            displayWinScene();

    }

    public void itemCollected(string name)
    {
        for(int i = 0; i < items.GetLength(0); i++) {
            ShoppingListItem x = shoppingListItems[i];
            if(x.ItemName.Equals(name)) {
                x.currentAmount++;
                updateItems();
            }
        }
    }

    public void displayWinScene()
    {
        shoppingListPanel.SetActive(false);
        winPanel.SetActive(true);
        Camera.main.GetComponent<FPSCameraController>().enabled = false;
        Debug.Log("You Won!");
    }
}
