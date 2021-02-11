using System;
using System.Collections.Generic;
using System.Text;

namespace DnDPlayerMaker
{
    class Weapon : IAmItem
    {
        public string Name { get; private set; }
        public int Proficiency { get; private set; } //0-импровизированное, 1-простое, 2-особое
        public bool IsMeleeRanged { get; private set; }
        public bool IsLongRange { get; private set; }
        public WeaponType Type { get; private set; }
        public bool IsPowerMatters { get; private set; }
        public List<Damage> DamageList = new List<Damage>();
        public int CritNum { get; private set; }
        public int CritTimes { get; private set; }
        public int Distance { get; private set; }
        public double Holding { get; private set; }
        public int Price { get; private set; } //в медных монетах

        //для дальнобойного оружия
        public Weapon(string name, int proficiency, bool isMeleeRanged, bool isLongRange, WeaponType type, bool isPowerMatters, int critNum,
                      int critTimes, int distance, double holding, int price, List<Damage> damageList)
        {
            Name = name;
            Proficiency = proficiency;
            IsMeleeRanged = isMeleeRanged;
            IsLongRange = isLongRange;
            Type = type;
            IsPowerMatters = isPowerMatters;
            CritNum = critNum;
            CritTimes = critTimes;
            Distance = distance;
            Holding = holding;
            Price = price;
            DamageList = damageList;
        }

        //для милишного оружия
        public Weapon(string name, int proficiency, bool isMeleeRanged, bool isLongRange, bool isPowerMatters, int critNum,
                      int critTimes, double holding, int price, List<Damage> damageList)
        {
            Name = name;
            Proficiency = proficiency;
            IsMeleeRanged = isMeleeRanged;
            IsLongRange = isLongRange;
            Type = WeaponType.Метательное;
            IsPowerMatters = isPowerMatters;
            CritNum = critNum;
            CritTimes = critTimes;
            Distance = 0;
            Holding = holding;
            Price = price;
            DamageList = damageList;
        }

    }
    class Damage
    {
        public bool IsRandom { get; private set; }
        public int DamageTimes { get; private set; }
        public int DamageNum { get; private set; }
        public DamageType[] Type { get; private set; }

        public Damage(bool isRandom, int damageTimes, int damageNum, DamageType[] type)
        {
            IsRandom = isRandom;
            DamageTimes = damageTimes;
            DamageNum = damageNum;
            Type = type;
        }
    }

    public enum WeaponType
    {
        Метательное,
        Стрелковое
    }
    public enum DamageType
    {
        Дробящий //Дописать остальные типы урона
    }

    class Armor : IAmItem
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public ArmorType Type { get; private set; }
        public int Bonus { get; private set; }
        public int Penalty { get; private set; }
        public int MaxDexterity { get; private set; }

        public Armor(string name, int price, ArmorType type, int bonus, int penalty, int maxDexterity)
        {
            Name = name;
            Price = price;
            Type = type;
            Bonus = bonus;
            Penalty = penalty;
            MaxDexterity = maxDexterity;
        }
    }

    public enum ArmorType
    {
        Лёгкий,
        Средний,
        Тяжёлый,
        Щит
    }

    class Equipment : IAmItem
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public Equipment(string name, int price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }

    public interface IAmItem
    {
        public string Name { get; }
        public int Price {get;}
    }
}
