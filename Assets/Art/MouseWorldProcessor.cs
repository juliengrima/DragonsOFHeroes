using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

#if UNITY_EDITOR
[InitializeOnLoad]
#endif
public class MouseWorldProcessor : InputProcessor<Vector2>
{
    #if UNITY_EDITOR
    static MouseWorldProcessor()
    {
        Initialize();   
    }
    #endif

    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        InputSystem.RegisterProcessor<MouseWorldProcessor>();
    }

    public override Vector2 Process( Vector2 value, InputControl control )
    {
        return Camera.main.ScreenToWorldPoint( value );
    }
}
