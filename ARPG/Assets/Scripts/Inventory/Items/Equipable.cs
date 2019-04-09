using System;
using UnityEngine;
using System;

//This creates an equipable item
[Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Objects/Equipable")]
public class Equipable : Item {
	//Inherits all of item but has statboost and equiptype which is a enum
    public int statBoost;
	public EquipType equipType = EquipType.Armour;
}

//Enum of the equipment type
public enum EquipType
{
	Armour,
	Wand,
	Weapon,
	Potion
};
