using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A2
{
    public class HealthInfoUI : MonoBehaviour
    {
        public Transform healthBarPlayer;
        public Transform healthBarBase;
        public Transform raditionLevelPlayer;
        public HitReciever hitRecieverPlayer;
        public HitReciever hitRecieverBase;
        public RadiationReciever raditionReciever;

        // Update is called once per frame
        void Update()
        {
            healthBarPlayer.gameObject.GetComponent<Slider>().value = hitRecieverPlayer.healthState.health/(float)hitRecieverPlayer.healthState.healthMax;
            healthBarBase.gameObject.GetComponent<Slider>().value = hitRecieverBase.healthState.health/(float)hitRecieverBase.healthState.healthMax;
            raditionLevelPlayer.gameObject.GetComponent<Slider>().value = raditionReciever.raditionLevel/(float)raditionReciever.raditionLevelMax;
            if(healthBarPlayer.gameObject.GetComponent<Slider>().value == 0f || healthBarBase.gameObject.GetComponent<Slider>().value == 0f || raditionLevelPlayer.gameObject.GetComponent<Slider>().value == 1f)
            {
                Screen.lockCursor = false;
                Cursor.visible = true;
                Application.LoadLevel("EndScene");
            }
        }
    }
}
