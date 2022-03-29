using System;

namespace avenger
{
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
            Avenger IronMan = new Avenger("Tony Stark");
            Weapon RocketSuit = new Weapon("Rocket suit");

            RocketSuit.WeaponEquipped += IronMan.OnWeaponEquipped;

            RocketSuit.Equip(IronMan);
        }

}
}
