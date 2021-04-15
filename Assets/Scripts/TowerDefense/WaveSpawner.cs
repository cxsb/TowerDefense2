using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace A2
{
    public class WaveSpawner : SingletonMono<WaveSpawner>
    {
        public System.Action<int> actionSpawnZombie;
        public System.Action actionSpawnLoot;
        public float secondsPerRound = 5;
        public int zombieNum;
        public int round { get;private set; }

        // Start is called before the first frame update
        void Start()
        {
            Spawn();
        }

        IEnumerator waitSpawn(float interval)
        {
            if(actionSpawnLoot != null) actionSpawnLoot();
            WaveUI.Instance.Show("WAVE " + round.ToString() + " COMPLETE");
            yield return new WaitForSeconds(interval);
            Spawn();
        }

        private void Spawn()
        {
            if(actionSpawnZombie != null) actionSpawnZombie(round);
            round++;
            WaveUI.Instance.Show("WAVE " + round.ToString());
        }

        public void ZombieDeath()
        {
            zombieNum--;
            if(zombieNum<=0) StartCoroutine(waitSpawn(secondsPerRound));;
        }
    }
}