# GitHub Copilot Instructions for "I Clearly Have Enough! (Continued)" Mod Development

## Mod Overview and Purpose
**Mod Name:** I Clearly Have Enough! (Continued)  
**Author:** ChippedChap  

The "I Clearly Have Enough! (Continued)" mod aims to enhance the building experience in RimWorld by improving how resource requirements are displayed during blueprint placement. The mod ensures that all resources on the map are considered, preventing false alerts of insufficient resources when there are, in fact, enough materials available.

## Key Features and Systems
- **Enhanced Resource Count:** The mod counts all available resources on the map, ensuring more accurate resource requirements display.
- **Architect Tab Improvement:** Updates the architect tab's blueprint needs display so the text remains accurate and doesn't reflect a deficit if resources are present.
- **MapComponent Usage:** Incorporates a MapComponent for efficient resource counting, maintaining performance on low-end systems.
- **Optimized Resource Checking Interval:** Resource counting updates less frequently (every 204 ticks), syncing with the vanilla game's resource counter rate.

## Coding Patterns and Conventions
- **Naming Conventions:** Classes and methods use PascalCase, with descriptive names indicating their functionality (e.g., `Designator_Build_DrawPanelReadout`).
- **Method Documentation:** Methods like `GetPresentOnMap` and `UpdateResourceCounts` clearly indicate their purpose and are implemented consistently across similar use-cases.
- **Single Responsibility Principle:** Classes and methods focus on specific tasks, such as updating resource counts or modifying UI elements.

## XML Integration
While this mod doesn't make extensive use of XML files, integration can be added to define configurable settings or translations. Utilize XML to define any game data that requires frequent updates or user-specific configurations.

## Harmony Patching
The mod relies on Harmony for method patching, allowing seamless integration with the game's functions without directly altering game code.

### Key Harmony Classes
- **Designator_Build_DrawPanelReadout:** Transpilers modify how resources are counted on the map.
- **MainTabWindow_PostOpen:** Postfix patches adjust window displays post-opening.
- **AllResourcesCounter_MapComponent:** Handles the core logic of counting resources using Harmony patches.

### Harmony Best Practices
- **Non-Invasive Modifications:** Ensure patches are non-invasive and do not alter game logic in ways that could conflict with other mods.
- **Error Handling:** Implement try-catch blocks to gracefully handle exceptions within patches.

## Suggestions for Copilot
- **Code Autocompletion:** Use descriptive comments and method names to guide autocompletion to relevant code blocks when expanding functionality.
- **Pattern Recognition:** Leverage Copilot to suggest code patterns based on existing methods like `GetPresentOnMap`.
- **Cross-Reference:** Utilize Copilot to reference other relevant classes or methods, enhancing code cohesion and integration.
- **Performance Mindfulness:** Suggest efficient implementation patterns, especially when working with frequent update loops or resource checks.

By following these guidelines and leveraging GitHub Copilot, you can efficiently maintain and expand the "I Clearly Have Enough! (Continued)" mod, ensuring a smooth and enhanced gameplay experience in RimWorld.

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
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

