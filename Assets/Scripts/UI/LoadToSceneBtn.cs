using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A2
{
    public class LoadToSceneBtn : MonoBehaviour
    {
        public System.String nextScene;
        // Start is called before the first frame update
		void Start ()
		{
			Button btn = this.GetComponent<Button> ();
			btn.onClick.AddListener(OnClick);
		}

        void OnClick()
        {
            Application.LoadLevel(nextScene);
        }
    }
}
