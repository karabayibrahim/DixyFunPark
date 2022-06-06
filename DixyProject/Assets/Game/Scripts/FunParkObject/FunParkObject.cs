using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FunParkObject : MonoBehaviour,ITouch
{
    [SerializeField] private GameObject modelObject;
    [SerializeField] private float myValue;
    [SerializeField] private GameObject valueText;

    public void DoTouch()
    {
        if (GameManager.Instance.PlayerController.MyMoney>=myValue)
        {
            valueText.SetActive(false);
            modelObject.transform.DOScale(Vector3.one, 2f);
            var tempMoney= GameManager.Instance.PlayerController.MyMoney -myValue;
            DOTween.To(() => GameManager.Instance.PlayerController.MyMoney, x => GameManager.Instance.PlayerController.MyMoney = x, tempMoney, 1).OnUpdate(() =>
            {
                System.Math.Round(GameManager.Instance.PlayerController.MyMoney, 0);
                GameManager.Instance.UIManager.MoneyText.text = " " + "-" + " " + GameManager.Instance.PlayerController.MyMoney.ToString() + "$";
            });
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
