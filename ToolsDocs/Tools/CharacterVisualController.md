![[ToolsCharacterVisualController.mp4]]

The purpose of this script is to manage the visual state of the characters on the c# end so that it is easy and convenient for users to update character visual states and not get bogged down by shader manipulation. In its current state it merely changes the state of the eyes but also has the ability to shift between to visual patterns as seen across the character's body (WIP). 

In eye settings we are able to set the shader attributes of the eyes connected to the script. This allows us to store the shader properties used by the eye shader. Too see more about the eye attributes data structure see [[ShaderPropertyEdit]]. 

The state of the element relates to the emotional state that these attributes would be related to. There can be multiple elements of the same state but when the character chooses that emotional state, only the top most element in the list to update the material with. 

![[Pasted image 20240613102807.png]]

