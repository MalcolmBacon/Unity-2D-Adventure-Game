using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ObserverListener : MonoBehaviour
{
    public Observer observer;
    public UnityEvent observeEvent;
    public void OnObserveRaised()
    {
        observeEvent.Invoke();
    }
    private void OnEnable() {
        observer.RegisterListener(this);
    }
    private void OnDisable() {
        observer.DeRegisterListener(this);
    }
}
