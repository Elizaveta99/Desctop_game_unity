using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CureSpell : Spell
{

    public PlayerState playerstate;
    public Mana playermana;

    private void Start()
    {
        playerstate = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
        playermana = GameObject.FindGameObjectWithTag("Player").GetComponent<Mana>();
    }

    public override void MagicEffect(Player go, int val) 
    {
        if (playermana.currentMana >= 20 && playerstate.currentState == PlayerState.enumstate.ill)
        {
            playerstate.currentState = PlayerState.enumstate.normal; 
            playermana.currentMana -= 20;
        }
    }
}
