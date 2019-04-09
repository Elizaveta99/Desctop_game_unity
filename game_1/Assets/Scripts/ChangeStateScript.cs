using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStateScript : MonoBehaviour
{
    public Text textstate;
    public Player player;

	void Start ()
    {
        player = Hero.hero; 
    }
	
	void Update ()
    {
        if (player.State == BasePlayer.enumstate.normal)
            textstate.text = "normal";
        if (player.State == BasePlayer.enumstate.dead)
            textstate.text = "dead";
        if (player.State == BasePlayer.enumstate.ill)
            textstate.text = "ill";
        if (player.State == BasePlayer.enumstate.paralyzed)
            textstate.text = "paralyzed";
        if (player.State == BasePlayer.enumstate.poizoned)
            textstate.text = "poizoned";
        if (player.State == BasePlayer.enumstate.weakened)
            textstate.text = "weakened";
    }
}
