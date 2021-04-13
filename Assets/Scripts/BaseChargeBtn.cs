using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class BaseChargeBtn : MonoBehaviour
    {

        // Update is called once per frame
        private void Update()
        {
            var hits = Physics.OverlapSphere(transform.position,1f);
            foreach(var hit in hits)
            {
                GameObject hitObj = hit.GetComponent<Collider>().gameObject; 
                if(hitObj.tag == "Player")
                {
                    PlayerBag.Instance.ChargeToBase();
                }
            }
        }
    }
}