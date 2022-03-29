using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avenger
{
    public class Avenger
    {
        public string Name { get; set; }
        public Weapon Weapon { get; set; }
        public Avenger(
            string name
            )
        {
            Name = name;
        }
        public Avenger(
            string name,
            Weapon wp
            )
        {
            Name = name;
            Weapon = wp;
        }
        public void OnWeaponEquipped(object source, EventArgs e)
        {
            Console.WriteLine($"{this.Name} has equipped {Weapon.Name}!");
        }
    }
}
