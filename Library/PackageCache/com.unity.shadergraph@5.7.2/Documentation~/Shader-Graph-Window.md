# Shader Graoh Window

## Description

The **Shader Graph Window** contains the workspace for creating shaders using the **Shader Graph** system. To open the **Shader Graph Window** you must first create a [Shader Graph Asset](index.md). For more information see the [Getting Started](Getting-Started.md) section.

The **Shader Graph** window contains various individual elements such as the [Blackboard](Blackboard.md) and [Master Preview](Master-Preview.md). These elements can be moved inside the workspace. They will automatically anchor to the nearest corner when scaling the **Shader Graph Window**.

## Title Bar

The title bar at the top of the **Shader Graph Window** contains actions that can be performed on the **Graph**.

| Item        | Description |
|:------------|:------------|
| Save Asset | Saves the graph to update the [Shader Graph Asset](index.md) |
| Show In Project | Hightlights the [Shader Graph Asset](index.md) in the [Project Window](https://docs.unity3d.com/Manual/ProjectView.html) |

## Workspace

The workspace is where you create [Node](Node.md) networks. 
You can navigate the workspace by holding Alt and left mouse button to pan and zoom with the scroll wheel.

You can hold left mouse button and drag to select multiple [Nodes](Node.md) with a marquee. There are also various shortcut keys to use for better workflow.

| Hotkey      | Windows     | OSX         | Description |
|:------------|:------------|:------------|:------------|
| Cut | Ctrl + X | Command + X | Cuts selected [Nodes](Node.md) to the clipboard
| Copy | Ctrl + C | Command + C | Copies selected [Nodes](Node.md) to the clipboard
| Paste | Ctrl + V | Command + V | Pastes [Nodes](Node.md) in the clipboard
| Focus | F | F | Focus the workspace on all or selected [Nodes](Node.md)
| Create Node | Spacebar | Spacebar | Opens the [Create Node Menu](Create-Node-Menu.md)

## Context Menu

Right clicking within the workspace will open a context menu. Note that right clicking on an item within the workspace, such as a [Node](Node.md), will open the context menu for that item and not the workspace.

| Item        | Description |
|:------------|:------------|
| Create Node | Opens the [Create Node Menu](Create-Node-Menu.md) |
| Cut | Cuts selected [Nodes](Node.md) to the clipboard |
| Copy | Copies selected [Nodes](Node.md) to the clipboard |
| Paste | Pastes [Nodes](Node.md) in the clipboard |
| Delete | Deletes selected [Nodes](Node.md) |
| Duplicate | Duplicates selected [Nodes](Node.md) |
| Collapse Previews | Collapses previews on all [Nodes](Node.md) |
| Expand Previews | Expands previews on all [Nodes](Node.md) |