def credit_card_validator(card_number):
    card_digits=[]
    for i in card_number:
        card_digits.append(int(i))
    
    print(card_digits)
    checksum = 0
    
    for i in range(len(card_digits) - 2, -1, -2):
        doubled_digit = card_digits[i] * 2
        if doubled_digit > 9:
            doubled_digit -= 9
        card_digits[i] = doubled_digit
    
   
    checksum = sum(card_digits)
    
 
    return checksum % 10 == 0


card_number = input("Enter card number")
if credit_card_validator(card_number):
    print("The credit card number is valid")
else:
    print("The credit card number is not valid.")
