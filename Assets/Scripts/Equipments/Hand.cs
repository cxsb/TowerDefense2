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

        public TurretSwitch GetTurretSwitch()
        {
            var hits = Physics.OverlapSphere(InitiativeEquipmentRoot.transform.position,1f);
            foreach(var hit in hits)
            {
                GameObject hitObj = hit.GetComponent<Collider>().gameObject; 
                TurretSwitch turretSwitch = hitObj.GetComponent<TurretSwitch>();
                if(turretSwitch!=null)
                {
                    return turretSwitch;
                }
            }
            return null;
        }

        override public bool GetRunnable()
        {
            return true;
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
                TurretSwitch turretSwitch = hitObj.GetComponent<TurretSwitch>();
                if(turretSwitch!=null)
                {
                    turretSwitch.OpenOrClose();
                }
            }
        }

        private void TryLevelUp()
        {
            var hits = Physics.OverlapSphere(InitiativeEquipmentRoot.transform.position,1f);
            foreach(var hit in hits)
            {
                GameObject hitObj = hit.GetComponent<Collider>().gameObject; 
                TurretSwitch turretSwitch = hitObj.GetComponent<TurretSwitch>();
                if(turretSwitch!=null)
                {
                    turretSwitch.TryLevelUp();
                }
            }
        }
    }
}

