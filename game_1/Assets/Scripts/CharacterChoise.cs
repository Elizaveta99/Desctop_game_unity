using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CharacterChoise : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;
    public Text info;
    private string text;
    public Player player;

    private void Start ()
    {
        player = Hero.hero;

        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;

        foreach (GameObject go in characterList)
            go.SetActive(false);

        if (characterList[index])
        {
            characterList[index].SetActive(true);
            player.Info(ref info, index);
        }
	}


	
	public void ToggleLeft()
    {
        characterList[index].SetActive(false);

        index--;
        if (index < 0)
            index = characterList.Length - 1;
        //Info(index);
        player.Info(ref info, index);

        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        characterList[index].SetActive(false);

        index++;
        if (index >= characterList.Length)
            index = 0;
        player.Info(ref info, index);

        characterList[index].SetActive(true);
    }

    public void Ok()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);

        if (index == 0)
        {
            Debug.Log("choose");
            player = new Player(0, "Human", Player.enumrace.human, Player.enumgender.male);
            player.AbilityToTalk = true;
            player.AbilityToMove = true;
            player.State = Player.enumstate.normal;
            player.Maxhp = 100;
            player.Hp = 100;
            player.Maxmn = 40;
            player.Mn = 40;
            player.Age = 20;
            player.Experience = 0;
        }

        if (index == 1)
        {
            player = new Player(0, "Orc", Player.enumrace.orc, Player.enumgender.male);
            player.AbilityToTalk = true;
            player.AbilityToMove = true;
            player.State = Player.enumstate.normal;
            player.Maxhp = 140;
            player.Hp = 140;
            player.Maxmn = 10;
            player.Mn = 10;
            player.Age = 100;
            player.Experience = 0;
        }

        if (index == 2)
        {
            player = new Player(0, "Goblin", Player.enumrace.goblin, Player.enumgender.male);
            player.AbilityToTalk = true;
            player.AbilityToMove = true;
            player.State = Player.enumstate.normal;
            player.Maxhp = 60;
            player.Hp = 60;
            player.Maxmn = 10;
            player.Mn = 10;
            player.Age = 500;
            player.Experience = 0;
        }

        if (index == 3)
        {
            player = new Player(0, "Gnome", Player.enumrace.gnome, Player.enumgender.male);
            player.AbilityToTalk = true;
            player.AbilityToMove = true;
            player.State = Player.enumstate.normal;
            player.Maxhp = 100;
            player.Hp = 100;
            player.Maxmn = 60;
            player.Mn = 60;
            player.Age = 50;
            player.Experience = 0;
        }

        if (index == 4)
        {
            player = new Player(0, "Elf", Player.enumrace.elf, Player.enumgender.male);
            player.AbilityToTalk = true;
            player.AbilityToMove = true;
            player.State = Player.enumstate.normal;
            player.Maxhp = 60;
            player.Hp = 60;
            player.Maxmn = 140;
            player.Mn = 140;
            player.Age = 3;
            player.Experience = 0;
        }

        SceneManager.LoadScene("Stage1");

    }
}
