# MakoCelo
* Log file parser for Company of Heroes 2 match stats.
* Written in Visual Basic 2019.
* Version: 4.20
* Posted: December 3, 2020

VERSION
------------------------------------------------------------------
4.00 - Adds Note Crawlers, Sounds, and image overlays for advanced
       streaming options.
       
4.10 - Sound volume and stop button. Manual Stat page sizing. 
       Bug fixes.   
       
4.20 - Added Load/Save setup buttons.
       
SUMMARY
------------------------------------------------------------------
MakoCelo is a log file parser for the game Company of Heroes 2.
The program displays all players, their ranks, and the factions
they are playing. Additional stats can be found by clicking the 
player name in the STATS window or using the PopUp menu option.

Stats displayed by this program are limited to what is available
in the local log file at runtime.

For a full featured program please search CELO on COH2.Org for
the original program. The Company of Heroes ELO program. Or 
look at https://github.com/0xNeffarion/CELO-Enhanced

The goal of this application is to make it easy for streamers
to create custom match stat visuals for their streams. Preset
size and layouts make it a one click operation to get consistent
layouts.

For examples and additional information goto:
https://www.coh2.org/topic/103744/mako-celo

GET STARTED
------------------------------------------------------------------
1) To get started, click on FIND LOG FILE to locate the Relic Log
file used for match stats. The file is called Warnings.log. 
2) Once a game is started, click on CHECK LOG FILE or SCAN LOG
EVERY 10S. The program will open the log file and look for a
match. For best results restart COH2 frequently.


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

v3.30
* Added Save stats image button.
* Changed COPY and SAVE to enabled at all times.
* Slight speed improvements on FX routines.
* Added additional error checking.
* Cleaned up code for posting.

v3.40
* Changed stats page default sizes to better fit COH2 screen.
* Added centered screen X Layouts.
* Optimized FX routines.
* Fixed bad faction detection code.
* Added bad match stats bypass option so replays show names.
* Added Tool Tip option to help new users figure out controls.

v4.00
* Added NOTE objects with various text crawl animations.
* Added SOUND section to quickly play premade WAVE sound files.
* Added STATS page PopUp context menu option.
* Added Window position and size storage option.

v4.10
* Changed STAT page sizing to manual mode.
* Added individual sound volume thru popup menu.
* Added STOP button to sound player.
* Fixed a recursive bug during the log file scan.
* Added animation smoothing mode option.
* Various smaller bug fixes.

v4.20
* Added setup Load/Save buttons for access to multiple setups.
* Changed ABOUT dialog to RTF for ease of use.
