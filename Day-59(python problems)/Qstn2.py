def is_prime(num):
    if num <=1:
        return False
    for i in range(2, int(num**0.5) + 1):
        if num % i == 0:
            return False
    return True

def prime_numbers_list(n):
    primeList = []
    for num in range(2, n + 1):
        if is_prime(num):
            primeList.append(num)
    return primeList

number=int(input("Enter the N number for Prime number List"))
print("Prime number List",prime_numbers_list(number))
