using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TopicClick : MonoBehaviour
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

        HeadlineMaker.GenerateNotes(this.transform.GetSiblingIndex());
    }
}