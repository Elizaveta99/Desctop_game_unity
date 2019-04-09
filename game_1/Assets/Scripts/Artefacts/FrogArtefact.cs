using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogArtefact : Artefacts
{
    public FrogArtefact()
    {
        power = 100;
        renewability = false;
    }

    public PlayerState playerstate;
    public Player player;
    public Text text;

    private void Start()
    {
        player = Hero.hero;
    }

    public override void MagicEffect(Player go, int val)
    {
        playerstate = GetComponent<PlayerState>();
        if (power > 0)
        {
            PlayerState.enumstate st = playerstate.currentState;

            if (st == PlayerState.enumstate.poizoned)
            {
                playerstate.currentState = PlayerState.enumstate.normal;
                player.State = (BasePlayer.enumstate)playerstate.currentState;
                text.text = "normal";
                power = 0;
            }
        }
    }
}
