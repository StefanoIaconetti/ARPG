﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeepingManager : MonoBehaviour
{
	public Player player;
	public bool canSell = false;
	public GameObject playerInventory;
	public InventoryItem currentItem;
	public bool startSell;
	public GameObject shopkeeperSelling;

	public void LateUpdate(){
		if(startSell){

			StartCoroutine(Selling (currentItem.item));
			startSell = false;


			Player.UpdateUI ();
		}

	}

	public void SetSell(){
		canSell = true;
		playerInventory.SetActive (true);
	}

	public IEnumerator Selling(Item item) {
		{
			shopkeeperSelling.SetActive (true);
			yield return new WaitForSeconds (6f);
			player.gold += item.cost;
			player.xp += 50;
			shopkeeperSelling.SetActive (false);

		}

	}
}
