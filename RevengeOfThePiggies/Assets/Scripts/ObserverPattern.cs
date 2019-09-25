using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NotificationType {ShotsUpdated, ScoreUpdated}; //Notification types; add more here

public abstract class Observer : MonoBehaviour 
{
    public abstract void OnNotify(object o, NotificationType n); //If something is an observe, this lets it have a trigger to do something
}

public abstract class Subject : MonoBehaviour
{
    protected List<Observer> observers = new List<Observer>(); //Holds list of observers

    public void registerObserver(Observer o) //Add observers to the list
    {
        observers.Add(o);
    }

    public void unregisterObserver(Observer o) //Removes observers from the list
    {
        observers.Remove(o);
    }

    public void Notify(object o, NotificationType n) //Function for notifying observers
    {
        foreach(Observer ob in observers)
        {
            ob.OnNotify(o, n);
        }
    }
}
