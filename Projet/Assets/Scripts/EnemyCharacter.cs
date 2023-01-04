using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyCharacter : Character
{
    [SerializeField] private ThirdPersonShooterController player;
    [SerializeField] private GameObject originalBullet;
    private NavMeshAgent _navMeshAgent;

    protected void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected void OnEnable()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return null;
            _navMeshAgent.enabled = true;

            while (enabled)
            {
                _navMeshAgent.SetDestination(new Vector3(
                    player.transform.position.x,// Random.Range(-12f, 12f),
                    0f,
                    player.transform.position.z));//Random.Range(-12f, 12f)));

                do yield return null;
                while (_navMeshAgent.hasPath);


                if (!Physics.Linecast(transform.position, player.transform.position))
                {

                    while (Quaternion.Angle(transform.rotation, Quaternion.LookRotation((player.transform.position - transform.position))) != 0)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation((player.transform.position - transform.position).normalized),
                            360f * Time.deltaTime);
                        yield return null;
                    }

                    var trans = transform;
                    var temp = Instantiate(originalBullet, trans.position + trans.forward, trans.rotation);
                    temp.SetActive(true);
                }

                // Destination reached, wait before moving again.
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
