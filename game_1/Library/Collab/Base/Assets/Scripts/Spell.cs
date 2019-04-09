using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Spell : MonoBehaviour, IMagic
{
    public /*private*/ int minMn;
    public /*private*/ bool pronounceCmp;
    public /*private*/ bool actCmp;
    public abstract void MagicEffect(GameObject go, int val);
}
