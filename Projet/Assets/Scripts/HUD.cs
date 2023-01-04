using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private ThirdPersonShooterController thirdPersonShooter;
    [SerializeField] private GameObject fill;
    private float CurrentHP;
    private float MaxHP = 90f;

    void Update()
    {
        CurrentHP = thirdPersonShooter.HP;
        var porcentage = CurrentHP / MaxHP;

        fill.GetComponent<RectTransform>().anchorMax = new Vector2(porcentage, 1);
    }
}
