
class Person {
    constructor(name, age) {
      this.name = name;
      this.age = age;
    }
  
    displayDetails() {
      console.log(`Name: ${this.name}, Age: ${this.age}`);
    }
  }
  
  
  class Student extends Person {
    constructor(name, age, rollNumber, grade) {
      super(name, age); 
  
      this.rollNumber = rollNumber;
      this.grade = grade;
    }
  
  
    displayDetails() {
      super.displayDetails(); 
      console.log(`Roll Number: ${this.rollNumber}, Grade: ${this.grade}`);
    }
  
 
  }
  
 
  let student1 = new Student("Alice", 20, "21212", "A");
  

  student1.displayDetails(); 


  console.log(student1.name); 
  console.log(student1.age); 
  
 
  console.log(student1.rollNumber); 
  console.log(student1.grade); 
  