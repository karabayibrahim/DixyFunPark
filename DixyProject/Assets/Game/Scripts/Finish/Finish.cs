using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour,ICollectable
{
    public void DoCollect()
    {
        GameManager.Instance.GameState = GameState.FINISH;
        GameManager.Instance.FinishStatus();
        GameManager.FinishAction?.Invoke();
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
