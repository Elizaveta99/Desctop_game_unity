using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectArtefacts : MonoBehaviour
{
    public Text amount1;
    public Text amount2;
    public Text amount3;
    public Text amount4;
    public Text amount5;
    public Text amount6;
    public int art1 = 0;
    public int art2 = 0;
    public int art3 = 0;
    public int art4 = 0;
    public int art5 = 0;
    public int art6 = 0;
    int f1 = 0, f2 = 0, f3 = 0, f4 = 0, f5 = 0, f6 = 0;

    void Start ()
    {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "artefact1")
        {
            if (Input.GetKeyDown(KeyCode.P) && f1 == 0)
            {
                Debug.Log("art1 collect", gameObject);
                other.gameObject.SetActive(false);
                art1++;
                amount1.text = art1.ToString();
                f1 = 1;
            }
        }
        if (other.gameObject.tag == "artefact2")
        {
            if (Input.GetKeyDown(KeyCode.P) && f2 == 0)
            {
                other.gameObject.SetActive(false);
                art2++;
                amount2.text = art2.ToString();
                f2 = 1;
            }
        }
        if (other.gameObject.tag == "artefact3")
        {
            if (Input.GetKeyDown(KeyCode.P) && f3 == 0)
            {
                other.gameObject.SetActive(false);
                art3++;
                amount3.text = art3.ToString();
                f3 = 1;
            }
        }
        if (other.gameObject.tag == "artefact4")
        {
            if (Input.GetKeyDown(KeyCode.P) && f4 == 0)
            {
                other.gameObject.SetActive(false);
                art4++;
                amount4.text = art4.ToString();
                f4 = 1;
            }
        }
        if (other.gameObject.tag == "artefact5")
        {
            if (Input.GetKeyDown(KeyCode.P) && f5 == 0)
            {
                other.gameObject.SetActive(false);
                art5++;
                amount5.text = art5.ToString();
                f5 = 1;
            }
        }
        if (other.gameObject.tag == "artefact6")
        {
            if (Input.GetKeyDown(KeyCode.P) && f6 == 0)
            {
                other.gameObject.SetActive(false);
                art6++;
                amount6.text = art6.ToString();
                f6 = 1;
            }
        }
    }

    void Update ()
    {
		
	}
}
