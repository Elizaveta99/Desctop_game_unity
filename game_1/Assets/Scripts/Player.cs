using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Player : BasePlayer, IComparable
{
    new private readonly string name;
        public enum enumrace { human, gnome, elf, orc, goblin }
        private readonly enumrace race;
        public enum enumgender { male, female }
        private readonly enumgender gender;
        private int age;
        private int experience;
        private readonly int maxmn;
        private int mn;

    public Player(int _ID, string _name, enumrace _race, enumgender _gender)
                         : base(_ID)
        {
            name = _name;
            race = _race;
            gender = _gender;
        }

        public string Name
        { get; private set; }

        public enumrace Race
        { get; private set; }

        public enumgender Gender
        { get; private set; }

        public int Age
        { get;  set; }

        public int Experience
        { get;  set; }

        public int Maxmn
        { get; set; }

        public int Mn
        { get; set; }

    public int CompareTo(object obj)
        {
            Player pl = (Player)obj;
            if (this.experience < pl.experience)
                return -1;
            if (this.experience > pl.experience)
                return 1;
            return 0;
        }

    public void Info(ref Text info, int index)
    {
        string text1 = "", text2 = "", text3 = "", text5 = "", text6 = "", text4 = "";
        text1 = "Race:";
        if (index == 0) text1 += "Human  ";
        if (index == 1) text1 += "Orc  ";
        if (index == 2) text1 += "Goblin  ";
        if (index == 3) text1 += "Gnome  ";
        if (index == 4) text1 += "Elf  ";

        text2 = "Name:";
        if (index == 0) text2 += "Human ";
        if (index == 1) text2 += "Orc ";
        if (index == 2) text2 += "Goblin ";
        if (index == 3) text2 += "Gnome ";
        if (index == 4) text2 += "Elf ";

        text3 = "Gender:";
        text3 += "male ";

        text5 = "Age:";
        if (index == 0) text5 += "20  ";
        if (index == 1) text5 += "100  ";
        if (index == 2) text5 += "500  ";
        if (index == 3) text5 += "50  ";
        if (index == 4) text5 += "3  ";

        text6 = "Health:";
        if (index == 0 || index == 3) text6 += "100 ";
        if (index == 1) text6 += "140 ";
        if (index == 2 || index == 4) text6 += "60 ";

        text4 = "Mana:";
        if (index == 0) text4 += "40";
        if (index == 1 || index == 2) text4 += "10";
        if (index == 3) text4 += "60";
        if (index == 4) text4 += "140";

        info.text = text1;
        info.text += text2;
        info.text += text3;
        info.text += text5;
        info.text += text6;
        info.text += text4;
    }
}
