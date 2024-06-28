n=int(input("Enter number of row for stars"))

st=n
ed=n
for i in range(n):
    for j in range(0,n*2):
        if(j>=st and j<=ed):
            print("*",end="")
        else:
            print(" ",end="")
    st-=1
    ed+=1
    print()
