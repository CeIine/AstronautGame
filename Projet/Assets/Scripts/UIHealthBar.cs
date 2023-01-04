using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private EnemyCharacter enemy;
    [SerializeField] private GameObject fill;
    [SerializeField] private new Camera camera;

    private float CurrentHP;
    private float MaxHP = 90f;

    void Update()
    {
        this.transform.rotation = camera.transform.rotation;

        CurrentHP = enemy.HP;
        var porcentage = CurrentHP / MaxHP;

        fill.GetComponent<RectTransform>().anchorMax = new Vector2(porcentage, 1);

    }
}
