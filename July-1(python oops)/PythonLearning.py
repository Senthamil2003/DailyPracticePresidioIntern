class Person:
    def __init__(self,name,age):
        self.name=name
        self.age=age
    def print_personal_info(self):
        print(self.name,self.age)
class Student(Person):
    def __init__(self, name, age,degree,cgpa):
        super().__init__(name, age)
        self.degree=degree
        self.cgpa=cgpa
    def print_student_info(self):
        super().print_personal_info()
        print(self.degree,self.cgpa)


p=Person("Eren",12)
p.print_personal_info()
studentData=Student("Armin",20,"Colosal Titan",10)
studentData.print_student_info()
