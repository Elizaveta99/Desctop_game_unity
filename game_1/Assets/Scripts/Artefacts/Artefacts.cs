using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Artefacts : MonoBehaviour, IMagic
{
    public int power;
    public bool renewability;
    public abstract void MagicEffect(Player go, int val);
}
