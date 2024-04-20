/*
2
Solmyr 85 120
Kyrre 99 50
Heal - Solmyr - 10
Recharge - Solmyr - 50
TakeDamage - Kyrre - 66 - Orc
CastSpell - Kyrre - 15 - ViewEarth
End

 */

namespace _03.HeroesofCodeandLogicVII
{
    class Hero
    {
        public Hero(string nickName, uint hp, uint mp)
        {
            NickName = nickName;
            Hp = hp;
            Mp = mp;
        }

        public string NickName { get; set; }
        public uint Hp { get; set; }
        public uint Mp { get; set; }

        internal class Program
        {
            static void Main(string[] args)
            {
                List<Hero> heroes = new List<Hero>();

                int heroesForParty = int.Parse(Console.ReadLine());
                for (int i = 0; i < heroesForParty; i++)
                {
                    string[] input = Console.ReadLine().Split();
                    string name = input[0];
                    uint hp = uint.Parse(input[1]);
                    uint mp = uint.Parse(input[2]);
                    if (hp > 100)
                    {
                        hp = 100;
                    }
                    if (mp > 200)
                    {
                        mp = 200;
                    }
                    Hero newHero = new Hero(name, hp, mp);
                    heroes.Add(newHero);
                }

                string lines;
                while ((lines = Console.ReadLine()) != "End")
                {
                    string[] arguments = lines.Split(" - ");

                    string action = arguments[0];
                    string heroName = arguments[1];
                    var currentHero =  heroes.Find(x => x.NickName == heroName);

                    switch (action)
                    {
                        case "CastSpell":
                            uint mpNeded = uint.Parse(arguments[2]);
                            string spellName = arguments[3];

                            if (currentHero != null)
                            {
                                if (((int)currentHero.Mp - mpNeded) >= 0) 
                                { 
                                    currentHero.Mp -= mpNeded;
                                    Console.WriteLine($"{currentHero.NickName} has successfully cast {spellName} and now has {currentHero.Mp} MP!");
                                }
                                else
                                {
                                    Console.WriteLine($"{currentHero.NickName} does not have enough MP to cast {spellName}!");
                                }
                            }
                            break;
                        case "TakeDamage":

                            uint damage = uint.Parse(arguments[2]);
                            string attacker = arguments[3];


                            if (currentHero != null)
                            {
                                int hpLeft = (int)currentHero.Hp -  (int)damage;

                                if (hpLeft <= 0)
                                {
                                    heroes.Remove(currentHero);
                                    Console.WriteLine($"{heroName} has been killed by {attacker}!");
                                }
                                else
                                {
                                    currentHero.Hp -= damage;
                                    Console.WriteLine($"{currentHero.NickName} was hit for {damage} HP by {attacker} and now has {currentHero.Hp} HP left!");
                                }
                            }

                            break;
                        case "Recharge": 
                            uint increseMp = uint.Parse(arguments[2]);
                            if (currentHero != null)
                            {
                                if ((currentHero.Mp +  increseMp) > 200)
                                {
                                    uint mpLeft = (currentHero.Mp + increseMp) - 200;
                                    uint recoveryMp = increseMp - mpLeft;
                                    currentHero.Mp = 200;
                                    Console.WriteLine($"{currentHero.NickName} recharged for {recoveryMp} MP!");
                                }
                                else
                                {
                                   currentHero.Mp += increseMp;
                                    Console.WriteLine($"{currentHero.NickName} recharged for {increseMp} MP!");
                                }

                            }
                            break;
                        case "Heal":
                            uint increseHp = uint.Parse(arguments[2]);
                            if (currentHero != null)
                            {
                                if ((currentHero.Hp + increseHp) > 100)
                                {
                                    uint hpLeft = (currentHero.Hp + increseHp) - 100;
                                    uint recoveryHp = increseHp - hpLeft;
                                    currentHero.Hp = 100;
                                    Console.WriteLine($"{currentHero.NickName} healed for {recoveryHp} HP!");
                                }
                                else
                                {
                                    currentHero.Hp += increseHp;
                                    Console.WriteLine($"{currentHero.NickName} healed for {increseHp} HP!");
                                }

                            }
                            break;
                            
                    }
                }

                if (heroes.Count > 0)
                {
                    foreach (var hero in heroes)
                    {
                        Console.WriteLine(hero.NickName);
                        Console.WriteLine($"HP: {hero.Hp}");
                        Console.WriteLine($"MP: {hero.Mp}");
                    }
                }
            }
        }
    }
}
