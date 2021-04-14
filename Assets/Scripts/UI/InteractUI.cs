using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A2
{
    public class InteractUI : MonoBehaviour
    {
        public Hand hand;

        public Text lv;
        public Text attack;
        public Text fireInterval;
        public Text multishot;
        public Text attackRange;

        public Text interactHint;
        public Text levelHint;
        
        public GameObject interactUI;

        // Update is called once per frame
        void Update()
        {
            var turret = hand.GetTurret();
            if(turret == null) interactUI.SetActive(false);
            else
            {
                interactUI.SetActive(true);
                if(turret.isOpen) interactHint.text = "Close";
                else interactHint.text = "Open";
                lv.text = "Lv : " + turret.level.ToString();
                attack.text = "Damage : " + turret.gun.bullet.damageTemp.ToString();
                fireInterval.text = "Interval : "+turret.gun.fireInterval.ToString();
                multishot.text = "Multishot : "+turret.gun.multishot.ToString();
                attackRange.text = "Attack Range : " +turret.turretAI.attackRange.ToString();
                if(turret.GetIsLevelMax()) levelHint.text = "level max";
                else levelHint.text = "cost "+turret.GetCostToNextLevel().ToString()+" to upgrade";
            }
        }
    }
}
