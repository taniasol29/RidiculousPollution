using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum state { DOWN = 0, UP, AIR };
    public state currentState = state.DOWN;
    PlayerMovements movements;

    void Start()
    {

    }

    void Update()
    {
        if (currentState == state.DOWN)
        {
            SetState(state.DOWN);
            //if(movements.collided)
            //{
            //    currentState = state.UP;
            //}
            //OnChangeState(state.DOWN, state.UP);
        }
        else if (currentState == state.UP)
        {
            //SetState(state.UP);
            //movements.ReverseGravity();
        }
        else
        {
            SetState(state.AIR);
        }
    }

    public void SetState(state state)
    {
        //OnChangeState(currentState, state);
        currentState = state;
    }

    //void OnChangeState(state prev, state cur)
    //{
    //    //if(movements.collided)
    //    //{
    //    //  
    //    //}
    //}
}
