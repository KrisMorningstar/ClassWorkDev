using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CarSteer : MonoBehaviour
{
    [SerializeField] private float steerPos;
    [SerializeField] private Image steerImage;

    [SerializeField] private float leftSteerMax;
    [SerializeField] private float rightSteerMax;

    [SerializeField] EventSystem _eventSystem;
    [SerializeField] GraphicRaycaster _graphicRaycaster;
    private PointerEventData _pointerEventData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Steering()
    {

    }
}
