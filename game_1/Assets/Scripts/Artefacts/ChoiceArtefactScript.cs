using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceArtefactScript : MonoBehaviour
{
    public LivingWaterArtefact artef1;
    public DeadWaterArtefact artef2;
    public RodArtefact artef3;
    public FrogArtefact artef4;
    public PoisonArtefact artef5;
    public BasiliskEyeArtefact artef6;
    public Player plr;
    public Player en;
    public CollectArtefacts amount;

    public bool isArt1 = false;
    public bool isArt2 = false;
    public bool isArt3 = false;
    public bool isArt4 = false;
    public bool isArt5 = false;
    public bool isArt6 = false;
    GameObject temp;



    void Start ()
    {
        artef1 = GetComponent<LivingWaterArtefact>();
        artef2 = GetComponent<DeadWaterArtefact>();
        artef3 = GetComponent<RodArtefact>();
        artef4 = GetComponent<FrogArtefact>();
        artef5 = GetComponent<PoisonArtefact>();
        artef6 = GetComponent<BasiliskEyeArtefact>();
        plr = Hero.hero;
        en = Hero.hero;
        amount = GetComponent<CollectArtefacts>();
 
    }

    void Update ()
    {
        amount = GetComponent<CollectArtefacts>();
        artef1 = GetComponent<LivingWaterArtefact>();

        if (Input.GetKeyDown(KeyCode.Z)) isArt1 = true;
        if (isArt1)
        {
            if (amount.art1 > 0)
            {
                artef1.MagicEffect(plr, 50);
                amount.art1--;
                amount.amount1.text = amount.art1.ToString();
            }
            isArt1 = false;
        }

        if (Input.GetKeyDown(KeyCode.X)) isArt2 = true;
        if (isArt2)
        {
            if (amount.art2 > 0)
            {
                artef2.MagicEffect(plr, 50);
                amount.art2--;
                amount.amount2.text = amount.art2.ToString();
            }
            isArt2 = false;
        }

        if (Input.GetKeyDown(KeyCode.C)) isArt3 = true;
        if (isArt3)
        {
            if (amount.art3 > 0)
            {
                artef3.MagicEffect(en, 20);
                amount.art3--;
                amount.amount3.text = amount.art3.ToString();
            }
            isArt3 = false;
        }

        if (Input.GetKeyDown(KeyCode.V)) isArt4 = true;
        if (isArt4)
        {
            if (amount.art4 > 0)
            {
                artef4.MagicEffect(plr, 0);
                amount.art4--;
                amount.amount4.text = amount.art4.ToString();
            }
            isArt1 = false;
        }

        if (Input.GetKeyDown(KeyCode.B)) isArt5 = true;
        if (isArt5)
        {
            if (amount.art5 > 0)
            {
                artef5.MagicEffect(en, 20);
                amount.art5--;
                amount.amount5.text = amount.art5.ToString();
            }
            isArt5 = false;
        }

        if (Input.GetKeyDown(KeyCode.N)) isArt6 = true;
        if (isArt6)
        {
            if (amount.art6 > 0)
            {
                artef6.MagicEffect(en, 0);
                amount.art6--;
                amount.amount6.text = amount.art6.ToString();
            }
            isArt6 = false;
        }
    }
}
