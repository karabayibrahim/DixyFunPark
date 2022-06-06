using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class Child : MonoBehaviour,ICollectable
{
    [SerializeField] private float _speed;

    private Animator _anim;
    private bool moveControl = false;

    public void DoCollect()
    {
        GameManager.Instance.PlayerController.MyChilds.Add(this);
        GameManager.Instance.UIManager.ChildCountText.text = " "+"-"+" "+GameManager.Instance.PlayerController.MyChilds.Count.ToString();
        moveControl = true;
        //transform.SetParent(GameManager.Instance.PlayerController.gameObject.transform);
        transform.DOMove(new Vector3(0, 0, GameManager.Instance.PlayerController.transform.position.z- GameManager.Instance.PlayerController.MyChilds.Count), 0.5f);
        transform.DORotate(new Vector3(0, 0, 0), 0.1f);
        _anim.CrossFade("Run", 0.1f);
        var offset = GameManager.Instance.Cam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
        GameManager.Instance.Cam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(offset.x,offset.y,offset.z-1f);
    }

    // Start is called before the first frame update
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
        
    }

    private void FixedUpdate()
    {
        if (moveControl& GameManager.Instance.GameState == GameState.PLAY)
        {
            Movement();
        }
    }

    private void Movement()
    {
        transform.Translate(0, 0, Time.deltaTime * _speed);
    }

    public void ChangeAnimation(string _animName)
    {
        _anim.CrossFade(_animName, 0.1f);
    }

    public void ChangeMoveControl(bool _movecontrol)
    {
        moveControl = _movecontrol;
    }

    public void FinishStatus()
    {
        _anim.CrossFade("Waving", 0.1f);
    }


}
