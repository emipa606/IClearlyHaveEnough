# GitHub Copilot Instructions for "RimWorld Mod - Resource Management Enhancements"

## Mod Overview and Purpose
This RimWorld mod, titled "Resource Management Enhancements," aims to improve the way players interact with and manage resources within the game. It introduces advanced resource counting and displays crucial resource information directly within the UI, helping players to make more informed decisions about resource allocation and construction planning.

## Key Features and Systems
- **All Resources Counter**: A new map component that tracks and displays the total resources available on the map. This tool helps players easily monitor their stockpile levels without needing to sift through various inventories.
- **Custom UI Elements**: New UI components are introduced, displaying resource information and special mouse attachments to aid in building design and placement.
- **Initialization and Integration Hooks**: Static initializers and certain hooks are used to ensure seamless integration with the base game mechanics, enhancing the user experience.

## Coding Patterns and Conventions
- **Naming Conventions**: All class names are prefixed with the scope and purpose, e.g., `Designator_Build_DrawPanelReadout`.
- **Access Modifiers**: We use `internal` where possible to encapsulate the components tightly within the mod. Methods and classes are exposed only as necessary.
- **Code Structure**: Each class is primarily responsible for one piece of functionality. This maintains clarity and modularity.
- **Error Handling**: Utilize try-catch blocks in key areas that interact with game systems to gracefully handle unexpected errors.
  
## XML Integration
In RimWorld mods, XML files often define new items, buildings, and textures. Ensure that XML files are correctly set up to reference your new C# components where applicable, especially when defining new UI elements or resources.

- **XML Linking**: Ensure your XML files are correctly defined in the `About` folder and link them to corresponding C# logic when required.
- **Namespace Management**: Make sure to use proper namespaces to avoid conflicts with existing game elements or other mods.

## Harmony Patching
Harmony is used to patch or extend existing methods within RimWorld without altering the original game code. This method ensures that mods are compatible with updates and other mods.

- **Safe Patching Practices**: Always ensure patches are well-documented and assume the presence of other mods. Avoid hard dependencies on unpatched base methods where possible.
- **Conflict Resolution**: Use prefix and postfix patches to access method variables safely. Handle potential conflicts by checking existing patches and collaborating with other mod authors when necessary.

## Suggestions for Copilot
To maximize GitHub Copilot's assistance:

- **Code Comments**: Keep detailed comments for each method and class, explaining the purpose and logic. This helps Copilot understand the intended functionality.
- **Provide Context**: When using Copilot, provide context in terms of class purpose, especially when starting new classes or methods.
- **Configuration Files**: Reference properly structured configuration or instruction files to guide Copilot in adapting the existing structure.
- **Review Suggestions**: Always review Copilot's suggestions critically, as it may not fully understand the specifics of your modding context. Ensure it adheres to the RimWorld modding best practices as described above.

By following these detailed guidelines, you can effectively utilize GitHub Copilot and enhance your mod development process. Happy modding!
