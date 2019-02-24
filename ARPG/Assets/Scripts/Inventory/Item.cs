using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
        //When the NPC collides
        void OnTriggerEnter2D(Collider2D character)
        {
            //When colliding with the player
            if (character.gameObject.name == "Player")
            {
                PickUp();

            }
        }

    void PickUp()
    {
        Destroy(gameObject);
    }

    void Update()
    {

    }
    
}
