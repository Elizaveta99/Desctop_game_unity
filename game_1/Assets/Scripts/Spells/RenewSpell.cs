using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RenewSpell : Spell
{

    public PlayerState playerstate;
    public Mana playermana;
    public PlayerHealth playerhealth;

    private void Start()
    {
        playerstate = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
        playermana = GameObject.FindGameObjectWithTag("Player").GetComponent<Mana>();
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    public override void MagicEffect(Player go, int val) 
    {
        if (playermana.currentMana >= 150 && playerstate.currentState == PlayerState.enumstate.dead)
        {
            playerstate.currentState = PlayerState.enumstate.normal; 
            playermana.currentMana -= 150;
            playerhealth.currentHealth = 1;
        }
    }
}
