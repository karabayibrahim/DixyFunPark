using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _movementClampNegative;
    [SerializeField] private float _movementClampPositive;
    [SerializeField] private float _horizontalSpeed;

    public List<Child> MyChilds = new List<Child>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalControl();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ICollectable>()!=null)
        {
            other.GetComponent<ICollectable>().DoCollect();
        }
    }

    private void Movement()
    {
        transform.Translate(0, 0, Time.deltaTime * _speed);
    }

    private void HorizontalControl()
    {
        if (Input.touchCount > 0)
        {
            Touch _theTouch = Input.GetTouch(0);

            if (_theTouch.phase == TouchPhase.Moved)
            {
                Vector2 touchPos = _theTouch.deltaPosition;
                if (touchPos != Vector2.zero)
                {
                    transform.Translate(touchPos.x * (_horizontalSpeed / 100) * Time.deltaTime, 0, 0);
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, _movementClampNegative, _movementClampPositive), transform.position.y, transform.position.z);
                }
            }
        }
    }
}
