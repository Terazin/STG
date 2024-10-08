using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteScript : MonoBehaviour
{
    // ...

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet")) // 弾と衝突したらプレイヤーを消滅させる
        {
            gameObject.SetActive(false);
        }
    }
}
