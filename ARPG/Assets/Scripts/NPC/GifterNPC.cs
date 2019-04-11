using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GifterNPC : GenericNPC {

    public LootTable gifts;

    public override void Triggered() {
        base.Triggered();

        Item item = gifts.LootItem();
        InventoryItem gift = new InventoryItem(item, 1);
        Player.inventory.AddItem(gift);
        Player.UpdateUI();

    }

}
