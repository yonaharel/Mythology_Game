using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent buttonClick;
  
    void Awake()
    {
        if (buttonClick == null) { buttonClick = new UnityEvent(); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        print("click");
    }
}
