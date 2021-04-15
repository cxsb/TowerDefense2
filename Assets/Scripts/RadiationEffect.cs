using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class RadiationEffect : MonoBehaviour
    {
        public GameObject radiationPanel;
        public RadiationReciever radiationReciever;
        // Update is called once per frame
        void Update()
        {
            radiationPanel.SetActive(radiationReciever.isInZone);
        }
    }
}
