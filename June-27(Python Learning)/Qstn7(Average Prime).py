def is_prime(num):
    if num <= 1:
        return False
    
    for i in range(2, int(num**0.5) + 1):
        if num % i == 0:
            return False
    
    return True

Numbers=list(map(int,input().split()))
Average_ct=0
Average_sum=0
for i in Numbers:
    if(is_prime(i)):
        Average_ct+=1
        Average_sum+=i
if(Average_ct==0):
    print("No Prime Numbers Average is 0")
else:
    print(Average_sum,Average_ct)
    print(f"Average of all the prime numbers is {Average_sum/Average_ct}")



