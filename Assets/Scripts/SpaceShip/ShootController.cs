using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    Transform shootTr;
    Rigidbody shootRb;
    public float shootPower = 0f;
    public float lifeTime = 4f;
    private float time = 0f;

    public float shoottDamage = 1;
    Vector3 lastBulletPos;
    public LayerMask hitboxMask;

    void Start()
    {
        shootTr = GetComponent<Transform>();
        shootRb = GetComponent<Rigidbody>();
        shootRb.velocity = this.transform.forward * shootPower;
        hitboxMask = LayerMask.NameToLayer("Hitbox");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= lifeTime) Destroy(this.gameObject);
    }
    
}
