﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class HealthState : MonoBehaviour
    {
        public System.Action actionHealthChange;
        public System.Action actionDeath;

        public GameObject GameWorldObj;
        public bool removeWhenDeath;

        public int healthMax;
        public int health;

        public void HealthChange()
        {
            if(actionHealthChange!=null)
            {
                actionHealthChange();
            }
        }

        public void Death()
        {
            if(actionDeath!=null)
            {
                actionDeath();
            }
            if(removeWhenDeath) Destroy(GameWorldObj);
        }
    }
}
