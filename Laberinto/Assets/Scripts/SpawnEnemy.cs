using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo que quieres instanciar
    public int numberOfEnemiesToSpawn = 5; // Número de enemigos a crear

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            // Genera una posición aleatoria en el plano XZ
            Vector3 randomPosition = new Vector3(Random.Range(-80,102 ), 0f, Random.Range(63,-106 ));

            // Instancia el enemigo en la posición aleatoria
            GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }



}