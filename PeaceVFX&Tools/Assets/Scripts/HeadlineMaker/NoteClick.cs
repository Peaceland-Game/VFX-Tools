using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteClick : MonoBehaviour
{
    public HeadlineMaker HeadlineMaker { get; set; }

    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (HeadlineMaker == null)
            return;

        HeadlineMaker.GenerateHeadline(this.transform.GetSiblingIndex());
    }
}
