using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class PlayerBag : SingletonMono<PlayerBag>
    {
        public int power { get; private set;}
        public void GetPowerPack(int value)
        {
            power += value;
        }
        public void ChargeToBase()
        {
            Base.Instance.Charge(power);
            power = 0;
        }
    }
}
