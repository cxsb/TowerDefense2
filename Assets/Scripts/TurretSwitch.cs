using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    [System.Serializable]
    public class TurretLevel
    {
        public int attack;
        public float fireInterval;
        public int cost;
    }

    public class TurretSwitch : MonoBehaviour
    {
        public bool isOpen;
        public int level;
        public List<TurretLevel> levelInfo = new List<TurretLevel>();
        public Turret turret;
        public Gun gun;
        public void OpenOrClose()
        {
            isOpen = !isOpen;
            turret.enabled = isOpen;
            if(isOpen)
            {
                Base.Instance.AddCost(1);
            }
            else
            {
                Base.Instance.RemoveCost(1);
            }
        }

        public void TryLevelUp()
        {
            if(level>=levelInfo.Count-1) return;
            if(Base.Instance.power - levelInfo[level+1].cost >= 0)
            {
                level++;
                gun.bullet.damageTemp = levelInfo[level].attack;
                gun.fireInterval = levelInfo[level].fireInterval;
                Base.Instance.Cost(levelInfo[level].cost);
            }
        }

        private void Start()
        {
            gun.bullet.damageTemp = levelInfo[0].attack;
            gun.fireInterval = levelInfo[0].fireInterval;
        }

        public System.String GetShowOnUI()
        {
            if(isOpen) return "Close turret";
            else return "Open turret";
        }
    }
}
