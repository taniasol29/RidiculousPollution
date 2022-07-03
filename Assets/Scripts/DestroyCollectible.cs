using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyCollectible : MonoBehaviour
{
    public GameObject manager;

    HookInputs hookInputs;
    HookInputs.PlayerInteractionsActions playerInteractionsActions;
    private Vector3 mousePos = Vector3.zero;
    float isLeftClick;

    private void Awake()
    {
        hookInputs = new HookInputs();
        playerInteractionsActions = hookInputs.PlayerInteractions;
        playerInteractionsActions.LeftClick.performed += ctx => isLeftClick = ctx.ReadValue<float>();
        playerInteractionsActions.MousePosition.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        hookInputs.Enable();
    }

    private void OnDisable()
    {
        hookInputs.Disable();
    }

    private void Start()
    {
        manager = GameObject.Find("LevelManager");
    }

    private bool LeftMouseClick()
    {
        if(isLeftClick == 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {
        if(LeftMouseClick())
        {
            RaycastHit hit;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            //Debug.Log("mouse pos :" + worldPos);

            if (Physics.Raycast(worldPos, Vector3.forward, out hit))
            {
                //if (hit.collider.gameObject.GetComponent<ReadyToDestroy>().IsReadyToDestroy())
                //{
                    Destroy(hit.collider.gameObject);
                //}
            }
        }
    }
}
