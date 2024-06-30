def getHint(secret, guess):
    d = {}
    bct = 0
    secret = list(secret)
    guess = list(guess)
    for i in range(len(secret)):
        if secret[i] == guess[i]:
            bct += 1
            secret[i] = '*'
            guess[i] = '*'
        else:
            if secret[i] not in d:
                d[secret[i]] = 1
            else:
                d[secret[i]] += 1
    cct = 0
    for i in guess:
        if i != "*" and i in d and d[i] != 0:
            d[i] -= 1
            cct += 1
    return str(bct) + "A" + str(cct) + "B"

def play_game():
    secret_word = "newyork"
    
    print("Welcome to the Cow and Bull game!")
    
    attempts = 0
    while True:
        guess = input("Enter your guess (7-letter word): ").lower()
        if len(guess) != 7 or not guess.isalpha():
            print("Invalid input. Please enter a 7-letter word.")
            continue
        
        attempts += 1
        feedback = getHint(secret_word, guess)
        print(f"Feedback: {feedback}")
        
        if feedback == "7A0B":
            print(f"Congratulations You guessed the word '{secret_word}' in {attempts} attempts.")
            score = max(10 - attempts, 0) * 100
            print(f"Your score: {score}")
            break


play_game()
