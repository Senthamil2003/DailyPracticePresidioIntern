from datetime import datetime
import re
import XmlFileStore
import TextFileStore
import PdfFileStore
class Person():
    def __init__(self,name,dateOfBirth,mobile):
        self.name=name
        self.dateOfBirth=dateOfBirth
        self.mobile=mobile
    def calculate_age(self,date_of_birth):
        today = datetime.today()
        age = today.year - date_of_birth.year
        if (today.month, today.day) < (date_of_birth.month, date_of_birth.day):
            age -= 1
        return age
   
    def showDetails(self):
        print("Name",self.name)
        print("Date of birth",self.dateOfBirth)
        print("Age ", self.calculate_age(self.dateOfBirth))
        print("Mobile ",self.mobile)


class Employee(Person):
    def __init__(self, name, dateOfBirth, mobile,role,officeMail):
        super().__init__(name, dateOfBirth, mobile)
        self.role=role
        self.officeMail=officeMail
    def showDetails(self):
        super().showDetails()
        print("Role",self.role)
        print("Office Mail",self.officeMail)
        n=int(input("Enter option \n 1Save in xl \n 2.save in Text file \n 3.save in Pdf"))
        if(n==1):
            self.saveXml()
        elif(n==2):
            self.saveText()
        elif(n==3):
            self.savePdf()

            
        
    def saveXml(self):
        XmlFileStore.AddtoXl(self.name,self.officeMail,self.calculate_age(self.dateOfBirth),self.dateOfBirth,self.role)
    def saveText(self):
        TextFileStore.saveToTxt(self.name,self.officeMail,self.calculate_age(self.dateOfBirth),self.dateOfBirth,self.role)
    def savePdf(self):
        PdfFileStore.add_data_to_pdf(self.name,self.officeMail,self.calculate_age(self.dateOfBirth),self.dateOfBirth,self.role)






def check_Dob(dob):
    pattern = r"^\d{2}-\d{2}-\d{4}$"
    if re.match(pattern, dob):
        day, month, year = map(int, dob.split('-'))
        if 1 <= month <= 12 and 1 <= day <= 31:
            return True
    return False
def checkPhone(phone):
    if(len(phone)==10):
        return True
    return False

name =input("Enter the name")
while(1):
    dateOfBIrth=input("Enter Date Of birth in  dd-mm-yyyy")
    if(check_Dob(dateOfBIrth)):
        break
day, month, year = map(int, dateOfBIrth.split('-'))
mobile=input("Enter Mobile")
role=input("Enter the role of Employee")
officeMail=input("Enter the office Mail")
employee=Employee(name,datetime(year,month,day),mobile,role,officeMail)
employee.showDetails()

    

