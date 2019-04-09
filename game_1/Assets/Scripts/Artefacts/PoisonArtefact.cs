using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoisonArtefact : Artefacts
{
    public PoisonArtefact()
    {
        power = 100; 
        renewability = true;
    }

    public PlayerState playerstate;
    public PlayerHealth playerhealth;
    public Slider healthSlider;
    public Player player;
    public Text text;

    private void Start()
    {
        playerhealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<PlayerHealth>();
        playerstate = GameObject.FindGameObjectWithTag("Enemy").GetComponent<PlayerState>();
    }

    public override void MagicEffect(Player go, int val)
    {
        playerhealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<PlayerHealth>();
        playerstate = GameObject.FindGameObjectWithTag("Enemy").GetComponent<PlayerState>();
        if (playerstate.currentState == PlayerState.enumstate.normal || playerstate.currentState == PlayerState.enumstate.weakened)
        {
            playerstate.currentState = PlayerState.enumstate.poizoned;
            playerhealth.currentHealth -= val;
        }
    }
}
