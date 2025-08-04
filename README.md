# Formation Fixer for More Party Slots RT



## About

A mod for Owlcat's Warhammer 40,000 Rogue Trader.

Adjusts the formation templates and UI to allow for larger parties, intended for use in conjunction with ADDB's [More Party Slots RT](https://www.nexusmods.com/warhammer40kroguetrader/mods/165) mod. Supports up to 24 party members, including pets (double the provision of vanilla).

By default, the game only handles up to 12 entities in a party formation. Anything beyond that and characters are forced into the same position on top of one another. This mod edits all the custom formations to allow for more characters, adding an additional 12 positions to bring the total to 24. It also adjusts the scaling of the character portraits in the formation manager UI to allow for more space to fit larger parties. Additionally, the settings of the Auto formation have been tweaked to try and better accommodate large parties, and maximise the use of the UI space for it in the formation manager.

## Install
1. Download the latest version of the mod from [Github](https://github.com/DarthParametric/RT_Formation_Fixer/releases/latest), [Nexus Mods](https://www.nexusmods.com/games/warhammer40kroguetrader/mods/xxxxx), or via [ModFinder RT](https://github.com/CasDragon/ModFinder/releases/latest).
1. Install the mod manually, via UMM, or via ModFinder.
1. Run your game.

## Notes
- More Party Slots is not strictly required, but there's little point in using this mod unless you have a party beyond the vanilla 6. Although it may prove useful for vanilla 6 + 6 pets.
- The vanilla game has a hard limit of 20 units in the party, which this mod has expanded to 24. While More Party Slots might let you add more units beyond that, doing so will cause the game to crash when loading an area with all of them in the party. While the cap itself is easy to raise, each new party member would require a new set of formation positions.
- The formation manager UI scaling has been adjusted to fit larger formations more comfortably and give you more room to customise their positions. The various patches involved to do so though may cause some unexpected wonkiness, so use the Restore to Default button if things get messed up.
- The Auto formation does not handle large parties very well. I have tried to adjust its behaviour, with limited success. However, the formation manager UI tab for it does now dynamically adjust the formation position to try and maximise the available space.
- Should work with both the keyboard/mouse and controller UI schemes.

## Thanks & Acknowledgements
- microsoftenator2022 - Helped out with creating my first transpiler for Wrath and various aspects of the Wrath Formation Fixer mod. Helped out a lot for the RT version with correcting my syntax goofs and providing the solution to a particularly vexing code insertion translation.
- Kurufinve - Helped pin down the root issue with the formation UI window not updating with the mod's changes immediately on opening and offered critique on bundle/asset loading (or more specifically my poor implementation thereof).
- ADDB - Provided the IEnumerable list code to handle either kb/m or controller schemes after his attempts to dumb it down to explain the general concept to me weren't dumbed down enough for me to understand.
- Everyone in the `#mod-dev-technical` channel of the Owlcat Discord server for various modding-related discussions and suggestions, help troubleshooting issues, and answering general questions.
