using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class ZombieAnimCtrl : MonoBehaviour
    {
        public Character character;
        public Gun gun;
        
        public Animator zombieAnim;

        private void Start() 
        {
            init();
        }

        public void init()
        {
            character.actionReportAxis += ReportAxis;

            if(gun != null)
            {
                gun.actionShoot += Shoot;
                gun.actionReload += Reload;
            }
        }

        private void Shoot(bool isAim)
        {
            zombieAnim.Play("zombie_attack", 0, 0f);
        }

        private void Reload(bool isSingle, bool isUniqueMode)
        {
            
        }

        private void ReportAxis(float v, float h)
        {
            var viewVector = new Vector3(h,0,v);
            if(h==0 && v ==0)
            {
                viewVector = Vector3.forward;
            }
            transform.rotation = Quaternion.Lerp(transform.rotation,character.transform.rotation * Quaternion.LookRotation(viewVector, Vector3.up),10f * Time.deltaTime);
            zombieAnim.SetFloat("MoveSpeed", (float)System.Math.Sqrt(v*v+h*h));
        }
    }
}
