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
        public int multishot;
        public BulletType bulletType;
        public int attackRange;
        public int cost;
    }

    public class Turret : MonoBehaviour
    {
        public bool isOpen;
        public int level;
        public List<TurretLevel> levelInfos = new List<TurretLevel>();
        public TurretAI turretAI;
        public Character character;
        public Gun gun;
        public void OpenOrClose()
        {
            isOpen = !isOpen;
            turretAI.enabled = isOpen;
            if(isOpen)
            {
                Base.Instance.AddCost(1);
            }
            else
            {
                Base.Instance.RemoveCost(1);
                gun.FunctionBtnInput(character, BtnType.Main1, BtnInputType.Up);
            }
        }

        public void TryLevelUp()
        {
            if(level>=levelInfos.Count-1) return;
            if(Base.Instance.power - levelInfos[level+1].cost >= 0)
            {
                level++;
                SetGunParameters(levelInfos[level]);
                Base.Instance.Cost(levelInfos[level].cost);
            }
        }

        public bool GetIsLevelMax()
        {
            return level>=levelInfos.Count-1;
        }

        public int GetCostToNextLevel()
        {
            if(GetIsLevelMax()) return levelInfos[level].cost;
            else return 0;
        }

        private void Start()
        {
            if(levelInfos.Count>0) SetGunParameters(levelInfos[0]);
        }

        private void SetGunParameters(TurretLevel levelInfo)
        {
            gun.bullet.damageTemp = levelInfo.attack;
            gun.fireInterval = levelInfo.fireInterval;
            gun.multishot = levelInfo.multishot;
            gun.bulletType = levelInfo.bulletType;
            turretAI.attackRange = levelInfo.attackRange;
        }

        public System.String GetShowOnUI()
        {
            if(isOpen) return "Close turret";
            else return "Open turret";
        }
    }
}
