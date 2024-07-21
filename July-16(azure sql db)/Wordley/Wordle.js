
const words = ['apple', 'beach', 'chair', 'dance', 'eagle', 'flame', 'grape', 'house', 'igloo', 'juice'];
let secretWord = words[Math.floor(Math.random() * words.length)];
let attempts = 6;
let currentAttempt = 0;
let currentTile = 0;

const gameBoard = document.getElementById('game-board');
const keyboard = document.getElementById('keyboard');
const message = document.getElementById('message');

function createGameBoard() {
    for (let i = 0; i < 6; i++) {
        for (let j = 0; j < 5; j++) {
            const tile = document.createElement('div');
            tile.classList.add('tile');
            gameBoard.appendChild(tile);
        }
    }
}

function createKeyboard() {
    const rows = [
        ['Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P'],
        ['A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L'],
        ['ENTER', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '⌫']
    ];

    rows.forEach(row => {
        const rowElement = document.createElement('div');
        rowElement.classList.add('keyboard-row');
        row.forEach(key => {
            const keyElement = document.createElement('div');
            keyElement.classList.add('key');
            keyElement.textContent = key;
            keyElement.setAttribute('data-key', key);
            if (key === 'ENTER') keyElement.id = 'enter-key';
            if (key === '⌫') keyElement.id = 'backspace-key';
            keyElement.addEventListener('click', () => handleKeyPress(key));
            rowElement.appendChild(keyElement);
        });
        keyboard.appendChild(rowElement);
    });
}

function handleKeyPress(key) {
    if (currentAttempt >= attempts) return; // Stop if game is over
    if (key === 'ENTER') {
        submitGuess();
    } else if (key === '⌫') {
        deleteLetter();
    } else if (currentTile < (currentAttempt + 1) * 5) {
        addLetter(key);
    }
}

function addLetter(letter) {
    if (currentTile < (currentAttempt + 1) * 5) {
        const tile = gameBoard.children[currentTile];
        tile.textContent = letter;
        currentTile++;
    }
}

function deleteLetter() {
    if (currentTile > currentAttempt * 5) {
        currentTile--;
        const tile = gameBoard.children[currentTile];
        tile.textContent = '';
    }
}

function submitGuess() {
    if (currentTile % 5 !== 0 || currentTile !== (currentAttempt + 1) * 5) {
        message.textContent = 'Please enter a 5-letter word.';
        return;
    }

    const guess = Array.from(gameBoard.children)
        .slice(currentAttempt * 5, (currentAttempt + 1) * 5)
        .map(tile => tile.textContent.toLowerCase())
        .join('');

    for (let i = 0; i < 5; i++) {
        const tile = gameBoard.children[currentAttempt * 5 + i];
        const letter = guess[i];
        const key = document.querySelector(`.key:not(#enter-key):not(#backspace-key)[data-key="${letter.toUpperCase()}"]`);

        if (letter === secretWord[i]) {
            tile.classList.add('correct');
            key.classList.add('correct');
        } else if (secretWord.includes(letter)) {
            tile.classList.add('present');
            if (!key.classList.contains('correct')) {
                key.classList.add('present');
            }
        } else {
            tile.classList.add('absent');
            key.classList.add('absent');
        }
    }

    if (guess === secretWord) {
        message.textContent = 'Congratulations! You guessed the word!';
        disableKeyboard();
    } else {
        currentAttempt++;
        if (currentAttempt >= attempts) {
            message.textContent = `Game over. The word was ${secretWord}.`;
            disableKeyboard();
        }
    }
    currentTile = currentAttempt * 5; // Reset currentTile for the next row
}

function disableKeyboard() {
    const keys = document.querySelectorAll('.key');
    keys.forEach(key => key.style.pointerEvents = 'none');
}

createGameBoard();
createKeyboard();

document.addEventListener('keydown', (event) => {
    const key = event.key.toUpperCase();
    if (key === 'ENTER' || key === 'BACKSPACE' || (key.length === 1 && key.match(/[A-Z]/))) {
        handleKeyPress(key === 'BACKSPACE' ? '⌫' : key);
    }
});
