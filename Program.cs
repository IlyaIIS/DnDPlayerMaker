using System;

namespace DnDPlayerMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface.DoStartMenuInteractions();
        }
    }
    
    static class DataWorker
    {

    }

    static class Interface
    {
        static public void DoStartMenuInteractions()
        {
            int pos = 0;
            ConsoleKeyInfo key;
            do
            {
                DrawPointsMenu(pos, new string[] { "Создать нового персоонажа", "Загрузить персоонажа" });

                key = Console.ReadKey(true);

                TryMovePos(2, key, ref pos);

                if (key.Key == ConsoleKey.Enter)
                    if (pos == 0)
                    {
                        Player.SetNewPlayer();
                        DoNavigationMenuInteractions();
                    } else
                    {
                        //добавить загрузку с файла в dataworker
                    }

            } while (key.Key != ConsoleKey.Escape);
        }

        static public void DoNavigationMenuInteractions()
        {
            Console.Clear();
            int pos = 0;
            ConsoleKeyInfo key;
            do
            {
                DrawPointsMenu(pos, new string[]
                {
                    "Основная информация",
                    "Характеристики",
                    "Особенности класса",
                    "Инвентарь",
                    "Вся информация"
                });

                key = Console.ReadKey(true);

                TryMovePos(4, key, ref pos);

                if (key.Key == ConsoleKey.Enter)
                    switch (pos)
                    {
                        case 0:
                            DoMainInfMenuInteractins();
                            break;
                        case 1:
                            DoCharacteristicMenuInteractions();
                            break;
                        case 2:
                            DoPlayerFeatureMenuInteractions();
                            break;
                        case 3:
                            DoInventoryInteractions();
                            break;
                        default:
                            throw new Exception("Выход за пределы меню");
                    }

            } while (key.Key != ConsoleKey.Escape);

            static void DoMainInfMenuInteractins()
            {
                Console.Clear();
                int pos = 0;
                ConsoleKeyInfo key;
                do
                {
                    DrawPointsMenu(pos, new string[]
                    {
                        "Имя: " + Player.Name,
                        "Пол: " + Player.Gender,
                        "Мировоззрение: " + Player.Worldview,
                        "Народ: " + Player.Nation,
                        "Класс: " + Player.Class
                    });

                    key = Console.ReadKey(true);

                    TryMovePos(5, key, ref pos);

                    if (key.Key == ConsoleKey.Enter)
                        switch (pos)
                        {
                            case 0:
                                Console.SetCursorPosition(5, pos);
                                Player.Name = Console.ReadLine();
                                DrawMenuItem(0, pos, "Имя: " + Player.Name + new string(' ', 10));
                                break;
                            case 1:
                                Console.SetCursorPosition(0, pos);
                                Player.Gender = (Gender)DrawMenuAndGetItem(5, new string[] { "М", "Ж" });
                                DrawMenuItem(0, pos, "Пол: " + Player.Gender + new string(' ', 10));
                                break;
                            case 2:
                                Console.SetCursorPosition(0, pos);
                                Player.Worldview = (Worldview)DrawMenuAndGetItem(15, new string[] { "ПД", "НД", "ХД", "ПН", "Н", "ХН", "ПЗ", "НЗ", "ХЗ" });
                                DrawMenuItem(0, pos, "Мировоззрение: " + Player.Nation + new string(' ', 10));
                                break;
                            case 3:
                                Console.SetCursorPosition(0, pos);
                                Player.Nation = (Nation)DrawMenuAndGetItem(7, new string[] { "Человек", "Эльф", "Дварф", "Кицуне", "Минас", "Серпент", "Аазимар", "Тифлинг" });
                                DrawMenuItem(0, pos, "Народ: " + Player.Nation + new string(' ', 10));
                                break;
                            case 4:
                                Console.SetCursorPosition(0, pos);
                                Player.Class = (PlClass)DrawMenuAndGetItem(7, new string[] { "Воин", "Жрец", "Волшебник", "Плут", "Варвар" });
                                DrawMenuItem(0, pos, "Класс: " + Player.Class + new string(' ', 10));
                                break;
                            default:
                                throw new Exception("Выход за пределы меню");
                        }
                } while (key.Key != ConsoleKey.Escape);
                Console.Clear();

                static int DrawMenuAndGetItem(int indent, string[] str)
                {
                    int pos = 0;
                    ConsoleKeyInfo key;
                    do
                    {
                        DrawIteams(indent, pos, str);

                        key = Console.ReadKey(true);

                        TryMovePos(str.Length, key, ref pos, true);
                    } while (key.Key != ConsoleKey.Enter);

                    return pos;
                }
            }
        }

        //Рисует фигню типа < П1 П2 П3 >
        static void DrawIteams(int indent, int pos, string[] str)  
        {
            Console.SetCursorPosition(indent, Console.CursorTop);
            Console.Write('<');
            for (int i = 0; i < str.Length; i++)
            {
                if (pos == i) Console.ForegroundColor = ConsoleColor.White;
                else Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(' ' + str[i]);
            }
            Console.ResetColor();
            Console.Write(" >");
        }

        static void DoCharacteristicMenuInteractions()
        {
            Console.Clear();
            int pos = 0;
            int points = Player.CharacteristicPoints;
            ConsoleKeyInfo key;
            do
            {
                DrawPointsMenu(pos, new string[]
                {
                        $"Сила: <{Player.Characteristic[0]}>",
                        $"Ловкость: <{Player.Characteristic[1]}>",
                        $"Выносливость: <{Player.Characteristic[2]}>",
                        $"Интеллект: <{Player.Characteristic[3]}>",
                        $"Мудрость: <{Player.Characteristic[4]}>",
                        $"Харизма: <{Player.Characteristic[5]}>"
                });
                Console.WriteLine("Свободных очков: " + points + ' ');

                key = Console.ReadKey(true);

                TryMovePos(6, key, ref pos);

                if (key.Key == ConsoleKey.LeftArrow && Player.Characteristic[pos] > 7)
                {
                    Player.Characteristic[pos]--;
                    points += (int)Math.Ceiling((decimal)Math.Abs(Player.Characteristic[pos] - 10) / 2);
                    if (10 - Player.Characteristic[pos] == 0) points++;
                }
                if (key.Key == ConsoleKey.RightArrow && points >= (int)Math.Ceiling((decimal)Math.Abs(Player.Characteristic[pos] - 10) / 2))
                {
                    points -= (int)Math.Ceiling((decimal)Math.Abs(Player.Characteristic[pos] - 10) / 2);
                    if (10 - Player.Characteristic[pos] == 0) points--;
                    Player.Characteristic[pos]++;
                }
            } while (key.Key != ConsoleKey.Escape);
            Player.CharacteristicPoints = points;
            Console.Clear();
        }

        static void DoInventoryInteractions()
        {
            Console.Clear();
            Console.WindowWidth = 140;
            DrawWindowWithTitle(0, 2, 21, 24, "Инвентарь");
            DrawWindowWithTitle(22, 2, 108, 24, String.Format(WeaponStringFormat, "Владение", "Тип", "Название", "Урон", "Крит", "Тип урона", "Дист.", "Хват", "Цена"));
            DrawPointsMenu(-1, 23, 5, false, GetWeaponsNameArray());
            int place = 0; // 0-инвентарь, 1-оружие, 2-броня, 3-предметы
            int[] pos = new int[4];
            ConsoleKeyInfo key;
            do
            {
                string[] nameArray = (place == 0) ? Player.GetItemsNameArray() : (place == 1) ? GetWeaponsNameArray() : (place == 2) ? GetArmorNameArray() : GetEquipmentsNameArray() ;
                if (place == 0) DrawPointsMenu(pos[place], 1,  5, false, nameArray);
                else            DrawPointsMenu(pos[place], 23, 5, false, nameArray);
                DrawCahsWindow();
                DrawPlaceWindow(place);

                key = Console.ReadKey(true);

                TryMovePos(nameArray.Length, key, ref pos[place]);

                //переключение между инвентарём, оружимем и предметами
                if (key.Key == ConsoleKey.LeftArrow && place != 0)
                {
                    place--;
                    if (place == 0) DrawPointsMenu(-1, 23, 5, false, GetWeaponsNameArray());
                    if (place == 1)
                    {
                        ClearWindow(22, 2, 91, 24);
                        DrawWindowWithTitle(22, 2, 108, 24, String.Format(WeaponStringFormat, "Владение", "Тип", "Название", "Урон", "Крит", "Тип урона", "Дист.", "Хват", "Цена"));
                    }
                    if (place == 2)
                    {
                        ClearWindow(22, 2, 43, 24);
                        DrawWindowWithTitle(22, 2, 91, 24, String.Format(ArmorStringFormat, "Тип(Вес)", "Название", "Бонус к КБ", "Штраф", "Макс. ЛВК", "Цена"));
                    }
                }
                if (key.Key == ConsoleKey.RightArrow && place != 3)
                {
                    place++;
                    if (place == 1)
                    {
                        DrawPointsMenu(-1, 1, 5, false, Player.GetItemsNameArray());
                        DrawWindowWithTitle(22, 2, 108, 24, String.Format(WeaponStringFormat, "Владение", "Тип", "Название", "Урон", "Крит", "Тип урона", "Дист.", "Хват", "Цена"));
                    }
                    if (place == 2)
                    {
                        ClearWindow(22, 2, 123, 24);
                        DrawWindowWithTitle(22, 2, 91, 24, String.Format(ArmorStringFormat, "Тип(Вес)", "Название", "Бонус к КБ", "Штраф", "Макс. ЛВК", "Цена"));
                    }
                    if (place == 3)
                    {
                        ClearWindow(22, 2, 91, 24);
                        DrawWindowWithTitle(22, 2, 43, 24, "Снаряжение");
                    }
                }

                // покупка/продажа предметов
                if (key.Key == ConsoleKey.Enter)
                {
                    if (place == 0 && Player.ItemsList.Count > 0)
                    {
                        Player.Cash += Player.ItemsList[pos[place]].Price;

                        ClearWindow(1, 6, 20, 23);
                        DrawWindowWithTitle(0, 2, 21, 24, "Инвентарь");
                        Player.ItemsList.Remove(Player.ItemsList[pos[place]]);
                        if (pos[place] != 0) pos[place] -= 1;
                    }
                    if (place == 1)
                    {
                        if (Player.Cash >= Shop.WeaponsList[pos[place]].Price)
                        {
                            Player.Cash -= Shop.WeaponsList[pos[place]].Price;
                            Player.ItemsList.Add(Shop.WeaponsList[pos[place]]);
                        }
                    }
                    if (place == 2)
                    {
                        if (Player.Cash >= Shop.ArmorList[pos[place]].Price)
                        {
                            Player.Cash -= Shop.ArmorList[pos[place]].Price;
                            Player.ItemsList.Add(Shop.ArmorList[pos[place]]);
                        }
                    }
                    if (place == 3)
                    {
                        if (Player.Cash >= Shop.EquipmentList[pos[place]].Price)
                        {
                            Player.Cash -= Shop.EquipmentList[pos[place]].Price;
                            Player.ItemsList.Add(Shop.EquipmentList[pos[place]]);
                        }
                    }
                    DrawPointsMenu(-1, 1, 5, false, Player.GetItemsNameArray());
                    if (place == 0)
                        if (Player.ItemsList.Count > 0)
                            Console.Write("\n║" + new string(' ', 18));
                        else
                            Console.Write(new string(' ', 18));
                    else
                        DrawPointsMenu(pos[place], 23, 5, false, nameArray);
                }

            } while (key.Key != ConsoleKey.Escape);
            Console.Clear();

            static void DrawCahsWindow()
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("╔═══════════════╗");
                Console.WriteLine($"║Деньги: {Player.Cash}бм║");
                Console.WriteLine("╠═══════════════╩");
            }

            static void DrawPlaceWindow(int place)
            {
                Console.SetCursorPosition(0, 1);
                DrawIteams(18, place, new string[] { "инвентарь", "оружие", "броня", "предметы" });
            }
        }

        static void DoPlayerFeatureMenuInteractions()
        {
            if (Player.Class == PlClass.Воин)
            {
                Console.Clear();
                DrawWindowWithTitle(1, 2, 87, 24, String.Format(WeaponStringFormat, "Владение", "Тип", "Название", "Урон", "Крит", "Тип урона", "Дист.", "Хват", "Цена"));
                DrawPointsMenu(-1, 2, 5, false, GetWeaponsNameArray());
                DrawPlayersWeapon();
                int pos = 0;
                ConsoleKeyInfo key;
                do
                {
                    DrawPointsMenu(pos, 2, 5, false, GetWeaponsNameArray());

                    key = Console.ReadKey(true);

                    TryMovePos(Shop.WeaponsList.Count, key, ref pos);

                    if (key.Key == ConsoleKey.Enter)
                    {
                        Player.SpecialWarriorsWeapon = Shop.WeaponsList[pos];
                        DrawPlayersWeapon();
                    }
                } while (key.Key != ConsoleKey.Escape);
                Console.Clear();

                static void DrawPlayersWeapon()
                {
                    string localStr = " ║Выбранное оружие: " + Player.SpecialWarriorsWeapon.Name;
                    Console.SetCursorPosition(1, 0);
                    Console.WriteLine("╔" + new string('═', localStr.Length - 2) + "╗");
                    Console.Write(localStr);
                    Console.SetCursorPosition(localStr.Length, 1);
                    Console.Write("║");
                    Console.SetCursorPosition(1, 2);
                    Console.Write("╠" + new string('═', localStr.Length - 2) + "╩");
                }
            }
            if (Player.Class == PlClass.Волшебник)
            {

            }
        }
        static public string WeaponStringFormat = "{0,-10} {1,-12} {2,-20} {3,-8} {4,-4} {5,-9} {6,-5} {7,-4} {8,-5}";
        static public string[] GetWeaponsNameArray()
        {
            string[] output = new string[Shop.WeaponsList.Count];
            for (int i = 0; i < Shop.WeaponsList.Count; i++)
            {
                Weapon weapon = Shop.WeaponsList[i];

                string prof = weapon.Proficiency == 0 ? "Импровиз." : weapon.Proficiency == 1 ? "Простое" : "Особое";
                string type = weapon.IsLongRange ? weapon.Type.ToString() : "Б/Б";
                string name = weapon.Name;
                string damage = weapon.DamageList[0].DamageTimes.ToString() + "d" + weapon.DamageList[0].DamageNum.ToString() + (weapon.IsPowerMatters ? "+СИЛ" : "");
                string crit = weapon.CritNum.ToString() + "x" + weapon.CritTimes.ToString();
                string damageType = weapon.DamageList[0].Type[0].ToString();
                string distance = weapon.Distance.ToString() + "фт";
                string holding = weapon.Holding.ToString();
                string price = weapon.Price.ToString();

                output[i] = String.Format(WeaponStringFormat, prof, type, name, damage, crit, damageType, distance, holding, price);
            }

            return output;
        }

        //доработать отображение предметов (добавить отображение цены и описание)
        static public string EquipmentStringFormat = "";
        static public string[] GetEquipmentsNameArray()
        {
            string[] output = new string[Shop.EquipmentList.Count];
            for (int i = 0; i < Shop.EquipmentList.Count; i++) 
                output[i] = Shop.EquipmentList[i].Name;

            return output;
        }
        static public string ArmorStringFormat = "{0,-8} {1,-25} {2,-10} {3,-5} {4,-9} {5,-6}";
        static public string[] GetArmorNameArray()
        {
            string[] output = new string[Shop.ArmorList.Count];
            for (int i = 0; i < Shop.ArmorList.Count; i++)
            {
                Armor armor = Shop.ArmorList[i];

                ArmorType type = armor.Type;
                string name = armor.Name;
                int bonus = armor.Bonus;
                int penalty = armor.Penalty;
                string maxDexterity = armor.Type != ArmorType.Щит ? armor.MaxDexterity.ToString() : "-";
                int price = armor.Price;

                output[i] = String.Format(ArmorStringFormat, type, name, bonus, penalty, maxDexterity, price);
            }

            return output;
        }
        //рисует верикальный список, подсвечивая ячейку под номером pos (+перегрузки на все случаи жизни)
        static void DrawPointsMenu(int pos, string[] str)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < str.Length; i++)
                DrawMenuItem(i, pos, str[i]);
        }
        static void DrawPointsMenu(int pos, int x, int y, string[] str)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < str.Length; i++)
                DrawMenuItem(i, pos, str[i], x, y);
        }
        static void DrawPointsMenu(int pos, int x, int y, bool isFill, string[] str)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < str.Length; i++)
                DrawMenuItem(i, pos, str[i], x, y, isFill);
        }
        static void DrawMenuItem(int num, int pos, string str)
        {
            if (num == pos) Console.ForegroundColor = ConsoleColor.White;
            else Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine(str + new string(' ', Console.WindowWidth - Console.CursorLeft - str.Length));

            Console.ResetColor();
        }
        static void DrawMenuItem(int num, int pos, string str, int x, int y)
        {
            if (num == pos) Console.ForegroundColor = ConsoleColor.White;
            else Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(x, y + num);

            Console.Write(str + new string(' ', Console.WindowWidth - Console.CursorLeft - str.Length));

            Console.ResetColor();
        }
        static void DrawMenuItem(int num, int pos, string str, int x, int y, bool isFill)
        {
            if (num == pos) Console.ForegroundColor = ConsoleColor.White;
            else Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(x, y + num);

            Console.Write(str + (isFill ? new string(' ', Console.WindowWidth - Console.CursorLeft - str.Length) : ""));

            Console.ResetColor();
        }

        static void DrawWindow(int inpx1, int inpy1, int inpx2, int inpy2)
        {
            int x1 = Math.Min(inpx1, inpx2);
            int x2 = Math.Max(inpx1, inpx2);
            int y1 = Math.Min(inpy1, inpy2);
            int y2 = Math.Max(inpy1, inpy2);

            Console.SetCursorPosition(x1, y1);
            Console.Write('╔' + new string('═', x2 - x1 - 1) + '╗');
            for (int i = 1; i < y2 - y1; i++)
            {
                Console.SetCursorPosition(x1, y1 + i);
                Console.Write('║');
                Console.SetCursorPosition(x2, y1 + i);
                Console.Write('║');
            }
            Console.SetCursorPosition(x1, y2);
            Console.Write('╚' + new string('═', x2 - x1 - 1) + '╝');
        }

        static void ClearWindow(int inpx1, int inpy1, int inpx2, int inpy2)
        {
            int x1 = Math.Min(inpx1, inpx2);
            int x2 = Math.Max(inpx1, inpx2);
            int y1 = Math.Min(inpy1, inpy2);
            int y2 = Math.Max(inpy1, inpy2);

            for (int i = 0; i < y2 - y1 + 1; i++)
            {
                Console.SetCursorPosition(x1, y1 + i);
                Console.Write(new string(' ', x2 - x1 + 1));
            }
            
            Console.SetCursorPosition(x1, y2);
            Console.Write(new string(' ', x2 - x1 + 1));
        }

        static void DrawWindowWithTitle(int x1, int y1, int x2, int y2, string title)
        {
            DrawWindow(x1, y1, x2, y2);
            Console.SetCursorPosition(Math.Min(x1, x2) + (Math.Abs(x2 - x1) + 1 - title.Length) / 2, Math.Min(y1, y2) + 1);
            Console.Write(title);
            DrawLine(Math.Min(x1, x2) + 1, Math.Min(y1, y2) + 2, Math.Max(x1, x2) - 1);
        }

        static void DrawLine(int x1, int y1, int x2)
        {
            Console.SetCursorPosition(Math.Min(x1,x2), y1);
            Console.Write(new string('═', Math.Abs(x2 - x1) + 1));
        }

        //вертикальное перемещение стрелочками по пунктам меню
        static bool TryMovePos(int max, ConsoleKeyInfo key, ref int pos)
        {
            int prePos = pos;
            if (key.Key == ConsoleKey.UpArrow && pos > 0) pos--;
            if (key.Key == ConsoleKey.DownArrow && pos < max - 1) pos++;
            return pos != prePos;
        }
        //горезонтальное перемещение стрелочками по пунктам меню
        static bool TryMovePos(int max, ConsoleKeyInfo key, ref int pos, bool IsHorizontal)
        {
            int prePos = pos;
            if (key.Key == ConsoleKey.LeftArrow && pos > 0) pos--;
            if (key.Key == ConsoleKey.RightArrow && pos < max - 1) pos++;
            return pos != prePos;
        }
    }

    
}
