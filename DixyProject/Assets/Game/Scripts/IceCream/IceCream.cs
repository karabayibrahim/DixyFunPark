using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class IceCream : MonoBehaviour,ICollectable
{
    [SerializeField] private Transform _childPoz;

    public void DoCollect()
    {
        var child = GameManager.Instance.PlayerController.MyChilds[GameManager.Instance.PlayerController.MyChilds.Count - 1];
        child.ChangeMoveControl(false);
        child.ChangeAnimation("Leave");
        child.transform.SetParent(transform);
        child.transform.DOMove(_childPoz.position, 0.5f);
        GameManager.Instance.PlayerController.MyChilds.Remove(child);
        GameManager.Instance.UIManager.ChildCountText.text = " " + "-" + " " + GameManager.Instance.PlayerController.MyChilds.Count.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
