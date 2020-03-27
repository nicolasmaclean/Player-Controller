using UnityEngine;

public class Item : MonoBehaviour
{
    public static ShoppingListManager shoppingListManagerStatic;
    public ShoppingListManager shoppingListManager;
    public string itemName;
    public int amount = 1;
    public float rotationSpeed = 1f;

    Vector3 rotation;

    void Start()
    {
        rotation = transform.rotation.eulerAngles;
        shoppingListManagerStatic = shoppingListManager;
    }

    void Update()
    {
        rotation.y++;
        transform.rotation = Quaternion.Euler(rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        shoppingListManagerStatic.itemCollected(itemName);

        Destroy(gameObject);
    }
}
