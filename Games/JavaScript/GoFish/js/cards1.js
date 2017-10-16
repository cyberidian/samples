	// helper functions

	function getWidth() {
	  return Math.max(
		document.body.scrollWidth,
		document.documentElement.scrollWidth,
		document.body.offsetWidth,
		document.documentElement.offsetWidth,
		document.documentElement.clientWidth
	  );
	}
	function getPropertyArray(obj, propName){
		var propArray = [];
		Object.keys(obj).forEach(function(key) {
			var val = obj[key][propName];
			propArray.push(val);
		});
		return propArray;
	}
	function loadSelectOptions(list, element){
		"use strict";
		var opElement = document.getElementById(element);
		for(var i = 0; i < list.length; i++) {
			var opt = document.createElement('option');
			opt.innerHTML = list[i];
			opt.value = list[i];
			opElement.appendChild(opt);
		}
	}
	function getElement(id){
		return document.getElementById(id);
	}
	function setElement(element, value){
		document.getElementById(element).innerText = value;
	}
	function hideElement(element){
		document.getElementById(element).style.display = 'none';
	}
	function showElement(element){
		document.getElementById(element).style.display = 'block';
	}
	//game initializing functions
	function loadPlayerAskOptions(list){
		loadSelectOptions(list, 'player2GameAction');	
	}

	function player(name, game){
		this.name=name;
		this.game=game;
	}
	function game(){
		this.hand=[];
		this.sets=[];
		this.score=0;
	}
	function card (displayName, name){
		this.displayName = displayName;
		this.name = name;
	}	
	
	function initPlayers(numPlayers, names){
		var players = [];
		for(var p=0; p < numPlayers; p++){
			players.push(new player(names[p],new game()));
		}
		return players;
	}
	
	function getDeck(){
				var cards = [];
				var displayNames = ['Nemo', 'Octo', 'Fanny', 'Shark', 'Lemonhead', 'Rainbow', 'Freddy', 'Spike', 'Goblin', 'Puffer', 'Hermit', 'Stripe'];
				var names = ['1F', '2F', '3F', '4F', '5F', '6F', '7F', '8F', '9F', '10F', '11F', '12F'];
				for(var i=0; i < names.length; i++){
					cards.push(new card(displayNames[i], names[i] ));
				}
				return cards;
	}
	
			
	function setScore(score){
			setElement('score', score.toString());
		}
	function setStatus(message){
			setElement("gameStatus", message)
		}
		
	function initStatus(){
		setStatus("Enter Name and click Start Game");
		setScore(0);
	}
	function initPlayerControls(){
		//show playerStartGame
		showElement('playerStartGame');
		//hide playerGameControls
		hideElement('playerGameControls');
		hideElement('otherPlayerDisplay');
		//clear status bar
		
		setElement('gameStatus', '');
		setElement('score', '0');
	}
	function displayPlayerControls(list){
		loadPlayerAskOptions(list);
		//show playerStartGame
		showElement('playerGameControls');
		showElement('otherPlayerDisplay');
		//hide playerGameControls
		hideElement("playerStartGame");
	}

	function initStage(targetId){
		var stage = document.getElementById(targetId);
		var stage_background = document.createElement("div");
		stage_background.id = "stage_background";
		stage.appendChild(stage_background);
		initPlayerControls();
		
		return stage_background;
	}

	
	function GoFishGame(players, deck, cardStage){
		var activePlayer = 1;
		//deck functions
		var shuffleDeck= function(deck){
			var sortedDeck = deck.sort(function() { return Math.round(Math.random()) - 0.5; });
			return 	sortedDeck;		
		}
	
		var dealFirstHands = function(cardsPerHand,players,deck){
			for(var j=0; j < cardsPerHand; j++) {
				for(var i=0; i < players.length; i++) {
					if(deck.length >0){
						players[i].game.hand.push(deck.pop());
					}
				}
			}
			return players;
		};

		var displayPlayerHand = function(cardsPerHand,cardStage, hand){
			// template for card
			var cardUI = document.createElement("div");
			var cards = [];
			
			var stageElement = getElement("stage");
			var stageWidth = getWidth();
			var leftStart = (stageWidth/2)-230;
			//var leftStart = 0;
			if(leftStart < 0){
				leftStart=0;
			};
			
			for(var i=0; i < cardsPerHand; i++) {
				var cardsPerRow = cardsPerHand;
				var newCard = cardUI.cloneNode(true);
				newCard.id = "card" + i;
				newCard.innerHTML = "<img src=\"Content/images/fishCards/" + hand[i].name + ".png\" alt=\"" + hand[i].displayName +  "\" />";
				newCard.fromtop = 60;
    			newCard.fromleft = leftStart + 100 * (i%cardsPerRow);
				newCard.style.top = newCard.fromtop + "px";
				newCard.style.left = newCard.fromleft + "px";
				newCard.style.zIndex = "0";
				cardStage.appendChild(newCard);
				cards.push(newCard);
			}
		}
		
		//end deck functions
		
		//card play functions
		var dealGame = function(players, deck, cardStage){
			var cardsPerHand=5;
			var score=0;
			var sets=[];
			var hand=[];
			
			//initialize deck
			deck = shuffleDeck(deck);
			
			//initialize player games
			for(var p=0; p < players.length; p++) {
				players[p].game= new game(hand, sets, score);
			}
				
			//deal hand to players 
			players = dealFirstHands(cardsPerHand,players,deck);
			
			//display player hand
			var player = players[activePlayer]; 
			hand = players[activePlayer].game.hand;
			displayPlayerHand(cardsPerHand,cardStage, hand);
			var handList = getPropertyArray(hand, "displayName");
			displayPlayerControls(handList);
			setScore(score);
			setStatus("Your turn!");
			//wait for game play
			started = true;

		}


		var cardClick = function(id)
		{
			alert('card clicked');
		};		
		var cardRequest = function(id){
			alert('card requested');
		}
	
		// end card play functions
		
		dealGame(players, deck, cardStage);

	}
	

	var GoFish = function(targetId)
	{
		//configuration 
		var numPlayers=2;
		var otherPlayer=0;//
		var activePlayer=1;//
		var computerPlayerName = 'The Computer';	
		var playerNames=[];
		playerNames[otherPlayer]=computerPlayerName;
		setElement("otherPlayer", computerPlayerName);
		// initialise
		var started = false;
		var cardStage = initStage(targetId);
		initStatus();
		
		var startGame = function(){
			playerNames[activePlayer]=getElement('playerName').value;
			var players = initPlayers(numPlayers, playerNames);
			var deck = getDeck();		
			GoFishGame(players, deck, cardStage);
		}
			
		return startGame;

	}