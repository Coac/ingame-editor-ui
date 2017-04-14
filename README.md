# Ingame Editor UI
Unity3D in-game UI, which shows at runtime a Hierarchy and an Inspector like the built-in Editor.
Can be useful when testing game on Android or doing some reverse-engineering ;)

## Features

### Hierarchy
The Hierarchy displays all GameObjects in the active Scene.

- Update the GameObject list
- Save all displayed GameObject in a text file
- Show the child count
- Expand a GameObject to show its children
- Inspect a GameObject

### Inspector
The Hierarchy lists the components of the selected GameObject
- Display general information (tag, layer)
- Remove the inspected GameObject
- Remove a component
- Enable/Disable a MonoBehaviour
- Show the component fields
- Show the component props
- Show the component methods
- Edit on the fly component fields/props

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
Simply drop the scripts in your Unity3D Project and attach `IngameEditorUI` to a GameObject

![ScreenDemo png](/screenDemo.png)
