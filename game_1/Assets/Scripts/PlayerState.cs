using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum enumstate { normal, weakened, ill, poizoned, paralyzed, dead }
    public enumstate startingState;
    public enumstate currentState;

	// Use this for initialization
	void Start ()
    {
        startingState = enumstate.normal;
        currentState = startingState;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
