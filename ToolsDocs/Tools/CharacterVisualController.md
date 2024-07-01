![[ToolsCharacterVisualController.mp4]]

The purpose of this script is to manage the visual state of the characters on the c# end so that it is easy and convenient for users to update character visual states and not get bogged down by shader manipulation. In its current state it can change the appearance of the character's eyes, mouth, and body patterns. 

In eye settings we are able to set the shader attributes of the eyes connected to the script. This allows us to store the shader properties used by the eye shader. To see more about the eye attributes data structure see [[ShaderPropertyEdit]]. 

For the body pattern it follows a similar pattern as eye and the mouth but not all attributes of the body's material are included. This is on purpose as changing some settings does not either look natural and prove to be too drastic of a change making the character unrecognizable. You may also notice that timescale and direction are separate from the pattern attributes. This is also deliberate since time is managed  by the CharacterVisualController. We do this because using the Time node within shader graph is fine if the timescale and direction do not change. This is because changing the timescale with the shader managing time would change the image to a point as if it were always at the given timescale. This makes interpolating looking very chaotic and bad. With time being manage with C# we a cleaner way to change delta time rather than time as a whole. 

![[TimeScale&PatternDir.png]]

The state of the element relates to the emotional state that these attributes would be related to. There can be multiple elements of the same state but when the character chooses that emotional state, only the topmost element in the list will be used to update the material. 

![[EyeAttributes.png]]

How to use:
- Attach the script to a character object.
- Apply materials for the character's eyes and mouth onto quads, and add those quads' MeshRenderers to the Eyes and Mouth lists of the script (dragging the quads into the lists will work).
- Using the ShaderPropertyEdit script, generate a template for the Eye shader, and copy that template into the Eye Settings list. 
	- Alternatively, the ShaderPropertyEdit script can generate random values for each field, so that the values are not all set to 0.
- Change the emotional State value for the EyeSettings to one of 7 preset emotions, and tweak any and all colors, floats, vectors, etc. to your heart's content.
- Repeat the above two steps for the Mouth shader and MouthSettings. Additionally, the IsTalking checkbox can set whether the scale of the mouth changes to simulate talking.
- After editing the values, set the Emotional State of the script itself to whichever state was just altered, and then click the Update All button to apply those changes to the character's eyes and mouth.
- Enjoy!

