using System;
using UnityEngine;
using System;

[Serializable]
//This gives us the ability to easily add a new item, this is also a scriptable object
[CreateAssetMenu(fileName = "New Item", menuName = "Objects/Item")]
public class Item : ScriptableObject
{
    //These are the values that a default item will have
    public string name = "Item";
    public Sprite icon = null;
    public int cost = 0;
	public bool canEquip = false;

}
