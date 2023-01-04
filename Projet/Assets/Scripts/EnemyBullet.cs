using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private GameObject originalBulletExplosion;
    private GameObject newBulletExplosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Destruction du bullet après collision
        Destroy(gameObject);

        if (collision.gameObject.TryGetComponent<ThirdPersonShooterController>(out var character))
        {
            character.ApplyDamage(20);
        }

        //FX
        newBulletExplosion = Instantiate(originalBulletExplosion);
        newBulletExplosion.transform.position = transform.position;
        newBulletExplosion.SetActive(true);
    }
}
