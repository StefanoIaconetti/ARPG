using System;
using UnityEngine;
//This gives us the ability to easily add a new item, this is also a scriptable object
[CreateAssetMenu(fileName = "New Item", menuName = "Objects/Item")]
public class Item : ScriptableObject
{
    //These are the values that a default item will have
    public string name = "New Item";
    public Sprite icon = null;
    public int cost = 0;
    public int quantity = 0;

    public static implicit operator Item(InventoryItem v) {
        throw new NotImplementedException();
    }
}
