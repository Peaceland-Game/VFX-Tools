using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    [SerializeField] Vector3 startScale;
    [SerializeField] float spawnTime;
    [SerializeField] AnimationCurve scaleCurve;
    [SerializeField] float delayBeforeType;
    [SerializeField] float typeSpeed;

    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI textMesh;

    private string message = "";
    private void Start()
    {
        StartNotfication("Choice Remembered");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            StartNotfication("Choice Remembered");
    }

    public void StartNotfication(string message)
    {
        this.message = message;
        StartCoroutine(SpawnNotif());
        StartCoroutine(Type());
    }

    private IEnumerator SpawnNotif()
    {
        float timer = 0.0f;
        Vector3 targetSize = this.transform.localScale;

        while(timer <= spawnTime)
        {
            float lerp = timer / spawnTime;
            this.transform.localScale = Vector3.Lerp(startScale, targetSize, scaleCurve.Evaluate(lerp));

            Vector3 noA = (Vector3)(Vector4)image.color;
            image.color = (Vector4)noA + new Vector4(0, 0, 0, lerp);
            textMesh.color = new Vector4(0, 0, 0, lerp);

            timer += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator Type()
    {
        int currentChar = 0;

        string current = "";
        textMesh.text = current;

        yield return new WaitForSeconds(delayBeforeType);

        while(currentChar < message.Length)
        {

            current += message[currentChar];
            textMesh.text = current;

            currentChar++;
            yield return new WaitForSeconds(1.0f / typeSpeed);
        }
    }
}
