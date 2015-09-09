var engine = (function (){
    var numberToGuess,
        currentPlayer,
        callBack,
        keyCount = 0,
        flag = false;
    /*
    * Adding functions to the Storage prototype in order
    * to store objects in session storage.
    * Code is from Doncho Minkov's lecture on the subject.
    * */
    Storage.prototype.setObject = function setObject(key, obj){
        this.setItem(key, JSON.stringify(obj));
    };
    Storage.prototype.getObject = function setObject(key){
        return JSON.parse(this.getItem(key));
    };

    function init(playerName, endCallback){
        currentPlayer = new Player();
        currentPlayer.init(playerName, 0);
        numberToGuess = numberGenerator();
        /*
        * NOTE: Here we get the endCallback name property
        * as we expect a function as a parameter we need to
        * get its name in order to be able to call it again
        * later.
        * */
        callBack = endCallback.name;
        //This flag will ensure that the init function was invoked first.
        flag = true;
    };
    function guess(number){
        //If init function is not invoked we throw error.
        if(!flag){
            throw new Error('Unable to guess number prior to game init!');
        }
        if(typeof number == NaN || number == null || number == undefined){
            throw new Error('You must enter a number!');
        }
        if(number.toString().length !== 4){
            throw new Error('Number must be 4 digits long!');
        }
        var i,
            j,
            currentSheeps = 0,
            currentRams = 0,
            len = 4,
            currentGuess = number.toString();
        /*
        * NOTE: We invoke the 'continue' command after
        * we find a sheep or a ram because otherwise
        * we will have wrong behaviour in some cases.
        * */
        for(i = 0; i < len; i+=1){
            for(j = 0; j < len; j+=1){
                if(currentGuess.charAt(j) == numberToGuess.charAt(i)){
                    if(j == i){
                        currentRams +=1;
                        continue;
                    } else {
                        currentSheeps +=1;
                        continue;
                    }
                }
            }
        }
        /*
        * In case of victory we save the current player
        * name and score. After that we call the callBack function.
        * */
        if(currentRams == 4){
            saveState();
            window[callBack]();
        }
        /*
        * The result variable is used in order to return the
        * current game status as it is required in the homework task.
        * */
        var result = {sheeps: currentSheeps, rams: currentRams};
        //It is very important to clear those variables.
        currentRams = 0;
        currentSheeps = 0;
        return result;
    };
    /*
    * NOTE: Here we push into the array Objects that are
    * instances of Player thus being able to utilize the
    * overloaded toString() player method when visualizing the
    * collection.
    * */
    function getHighScore(count){
        var i = 0;
        var result = [];
        while(restoreState(i) !== null && i < count){
            result.push(restoreState(i).toString());
            i+=1;
        }
        return result;
    };
    /*
    * Generates random 4 digit number(don't ask me how) that we have to guess.
    * Also ensures that the number won't have a 0 on it's last
    * digit position.
    * */
    function numberGenerator(){
        do {
            var randomValue = Math.floor(1000 + Math.random() * 9000).toString();
            randomValue = randomValue.substring(0, 4);
        }while(randomValue.charAt(3) == '0');
        return randomValue;
    };
    /*
    * Saves current Player score in the session state as
    * an object.
    * */
    function saveState(){
        var temp = currentPlayer.getScore();
        temp +=1;
        currentPlayer.setScore(temp);
        sessionStorage.setObject(keyCount, currentPlayer);
        keyCount+=1;
    };
    /*
    * restoreState function is used to return a ready to use
    * Player type object after recovering it from the session storage.
    * */
    function restoreState(key){
        var tempPlayer = sessionStorage.getObject(key);
        var newPlayer = new Player();
        for(var prop in tempPlayer){
            newPlayer[prop] = tempPlayer[prop];
        }
        return newPlayer;
    };

    return {
        init: init,
        guess: guess,
        getHighScore: getHighScore
    };
})();