using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A2
{
    public class InteractUI : MonoBehaviour
    {
        public Hand hand;
        public Text interactHint;
        public Text lv;
        public Text attack;
        public Text fireInterval;
        public Text levelHint;
        public GameObject interactUI;

        // Update is called once per frame
        void Update()
        {
            var res = hand.GetTurretSwitch();
            if(res == null) interactUI.SetActive(false);
            else
            {
                interactUI.SetActive(true);
                if(res.isOpen) interactHint.text = "Close";
                else interactHint.text = "Open";
                lv.text = "Lv : " + res.level.ToString();
                attack.text = "Damage : " + res.levelInfo[res.level].attack.ToString();
                fireInterval.text = "Interval : "+res.levelInfo[res.level].fireInterval.ToString();
                if(res.level>=res.levelInfo.Count-1) levelHint.text = "level max";
                else levelHint.text = "cost "+res.levelInfo[res.level].cost.ToString()+" to upgrade";
            }
        }
    }
}
