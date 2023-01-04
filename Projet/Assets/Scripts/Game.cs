using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private EnemyCharacter originalEnemy;
    [SerializeField] private GameObject text;

    private List<EnemyCharacter> enemies = new();
    public static Game Instance;
    public int nbKill = 100;

    private int nbEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        StartCoroutine(EnemyCoroutine());
    }

    public void DeleteEnemy(EnemyCharacter enemy)
    {
        enemies.Remove(enemy);
        nbKill++;
        text.GetComponent<TextMeshProUGUI>().text = "Kill(s) : " + nbKill ;
    }

    public void DeleteAllEnemy()
    {
        foreach(EnemyCharacter enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies.Clear();
    }

    IEnumerator EnemyCoroutine()
    {
        float time = 2;//Random.Range(0.5f, 3);
        this.nbEnemies = 5;
        while (true)
        {
            if(nbKill == 20)
            {
                nbEnemies = 10;
            }
            else if(nbKill == 50){
                nbEnemies = 20;
            }
            else if (nbKill == 100)
            {
                nbEnemies = 30;
            }

            if (enemies.Count < nbEnemies)
            {
                int x = Random.Range(-14, 14);
                int z = Random.Range(-14, 14);
                var pos = new Vector3(x, originalEnemy.transform.position.y, z);

                var newEnemy = Instantiate(originalEnemy, pos , Quaternion.identity);
                newEnemy.gameObject.SetActive(true);
                enemies.Add(newEnemy);


                yield return new WaitForSeconds(time);

            }

            yield return new WaitForSeconds(time);

        }

    }
}
