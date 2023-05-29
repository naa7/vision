using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetNewsCount : MonoBehaviour
{
    void Start()
    {
        PersistentData.Instance.SetNewsCount(0);
    }
}
