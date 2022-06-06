using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _movementClampNegative;
    [SerializeField] private float _movementClampPositive;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _myMoney;
    [SerializeField] private bool childMoveControl = false;

    public List<Child> MyChilds = new List<Child>();

    public float MyMoney
    {
        get
        {
            return _myMoney;
        }
        set
        {
            if (MyMoney == value)
            {
                return;
            }
            _myMoney = value;

        }
    }

    void Start()
    {
        _anim = GetComponent<Animator>();
        GameManager.FinishAction += FinishStatus;
    }

    private void OnDisable()
    {
        GameManager.FinishAction -= FinishStatus;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState==GameState.PLAY)
        {
            HorizontalControl();
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.GameState == GameState.PLAY)
        {
            Movement();
        }
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
                    ChildFollow();
                }
            }
        }
    }

    private void ChildFollow()
    {
        StartCoroutine(ChildFollowTimer());
    }

    private IEnumerator ChildFollowTimer()
    {
        foreach (var item in MyChilds)
        {
           item.transform.DOMoveX(gameObject.transform.position.x, 0.2f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void StartStatus()
    {
        _anim.CrossFade("Run", 0.1f);
    }

    public void FinishStatus()
    {
        _anim.CrossFade("Idle", 0.1f);
        DOTween.To(() => MyMoney, x => MyMoney = x,MyChilds.Count * 10f, 1).OnUpdate(() =>
        {
            System.Math.Round(MyMoney,0);
            GameManager.Instance.UIManager.MoneyText.text = " " + "-" + " " + MyMoney.ToString() + "$";
        });
    }

}

