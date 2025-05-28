using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAdditionallyGivesHint : MonoBehaviour
{
    [SerializeField]
    HintObject _hintObject;
    public HintObject HintObject { get { return _hintObject; } }
}
