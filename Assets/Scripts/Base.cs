using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class Base : SingletonMono<Base>
    {
        public int power { get; private set; }
        public int initPower = 100;
        public float interval = 3;
        private int cost = 0;
        public void Charge(int value)
        {
            power += value;
        }

        public void AddCost(int value)
        {
            cost += value;
        }

        public void RemoveCost(int value)
        {
            cost -= value;
        }

        private void Start()
        {
            power = initPower;
            StartCoroutine(CoroutineCost());
        }

        IEnumerator CoroutineCost()
        {
            yield return new WaitForSeconds(interval);
            Cost(cost);
            yield return CoroutineCost();
        }

        public void Cost(int value)
        {
            if(power - value > 0) power -= value;
            else power = 0;
        }
    }
}