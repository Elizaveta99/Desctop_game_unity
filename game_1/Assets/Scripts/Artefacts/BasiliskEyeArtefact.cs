using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasiliskEyeArtefact : Artefacts
{
    public BasiliskEyeArtefact()
    {
        power = 100;
        renewability = false;
    }

    public PlayerState playerstate;
    public Player player;
    public Text text;
    public EnemyMove move;
    public Animator moveanim;
    public EnemyAttack attac;

    private void Start()
    {
        player = Hero.hero;
    }

    public override void MagicEffect(Player go, int val)
    {
        playerstate = GameObject.FindGameObjectWithTag("Enemy").GetComponent<PlayerState>();
        move = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMove>();

        if (power > 0)
        {
            PlayerState.enumstate st = playerstate.currentState;
            if (st != PlayerState.enumstate.dead)
            {
                playerstate.currentState = PlayerState.enumstate.paralyzed;

                move.maxSpeed = 0;
                moveanim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
                attac = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAttack>();
                move.flag = true;
                moveanim.SetTrigger("Stay");
                attac.enabled = false;
                power = 0;
            }
        }
    }
}
