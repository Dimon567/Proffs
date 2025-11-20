using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.Rendering;

public class LevelManager : MonoBehaviour
{
    public LevelManager instanse;
    public List<StepEdit> editSteps;

    void Start()
    {
        instanse = this;
    }

    void Update()
    {

    }

}

[Serializable]
public class StepEdit
{
    enum typeChanges
    {
        Put = 1,
        Rotate = 2,
        Delete = 3
    }

    public int itemId;
    public int stepId;
    public Transform stepTransform;
}
