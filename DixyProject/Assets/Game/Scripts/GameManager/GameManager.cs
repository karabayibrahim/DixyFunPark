using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
public class GameManager : MonoSingleton<GameManager>
{
    public PlayerController PlayerController;
    public CinemachineVirtualCamera Cam;
    public CinemachineVirtualCamera CamFinish;
    public UIManager UIManager;
    public GameState GameState;
    public static Action FinishAction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TouchSystem();
    }
    public void FinishStatus()
    {
        CamFinish.gameObject.SetActive(true);
    }

    private void TouchSystem()
    {
        if (GameManager.Instance.GameState==GameState.FINISH)
        {
            if (Input.touchCount>0)
            {
                Touch finger = Input.GetTouch(0);
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(finger.position),out hit))
                {
                    if (hit.collider.GetComponent<ITouch>()!=null)
                    {
                        hit.collider.GetComponent<ITouch>().DoTouch();
                    }
                }
            }
        }
    }
}
