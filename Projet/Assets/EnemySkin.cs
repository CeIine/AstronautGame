using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ThirdPersonShooterController player))
        {
            player.ApplyDamage(30);

        }

    }
}
