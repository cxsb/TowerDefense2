using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class WaveLootSpawner : MonoBehaviour
    {
        public GameObject objPerfab;
        public int percent;

        private void Start()
        {
            WaveSpawner.Instance.actionSpawnLoot += Spawn;
        }

        public void Spawn()
        {
            int count = Random.Range(0,100);
            if(count<percent)
            {
                var obj = Instantiate(objPerfab);
                obj.transform.position = transform.position;
            }
        }
    }
}