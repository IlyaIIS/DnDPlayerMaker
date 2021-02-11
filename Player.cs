using System;
using System.Collections.Generic;
using System.Text;

namespace DnDPlayerMaker
{
    static class Player
    {
        static public string Name { get; set; }
        static public Gender Gender { get; set; }
        static public Worldview Worldview { get; set; }
        static public Nation Nation { get; set; }
        static public PlClass Class { get; set; }
        static public int[] Characteristic { get; set; }
        static public int CharacteristicPoints { get; set; }
        static public List<IAmItem> ItemsList = new List<IAmItem>();
        static public int Cash { get; set; }
        static public Weapon SpecialWarriorsWeapon { get; set; }

        static public void SetNewPlayer()
        {
            Name = " ";
            Gender = Gender.М;
            Worldview = Worldview.Н;
            Nation = Nation.Человек;
            Class = PlClass.Воин;
            Characteristic = new int[6];
            for (int i = 0; i < Characteristic.Length; i++) Characteristic[i] = 10;
            CharacteristicPoints = 20;
            Cash = new int[] { 17500, 14000, 7000, 14000, 10500 }[(int)Class];
            SpecialWarriorsWeapon = new Weapon("", 0, false, false, false, 0, 0, 0, 0, null);
        }

        static public string[] GetItemsNameArray()
        {
            string[] output = new string[ItemsList.Count];
            for (int i = 0; i < ItemsList.Count; i++) output[i] = ItemsList[i].Name;

            return output;
        }
    }

    public enum Gender{ М, Ж }
    public enum Worldview { ПД, НД, ХД, ПН, Н, ХН, ПЗ, НЗ, ХЗ }
    public enum Nation { Человек, Эльф, Дварф, Кицуне, Минас, Серпент, Аазимар, Тифлинг}
    public enum PlClass { Воин, Жрец, Волшебник, Плут, Варвар}
}
