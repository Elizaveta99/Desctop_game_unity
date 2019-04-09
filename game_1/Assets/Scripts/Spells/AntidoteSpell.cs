using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AntidoteSpell : Spell
{
    //    Суть этого заклинания – перевести какого-либо персонажа
    //из состояния «отравлен» в состояние «здоров или ослаблен». Текущая
    //величина здоровья не изменяется.Заклинание требует 30 единиц маны.

    public PlayerState playerstate;
    public Mana playerMana;
    public Slider manaS;
    public Player plr;

    private void Start()
    {
    }

    public override void MagicEffect(Player go, int val) // как понять, в какое состояние переводить,здоров или ослаблен
    {
        plr = Hero.hero;
        playerstate = GetComponent<PlayerState>();
        playerMana = GetComponent<Mana>();
        manaS = playerMana.manaSlider;
        if (playerMana.currentMana >= 30 && playerstate.currentState == PlayerState.enumstate.poizoned)
        {
            playerstate.currentState = PlayerState.enumstate.normal; 
            plr.State = BasePlayer.enumstate.normal;
            playerMana.currentMana -= 30;
            manaS.value = playerMana.currentMana;
            plr.Mn = playerMana.currentMana;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MagicEffect(plr, 4);
        }
    }
}
