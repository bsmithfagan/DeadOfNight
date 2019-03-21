using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public int EnemyCount;
    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < EnemyCount; x++)
        {
            GameObject.Instantiate(zombie, new Vector3(Random.Range(40f, 450f), Random.Range(5f, 10f), Random.Range(40f, 450f)), new Quaternion(0, Random.rotation.y, 0, zombie.transform.rotation.w));
        }
    }
}
