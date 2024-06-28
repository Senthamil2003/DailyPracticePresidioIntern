import re
def check_Age(age):
    return age>0

def check_Phone(phone):
     return phone.isnumeric() and len(phone) ==10

def check_Name(name):
    return len(name)>3


def check_Dob(dob):
    pattern = r"^\d{2}-\d{2}-\d{4}$"
    if re.match(pattern, dob):
        day, month, year = map(int, dob.split('-'))
        if 1 <= month <= 12 and 1 <= day <= 31:
            return True
    return False



name=input("Enter the name")
age=int(input("Enter age"))
dateOfBirth=input("Enter Date of Birth birth(dd-mm-yyyy)")
phone=input("Enter Mobile")
isvalid=1
if(not check_Name(name)):
    isvalid=0
    print("Enter valid name")
if(not check_Age(age)):
    isvalid=0
    print("Enter valid Age")
if(not check_Dob(dateOfBirth)):
    isvalid=0
    print("Enter valid date of birth(dd-mm-yyyy)")
if(not check_Phone(phone)):
    isvalid=0
    print("Enter valid Phone")

    

if(isvalid):
    print("---------------------------")
    print(f"Details of {name}")
    print(f"Name: {name}")
    print(f"Age: {age}")
    print(f"Mobile number: {phone}")
    print(f"Date of birth: {dateOfBirth}")  


