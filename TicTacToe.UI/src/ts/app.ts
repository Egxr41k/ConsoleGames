//import { MainMatrix, GameState, Matrix } from "./matrix.js";

enum GameState {
    Started,
    Aborted,
    NotStarted,
    FinishedByDraw,
    FinishedByXWin,
    FinishedByOWin,
}

type Matrix = {
    gameField: string[][];
    gameState: GameState;
}

let MainMatrix: Matrix ={
    gameField: [
        [' ', ' ', ' '],
        [' ', ' ', ' '],
        [' ', ' ', ' '],
    ],
    gameState: 2
};

const message: Element = 
    document.querySelector('#game-state-info') as Element;

const messageContent: string = 
    message?.textContent as string;
    
const startBtn: Element =
    document.querySelector("#start-btn") as Element;

const resignBtn: Element =
    document.querySelector("#resign-btn") as Element;

const fields: NodeListOf<Element> = 
    document.querySelectorAll(".field");

fields.forEach((f: Element, i: number) =>
    f.addEventListener('click', () => UserInput(i))
);

startBtn.addEventListener('click', (): void => StartGame());
resignBtn.addEventListener('click', (): void => EndGame());

function StartGame(): void {
    fetch("https://localhost:7024/StartGame")
    .then(data => data.json())
    .then(json => {
        synchronize(json);
        showMatrix();
    });
}

function EndGame(): void {
    fetch("https://localhost:7024/EndGame")
    .then(data => data.json())
    .then((json) => {
        synchronize(json);    
    });
}

function synchronize(json: any){
    MainMatrix.gameField = json[0] as string[][];
    MainMatrix.gameState = json[1] as GameState;
    console.log(MainMatrix);
    message.innerHTML = `${messageContent}` + `${GameState[MainMatrix.gameState]}`;
}

function UserInput(i: number): void{
    if(MainMatrix.gameState == GameState.Started){
        let p = fields[i].children.item(0) as HTMLTextAreaElement;
        if (p.textContent == " ") {
            p.append("X");
            MainMatrix.gameField[~~(i/3)][i%3] = "X";
            console.log(`set to ${~~(i/3)} ${i%3}`)
            MakeMove();
        }
    }
    
}

function MakeMove(){
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

function showMatrix(){
    for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
            let p = fields[i*3+j].children.item(0) as HTMLTextAreaElement;
            p.textContent = MainMatrix.gameField[i][j];
            console.log(p.textContent);
        }
    }
}

//StartGame();