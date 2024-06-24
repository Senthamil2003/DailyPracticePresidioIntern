function Person(name, age) {
    this.name = name;
    this.age = age;
  }
  
  
  Person.prototype.sayHello = function() {
    console.log(`Hello, my name is ${this.name} and I am ${this.age} years old.`);
  };
  
  
  function Student(name, age, grade) {
    Person.call(this, name, age);
    this.grade = grade;
  }
  
  Student.prototype = Object.create(Person.prototype);
  Student.prototype.constructor = Student;
  
  
  Student.prototype.study = function() {
    console.log(`${this.name} is studying in grade ${this.grade}.`);
  };
  
  
  var john = new Person('John', 30);
  var alice = new Student('Alice', 20, '12th');
  
 
  john.sayHello(); 
  alice.sayHello();
  alice.study(); 
  