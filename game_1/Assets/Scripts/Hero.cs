using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public static Player hero;
    public int Maxhp;

	void Start ()
    {
		hero = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Maxhp = hero.Maxhp;

    }

    public void maxhp()
    {
        Maxhp = hero.Maxhp;
        //return hero.Maxhp;
    }
	
}
