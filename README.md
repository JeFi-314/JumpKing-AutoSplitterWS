# AutoSplitter for Jump King (Workshop Version)

This repository contains an auto-splitter for **Jump King** designed for use with **LiveSplit**.

Auto-splitters that rely on memory reading often need frequent updates to keep up with changes to the game's executable, which can be a maintenance burden. To solve this, this auto-splitter instead uses a Steam Workshop item to communicate directly with the LiveSplit component, bypassing memory address dependencies and enabling long-term support.

It consists of two components: the Workshop item and the LiveSplit component. These communicate through shared memory (based on modified communication code from the [**CelesteTAS-EverestInterop**](https://github.com/EverestAPI/CelesteTAS-EverestInterop)).

## Table of Contents

- [Prerequisites](#prerequisites)
- [How to Use](#how-to-use)
- [Split Types](#split-types)
- [Game States](#game-states)
- [In-Game Features](#in-game-features)
- [License Notice](#license-notice)

## Prerequisites

1. Subscribe to **[AutoSplitterWS](https://steamcommunity.com/sharedfiles/filedetails/?id=3446413963)** on the Steam Workshop. Ensure that this item is enabled before starting your game.
2. Obtain the LiveSplit component (set the game name to "Jump King Custom Maps" in **Edit Splits**, then activate the auto-splitter).

## How to Use

You can access the settings window by right-clicking on LiveSplit → **Edit Splits** ( → Set **Game Name** → **Activate** ) → **Settings**. The following options are available:

- **Auto Start Timer**: Automatically start the timer as soon as the game begins.
- **Auto Reset Timer**: Automatically reset the timer when restarting the game (via hotkey or the pause menu).
- **Undo Split**: Enable the undo split feature (see *Screen Splits* section for details).
- **Splits Setting**: Configure different split types for each existing segment. You can manually drag the icons on the right side to reposition the setting.

## Split types

The auto-splitter supports the following types of split conditions:

- **Manual Split** (Default): The segment won't be split automatically; you need to manually split it.

- **Screen Split**: The segment is splitted when a specified screen is reached. If **Undo Split** is enabled, and the player enters the screen but fails to land properly (as IL Rule 1), an undo split is automatically performed.

  - **Screen Number**: Specify the target screen number. You can toggle "Show Screen-#" in-game mod setting to show the current screen number.

- **Raven Split**: The segment is splitted when a raven escape event is triggered.

  - **Raven Name**: The name of the raven (the options are raven names used in the nexile map).
  - **Home Index**: The positional index of the raven (starting from 1).

  Name & home index can be directly found in the corresponding configuration file (e.g., `[name].ravset`) under the folder `Content\props\textures\raven\` (`[map folder]\props\textures\raven\` for custom map).

- **Item Split**: The segment is splitted when the total number of a specified item collected reaches a defined amount.

  - **Item Name**: The name of the item in the game.
  - **Count**: The required quantity for the split.

- **Ending Split**: The segment is splitted upon entering an ending (when reaching the princess).

  - **Ending Name**: There are three options available: *Main Babe*, *New Babe+*, and *Ghost of the Babe*.
  - For custom maps, you can find the corresponding ending screen in the `level_settings.xml` file within the `<ending_screen>`, `<ending_screen_second>`, and `<ending_screen_third>` tags.

- **Achievement Split**: The segment is splitted when a specific achievement is obtained.

  - **Achievement Name**: The name of the achievement as it appears on Steam. Hovering over the achievement will display its description.

**Note:** Within a single game frame, if multiple segments are splitted consecutively, only the first segment will be splitted while the subsequent segments will be skipped.

## Game States

The auto-splitter automatically tracks various in-game states such as the current screen reached, raven chase events, and more. These states form the basis for determining when to do auto-split. 

All game states are reset when a new LiveSplit run begins, while states related to screen and raven events are specifically reset when leaving the game (upon winning, restarting, or returning to the menu).

**Note**: If you exit to the menu and then continue the run, the screen and raven splits might not behave as expected.

## In-Game Features

The Workshop item for Jump King provides several features. You can find these features under **Workshop → Mods** in the main menu, or **Options → Mods** in the pause menu:

- **Show Screen-#**  
   When enabled, displays the current screen number in the top-right corner of the screen. This is especially helpful when setting up **Screen Splits**.

- **Connection Status Display**  
   Shows the current connection status between JumpKing and LiveSplit. There are 3 possible states:

   - **Connecting** – Attempting to connect to the LiveSplit. If this persists, make sure LiveSplit is open and the auto-splitter is activated.
   
   - **Connected** – Successfully connected and transmitting game data to the LiveSplit.
   
   - **Disconnected** – The connection has failed, often due to a version mismatch between the Workshop item and the auto-splitter. To resolve this, try updating the auto-splitter or unsubscribe-resubscribe to the Workshop item, then press the **Reconnect** button.

### License Notice

The communication portion is derived from [**CelesteTAS-EverestInterop**](https://github.com/EverestAPI/CelesteTAS-EverestInterop) by **Everest Team** and is used under the MIT License. Please refer to the headers in the related source files for complete license details.