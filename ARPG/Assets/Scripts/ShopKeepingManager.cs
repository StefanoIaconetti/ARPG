using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeepingManager : MonoBehaviour
{
	public Player player;
	public bool canSell = false;

	public IEnumerator Selling(Item item) {
		{
			yield return new WaitForSeconds (30f);
			player.gold += item.cost;

		}

	}
}
