using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class LivingWaterArtefact : Artefacts
{
    public LivingWaterArtefact()
    {
        power = 100;
        renewability = false;
    }

    public PlayerHealth playerhealth;
    public Slider healthSlider;
    public Player player;

    private void /*Start*/Awake() 
    {
        player = Hero.hero;

    }

    public override void MagicEffect(Player go, int val)
    {
        playerhealth = GetComponent<PlayerHealth>();
        healthSlider = playerhealth.healthSlider;

        if (power > 0)
        {           
            playerhealth.currentHealth += val;
            
            if (playerhealth.currentHealth > playerhealth.maxHealth)
                playerhealth.currentHealth = playerhealth.maxHealth;
            
            healthSlider.value = playerhealth.currentHealth;

            power = 0;
        }
    }
}
