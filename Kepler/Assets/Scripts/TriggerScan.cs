using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.ParticleSystem;

public class TriggerScan : MonoBehaviour
{
    [HideInInspector]
    public InputAction RightTrigger;
    [SerializeField]
    private ActionBasedController RightHandController;
    [SerializeField]
    GameObject Scanner;
    // Start is called before the first frame update
    void Start()
    {
        RightTrigger = RightHandController.activateAction.reference;
    }

    // Update is called once per frame
    void Update()
    {
        if (RightTrigger.IsPressed())
        {
            Scanner.SetActive(true);
        }
        else
        {
            Scanner.SetActive(false);
        }
    }
}
