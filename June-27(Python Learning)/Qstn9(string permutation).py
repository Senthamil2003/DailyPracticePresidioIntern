from itertools import permutations

def print_permutation(s):
    
    perm_value = permutations(s)
    for p in perm_value:
        print(''.join(p))

input_string = input("Enter a string: ")
print("All permutations:")
print_permutation(input_string)
