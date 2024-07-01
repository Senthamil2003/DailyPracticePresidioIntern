class Person:
    def __init__(self, name, age):
        self.name = name
        self.age = age

    def display(self):
        print(f"Name: {self.name}, Age: {self.age}")

class Student(Person):
    def __init__(self, name, age, student_id, major):
        super().__init__(name, age)
        self.student_id = student_id
        self.major = major

    def display(self):
        super().display()
        print(f"Student ID: {self.student_id}, Major: {self.major}")

class Teacher(Person):
    def __init__(self, name, age, employee_id, subject):
        super().__init__(name, age)
        self.employee_id = employee_id
        self.subject = subject
        
    def display(self):
        super().display()
        print(f"Employee ID: {self.employee_id}, Subject: {self.subject}")


def show_person_details(person):
    person.display()

person = Person("Alice", 45)
student = Student("Bob", 20, "13221", "Computer Science")
teacher = Teacher("Carol", 35, "21232", "English")


print("Person Details:")
show_person_details(person)

print("\nStudent Details:")
show_person_details(student)

print("\nTeacher Details:")
show_person_details(teacher)
