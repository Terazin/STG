using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    float _speed = 0.1f;

    public GameObject bulletPrefab; // �e�̃v���n�u
    public Transform firePoint;     // �e�̔��ˈʒu
    public float bulletSpeed = 20f; // �e�̑��x
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
        { // ���ֈړ�
            transform.position += Vector3.left * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        { // �E�ֈړ�
            transform.position += Vector3.right * _speed;
        }

        if (Input.GetKey(KeyCode.W))
        { // ��ֈړ�
            transform.position += Vector3.forward * _speed;
        }

        if (Input.GetKey(KeyCode.S))
        { // ���ֈړ�
            transform.position += Vector3.back * _speed;
        }
    }
    void Shoot()
    {
        // ���ˈʒu����e�𐶐�
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // �e�ɗ͂������đO���ɔ�΂�
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet")) // �e�ƏՓ˂�����v���C���[�����ł�����
        {
            gameObject.SetActive(false);
        }
    }

}
