using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class RadiationFreeZone : MonoBehaviour
    {
        public RadiationReciever raditionReciever;
        private void Update()
        {
            raditionReciever.isInZone = (raditionReciever.transform.position - transform.position).magnitude > 9.5;
        }
    }
}
