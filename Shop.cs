using System;
using System.Collections.Generic;
using System.Text;

namespace DnDPlayerMaker
{
    static class Shop
    {
        static public List<Weapon> WeaponsList = new List<Weapon>();
        static public List<Equipment> EquipmentList = new List<Equipment>();
        static public List<Armor> ArmorList = new List<Armor>();
        

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

            ArmorList.Add(new Armor("Кожанный доспех"         , 1000,   ArmorType.Лёгкий,  2, 0, 8));
            ArmorList.Add(new Armor("Клёпаный кожанный доспех", 2500,   ArmorType.Лёгкий,  3, 0, 7));
            ArmorList.Add(new Armor("Кольчужная рубаха"       , 10000,  ArmorType.Лёгкий,  4, 0, 6));
            ArmorList.Add(new Armor("Сыромятный доспех"       , 1500,   ArmorType.Средний, 4, 0, 5));
            ArmorList.Add(new Armor("Чешуйчатый доспех"       , 5000,   ArmorType.Средний, 5, 0, 4));
            ArmorList.Add(new Armor("Кольчуга"                , 15000,  ArmorType.Средний, 6, 0, 3));
            ArmorList.Add(new Armor("Пластинчатый доспех"     , 20000,  ArmorType.Тяжёлый, 7, 0, 2));
            ArmorList.Add(new Armor("Кольчужно-латный доспех" , 60000,  ArmorType.Тяжёлый, 8, 0, 1));
            ArmorList.Add(new Armor("Полный латный доспех"    , 150000, ArmorType.Тяжёлый, 9, 0, 0));
            ArmorList.Add(new Armor("Лёгкий щит"              , 900,    ArmorType.Щит    , 1, 0, 100));
            ArmorList.Add(new Armor("Тяжёлый щит"             , 2000,   ArmorType.Щит    , 2, 0, 100));
        }

        
    }
}
