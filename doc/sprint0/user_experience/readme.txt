When the app is initially launched, the 'startup_logo' will fade in and then out.

After fading out, the app will transition to the 'startup_menu'.

	-(if online multiplayer is implemented) In the top left corner, there will be a button for user profile.
	-center of the screen will have the Sinoda game logo
	-bottom left corner will contain the menu options (startup_menu_new_game)
		*when 'NEW GAME' is clicked, a submenu will popout to the right containing the game options. 
		 Further, if local multiplayer is selected, another submenu will popout to the right allowing the user 
		 to select the number of players.
		*When 'SINGLE PLAYER' is clicked, the app will directly transition to 'game_screen' but with only 1 player hud 
		 at the bottom of the screen.
		*When 'EXIT' is clicked, the app will shut down.

When a game has started and the app is in 'game_screen', there will be a number of HUDs created (bottom of 'game_screen') based on the 
number of players in the game, a HUD will be highlighted based on who's turn it currently is. The game board will scale itself based on 
the number of players in the game. There will also be a cog at the top right corner of the app that allows the user to access the settings 
as well as exit the app. 

When a piece of the current turn player is selected, his/her HUD will no longer be highlighted, instead the selected piece and all legal
moves will be highlighted. There will also be a button next to the selected piece that allows the player to upgrade the piece istead of
moving. As the game progresses, the HUDs will update and keep track of each player's score.

When all but 1 player remains, the app will transition to the 'game_over' screen and indicate which player won. Any click from this screen
will return the user to 'startup_menu'.