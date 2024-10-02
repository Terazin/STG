using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    float _bulletLife = 10.0f; // ’e‚Ì¶‘¶ŠÔ(•b)

    float _remainingTime = 0.0f; // Ÿ‚É’e‚ğ”­Ë‚·‚é‚Ü‚Å‚Ìc‚èŠÔ

    public int maxHP = 100; // Å‘åHP
    private int currentHP;

    public float speed = 2.0f;
    public float xMin = -10.0f;
    public float Xmax = 10.0f;

    public GameObject bulletPrefab; // ’e‚ÌPrefab
    public Transform firePoint; // ’e‚ğ”­Ë‚·‚éˆÊ’u
    public float fireRate = 2.0f; // ”­ËŠÔŠui•bj
    public float bulletSpeed = 20.0f; // ’e‚ÌƒXƒs[ƒh

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP; // ‰ŠúHP‚ğÅ‘åHP‚Éİ’è
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
        currentHP -= damage; // ƒ_ƒ[ƒW•ª‚¾‚¯HP‚ğŒ¸‚ç‚·

        if (currentHP <= 0)
        {
            Die(); // HP‚ªƒ[ƒˆÈ‰º‚É‚È‚Á‚½‚çÁ‚¦‚é
        }
    }

    void Die()
    {
        Destroy(gameObject); // “G‚ğÁ‚·
    }
}