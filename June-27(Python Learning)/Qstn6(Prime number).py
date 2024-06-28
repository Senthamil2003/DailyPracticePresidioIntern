def is_prime(num):
    if num <= 1:
        return False
    
    for i in range(2, int(num**0.5) + 1):
        if num % i == 0:
            return False
    
    return True

Number=int(input("Enter the number"))
if(is_prime(Number)):
    print(f"The  number {Number} is Prime")
else:
    print(f"The  number {Number} is not Prime")

