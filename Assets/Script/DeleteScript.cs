using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteScript : MonoBehaviour
{
    // ...

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet")) // �e�ƏՓ˂�����v���C���[�����ł�����
        {
            gameObject.SetActive(false);
        }
    }
}
