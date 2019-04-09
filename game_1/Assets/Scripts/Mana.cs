using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{

    public int startingMana;
    public int maxMana = 100;
    public int currentMana;
    public Slider manaSlider;
    bool attacking = false;

    private void Awake()
    {
        currentMana = startingMana;
    }

    void Update()
    {

    }

    private void ToDamage(int amount)
    {
        Debug.Log("you are attacking something...", gameObject);

        attacking = true;
        currentMana -= (2 * amount);
        manaSlider.value = currentMana;
        if (currentMana <= 0)
        {
            Debug.Log("you are empty");
        }
    }
}
