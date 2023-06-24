using UnityEngine;
using System.Collections;

public class HoldItems
{


    public int HoldItemID = -1;

    public int HoldInventoryID = -1;

    public int HoldEquipID = -1;

    public void UnHold()
    {
        HoldEquipID = -1;
        HoldInventoryID = -1;
        HoldItemID = -1;
    }


}
