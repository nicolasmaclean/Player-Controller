using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Array : MonoBehaviour
{
    public int arrayAmount;
    public Vector3 offset;
    public GameObject arrayTemplate;
    public List<GameObject> arrayItems = new List<GameObject>();

    public void resetItems()
    {
        foreach(GameObject x in arrayItems)
                DestroyImmediate(x);

            arrayItems = new List<GameObject>();

    }

    public void updateItems()
    {        
        resetItems();

        for(int i = 0; i < arrayAmount; i++) {
            Vector3 nPos = offset.z * i * transform.forward + offset.x * i * transform.right;
            GameObject arrItem = Instantiate(arrayTemplate, transform.position+nPos, transform.rotation);
            DestroyImmediate(arrItem.GetComponent<Array>());
            arrItem.transform.parent = transform;
            arrayItems.Add(arrItem);
        }
    }

    void Update()
    {
        if(arrayItems.Count != arrayAmount)
            updateItems();
    }
}
