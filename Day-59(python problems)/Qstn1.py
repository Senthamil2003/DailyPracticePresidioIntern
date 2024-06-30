def findLongSubstringWithoutRepeat(string_value):
    check_duplicate=set()
    ct=0
    start=0
    max_value=0
    for i in range(0,len(string_value)):
        if(string_value[i] not in check_duplicate):
            ct+=1
            check_duplicate.add(string_value[i])
        else:
            while(string_value[start]!=string_value[i]): 
                check_duplicate.remove(string_value[start])
                ct-=1
                start+=1
                
            start+=1
        if(ct>max_value):
            max_value=ct
    return max_value



string_value=input("Enter the string for longest substring")
print("Longest string length without repeat",findLongSubstringWithoutRepeat(string_value))