using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class RadiationFreeField : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            RadiationReciever raditionReciever = other.gameObject.GetComponent<RadiationReciever>();
            if(raditionReciever != null)
            {
                raditionReciever.isInZone = false;
            }
        }

        void OnTriggerExit(Collider other)
        {
            RadiationReciever raditionReciever = other.gameObject.GetComponent<RadiationReciever>();
            if(raditionReciever != null)
            {
                raditionReciever.isInZone = true;
            }
        }
    }
}
