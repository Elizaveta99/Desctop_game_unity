using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadWaterArtefact : Artefacts
{
    public DeadWaterArtefact()
    {
        power = 100;
        renewability = false;
    }

    public Mana playermana;
    public Slider manaSlider;
    public Player player;

    private void Start()
    {
        player = Hero.hero;
    }

    public override void MagicEffect(Player go, int val)
    {
        playermana = GetComponent<Mana>();
        manaSlider = playermana.manaSlider;
        if (power > 0)
        {
            playermana.currentMana += val;
            if (playermana.currentMana > playermana.maxMana)
                playermana.currentMana = playermana.maxMana;
            manaSlider.value = playermana.currentMana;
            player.Mn = playermana.currentMana;
            power = 0;
        }
    }
}
