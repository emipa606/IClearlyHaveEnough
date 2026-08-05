# Copilot Instructions for "I Clearly Have Enough! (Continued)" RimWorld Mod

## Mod Overview and Purpose
"I Clearly Have Enough! (Continued)" is a RimWorld mod that enhances the user experience when it comes to managing resources while placing blueprints. It improves the accuracy of the resource readout by counting all available resources on the map, ensuring that players are not incorrectly informed about resource shortages when, in fact, they have ample supplies.

## Key Features and Systems
- **Enhanced Resource Readout**: The mod adjusts how resource availability is displayed when placing blueprints. If sufficient resources are available on the map, the warning message is suppressed or altered for clarity.
- **Architect Tab Improvements**: Modifies the architect tab to reflect accurate blueprint material requirements vis-à-vis available resources, preventing unnecessary alert messages.
- **Performance Optimization**: Utilizes a `MapComponent` that updates resource counts every 204 ticks to reduce computational load on low-end PCs.
- **Error Management**: Provides guidance on handling errors related to save games and mod loading.

## Coding Patterns and Conventions
- **File Structure**: The project contains several C# source files each handling specific mod components.
  - Example files include `AllResourcesCounter_MapComponent.cs`, `IClearlyHaveEnoughInit.cs`, and `Designator_Build_DrawPlaceMouseAttachments.cs`.
- **Code Organization**: Classes and methods are logically divided, reflecting their specific roles, such as initialization routines, mouse attachment drawings, and window post-opening behaviors.

## XML Integration
- Currently, the mod does not contain XML files or definitions. All interactions and changes are managed through C# code.

## Harmony Patching
- **Method Patching**: Makes use of Harmony, a library that facilitates runtime patching of compiled methods. This mod specifically applies Harmony patches to modify the behavior of UI elements and game mechanics:
  - Use cases include transpilers and postfixes for methods dealing with UI and gameplay elements.

## Suggestions for Copilot
The following suggestions could be useful for further development and enhancements:
- **Adding XML Support**: Consider adding support for XML configurations to allow users to customize resource count update intervals or message formats.
- **Improving Performance**: Look into batched updates or exploring more efficient querying of in-game resources.
- **Enhancing Localization**: Expand localization support to cover more languages, building on the existing Japanese translation.
- **Advanced Logging**: Implement detailed logging for debugging and to assist in community support when errors occur.

The provided framework should allow further customization and expansion, leveraging GitHub Copilot assistance effectively to maintain and enhance the mod. As the mod continues to evolve, consider structured comments within the code to convey the purpose and logic applied in various methods, aiding Copilot in generating more contextually relevant suggestions.


This `.github/copilot-instructions.md` file provides a comprehensive overview and offers guidance to anyone looking to understand or contribute to the mod, with the help of GitHub Copilot. It covers essential technical aspects and promotes best practices.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).

