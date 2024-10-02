using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    public int damage = 10; // �e�̃_���[�W��

    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g���G���ǂ������m�F����
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage); // �e���G�ɓ���������_���[�W��^����
            Destroy(gameObject); // �e������
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
