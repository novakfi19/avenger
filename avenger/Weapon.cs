using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avenger
{
    public class Weapon
    {
        public string Name { get; set; }
        public Weapon(string n)
        {
            Name = n;
        }
        public void Equip(Avenger avenger)
        {
            avenger.Weapon = this;
            OnWeaponEquipped(avenger);
        }
        public delegate void WeaponEquippedHandler(object source, EventArgs e);
        public event WeaponEquippedHandler WeaponEquipped;

        protected virtual void OnWeaponEquipped(Avenger avenger)
        {
            if (WeaponEquipped != null)
            {
                WeaponEquipped(this, new WeaponEventArgs() { Avenger = avenger });
            }
        }
        public class WeaponEventArgs : EventArgs
        {
            public Avenger Avenger { get; set; }
        }
    }
}
