using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MovementBtn : MonoBehaviour
{
    public GameObject currentCam; 
    public GameObject targetCam; 
    public AdventureManager adventureManager;

    [Header("Animatoin")]
    [SerializeField] Button button;
    [SerializeField] float btnAppearTime;
    [SerializeField] float offsetTime;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(ChangePos);

        StartCoroutine(AppearAnim());
    }

    /// <summary>
    /// Simply swaps which camera is active 
    /// </summary>
    public void ChangePos()
    {
        targetCam.SetActive(true);
        currentCam.SetActive(false);

        adventureManager.SetNewZoneByIndex(this.transform.GetSiblingIndex());
    }

    private IEnumerator AppearAnim()
    {

        // Get rendering components 
        Image image = button.GetComponent<Image>();
        TextMeshProUGUI textMesh = button.GetComponentInChildren<TextMeshProUGUI>();

        // Remove alpha 
        Vector3 satBtn = (Vector3)(Vector4)image.color;
        Vector3 satTex = (Vector3)(Vector4)textMesh.color;
        image.color = (Vector4)satBtn;
        textMesh.color = (Vector4)satTex;

        yield return new WaitForSeconds(offsetTime * this.transform.GetSiblingIndex());


        float timer = 0.0f;

        while (timer <= btnAppearTime)
        {
            float lerp = timer / btnAppearTime;
            // Cast down remove alpha 
            satBtn = (Vector3)(Vector4)image.color;

            image.color = (Vector4)satBtn + new Vector4(0, 0, 0, lerp); ;
            textMesh.color = (Vector4)satTex + new Vector4(0, 0, 0, lerp); ;

            timer += Time.deltaTime;
            yield return null;
        }
    }


}
