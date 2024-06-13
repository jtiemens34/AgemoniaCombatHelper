# Agemonia Combat Helper

## Under Construction!

> Image of app running with Scenario 3 loaded

## Introduction
Combat in [Agemonia](https://agemonia.com/) can be difficult to keep track of, with a lot of double-checking which attacks monsters are using depending on which initiative card was drawn for the turn.

I've previously used [FrosthavenAssistant](https://github.com/gudyfr/FrosthavenAssistant) to keep track of similar things in [Frosthaven](https://boardgamegeek.com/boardgame/295770/frosthaven) to good effect, so I figured I'd try my hand at creating a similar application for this board game!

## Setup/Usage Guide
This application will be hosted online at TODO: Add link
- Add heroes
  - Click the Add Hero button
  - Select which class and level the hero is
- Select a scenario
  - Click the Select Scenario button
  - Select which scenario to load, optionally using the checkbox to display scenario names to avoid potential spoilers 
- Round structure
  - Click the action color indicator on heroes to assign which action color they will be acting with that turn
  - Click the + icon under any enemies to spawn an enemy of that type
  - Click the Draw Initiative Card button to draw the initiative card for the turn once all heroes are ready
    - This will automatically arrange all heroes/enemies to be arranged from top to bottom in their turn order
    - This will also display each enemy's intended attack option based on the attack indicator for that color of monster on the initiative card
  - Click each hero/enemy to signify their turn has been completed
  - Click the Draw Initiative Card button to advance to the next round once all heroes/enemies have acted
  - Repeat above steps until the scenario has ended
