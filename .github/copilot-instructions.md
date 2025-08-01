# GitHub Copilot Instructions for "Star Wars - Fully Functional Lightsabers (Continued)"

## Mod Overview and Purpose

The "Star Wars - Fully Functional Lightsabers (Continued)" mod for RimWorld introduces highly detailed and interactive lightsabers that players can construct, activate, and utilize within the game. Originally developed by Jecrell and Xen, and with assistance from Jedi Master Ailan, this mod allows players to immerse themselves in the Star Wars universe by wielding iconic lightsabers, complete with sound effects and special functionalities such as bullet deflection.

Please note, this mod is no longer actively updated by the original authors, but permission is granted to all modders to remix, recreate, and reuse the content.

## Key Features and Systems

- **Constructable Lightsabers**: Players can build lightsabers at the component assembly bench using a specific recipe that includes lightsaber casing and internals.
- **Crystal Integration**: Lightsabers can be customized with crystals, which can be refined or found as rare drops.
- **Deflection Mechanics**: Lightsabers include systems to deflect and reflect bullets using specialized components.
- **Activatable Effects**: Includes visual and sound effects that play when the lightsaber is activated.
- **Oversized Weapons**: The mod supports oversized weapon handling through dedicated components.

## Coding Patterns and Conventions

- **Component-Based Architecture**: The mod heavily uses a component-based approach to add functionality to lightsabers, making it easy to extend or modify.
- **Class Naming Conventions**: Classes are prefixed with `Comp` or `CompProperties` to indicate their association with specific components.
- **Internal Mod Structure**: The mod is organized into classes for different functionalities like `CompLightsaberActivatableEffect`, `CompCrystalSlotLoadable`, and `CompLightsaberDeflection`.

## XML Integration

XML is used extensively to define the recipes, items, and interactions within the RimWorld environment. For example, the construction materials for a lightsaber are defined in XML files, adhering to RimWorld's modding structure. This allows for seamless integration and modification by other modders.

## Harmony Patching

Harmony is used for runtime method patching to enhance or modify existing game functions:
- **Patch Example**: Patches are usually placed in `HarmonyPatches.cs`, and the `Harmony` prefix is used to denote these patches.
- **Use Cases**: Custom logic and features are integrated into the game using Harmony, ensuring compatibility and future-proofing for game updates.

## Suggestions for Copilot

- **Suggest Common C# Patterns**: Recommend common C# coding practices, like using `using` statements for disposing objects.
- **Recommend XML Snippets**: Provide XML snippets for quickly defining new lightsaber components or recipes.
- **Suggest Harmony Patches**: Include templates for creating new Harmony patches or modifying existing ones.

This mod is a rich resource for modders looking to create advanced weaponry or similar interactive systems in RimWorld. Feel free to explore and expand upon these foundations. May your creations be imbued with the essence of the Force!
