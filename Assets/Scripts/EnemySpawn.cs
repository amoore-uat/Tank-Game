using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.enemySpawnPoints.Add(this.gameObject.transform);
    }

    void OnDestroy()
    {
        GameManager.instance.enemySpawnPoints.Remove(this.gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
