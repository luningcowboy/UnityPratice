using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class DelayedPropertyAttribute : MonoBehaviour
{
    [OnValueChanged("ValueChangeCallback")]
    public int field;

    [ShowInInspector]
    [OnValueChanged("ValueChangeCallback")]
    public string property { get; set; }
    
    [Delayed]
    [OnValueChanged("ValueChangeCallback")]
    public int fieldDelay;
    
    [ShowInInspector, Sirenix.OdinInspector.DelayedProperty]
    [OnValueChanged("ValueChangeCallback")]
    public string propertyDelay { get; set; }
    

    public void ValueChangeCallback()
    {
        Debug.Log("ValueChangeCallback");
    }



}
