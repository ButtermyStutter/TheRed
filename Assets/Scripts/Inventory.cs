using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GenericRaycast raycast;
    private int scrapPicked = 0;

    public Text invenOutPutNumber;



    void Update()
    {
        invenOutPutNumber.text = scrapPicked.ToString();

        if (raycast.objectPickedup)
        {
            PickupUpdate();
        }
    }

    private void PickupUpdate()
    {
        scrapPicked++;
        raycast.objectPickedup = false;
    }
     

}
