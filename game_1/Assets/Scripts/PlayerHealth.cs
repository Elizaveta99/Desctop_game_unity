using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    public int maxHealth;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f; 
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    public Player player;
    public GameObject plr;

    Animator anim;
    CharacterController playerMovement;
    bool isDead = false;
    bool damaged = false;
    

    private void Awake()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>().hero;
        player = Hero.hero;
        playerMovement = GetComponent<CharacterController>();
        //startingHealth = player.Maxhp; 
        //maxHealth = player.Maxhp; 
        plr = GameObject.FindGameObjectWithTag("Player");//?? через getcomponent?
        currentHealth = startingHealth;
        maxHealth = startingHealth;
    }

	void Update () 
	//void FixedUpdate() 
    {

        player = Hero.hero;
        //playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

        if (damaged)
        {
            //Debug.Log("damageColor");
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if (player.Hp * 100 / player.Maxhp < 10) player.State = Player.enumstate.weakened;
        if (player.Hp * 100 / player.Maxhp < 10) player.State = Player.enumstate.normal;
        if (player.Hp == 0) player.State = Player.enumstate.dead;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !isDead)
        {
            Debug.Log("Dead1");
            Death();
        }
        //player.Hp = currentHealth;
    }

    private void Death()
    {
        isDead = true;
        anim.SetTrigger("PlayerDead");
        Debug.Log("Dead2");
        playerMovement = GetComponent<CharacterController>();
        playerMovement.enabled = false;
    }

}
