using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Character : MonoBehaviour
{
    [SerializeField] private GameObject originalCharacterExplosion;
    [SerializeField] private GameObject originalHealth;

    [SerializeField] public int HP { set ; get; }
    private GameObject newCharacterExplosion;
    private GameObject newHealth;


    // Start is called before the first frame update
    void Start()
    {
        HP = 90;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyDamage(int value)
    {
        HP -= value;
        if (HP <= 0)
        {
            newCharacterExplosion = Instantiate(originalCharacterExplosion);
            newCharacterExplosion.transform.position = transform.position;
            newCharacterExplosion.SetActive(true);

            if (gameObject.TryGetComponent<EnemyCharacter>(out EnemyCharacter e))
            {
                int randomNumber = Random.Range(1, 5);
                if (randomNumber == 1)
                {
                    newHealth = Instantiate(originalHealth);
                    newHealth.transform.position = transform.position;
                    newHealth.SetActive(true);
                }
                Game.Instance.DeleteEnemy(e);
            }
            else
            {
                Game.Instance.DeleteAllEnemy();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            Destroy(gameObject);

        }
    }

    public void ApplyHealth(int value)
    {
        if(HP != 90)
        {
            HP += value;
        }
    }
}
