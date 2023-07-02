"use strict";
//import { MainMatrix, GameState, Matrix } from "./matrix.js";
var GameState;
(function (GameState) {
    GameState[GameState["Started"] = 0] = "Started";
    GameState[GameState["Aborted"] = 1] = "Aborted";
    GameState[GameState["NotStarted"] = 2] = "NotStarted";
    GameState[GameState["FinishedByDraw"] = 3] = "FinishedByDraw";
    GameState[GameState["FinishedByXWin"] = 4] = "FinishedByXWin";
    GameState[GameState["FinishedByOWin"] = 5] = "FinishedByOWin";
})(GameState || (GameState = {}));
let MainMatrix = {
    gameField: [
        [' ', ' ', ' '],
        [' ', ' ', ' '],
        [' ', ' ', ' '],
    ],
    gameState: 2
};
const message = document.querySelector('#game-state-info');
const messageContent = message === null || message === void 0 ? void 0 : message.textContent;
const startBtn = document.querySelector("#start-btn");
const resignBtn = document.querySelector("#resign-btn");
const fields = document.querySelectorAll(".field");
fields.forEach((f, i) => f.addEventListener('click', () => UserInput(i)));
startBtn.addEventListener('click', () => StartGame());
resignBtn.addEventListener('click', () => EndGame());
function StartGame() {
    fetch("https://localhost:7024/StartGame")
        .then(data => data.json())
        .then(json => {
        synchronize(json);
        showMatrix();
    });
}
function EndGame() {
    fetch("https://localhost:7024/EndGame")
        .then(data => data.json())
        .then((json) => {
        synchronize(json);
    });
}
function synchronize(json) {
    MainMatrix.gameField = json[0];
    MainMatrix.gameState = json[1];
    console.log(MainMatrix);
    message.innerHTML = `${messageContent}` + `${GameState[MainMatrix.gameState]}`;
}
function UserInput(i) {
    if (MainMatrix.gameState == GameState.Started) {
        let p = fields[i].children.item(0);
        if (p.textContent == " ") {
            p.append("X");
            MainMatrix.gameField[~~(i / 3)][i % 3] = "X";
            console.log(`set to ${~~(i / 3)} ${i % 3}`);
            MakeMove();
        }
    }
}
function MakeMove() {
    fetch('https://localhost:7024/MakeMove', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            gfield: MainMatrix.gameField,
            gstate: MainMatrix.gameState,
        })
    })
        .then(data => data.json())
        .then(json => {
        synchronize(json);
        showMatrix();
    });
}
function showMatrix() {
    for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
            let p = fields[i * 3 + j].children.item(0);
            p.textContent = MainMatrix.gameField[i][j];
            console.log(p.textContent);
        }
    }
}
//StartGame();
