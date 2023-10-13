using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachine<T>
{
    public void OnInit(T t);
    public void OnExcute(T t);
    public void OnOut(T t);
}
