using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Text Object", menuName = "Miscellaneous/Text Object")]
public class TextObject : ScriptableObject
{
    [TextArea(15, 30)]
    public string text;
}
