using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
   public Func<bool> IsValid { get; private set; }
   public Func<State> GetNextState { get; private set; }
   public Transition(Func<bool> isValid, Func<State> getNextState)
    {
        IsValid = isValid;
        GetNextState = getNextState;
    }
}
