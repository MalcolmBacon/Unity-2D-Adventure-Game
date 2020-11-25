using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Observer", menuName = "Observer System/Observer")]
public class Observer : ScriptableObject
{
    public List<ObserverListener> listeners = new List<ObserverListener>();
    
    public void Raise()
    {
        //Loop through all signal listeners and raise a method 
        for (int i = listeners.Count - 1; i >= 0; i--) //go backwards to make sure if remove anything, don't cause an error 
        {
            listeners[i].OnObserveRaised();
        }
    }
    public void RegisterListener(ObserverListener listener)
    {
        listeners.Add(listener);
    }
    public void DeRegisterListener(ObserverListener listener)
    {
        listeners.Remove(listener);
    }
    
}
