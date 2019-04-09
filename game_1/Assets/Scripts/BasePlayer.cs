using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;  

public class BasePlayer : MonoBehaviour
{
        private readonly int ID;

        public enum enumstate { normal, weakened, ill, poizoned, paralyzed, dead }
        private enumstate state;

        private bool abilityToTalk;
        private bool abilityToMove;
        private readonly int maxhp;
        private int hp;

        public BasePlayer(int _ID)
        {
            ID = _ID;
        }

        public static int id
        { get; private set; }

        public enumstate State
        { get;  set; }

        public bool AbilityToTalk
        { get; set; }

        public bool AbilityToMove
        { get;  set; }

        public int Maxhp
        { get;  set; }

        public int Hp
        { get; set; }
}
