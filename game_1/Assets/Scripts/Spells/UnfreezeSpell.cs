using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnfreezeSpell : Spell
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
        if (go.Mn >= 85 && playerstate.currentState == PlayerState.enumstate.paralyzed)
        {
            playerstate.currentState = PlayerState.enumstate.normal;
            playerhealth.currentHealth = 1;
            playermana.currentMana -= 85;
        }
    }
}
