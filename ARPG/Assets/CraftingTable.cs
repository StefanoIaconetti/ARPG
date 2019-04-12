using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : NPC {

    protected Player player;
    public Canvas canvas;
    public bool canCraft;
    public Item[] potions = new Item[4];

    public override void Triggered() {
        if (canvas.isActiveAndEnabled) {
            canvas.enabled = false;
        } else {
            canvas.enabled = true;
        }
    }

    private void Start() {
        canvas.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    //On click strength crafting
    public void CraftStrengthPotion() {
        Craft("Meat", "Strength Potion", 0);
    }

    //On click magic crafting
    public void CraftMagicPotion() {
        Craft("Bone", "Magic Potion", 1);
    }

    //On click protection crafting
    public void CraftProtectionPotion() {
        Craft("Stone", "Protection Potion", 2);
    }

    //On click speed crafting
    public void CraftSpeedPotion() {
        Craft("Leaf", "Speed Potion", 3);
    }

    //Crafting method
    public void Craft(string recipeItem, string potionName, int arrayCount) {
        InventoryItem craftableItem = new InventoryItem(new Item(), 0);

        //Iterate through it
        foreach (InventoryItem item in Player.inventory.items) {
            if (item.item.name == recipeItem) {
                if (item.item.name == potionName || item.itemQuantity >= 4 && Player.inventory.items.Count < 9) {
                    canCraft = true;
                    craftableItem = item;
                }
            }
        }

        //Craft it
        if (canCraft) {
            for (int i = 0; i < 4; i++) {
                Player.inventory.RemoveItem(craftableItem);
            }
            InventoryItem newPotion = new InventoryItem(potions[arrayCount], 1);
            Player.inventory.AddItem(newPotion);
            Player.UpdateUI();
        }
    }
}
