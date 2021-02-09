using System;
using System.Collections.Generic;
using System.Text;

namespace DnDPlayerMaker
{
    static class Shop
    {
        static public List<Weapon> WeaponsList = new List<Weapon>();
        static public List<Equipment> EquipmentList = new List<Equipment>();

        //сюда вписать всё оружие и предметы (бля)
        static Shop()
        {
            List<Damage> localDamageList = new List<Damage> { new Damage(true, 1, 20, new DamageType[] { DamageType.Дробящий }) };
            WeaponsList.Add(new Weapon("Тестовое оружие 1", 0, true, true, WeaponType.Метательное, true, 20, 3, 10, 1.5, 30, localDamageList));
            WeaponsList.Add(new Weapon("Тестовое оружие 2", 0, true, true, WeaponType.Стрелковое , true, 19, 1, 20, 2, 20, localDamageList));
            WeaponsList.Add(new Weapon("Тестовое оружие 3", 0, true, false, true, 20, 3, 1, 20, localDamageList));
            WeaponsList.Add(new Weapon("Тестовое оружие 4", 0, true, false, true, 20, 3, 1.5, 30, localDamageList));

            EquipmentList.Add(new Equipment("Тестовый предмет 1", 10, "бла бла бла"));
            EquipmentList.Add(new Equipment("Тестовый предмет 2", 20, "бла бла бла"));
            EquipmentList.Add(new Equipment("Тестовый предмет 3", 30, "бла бла бла"));
            EquipmentList.Add(new Equipment("Тестовый предмет 4", 40, "бла бла бла"));
            EquipmentList.Add(new Equipment("Тестовый предмет 5", 50, "бла бла бла"));
        }

        static public string[] GetWeaponsNameArray()
        {
            string[] output = new string[WeaponsList.Count];
            for (int i = 0; i < WeaponsList.Count; i++)
            {
                string prof = WeaponsList[i].Proficiency == 0 ? "Импровиз." : WeaponsList[i].Proficiency == 1 ? "Простое" : "Особое";
                string type = WeaponsList[i].IsLongRange ? WeaponsList[i].Type.ToString() : "Б/Б";
                string name = WeaponsList[i].Name;
                string damage = WeaponsList[i].DamageList[0].DamageTimes.ToString() + "d" + WeaponsList[i].DamageList[0].DamageNum.ToString() + (WeaponsList[i].IsPowerMatters ? "+СИЛ" : "");
                string crit = WeaponsList[i].CritNum.ToString() + "x" + WeaponsList[i].CritTimes.ToString();
                string damageType = WeaponsList[i].DamageList[0].Type[0].ToString();
                string distance = WeaponsList[i].Distance.ToString() + "фт";
                string holding = WeaponsList[i].Holding.ToString();
                string price = WeaponsList[i].Price.ToString();

                output[i] = String.Format("{0,-10} {1,-12} {2,-20} {3,-8} {4,-4} {5,-9} {6,-5} {7,-4} {8,-5}", prof, type, name, damage, crit, damageType, distance, holding, price);
            }

            return output;
        }

        //доработать отображение предметов (добавить отображение цены и описание)
        static public string[] GetItemsNameArray()
        {
            string[] output = new string[EquipmentList.Count];
            for (int i = 0; i < EquipmentList.Count; i++) output[i] = EquipmentList[i].Name;

            return output;
        }
    }
}
