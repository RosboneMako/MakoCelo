# MakoCelo
Log file parser for Company of Heroes 2 match stats.

Written in Visual Basic 2019.

SUMMARY
------------------------------------------------------------------
MakoCelo is a log file parser for the game Company of Heroes 2.
The program displays all players, their ranks, and the factions
they are playing. By clicking a players name (left/right), each
players individual stats will be called up on your web browser.
Left clicking calls up Relics stats and left clicking calls up 
COH2.Org stats. Presing CTRL and Left mouse button sends the 
player name selected to google translate. CTRL and RIGHT mouse
send you to Coh2.Org main page for that player.

Stats displayed by this program are limited to what is available
in the local log file at runtime.

For a full featured program please search CELO on COH2.Org for
the original program. The Company of Heroes ELO program. Or 
look at https://github.com/0xNeffarion/CELO-Enhanced

The goal of this application is to make it easy for streamers
to create custom match stat visuals for their streams. Preset
size and layouts make it a one click operation to get consistent
layouts.

CONTRIBUTORS
------------------------------------------------------------------
Ishtari, Sturmpanther, Flappy

VERSION HISTORY
------------------------------------------------------------------
v1.00
* Initial Release.

v1.10
* Small bug fixes.

v2.00
* Added Graphical controls for both Rank and Name labels.
* Added Background Image scaling options: None,Tile,Fit.
* Added Background image size presets.
* Added label size and placement position presets.
* Added Search assist directory code.
* Changed unranked player rank to --- label.

v2.10
* Added UTF8 encoding when reading log files. This fixes non native language names showing up incorrectly.
* Added Light/Dark color schemes.		
* Added dialog box initial directory tracking.	
* Fixed minor bugs with Rank and Name label setup.
* COH2 game path is now hidden to reduce app size.
* Players ranks are now base 1 (was base 0).

v3.00
* Move to graphical code Stats Page.
* Most colors are now gradients.
* Font Shadows added.
* CTRL-LEFT mouse sends names to Google Translate.
* Test Setup data to show the max chars normally displayed.
* Fixed long names becoming jumbled using labels.	
* Default setup implemented for non streamers.
* Player select faction icon rollover added.
* New settings file with some future vals added.
	
v3.10
* Added FX mode controls for future graphical updates.
* Added Shade/Glow and Emboss FX.
* Added code to maintain last played match stats.
* Added Help Hint button for new FX types.
* Created MSI installation package.

v3.20
* Migrated to Visual Studio 2019
* Improved LOG file scanning. Catches out of order matchs
  and spectates.
* Added Blurry Label background FX.
* Able to apply all FX at once now.
* Ctrl-Right now directs you to Coh2.Org main player card page.
