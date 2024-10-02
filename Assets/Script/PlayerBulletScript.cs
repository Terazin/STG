using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    public int damage = 10; // 弾のダメージ量

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトが敵かどうかを確認する
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage); // 弾が敵に当たったらダメージを与える
            Destroy(gameObject); // 弾を消す
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
