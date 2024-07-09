using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISettings : MonoBehaviour
{
    [SerializeField] List<Section> sections;

    private GameObject holdObject;

    private void Start()
    {
        LoadSection(holdObject);
    }

    /// <summary>
    /// Swaps which section is currently active 
    /// </summary>
    /// <param name="section"></param>
    public void LoadSection(GameObject section)
    {
        if(holdObject != null)
            holdObject.SetActive(false);
        
        if(section != null)
            section.SetActive(true);

        holdObject = section;
}

    [System.Serializable]
    private class Section
    {
        [SerializeField] string title;
        [SerializeField] public GameObject sectionSettings;
    }
}
