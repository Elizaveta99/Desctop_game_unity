using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Spell : MonoBehaviour, IMagic
{
    public int minMn;
    public bool pronounceCmp;
    public  bool actCmp;
    public abstract void MagicEffect(GameObject go, int val);
}
