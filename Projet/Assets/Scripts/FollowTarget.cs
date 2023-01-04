using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;

    private Vector3 _currentVelocity;
    
    protected void Update()
    {
        if(target == null)
        {
            return;
        }
        transform.position = Vector3.SmoothDamp(
            transform.position,
            target.position,
            ref _currentVelocity,
            0.2f);
    }
}
