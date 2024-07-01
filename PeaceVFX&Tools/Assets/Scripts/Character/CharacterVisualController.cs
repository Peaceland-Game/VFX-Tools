using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ShaderPropertyEdit;

/*
 * Peaceland Character Visual Controller
 * Created by Narai Risser
 * Mouth functionality added by William Duprey
 * Last updated 6/24/24
 */

[ExecuteAlways]
public class CharacterVisualController : MonoBehaviour
{
    [Header("Overall Visuals")]
    [SerializeField] EmotionalState emotionalState;

    [Header("Eyes")]
    [SerializeField] List<Renderer> eyes;
    [SerializeField] List<EyeSettings> eyeSettings;

    [Header("Mouth")]
    [SerializeField] bool isTalking;
    [SerializeField] List<Renderer> mouths;
    [SerializeField] List<MouthSettings> mouthSettings;

    [Header("Pattern")]
    [SerializeField] List<PatternSettings> patterns;
    [SerializeField] List<Renderer> bodies;
    [Tooltip("How fast does the pattern change from one state to another")]
    [SerializeField] float changeTime;
    [SerializeField] AnimationCurve changeCurve;

    // If currently in the process of changing then hold onto next
    // Overwrites this if multiple changes are requested 
    private EmotionalState nextPatternEmotion;
    private bool isPatternChanging { get { return patternCoroutine != null; } }
    private Coroutine patternCoroutine;

    private EmotionalState holdState;
    private bool isHolding = false;


    private void Start()
    {
        holdState = emotionalState;
    }

    void Update()
    {

        if (emotionalState == holdState)
        {
            return;
        }

        UpdateEyes();
        UpdateMouth();
        UpdatePattern();

        holdState = emotionalState; 
    }

    public void UpdateEyes()
    {
        for (int i = 0; i < eyes.Count; i++)
        {
            // Determining a stupid, arbitrary convention:
            // - even numbered eyes have their cutout center X value multiplied by -1,
            // - odd numbered eyes have their X value multiplied by 1
            Vector3 offset;
            if (i % 2 == 0)
            {
                offset = new Vector3(-1, 1, 1);
            }
            else
            {
                offset = new Vector3(1, 1, 1);
            }

            EyeSettings settings = FindEyeSettings(emotionalState);
            settings?.LoadAttributesIntoEye(eyes[i], eyes[i].sharedMaterial.shader, offset);
        }
    }

    /// <summary>
    /// Updates the mouth
    /// </summary>
    public void UpdateMouth()
    {
        for(int i = 0; i < mouths.Count; i++)
        {
            MouthSettings settings = FindMouthSettings(emotionalState);
            settings?.LoadAttributesIntoMouth(mouths[i], mouths[i].sharedMaterial.shader, isTalking);
        }
    }

    /// <summary>
    /// Updates the body pattern 
    /// </summary>
    public void UpdatePattern()
    {
        if(bodies.Count == 0)
        {
            Debug.LogError("No bodies to apply to");
            return;
        }

        // Check if alreay shifting 
        if (isPatternChanging)
        {
            // Hold onto the next desired emotional pattern and override
            // previous nextPatternEmotion if multiple request are made  
            nextPatternEmotion = emotionalState;
            isHolding = true;
            return;
        }

        // Start shift to next pattern 
        patternCoroutine = StartCoroutine(ChangePatternCo(holdState, emotionalState));
    }

    private IEnumerator ChangePatternCo(EmotionalState currentState, EmotionalState nextState)
    {
        float timer = 0.0f;

        PatternSettings interpolated = new PatternSettings();

        PatternSettings currProps = FindPatternSettings(currentState);
        PatternSettings nextProps = FindPatternSettings(nextState);
        
        while (timer <= changeTime)
        {
            // Make sure to load helpers 
            currProps.patternAttributes.GeneratePropertyHelpers();
            nextProps.patternAttributes.GeneratePropertyHelpers();

            // Lerp property values 
            float lerp = timer / changeTime;
            ShaderProperties interpolatedProperties =
                ShaderPropertyEdit.InterpolateProperties(
                    currProps.patternAttributes,
                    nextProps.patternAttributes,
                    changeCurve.Evaluate(lerp));

            interpolatedProperties.GeneratePropertyHelpers();
            interpolated.patternAttributes = interpolatedProperties;

            for(int i = 0; i < bodies.Count; i++)
            {
                interpolated.LoadAttributesIntoPattern(bodies[i], bodies[i].sharedMaterial.shader);
            }

            timer += Time.deltaTime;
            yield return null;
        }

        patternCoroutine = null;
    }


    /// <summary>
    /// Searches for the first eye settings with matching emotion type 
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    private EyeSettings FindEyeSettings(EmotionalState state)
    {
        foreach (EyeSettings eye in eyeSettings)
        {
            if(eye.state == state)
            {
                return eye;
            }
        }

        // Eye not found 
        Debug.LogWarning("Eye state " + state + " not found");
        return null;
    }

    /// <summary>
    /// Searching for the first mouth settings with matching emotion type 
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    private MouthSettings FindMouthSettings(EmotionalState state)
    {
        foreach(MouthSettings mouth in mouthSettings)
        {
            if(mouth.state == state)
            {
                return mouth;
            }
        }

        // Mouth not found
        Debug.LogWarning("Mouth state " + state + " not found");
        return null;
    }

    /// <summary>
    /// Searching for the first pattern settings with matching emotion type 
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    private PatternSettings FindPatternSettings(EmotionalState state)
    {
        foreach (PatternSettings pattern in patterns)
        {
            if (pattern.state == state)
            {
                return pattern;
            }
        }

        // Pattern not found
        Debug.LogWarning("Pattern state " + state + " not found");
        return null;
    }

    [Serializable]
    private class EyeSettings
    {
        [SerializeField] public EmotionalState state;
        [SerializeField] ShaderPropertyEdit.ShaderProperties eyeAttributes;

        public void LoadAttributesIntoEye(Renderer eyeRenderer, Shader shader, Vector3 cutoutOffset)
        {
            // Call the generic methods for loading shader properties for the material
            ShaderPropertyEdit.GeneratePropertyHelpers(eyeAttributes, shader);
            ShaderPropertyEdit.LoadIntoMaterial(Application.isEditor ? eyeRenderer.sharedMaterial : eyeRenderer.material, eyeAttributes);

            // Update a specific property that the eyes have that allow the
            // cutout portion to be properly mirrored for left / right eyes.
            // Narai, I'm deeply sorry for defiling your beautiful tool.
            eyeRenderer.material.SetVector("_CutoutCenterOffset", cutoutOffset);
        }
    }

    /// <summary>
    /// Basically a copy of EyeSettings, that allows for the mouth to be updated separately.
    /// </summary>
    [Serializable]
    private class MouthSettings
    {
        [SerializeField] public EmotionalState state;
        [SerializeField] ShaderPropertyEdit.ShaderProperties mouthAttributes;

        public void LoadAttributesIntoMouth(Renderer mouthRenderer, Shader shader, bool isTalking)
        {
            ShaderPropertyEdit.GeneratePropertyHelpers(mouthAttributes, shader);
            ShaderPropertyEdit.LoadIntoMaterial(Application.isEditor ? mouthRenderer.sharedMaterial : mouthRenderer.material, mouthAttributes);

            // If isTalking is false,
            //      Set talk speed to 0 to prevent the mouth scale from changing
            //      Set MouthBaseSize to SilentMouthSize (allowing for different
            //        emotional states to have different silent mouth sizes)
            if (!isTalking)
            {
                mouthRenderer.material.SetFloat("_TalkSpeed", 0);
                mouthRenderer.material.SetVector("_MouthBaseSize", 
                    mouthRenderer.material.GetVector("_SilentMouthSize"));
            }
        }
    }

    /// <summary>
    /// Holds the pattern settings specific to an emotion 
    /// </summary>
    [Serializable]
    private class PatternSettings
    {
        [SerializeField] public EmotionalState state;
        [SerializeField] public ShaderPropertyEdit.ShaderProperties patternAttributes;
       
        public void LoadAttributesIntoPattern(Renderer bodyRenderer, Shader shader)
        {
            // Call the generic methods for loading shader properties for the material
            //ShaderPropertyEdit.GeneratePropertyHelpers(patternAttributes, shader);
            ShaderPropertyEdit.LoadIntoMaterial(Application.isEditor ? bodyRenderer.sharedMaterial : bodyRenderer.material, patternAttributes);
        }
    }


    private enum EmotionalState
    {
        CONTENT,
        SLEEPY,
        STUNNED,
        SAD,
        PLEASED,
        JOYFUL,
        ANGRY
    }
}
