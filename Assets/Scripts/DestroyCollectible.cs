using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyCollectible : MonoBehaviour
{
    //public GameObject manager;

    //HookInputs hookInputs;
    //HookInputs.PlayerInteractionsActions playerInteractionsActions;
    //private Vector3 mousePos = Vector3.zero;
    //float isLeftClick;

    [SerializeField] private InputActionAsset playerInputs;
    [SerializeField] private InputAction leftClick;
    [SerializeField] private Camera cam;
    [SerializeField] float destroyDelay = 2.0f;

    [SerializeField] ParticleSystem explosion;

    //values
    public int goValue;
    public bool isDestroyed = false;

    private void Awake()
    {
        //hookInputs = new HookInputs();
        //playerInteractionsActions = hookInputs.PlayerInteractions;
        //playerInteractionsActions.LeftClick.started += ctx => isLeftClick = ctx.ReadValue<float>();
        //playerInteractionsActions.MousePosition.performed += ctx => mousePos = ctx.ReadValue<Vector2>();

        var aMap = playerInputs.FindActionMap("PlayerInteractions");
        leftClick = aMap.FindAction("LeftClick");
        leftClick.started += OnLeftClick;
    }

    private void OnEnable()
    {
        //hookInputs.Enable();

        leftClick.Enable();
        explosion.Play();
        Invoke("Destroy", destroyDelay);
    }
    private void OnDisable()
    {
        //hookInputs.Disable();
    }

    private void Start()
    {
        //manager = GameObject.Find("LevelManager");
        explosion = gameObject.GetComponent<ParticleSystem>();
    }

    //private bool LeftMouseClick()
    //{
    //    if(isLeftClick == 1.0f)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //private void Update()
    //{
    //    if (LeftMouseClick())
    //    {
    //        RaycastHit hit;
    //        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
    //        Debug.Log("mouse pos :" + worldPos);

    //        if (Physics.Raycast(worldPos, Vector3.forward, out hit))
    //        {
    //            if (hit.collider.gameObject.GetComponent<ReadyToDestroy>().IsReadyToDestroy())
    //            {
    //                Destroy(hit.collider.gameObject);
    //            }
    //        }
    //    }
    //}

    void OnLeftClick(InputAction.CallbackContext context)
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.DrawLine(ray.origin, hit.point);
            if (hit.transform.CompareTag("Fish") || hit.transform.CompareTag("Polluant"))
            {
                //Debug.Log("ok");
                goValue = hit.collider.gameObject.GetComponent<CollectProperties>().collectValue;
                isDestroyed = true;
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
