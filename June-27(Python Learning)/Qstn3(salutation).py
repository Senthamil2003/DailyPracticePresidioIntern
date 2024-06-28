Name=input("Enter your name")
Gender=input("Enter gender(Male/Female)")
saluation=""
isvalid=1
if(Gender.lower()=="male"):
 
    saluation="Mr"
elif(Gender.lower()=="female"):
    saluation="Mrs"
else:
    isvalid=0
    print("Enter valid gender")
    
if(isvalid):
    print(f"Hello, {saluation} {Name} Welcome ")




