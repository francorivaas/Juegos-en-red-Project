using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T>
{
    IState<T> _current;
    public FSM() { }
    public FSM(IState<T> initState)
    {
        SetInit(initState);
    }
    public void SetInit(IState<T> initState)
    {
        _current = initState;
        _current.SetFSM = this;
        _current.Enter();
    }
    public void OnUpdate()
    {
        if (_current != null)
            _current.Execute();
    }
    public void OnLateUpdate()
    {
        if (_current != null)
            _current.LateExecute();
    }
    public void Transition(T input)
    {
        IState<T> newState = _current.GetTransition(input);
        if (newState != null)
        {
            _current.Sleep();
            //Debug.Log(_current + " TO: " + newState);
            _current = newState;
            _current.SetFSM = this;
            _current.Enter();
        }
    }
    public IState<T> CurrentState => _current;
}
