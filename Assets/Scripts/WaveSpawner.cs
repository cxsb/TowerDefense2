using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace A2
{
    public class WaveSpawner : SingletonMono<WaveSpawner>
    {
        public GameObject enemy;
        public List<WaveLootSpawner> respawnPoints = new List<WaveLootSpawner>();
        public float secondsPerRound = 5;
        public int zombieNum { get;private set; }
        public int round { get;private set; }

        // Start is called before the first frame update
        void Start()
        {
            Spawn();
        }

        IEnumerator waitSpawn(float interval)
        {
            foreach (var point in respawnPoints)
            {
                point.Spawn();
            }
            Debug.Log("power batteries have been rushed to the shore");
            yield return new WaitForSeconds(interval);
            Spawn();
        }

        private void Spawn()
        {
            Debug.Log(GetEnemyNum(round));
            zombieNum += GetEnemyNum(round);
            for(int i=0;i<GetEnemyNum(round);i++)
            {
                var obj = Instantiate(enemy);
                int x = Random.Range(-90,90);
                int y = Random.Range(-90,90);
                obj.transform.position = new Vector3(x,1,y);
            }
            round++;
        }

        public void ZombieDeath()
        {
            zombieNum--;
            if(zombieNum<=0) StartCoroutine(waitSpawn(secondsPerRound));;
        }

        private int GetEnemyNum(int roundNum)
        {
            return roundNum + 1;
        }
    }
}