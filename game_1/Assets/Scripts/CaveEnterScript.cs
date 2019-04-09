using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveEnterScript : MonoBehaviour
{

    GameObject cave;
    PlayerHealth playerHealth;
    int index;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        Debug.Log("cave", gameObject);
        //cave = GameObject.FindGameObjectWithTag("cave"); // не ищет?
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
       // index = PlayerPrefs.GetInt("CharacterSelected");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "cave")
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                //DontDestroyOnLoad(this.gameObject);

                //PlayerPrefs.SetInt("CharacterSelected", index);
                SceneManager.LoadScene("Cave");

            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "cave")
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                //DontDestroyOnLoad(this.gameObject);
                //PlayerPrefs.SetInt("CharacterSelected", index);
                SceneManager.LoadScene("Cave");
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
       //Debug.Log("cave  trigger out", gameObject);
    }
}
