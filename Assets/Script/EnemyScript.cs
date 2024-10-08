using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    float _bulletLife = 10.0f; // 弾の生存時間(秒)

    float _remainingTime = 0.0f; // 次に弾を発射するまでの残り時間

    public int maxHP = 100; // 最大HP
    private int currentHP;

    public float speed = 2.0f;
    public float xMin = -10.0f;
    public float Xmax = 10.0f;

    public GameObject bulletPrefab; // 弾のPrefab
    public Transform firePoint; // 弾を発射する位置
    public float fireRate = 2.0f; // 発射間隔（秒）
    public float bulletSpeed = 20.0f; // 弾のスピード

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP; // 初期HPを最大HPに設定
        InvokeRepeating("Shoot", 2.0f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        float xPoisition = Mathf.PingPong(Time.time * speed, Xmax - xMin) + xMin;
        transform.position = new Vector3(xPoisition,transform.position.y, transform.position.z);

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage; // ダメージ分だけHPを減らす

        if (currentHP <= 0)
        {
            Die(); // HPがゼロ以下になったら消える
        }
    }

    void Die()
    {
        Destroy(gameObject); // 敵を消す
    }
}