using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{

    public bool isPaused = false;
    public GameObject PauseMenuCanvas;

	void Start ()
    {
		
    }

    void Update ()
    {
        if (isPaused)
        {
            PauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            PauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ChoiceCharacterButton()
    {
        SceneManager.LoadScene("ChoiceCharacter");
    }

    public void Continue()
    {
        isPaused = false;
    }
}
