using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    float _speed = 0.1f;

    public GameObject bulletPrefab; // 弾のプレハブ
    public Transform firePoint;     // 弾の発射位置
    public float bulletSpeed = 20f; // 弾の速度
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        UpdateMove();
    }
    private void UpdateMove()
    {
        if (Input.GetKey(KeyCode.A))
        { // 左へ移動
            transform.position += Vector3.left * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        { // 右へ移動
            transform.position += Vector3.right * _speed;
        }

        if (Input.GetKey(KeyCode.W))
        { // 上へ移動
            transform.position += Vector3.forward * _speed;
        }

        if (Input.GetKey(KeyCode.S))
        { // 下へ移動
            transform.position += Vector3.back * _speed;
        }
    }
    void Shoot()
    {
        // 発射位置から弾を生成
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 弾に力を加えて前方に飛ばす
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet")) // 弾と衝突したらプレイヤーを消滅させる
        {
            gameObject.SetActive(false);
        }
    }

}
