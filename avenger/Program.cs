using System;
using System.Collections.Generic;

namespace avenger
{
    public class Demo
    {
        public event Action<int> VerejnaUdalost;
        public event Func<int, string> VerejnaUdalost2;

        public Demo()
        {
            VerejnaUdalost = Metoda1;

            if (VerejnaUdalost != null)
            {
                VerejnaUdalost(1);
            }

            VerejnaUdalost2 = Metoda2;
            VerejnaUdalost2?.Invoke(10);
        }
        public void Metoda1(int n)
        {
            Console.WriteLine(n);
        }
        public string Metoda2(int n)
        {
            return n.ToString();
        }
    }
    class Program
    {

        /*public delegate int Spocti(int i);
        public static int cislo = 0;
        public static int plus(int i)
        {
            cislo += i;
            return cislo;
        }
        public static int miuns(int i)
        {
            cislo -= i;
            return cislo;
        }
        static void Main(string[] args)
        {
            Spocti p1 = new Spocti(plus);
            Console.WriteLine(p1(1));
            Console.WriteLine(p1(3));
        }*/
        static void Main(string[] args)
        {
            /*Avenger IronMan = new Avenger("Tony Stark");
            Weapon RocketSuit = new Weapon("Rocket suit");

            RocketSuit.WeaponEquipped += IronMan.OnWeaponEquipped;

            RocketSuit.Equip(IronMan);
            */

            MCServer server = new MCServer();
            var player = new Player() { Name = "Gejmr" };
            var broadcast = new Broadcast();
            var world = new World();

            server.PlayerConnected += broadcast.whenPlayerConnects;
            server.PlayerConnected += world.Spawn;
            server.PlayerDisconnected += broadcast.whenPlayerDisconnects;

            server.Connect(player);

            server.Disconnect(player);
        }

    }
    class MCServer
    {
        List<Player> players = new List<Player>();
        public event Action<Player> PlayerConnected;
        public event Action<Player> PlayerDisconnected;
        public void Connect(Player p)
        {
            players.Add(p);
            PlayerConnected?.Invoke(p);
        }
        public void Disconnect(Player p)
        {
            PlayerDisconnected?.Invoke(p);
        }
    }
    class Broadcast
    {
        public void whenPlayerConnects(Player p)
        {
            Console.WriteLine($"{p.Name} has connected!");
        }
        public void whenPlayerDisconnects(Player p)
        {
            Console.WriteLine($"{p.Name} has disconnected!");
        }
    }
    class Player
    {
        public string Name { get; set; }
    }
    class World
    {
        public void Spawn(Player p)
        {
            //...
            Console.WriteLine($"{p.Name} has spawned!");
        }
    }
}
