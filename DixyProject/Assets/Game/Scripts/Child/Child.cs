using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour,ICollectable
{
    public void DoCollect()
    {
        GameManager.Instance.PlayerController.MyChilds.Add(this);
        transform.SetParent(GameManager.Instance.PlayerController.gameObject.transform);
        transform.localPosition = new Vector3(0, 0, -GameManager.Instance.PlayerController.MyChilds.Count);
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
