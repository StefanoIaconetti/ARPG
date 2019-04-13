using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GifterNPC : NPC {

    public LootTable gifts;
    public bool isTalkedTo;

    public override void Triggered() {
        base.Triggered();
        if (isTalkedTo == false) {
            Item item = gifts.LootItem();
            InventoryItem gift = new InventoryItem(item, 1);
            Player.inventory.AddItem(gift);
            Player.UpdateUI();
            isTalkedTo = true;
        }
    }

    private void FixedUpdate() {
        if (isTalkedTo) {
            GetComponent<GifterNPC>().nameOfCharacter = "gifterafter";
        }
    }

}
