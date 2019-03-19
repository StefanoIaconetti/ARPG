using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXPBar : MonoBehaviour {

    public Image xp;
    public Player player;

    // Start is called before the first frame update
    void Start() {
        xp = GetComponent<Image>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update() {
        xp.fillAmount = player.xp / player.maxLevelXP;
    }
}
