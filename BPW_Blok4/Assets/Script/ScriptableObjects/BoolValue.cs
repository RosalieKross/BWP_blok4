﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolValue : ScriptableObject, ISerializationCallbackReceiver
{


    public bool initialValue;

    [HideInInspector]
    public bool RunTimeValue;


    public void OnAfterDeserialize()
    {
        RunTimeValue = initialValue;
    }

    public void OnBeforeSerialize()
    {

    }
}
