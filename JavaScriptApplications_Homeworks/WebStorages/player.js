/*
* Simple Player object with private properties and
* an init method. We can actually solve the homework task
* without using a dedicated Player class. So this code here
* is not obligatory for the homework solution. We just need
* to keep in mind the output format of the functions in
* engine.js .
* */
function Player(){
    Player.prototype.init = function(name, score){
        this.setName(name);
        this.setScore(score);
    }

    Player.prototype.getName = function(){
        return this._name;
    }

    Player.prototype.setName = function(name){
        this._name = name;
    }
    Player.prototype.getScore = function(){
        return this._score;
    }

    Player.prototype.setScore = function(score){
        this._score = score;
    }
    Player.prototype.toString = function(){
        return 'name: \'' + this.getName() + '\', score: ' + this.getScore();
    }
};