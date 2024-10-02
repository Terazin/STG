using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteScript : MonoBehaviour
{
    // ...

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet")) // ’e‚ÆÕ“Ë‚µ‚½‚çƒvƒŒƒCƒ„[‚ğÁ–Å‚³‚¹‚é
        {
            gameObject.SetActive(false);
        }
    }
}
