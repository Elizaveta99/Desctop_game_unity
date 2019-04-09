using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RodArtefact : Artefacts
{
    public RodArtefact()
    {
        power = 100; 
        renewability = true;
    }

    public PlayerHealth playerhealth;
    public Slider healthSlider;
    public Player player;

    private void Start() 
    {

        playerhealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<PlayerHealth>();
        healthSlider = playerhealth.healthSlider;
    }

    public override void MagicEffect(Player go, int val)
    {
        playerhealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<PlayerHealth>();
        playerhealth.currentHealth -= val;

        power -= val;
    }
}
