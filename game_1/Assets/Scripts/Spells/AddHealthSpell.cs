using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AddHealthSpell : Spell
{
    public Player plr;
    public PlayerHealth playerHealth;
    public Mana playerMana;
    public Slider healthS, manaS;

    public override void MagicEffect(Player go, int val)
    {
        plr = Hero.hero;
        playerHealth = GetComponent<PlayerHealth>();
        playerMana = GetComponent<Mana>();
        healthS = playerHealth.healthSlider;
        manaS = playerMana.manaSlider;
        Debug.Log(playerHealth.currentHealth.ToString());
        Debug.Log(playerHealth.maxHealth.ToString());
        Debug.Log(playerMana.currentMana.ToString());
        Debug.Log(playerMana.maxMana.ToString());
        if ((playerHealth.currentHealth < playerHealth.maxHealth) && (playerMana.currentMana >= val))
        {
            Debug.Log("working!!");
            playerMana.currentMana -= val;
            playerHealth.currentHealth += val / 2;
            healthS.value = playerHealth.currentHealth;
            manaS.value = playerMana.currentMana;
            plr.Hp = playerHealth.currentHealth;
            plr.Mn = playerMana.currentMana;

        }


    }

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            MagicEffect(plr, 4);
        }
    }
}
