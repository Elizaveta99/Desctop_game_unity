using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArtefactsScript : MonoBehaviour
{
    public bool isArtef = false;
    public GameObject ArtefactsCanvas;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (isArtef)
        {
            ArtefactsCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            ArtefactsCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isArtef = !isArtef;
    }


}
