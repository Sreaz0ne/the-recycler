using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public SpawnableEnemy[] enemies;
    public float spawnTime = 2;
    public int minWave = 1;
    public int maxWave = 4;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnTime);
    }

    GameObject GetRandomEnemy() {
        float sumProbability = 0;
        foreach(SpawnableEnemy enemy in enemies)
        {
            sumProbability += enemy.spawnProbability;
        }

        float randomWeight = 0;
        do
        {
            //No weight on any number?
            if(sumProbability == 0)
                return null;
            randomWeight = Random.Range(0, sumProbability);
        }
        while(randomWeight == sumProbability);

        foreach(SpawnableEnemy enemy in enemies)
        {
            if(randomWeight < enemy.spawnProbability)
                return enemy.enemy;
            randomWeight -= enemy.spawnProbability;
        }

        return null;
    }

    void SpawnEnemy() {

        int enemiesInWave = (int)Random.Range(minWave, maxWave);
        for( int i = 0; i < enemiesInWave; i++ ) {

            GameObject enemy = GetRandomEnemy();
            
            if (!enemy)
                return;

            float enemyWidth = enemy.transform.GetComponent<SpriteRenderer>().bounds.extents.x;

            // Screen width
            // 82 is the size of UI
            float screenRatio = ((float)Screen.width - 82) / (float)Screen.height;
            float widthOrtho = Camera.main.orthographicSize * screenRatio;
            
            Vector2 spawnPoint = new Vector2();

            bool isSpawnPositionFound = false;
            while (!isSpawnPositionFound)
            {
                float spawnX = Random.Range(-widthOrtho + 0.2f + enemyWidth, widthOrtho -0.2f - enemyWidth);
                float spawnY = transform.position.y + Random.Range(transform.position.y, transform.position.y + 2);
            
                spawnPoint.x = spawnX; 
                spawnPoint.y = spawnY;

                Collider2D hitColliders = Physics2D.OverlapCircle(spawnPoint, 1);
                
                if (!hitColliders) 
                    isSpawnPositionFound = true;
            }

            Instantiate( enemy, spawnPoint, enemy.transform.rotation );
        }
    }
}
