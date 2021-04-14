using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A2
{
    public class WaveUI : SingletonMono<WaveUI>
    {
        public GameObject waveUI;
        public Text wave;
        public float secondsToHide;
        Coroutine coroutineHideWaveUI;

        public void Show(System.String content)
        {
            wave.text = content;
            waveUI.SetActive(true);
            if(coroutineHideWaveUI != null) StopCoroutine(coroutineHideWaveUI);
            coroutineHideWaveUI = StartCoroutine(CoroutineHideWaveUI());
        }

        IEnumerator CoroutineHideWaveUI()
        {
            yield return new WaitForSeconds(secondsToHide);
            waveUI.SetActive(false);
            coroutineHideWaveUI = null;
        }
    }
}