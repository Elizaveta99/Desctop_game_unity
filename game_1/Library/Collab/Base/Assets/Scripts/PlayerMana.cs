using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour {

    public int startingMana = 100;
    public int currentMana;
    public Slider manaSlider;
    bool attacking = false;

    // Use this for initialization
    private void Awake() {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void ToDamage(int amount)
    {
        Debug.Log("you are attacking something...", gameObject);

        attacking = true;
        currentMana -= (2 * amount);
        manaSlider.value = currentMana;
        //playerAudio.Play();
        if (currentMana <= 0)
        {
            Debug.Log("you are empty");
        }
    }
}
