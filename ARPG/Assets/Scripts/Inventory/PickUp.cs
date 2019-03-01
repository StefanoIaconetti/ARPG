using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    //Creates an instance of item
    public Item item;

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
            //Boolean to see if the item has picked up or not
           bool pickedUp = Inventory.instance.AddItem(item);
            if (pickedUp){
                //Destroys the gameobject because it is then added into the inventory
                Destroy(gameObject);
            }
        }
    }
}
