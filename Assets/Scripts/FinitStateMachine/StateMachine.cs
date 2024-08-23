using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    private Dictionary<T, Action> _stateDictionary = new Dictionary<T, Action>();
    private T _currentState;

    public StateMachine(T initialState)
    {
        _currentState = initialState;
    }
    public void SetInitialState(T initialState)
    {
        _currentState = initialState;
    }
    public void AddState(T state,Action action)
    {
        _stateDictionary[state] = action;
    }
    public void TransitionToState(T newState) 
    {
        if (_stateDictionary.ContainsKey(newState)) _currentState = newState;
    }
    public void ExecuteCurrentState()
    {
        if (_stateDictionary != null && _currentState != null && _stateDictionary.ContainsKey(_currentState)) 
        {
            Action currentStateAction = _stateDictionary[_currentState];
            if (currentStateAction != null) currentStateAction();
        }
            
    }
}
