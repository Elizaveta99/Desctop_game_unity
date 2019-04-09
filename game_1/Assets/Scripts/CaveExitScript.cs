using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveExitScript : MonoBehaviour
{

    GameObject cave;
    PlayerHealth playerHealth;

    void Awake /*Start*/ ()
    {
        //Debug.Log("cave door", gameObject);
        //cave = GameObject.FindGameObjectWithTag("cave"); // не ищет?
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("cave  trigger in door", gameObject);

        if (other.gameObject.tag == "door")
        {
            if (Input.GetKeyDown(KeyCode.Tab))
                SceneManager.LoadScene("Stage1");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "door")
        {
            Debug.Log("cave  trigger stay door", gameObject);

            if (Input.GetKeyDown(KeyCode.Tab))
                SceneManager.LoadScene("Stage1");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("cave  trigger out", gameObject);
    }
}
