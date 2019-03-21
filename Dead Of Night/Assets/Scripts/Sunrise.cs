using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunrise : MonoBehaviour
{
    public float intensity;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        intensity = 0.0001f;
    }

    // Update is called once per frame
    void Update()
    {
        if (intensity >= 1f || !Player.GetComponent<CharController_Motor>().alive) return;

        intensity += .0001f;
        GetComponent<Light>().intensity = intensity;

        if (intensity >= 1f)
        {
            KillZombies();
        }
    }

    void KillZombies()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject zombie in zombies)
        {
            zombie.GetComponent<EnemyController>().Die();
        }
    }
}
