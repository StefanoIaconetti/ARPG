using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Objects/Equipable")]
public class Equipable : Item {


    public int statBoost;
	public EquipType equipType = EquipType.Armour;
}

public enum EquipType
{
	Armour,
	Wand,
	Weapon,
	Potion
};
