using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    float _bulletLife = 10.0f; // �e�̐�������(�b)

    float _remainingTime = 0.0f; // ���ɒe�𔭎˂���܂ł̎c�莞��

    public int maxHP = 100; // �ő�HP
    private int currentHP;

    public float speed = 2.0f;
    public float xMin = -10.0f;
    public float Xmax = 10.0f;

    public GameObject bulletPrefab; // �e��Prefab
    public Transform firePoint; // �e�𔭎˂���ʒu
    public float fireRate = 2.0f; // ���ˊԊu�i�b�j
    public float bulletSpeed = 20.0f; // �e�̃X�s�[�h

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP; // ����HP���ő�HP�ɐݒ�
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
        currentHP -= damage; // �_���[�W������HP�����炷

        if (currentHP <= 0)
        {
            Die(); // HP���[���ȉ��ɂȂ����������
        }
    }

    void Die()
    {
        Destroy(gameObject); // �G������
    }
}