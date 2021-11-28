using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForInventory : MonoBehaviour
{
    [SerializeField]
    ItemConfig testItem;


    InventoryModel testModel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            testModel.EquipItem(testItem);
            Debug.Log("item added");
        }
    }
}
