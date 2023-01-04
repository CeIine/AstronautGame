using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform vfxHitYellow;
    [SerializeField] private Transform vfxHitRed;

    private Rigidbody bulletRigidBody;

    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 40f;
        bulletRigidBody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.GetComponent<BulletTarget>() != null)
        {
            //Hit target
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
            other.TryGetComponent(out Character enemyCharacter);
            enemyCharacter.ApplyDamage(30);
        }
        else
        {
            //Hit something else
            Instantiate(vfxHitYellow, transform.position, Quaternion.identity);

        }

        //Destruction du bullet après collision
        Destroy(gameObject);

        
    }
}
