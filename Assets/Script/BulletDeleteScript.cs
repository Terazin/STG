using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeleteScript : MonoBehaviour
{
    public float lifetime = 5.0f; // ’e‚ªÁ‚¦‚é‚Ü‚Å‚ÌŠÔi•bj

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
