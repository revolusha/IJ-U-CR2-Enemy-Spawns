using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Waypoint _target;

    public Waypoint Target { get; private set; }

    private void Start()
    {
        if (_target != null)
            Target = _target;
    }

    private void OnDrawGizmosSelected()
    {
        if (_target != null)
        {
            Vector2 targetVector = _target.transform.position - transform.position;
            Gizmos.DrawRay(transform.position, targetVector);
        }
    }
}
