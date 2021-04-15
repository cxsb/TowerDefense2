using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    [System.Serializable]
    public struct WaveNumPair
    {
        public int wave;
        public int num;
    }

    public class ZombieSpawner : MonoBehaviour
    {
        public GameObject enemy;
        private Dictionary<int,int> roundZombieNumChart = new Dictionary<int,int>();

        public List<WaveNumPair> waveNumPairs = new List<WaveNumPair>();
 
        public void ShowDic()
        {
            for (int i = 0; i < waveNumPairs.Count; i++)
            {
                int wave = waveNumPairs[i].wave;
                if (!roundZombieNumChart.ContainsKey(wave))
                {
                    roundZombieNumChart.Add(wave, waveNumPairs[i].num);
                }
                else
                {
                    Debug.LogError("key" + "有重复");
                }
            }
        }

        
        void Start()
        {
            ShowDic();
            WaveSpawner.Instance.actionSpawnZombie += Spawn;
        }
        public void Spawn(int round)
        {
            if(!roundZombieNumChart.ContainsKey(round)) return;
            int numZombie = roundZombieNumChart[round];
            WaveSpawner.Instance.zombieNum += numZombie;
            for(int i=0;i<numZombie;i++)
            {
                var obj = Instantiate(enemy);
                float x = Random.Range(-5,5)+transform.position.x;
                float y = Random.Range(-5,5)+transform.position.z;;
                obj.transform.position = new Vector3(x,transform.position.y,y);
            }
        }
    }
}
