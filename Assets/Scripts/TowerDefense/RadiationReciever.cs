using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class RadiationReciever : MonoBehaviour
    {
        public int damage = 3;
        public int restore = 10;
        public float interval = 1;

        public int raditionLevel { get;private set; }
        public int raditionLevelMax = 100;

        public bool isInZone;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(CoroutineRadiationEffect());
        }

        IEnumerator CoroutineRadiationEffect()
        {
            yield return new WaitForSeconds(interval);
            RadiationEffect();
            yield return CoroutineRadiationEffect();
        }

        private void RadiationEffect()
        {
            if(!isInZone)
            {
                RaditionLevelChange(-restore);
            }
            else
            {
                RaditionLevelChange(damage);
            }
        }

        private void RaditionLevelChange(int val)
        {
            if(val>0)
            {
                if(val+raditionLevel<raditionLevelMax) raditionLevel+=val;
                else raditionLevel = raditionLevelMax;
            }
            else
            {
                if(val+raditionLevel>0) raditionLevel+=val;
                else raditionLevel = 0;
            }
        }
    }
}
