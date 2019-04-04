using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //Creates an instance of item
    public Item item;
    public bool collide = false;

    //When the player collides
    void OnTriggerEnter2D(Collider2D character)
    {
        //When colliding with the player
        if (character.gameObject.name == "Player")
        {
            //If the player collides with player then collide is set to true.
            collide = true;
        }
    }

    void Update() {
        //If the player collided with the item
        if (collide){
			InventoryItem finalItem = new InventoryItem (item, 1);
            //Boolean to see if the item has picked up or not
			bool pickedUp = Player.inventory.AddItem(finalItem);
            if (pickedUp){
                //Destroys the gameobject because it is then added into the inventory
                Destroy(gameObject);
				Player.UpdateUI ();
            }
        }
    }
}
