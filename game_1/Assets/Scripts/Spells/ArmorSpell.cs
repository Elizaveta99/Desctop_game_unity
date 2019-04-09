using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArmorSpell : Spell
{

    public EnemyAttack enemyattack;

    public PlayerState playerstate;
    public Mana playermana;

    private void Start()
    {
        enemyattack = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAttack>(); ;
        playerstate = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
        playermana = GameObject.FindGameObjectWithTag("Player").GetComponent<Mana>();
    }

    public override void MagicEffect(Player go, int val) 
    {
        if (playermana.currentMana >= 50 * val)
        {
            playermana.currentMana -= 50 * val;
            enemyattack.enabled = false; 
        }
        else
        {
            playermana.currentMana = playermana.currentMana % 50;
        }
    }
}
