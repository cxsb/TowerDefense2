using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class PlayerAnimCtrl : MonoBehaviour
    {
        public Character character;
        
        public Animator playerAnim;

        private void Start() 
        {
            init();
        }

        public void init()
        {
            character.actionReportAxis += ReportAxis;
            playerAnim.SetBool("Grounded",true);
        }

        private void ReportAxis(float v, float h)
        {
            var viewVector = new Vector3(h,0,v);
            if(h==0 && v ==0)
            {
                viewVector = Vector3.forward;
            }
            transform.rotation = Quaternion.Lerp(transform.rotation,character.transform.rotation * Quaternion.LookRotation(viewVector, Vector3.up),10f * Time.deltaTime);
            playerAnim.SetFloat("MoveSpeed", (float)System.Math.Sqrt(v*v+h*h));
        }
    }
}
