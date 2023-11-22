using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject theEnemy;
    public int posX, posZ, enemyCount;
 // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 3)
        {
            posX= Random.Range(-70,93);
            posZ = Random.Range(-97,60);
            Instantiate(theEnemy, new Vector3(posX,0f,posZ),Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }

   

}
