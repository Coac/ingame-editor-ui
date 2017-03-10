# Debug Scene UI
Unity3D in-game UI which shows at runtime a Hierarchy and a Inspector like the built-in Editor.
Can be useful when testing game on Android or doing some reverse-engineering ;)

## Features

### Hierarchy
The Hierarchy displays all GameObjects in the active Scene.

- Update the GameObject list
- Save all displayed GameObject in a text file
- Expand a GameObject to show its children
- Remove a GameObject
- Inspect a GameObject

### Inspector
The Hierarchy lists the components of the selected GameObject
- Display general information (tag, layer)
- Remove a components
- Enable/Disable a MonoBehaviour
- Show the component fields
- Show the component props
- Show the component methods

### Debug Console
The Debug Console acts as the Console in Unity Editor.
- Show all types of logs
- Filter logs by type
- Colorful logging
- Clear logs

### Miscellaneous
- Toggle the debug UI with configurable Key (default = `END`)
- Display FPS

## Usage
Simply drops the scripts in your Unity3D Project and attach `DebugSceneUI` to a GameObject

## Example
Used in the free [Flappy Bird Style Project](https://www.assetstore.unity3d.com/en/#!/content/80330)

![ScreenDemo png](/screenDemo.png)
