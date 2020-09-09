using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
, IPointerEnterHandler, IPointerExitHandler
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("OnPointerDown");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("OnPointerClick");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("OnPointerEnter"); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("OnPointerExit"); 
    }
}
