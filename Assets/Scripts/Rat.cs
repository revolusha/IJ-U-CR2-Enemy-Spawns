using UnityEngine;

public class Rat : MonoBehaviour
{
    private Transform _path;
    private HealthBarControl _healthBarControl;
    private Waypoint _target;
    private SpriteRenderer _renderer;
    private Collider2D _collider;
    private static int _idCounter = 0;
    private int _id;
    private float _timeLeft;
    private float _speed;

    public void KillAfter(float time)
    {
        if (time < 0)
        {
            time = 0;
        }

        _timeLeft = time;
        _healthBarControl.SetMaxHealth(time);
        Destroy(gameObject, time);
    }

    public void SetPath(Transform path)
    {
        _path = path;
    }

    private void OnEnable()
    {
        _id = _idCounter++; 
        _healthBarControl = GetComponentInChildren<HealthBarControl>();
        _renderer = GetComponent<SpriteRenderer>();
        GetRandomSpeed();
    }

    private void Start()
    {
        FindNearestWaypoint();
    }

    private void Update()
    {
        _collider = _target.GetComponent<Collider2D>();

        if (_target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);

            Vector2 direction = _target.transform.position - transform.position;

            if (direction.x < 0)
            {
                _renderer.flipX = false;
            }
            else if (direction.x > 0)
            {
                _renderer.flipX = true;
            }
        }   

        _timeLeft -= Time.deltaTime;
        _healthBarControl.SetHealth(_timeLeft);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider == _collider)
        {
            if (_target != null)
            {
                _target = _target.Target;
                _collider = _target.GetComponent<Collider2D>();
            }
        }
    }

    private void FindNearestWaypoint()
    {
        float minDistance = float.MaxValue;
        Vector2 currentPointVector;

        for (int i = 0; i < _path.childCount; i++)
        {
            currentPointVector = _path.GetChild(i).position;
            currentPointVector -= new Vector2(transform.position.x, transform.position.y);

            if (currentPointVector.magnitude < minDistance)
            {
                minDistance = currentPointVector.magnitude;
                _target = _path.GetChild(i).GetComponent<Waypoint>();
            }
        }
    }

    private void GetRandomSpeed()
    {
        const float MinSpeed = 0.5f;
        const float MaxSpeed = 3f;

        _speed = Random.Range(MinSpeed, MaxSpeed);
    }
}
