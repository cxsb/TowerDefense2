using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class Hand : InitiativeEquipment
    {
        public GameObject InitiativeEquipmentRoot;
        override public System.String GetShowOnUI()
        {
            return "null";
        }

        public Turret GetTurret()
        {
            var hits = Physics.OverlapSphere(InitiativeEquipmentRoot.transform.position,1f);
            foreach(var hit in hits)
            {
                GameObject hitObj = hit.GetComponent<Collider>().gameObject; 
                Turret turret = hitObj.GetComponent<Turret>();
                if(turret!=null)
                {
                    return turret;
                }
            }
            return null;
        }

        override public bool GetRunnable()
        {
            return false;
        }

        override public float GetSpeedAffect()
        {
            return 1;
        }

        override public void FunctionBtnInput(Character character, BtnType btnType, BtnInputType btnInputType)
        {
            if(btnType == BtnType.Main1)
            {
                if(btnInputType == BtnInputType.Up)
                {
                    OpenOrClose();
                }
            }
            if(btnType == BtnType.Main2)
            {
                if(btnInputType == BtnInputType.Up)
                {
                    TryLevelUp();
                }
            }
        }

        private void OpenOrClose()
        {
            var hits = Physics.OverlapSphere(InitiativeEquipmentRoot.transform.position,1f);
            foreach(var hit in hits)
            {
                GameObject hitObj = hit.GetComponent<Collider>().gameObject; 
                Turret turret = hitObj.GetComponent<Turret>();
                if(turret!=null)
                {
                    turret.OpenOrClose();
                }
            }
        }

        private void TryLevelUp()
        {
            var hits = Physics.OverlapSphere(InitiativeEquipmentRoot.transform.position,1f);
            foreach(var hit in hits)
            {
                GameObject hitObj = hit.GetComponent<Collider>().gameObject; 
                Turret turret = hitObj.GetComponent<Turret>();
                if(turret!=null)
                {
                    turret.TryLevelUp();
                }
            }
        }
    }
}

