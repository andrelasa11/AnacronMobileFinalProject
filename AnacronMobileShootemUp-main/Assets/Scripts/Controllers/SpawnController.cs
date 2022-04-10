using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    private Quaternion spawnRotation = new Quaternion(0,0,180,0); // deixar o z em 180º para o inimigo ser spawnado voltado para baixo

    [Header("Cadence")]
    [SerializeField] private float initialWaitTime; // tempo de espera para iniciar o spawn
    [SerializeField] private float cadenceBetweenWaves; // tempo de espera entre uma onda e outra

    [Header("Dependencies")]
    [SerializeField] private List<EnemyWavesConfig> wavesConfig; // referência para wavesconfig
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnerCoroutine());
    }

    private IEnumerator EnemySpawnerCoroutine()
    {
        yield return new WaitForSeconds(initialWaitTime);

        foreach (var wave in wavesConfig)
        {
            foreach (var enemy in wave.enemies)
            {
                Vector3 enemyPosition = Vector3.zero;

                if (enemy.useSpecificXPosition)
                {
                    enemyPosition = enemy.spawnReferencePosition;
                }

                else
                {
                    enemyPosition = new Vector3(Random.Range(-enemy.spawnReferencePosition.x, enemy.spawnReferencePosition.x), enemy.spawnReferencePosition.y, enemy.spawnReferencePosition.z); ;
                }

                SpawnEnemy(enemy.enemyPrefab, enemy.config, enemyPosition, spawnRotation);

                yield return new WaitForSeconds(wave.cadence);
            }
            yield return new WaitForSeconds(cadenceBetweenWaves);

        }

    }

    public void SpawnEnemy(EnemyController enemyPrefab, EnemyConfig config, Vector3 enemyPosition, Quaternion rotation)
    {
        var enemyInstance = Instantiate(enemyPrefab, enemyPosition, rotation);
        enemyInstance.config = config;
    }
        
}
