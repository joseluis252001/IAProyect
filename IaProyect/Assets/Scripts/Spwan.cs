using UnityEngine;

public class Spwan : MonoBehaviour
{

    
         [Header("Wander (npc)")]
        public GameObject npcPrefab;
         [Header("Wander (npc enemy)")]
        public GameObject enemyPrefab;
        public int npcCount = 5;
        public int enemyCount = 2;

        void Start()
        {
            SpawnEntities(npcPrefab, npcCount);
            SpawnEntities(enemyPrefab, enemyCount);
        }

        public void SpawnEntities(GameObject prefab, int count)
        {
            if (prefab == null) return;

            for (int i = 0; i < count; i++)
            {
                float randomX = Random.Range(-8f, 8f);
                float randomY = Random.Range(-4f, 4f);
                Vector3 spawnRandom = new Vector3(randomX, randomY, 0);
                Instantiate(prefab, spawnRandom, Quaternion.identity);
            }
        }
    
}
