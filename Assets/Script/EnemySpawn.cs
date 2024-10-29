using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // 敵のプレハブ
    public Transform spawnPoint; // 敵が再出現する位置
    public float respawnDelay = 5.0f; // 再出現までの時間

    private GameObject currentEnemy;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = currentEnemy.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;  // 移動速度をリセット
            rb.angularVelocity = Vector3.zero; // 回転速度もリセット
        }
        currentEnemy.GetComponent<EnemyScript>().onEnemyDeath += HandleEnemyDeath; // 敵が死んだときのイベント登録
    }

    // 敵が倒されたときに呼ばれるメソッド
    void HandleEnemyDeath()
    {
        StartCoroutine(RespawnEnemy());
    }

    // 一定時間後に敵を再出現させるコルーチン
    IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnEnemy();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
