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
            WaveUI.Instance.Show("WAVE " + round.ToString() + " COMPLETE");
            yield return new WaitForSeconds(interval);
            Spawn();
        }

        private void Spawn()
        {
            zombieNum += GetEnemyNum(round);
            for(int i=0;i<GetEnemyNum(round);i++)
            {
                var obj = Instantiate(enemy);
                int x = Random.Range(-20,20);
                int y = Random.Range(-20,20);
                obj.transform.position = new Vector3(x,1,y);
            }
            round++;
            WaveUI.Instance.Show("WAVE " + round.ToString());
        }

        public void ZombieDeath()
        {
            zombieNum--;
            if(zombieNum<=0) StartCoroutine(waitSpawn(secondsPerRound));;
        }

        private int GetEnemyNum(int roundNum)
        {
            return (roundNum + 1)*3;
        }
    }
}